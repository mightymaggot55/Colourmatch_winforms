using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Colourmatch_winforms.SQLManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Colourmatch_winforms
{
    public partial class CreateMatch : Form
    {
        protected bool isBusy = false;
        protected bool cancelPending = false;

        public CreateMatch()
        {
            InitializeComponent();
        }

        private void CreateMatch_Load(object sender, EventArgs e)
        {
            InitialiseDropdowns();
            //InitialiseDropdownsAsync();
            InitialiseNewMatchNo();

        }

        private void InitialiseDropdowns()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                List<Tuple<System.Windows.Forms.ComboBox, string>> dropdownLists = new List<Tuple<System.Windows.Forms.ComboBox, string>>
                {
                    Tuple.Create(sColour_Box, SQLManager.SelectSQLColour),
                    Tuple.Create(sProcess_Box, SQLManager.SelectSQLProcess),
                    Tuple.Create(sMouldingMaterial_Box, SQLManager.SelectSQLMouldingMaterial),
                    Tuple.Create(sSalesContact_Box, SQLManager.SelectSalesContact),
                    Tuple.Create(sColourPrefix2_Box, SQLManager.SelectSQLColourPrefix),
                    Tuple.Create(sCustomer_Box, SQLManager.SelectSQLCustomers)
                };
                SetDropdownLists(dropdownLists);
                sw.Stop();
                Console.WriteLine(sw.Elapsed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetDropdownLists(List<Tuple<System.Windows.Forms.ComboBox, string>> dropdownlists)
        {
            foreach(Tuple<System.Windows.Forms.ComboBox, string> item in dropdownlists)
            {
                SetDropdownList(item.Item1, item.Item2);
            }
        }

        private void InitialiseNewMatchNo()
        {
            try
            {
                string sql = SQLManager.SelectSQLMaxRequestNo;
                MatchRequest_Sales match = new MatchRequest_Sales();
                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    conn.Open();
                    //Get the maximum of a column and return it 
                    using (var command = new SqlCommand(sql, conn))
                    {
                        int newReqNo = Convert.ToInt32(command.ExecuteScalar());
                        newReqNo += 1;
                        sMatchRequestNo_Box.Text = Convert.ToString(newReqNo);
                        sMatchStrokeNo_Box.Text = Convert.ToString(1);

                        match.matchNo = Convert.ToString(sMatchRequestNo_Box.Text) + "/" + Convert.ToString(sMatchStrokeNo_Box.Text);
                        match.reqNo = newReqNo;
                        match.strokeNo = Convert.ToInt32(sMatchStrokeNo_Box.Text);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void SetDropdownList(System.Windows.Forms.ComboBox comboBox, string SQLCommand)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionManager.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLCommand, conn);
                var result = cmd.ExecuteReader();
                int i = 0;
                while (result.Read())
                {
                    comboBox.Items.Add(result[0].ToString());
                    i++;
                }
                string output = string.Format("{0} rows Added to " + comboBox.Name.ToString(), i);
                Console.WriteLine(output);

                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void SaveSalesInformation()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    conn.Open();
                    MatchRequest_Sales matchInfo = new MatchRequest_Sales();
                    matchInfo = PrepData();

                    string sqlElements = "'" + matchInfo.matchNo + "', " + matchInfo.reqNo + ", " + matchInfo.strokeNo + ", '" + matchInfo.salesContact + "', '" + matchInfo.customer + "', '" + matchInfo.customerContact + "', '" + matchInfo.projectReference + "', '" + matchInfo.process + "', '" + matchInfo.mouldingMaterial + "', '" + matchInfo.colour + "', '" + matchInfo.colourPrefixOne + "', '" + matchInfo.colourPrefixTwo + "', '" + matchInfo.lightSource + "', '" + matchInfo.plaques + "', '" + matchInfo.colourTarget + "', '" + matchInfo.pelletSize + "', '" + matchInfo.heatStability + "', '" + matchInfo.sampleQuantity + "', '" + matchInfo.lightFastness + "', '" + matchInfo.additionRate + "', '" + matchInfo.notes + "', '" + matchInfo.sampleType + "'";
                    string InsertIntoSalesString = SQLManager.SQLInsertSalesTable(sqlElements);
                    string InsertIntoPurchasingTable = SQLManager.SQLInsertPurchasingTable(matchInfo.matchNo, matchInfo.reqNo, matchInfo.strokeNo);

                    using (var command = new SqlCommand(InsertIntoSalesString, conn))
                    {
                        Console.WriteLine(InsertIntoSalesString);
                        int rows = command.ExecuteNonQuery();
                        Console.WriteLine(rows);
                        MessageBox.Show("Match has been created");
                    }
                    using (var command = new SqlCommand("UPDATE [MatchRequest_Sales] SET [Date Created] = '" + sDate_Box.Text + "', [Date Required] = '" + sDateRequired_Box.Text + "' WHERE [Match Request No] = " + sMatchRequestNo_Box.Text + " AND [Match Stroke No] = " + sMatchStrokeNo_Box.Text + " ", conn))
                    {
                        int rows = command.ExecuteNonQuery();
                        Console.WriteLine(rows);

                    }
                    using (var command = new SqlCommand(InsertIntoPurchasingTable, conn))
                    {
                        Console.WriteLine(InsertIntoPurchasingTable);
                        int rows = command.ExecuteNonQuery();
                        Console.WriteLine(rows);
                        conn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error Saving Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SaveSalesInformationAsync()
        {
            try
            {
                await Task.Run(() =>
                {

                });
            }
            catch (Exception ex)
            {

            }
        }

        //private async void InitialiseDropdownsAsync()
        //{
        //    try
        //    {
        //        Stopwatch sw = new Stopwatch();
        //        sw.Restart();
        //        Task<Task>[] task = new Task<Task>[];

        //        await Task.run(() => SetDropdownListAsync(sColour_Box, SQLManager.SelectSQLColour));
        //        await Task.run(() => SetDropdownListAsync(sProcess_Box, SQLManager.SelectSQLProcess);
        //        await Task.run(() => SetDropdownListAsync(sMouldingMaterial_Box, SQLManager.SelectSQLMouldingMaterial);
        //        await Task.run(() => await SetDropdownListAsync(sSalesContact_Box, SQLManager.SelectSalesContact);
        //        await Task.run(() => SetDropdownListAsync(sColourPrefix2_Box, SQLManager.SelectSQLColourPrefix);
        //        await Task.run(() => SetDropdownListAsync(sCustomer_Box, SQLManager.SelectSQLCustomers);

        //        sw.Stop();
        //        Console.WriteLine(sw.Elapsed);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}

        private static async Task SetDropdownListAsync(System.Windows.Forms.ComboBox comboBox, string SQLCommand)
        {
            try
            {
                await Task.Run(() =>
                {

                    SqlConnection conn = new SqlConnection(ConnectionManager.ConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQLCommand, conn);
                    var result = cmd.ExecuteReader();
                    int i = 0;
                    while (result.Read())
                    {
                        comboBox.Items.Add(result[0].ToString());
                        i++;
                    }
                    string output = string.Format("{0} rows Added to " + comboBox.Name.ToString(), i);
                    Console.WriteLine(output);

                    conn.Close();

                    Task.WaitAll();
                });
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private MatchRequest_Sales PrepData()
        {
            MatchRequest_Sales match = new MatchRequest_Sales
            {
                matchNo = Convert.ToString(sMatchRequestNo_Box.Text + "-" + sMatchStrokeNo_Box.Text),
                reqNo = Int32.Parse(sMatchRequestNo_Box.Text),
                strokeNo = Int32.Parse(sMatchStrokeNo_Box.Text),
                date = DateTime.Parse(sDate_Box.Text),
                dateRequired = DateTime.Parse(sDateRequired_Box.Text),
                salesContact = Convert.ToString(sSalesContact_Box.Text),
                customer = Convert.ToString(sCustomer_Box.Text),
                customerContact = Convert.ToString(sCustomerContact_Box.Text),
                projectReference = Convert.ToString(sProjectReference_Box.Text),
                process = Convert.ToString(sProcess_Box.Text),
                mouldingMaterial = Convert.ToString(sMouldingMaterial_Box.Text),
                colour = Convert.ToString(sColour_Box.Text),
                colourPrefixOne = Convert.ToString(sColourPrefix1_Box.Text),
                colourPrefixTwo = Convert.ToString(sColourPrefix2_Box.Text),
                lightSource = Convert.ToString(sLightFastness_Box.Text),
                plaques = Convert.ToString(sPlaques_Box.Text),
                colourTarget = Convert.ToString(sColourTarget_Box.Text),
                pelletSize = Convert.ToString(sPelletSize_Box.Text),
                heatStability = Convert.ToString(sHeatStability_Box.Text),
                sampleQuantity = Convert.ToString(sSampleQuantity_Box.Text),
                lightFastness = Convert.ToString(sLightFastness_Box.Text),
                additionRate = Convert.ToString(sAdditionRate_Box.Text),
                notes = Convert.ToString(sSalesNotes_Box.Text),
                sampleType = Convert.ToString(sSampleType_Box.Text)
            };
            return match;
        }

        private void CreateMatch_button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSalesInformation();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ViewRequestLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void sProcess_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FormFunctions.ChangeProcessValues(sProcess_Box, sAdditionRate_Box, sPelletSize_Box, sLightFastness_Box, sHeatStability_Box);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
