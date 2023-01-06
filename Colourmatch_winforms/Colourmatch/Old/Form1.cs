//using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Colourmatch_winforms.ConnectionManager;

namespace Colourmatch_winforms
{
    public partial class ColourmatchDatabase_form : Form
    {        

        

        public ColourmatchDatabase_form()
        {
            InitializeComponent();            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ColourmatchDatabase_form_Load(object sender, EventArgs e)
        {            
            // TODO: This line of code loads data into the 'matchRequest_Sales_db1.MatchRequest_Sales' table. You can move, or remove it, as needed.
            this.matchRequest_SalesTableAdapter.Fill(this.matchRequest_Sales_db1.MatchRequest_Sales);
            // TODO: This line of code loads data into the 'customers_db.Customers' table. You can move, or remove it, as needed.
                       
            try
            {
                InitialiseDropdowns();
                InitialiseNewMatchNo();                
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void InitialiseDropdowns()
        {
            try
            {
                string SQLProcess = "SELECT Process FROM Colourmatch.dbo.Processes;";
                string SQLColourPrefix = "SELECT [Colour Effect] FROM Colourmatch.dbo.[Colour Effects];";
                string SQLColour = "SELECT Colour FROM Colourmatch.dbo.Colours;";
                string SQLMouldingMaterials = "SELECT Material FROM Colourmatch.dbo.[Moulding Material];";
                string SQLCustomers = "SELECT Customer FROM Colourmatch.dbo.Customers;";
                string SQLSuppliers = "SELECT Suppliers FROM Colourmatch.dbo.[Masterbatch Suppliers];";
                string SQLPurchasingContacts = "SELECT Contact FROM Colourmatch.dbo.[Purchasing Contacts];";
                string SQLSalesContacts = "SELECT Contact FROM Colourmatch.dbo.[Sales Contacts];";

                SetDropdownList(sColour_Box, SQLColour);
                SetDropdownList(sProcess_Box, SQLProcess);
                SetDropdownList(sMouldingMaterial_Box, SQLMouldingMaterials);
                SetDropdownList(sSalesContact_Box, SQLSalesContacts);
                SetDropdownList(sColourPrefix2_Box, SQLColourPrefix);
                SetDropdownList(sCustomer_Box, SQLCustomers);
                SetDropdownList(pSupplier1_Box, SQLSuppliers);
                SetDropdownList(p_Supplier2_Box, SQLSuppliers);
                SetDropdownList(pReceivedBy_Box, SQLPurchasingContacts);
                SetDropdownList(pReceivedByTwo_Box, SQLPurchasingContacts);
                SetDropdownList(pProcessedBy_Box, SQLSalesContacts);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void InitialiseNewMatchNo()
        {
            string sql = "SELECT MAX([Match Request No]) FROM Colourmatch.dbo.[MatchRequest_Sales]";
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
                    psMatchRequestNo_Box.Text = Convert.ToString(newReqNo);
                    sMatchStrokeNo_Box.Text = Convert.ToString(1);
                    psMatchStrokeNo_Box.Text = Convert.ToString(1);

                    match.matchNo = Convert.ToString(sMatchRequestNo_Box.Text) + "/" + Convert.ToString(sMatchStrokeNo_Box.Text);
                    match.reqNo = newReqNo;
                    match.strokeNo = Convert.ToInt32(sMatchStrokeNo_Box.Text);
                    sSearchBox.Text = match.matchNo;
                }
                conn.Close();
            }
        }

        private void sSaveChanges_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSalesInformation();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pSaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                SavePurchasingInformation();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sDate_Box_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sSampleType_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //sNewMatchButton
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ViewMatchRequestMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void OutstandingMatchRequestMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT [Match No] FROM Colourmatch.dbo.[MatchRequest_Sales] WHERE [Match No] = " + Convert.ToString(sSearchBox.Text)  + ";";
                ConnectionManager connection = new ConnectionManager();

                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    conn.Open();
                    //Get the maximum of a column and return it 
                    using (var command = new SqlCommand(sql, conn))
                    {
                        Console.WriteLine(command.ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error Saving Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sSearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void sColour_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetDropdownList(ComboBox comboBox, string SQLCommand)
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
            catch(SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
           
        }

        private void ViewRequestLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var form2 = new Colourmatch_winforms.Form2();
                form2.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void pNewMatchButton_Click(object sender, EventArgs e)
        {
           
        }

        private void sNewMatchButton_Click(object sender, EventArgs e)
        {
            try
            {
                InitialiseNewMatchNo();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error Saving Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePurchasingInformation()
        {
            try
            {
                MatchRequest_Purchasing match = new MatchRequest_Purchasing();
                string SQLElements = match.MasterbatchRefOne + ", " + match.MasterbatchRefTwo +"," + match.AdditionRateReceived +","+ match.LightFastnessReceived +","+ match.HeatStabilityReceived +","+ match.DateReceivedOne +","+ match.DateReceivedTwo +","+ match.MatchStatusOne +","+ match.MatchStatusTwo +","+ match.PurchasingNotesOne +","+ match.PurchasingNotesTwo +","+ match.AdditionalNotesOne +","+ match.AdditionalNotesTwo +","+ match.MultipleSuppliers;
                string SQL = "INSERT INTO Colourmatch.dbo.[MatchRequest_Purchasing]([Match No], [Match Request No], [Match Stroke No],[Masterbatch Ref One], [Masterbatch Ref Two], [Let Down Rate Received One], [Let Down Rate Received Two], [Light Fastness Received], [Heat Stability Received], [Date Received One], [Date Received Two], [Match Status One], [Match Status Two], [Purchasing Notes One], [Purchasing Notes Two], [Additional Notes One], [Additional Notes Two], [Multiple Suppliers]) ";
                string SQLInsert = SQL + SQLElements;

                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLInsert, conn))
                    {
                        string matchNo = sMatchRequestNo_Box.Text + "/" + sMatchStrokeNo_Box.Text;
                        string requestNo = sMatchRequestNo_Box.Text;
                        string strokeNo = sMatchStrokeNo_Box.Text;

                        command.Parameters.AddWithValue("MatchNo", Convert.ToString(matchNo));
                        command.Parameters.AddWithValue("ReqNo", Convert.ToInt32(requestNo));
                        command.Parameters.AddWithValue("StrokeNo", Convert.ToInt32(strokeNo));
                        command.Parameters.AddWithValue("MasterbRefOne", Convert.ToString(pMasterbatchReference_Box.Text));
                        command.Parameters.AddWithValue("MasterbRefTwo", Convert.ToString(pMasterbatchRefTwo_Box.Text));
                        command.Parameters.AddWithValue("LetDownReceivedOne", Convert.ToString(pAdditionRateReceived_Box.Text));
                        command.Parameters.AddWithValue("LetDownReceivedTwo", Convert.ToString(pAdditionRateReceivedTwo_Box.Text));
                        command.Parameters.AddWithValue("DateReceivedOne", Convert.ToString(pDateReceived_Box.Text));
                        command.Parameters.AddWithValue("DateReceivedTwo", Convert.ToString(pDateReceivedTwo_Box.Text));
                        command.Parameters.AddWithValue("MatchStatusOne", Convert.ToString(pMatchStatus_Box.Text));
                        command.Parameters.AddWithValue("MatchStatusTwo", Convert.ToString(pMatchStatusTwo_Box.Text));
                        command.Parameters.AddWithValue("PurchasingNotesOne", Convert.ToString(pPurchasingNotes_Box.Text));
                        command.Parameters.AddWithValue("AddtitionalNotesOne", Convert.ToString(pPurchasingNotes_Box.Text));
                        command.Parameters.AddWithValue("MultipleSuppliers", Convert.ToBoolean(pMultipleSuppliers_Checkbox.Checked));
                        int nRows = command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    string sqlElements = "'" + matchInfo.matchNo + "', " + matchInfo.reqNo + ", " + matchInfo.strokeNo + ", '" + matchInfo.date.ToShortDateString() + "', '" + matchInfo.dateRequired.ToShortDateString() + "', '" + matchInfo.salesContact + "', '" + matchInfo.customer + "', '" + matchInfo.customerContact + "', '" + matchInfo.projectReference + "', '" + matchInfo.process + "', '" + matchInfo.mouldingMaterial + "', '" + matchInfo.colour + "', '" + matchInfo.colourPrefixOne + "', '" + matchInfo.colourPrefixTwo + "', '" + matchInfo.lightSource + "', '" + matchInfo.plaques + "', '" + matchInfo.colourTarget + "', '" + matchInfo.pelletSize + "', '" + matchInfo.heatStability + "', '" + matchInfo.sampleQuantity + "', '" + matchInfo.lightFastness + "', '" + matchInfo.additionRate + "', '" + matchInfo.notes + "'";
                    string InsertIntoTable2 = "INSERT INTO Colourmatch.dbo.MatchRequest_Sales ([Match No], [Match Request No], [Match Stroke No], [Date Created], [Date Required], [Sales Contact], [Customer], [Customer Contact], [Project Reference], [Process], [Moulding Material], [Colour], [Colour Prefix One], [Colour Prefix Two], [Light Source], [Plaques], [Colour Target], [Pellet Size], [Heat Stability], [Sample Quantity], [Light Fastness], [Addition Rate],[Notes]) VALUES(" + sqlElements + ");";
                    
                    using (var command = new SqlCommand(InsertIntoTable2, conn))
                    {
                        Console.WriteLine(InsertIntoTable2);
                        int rows = command.ExecuteNonQuery();
                        Console.WriteLine(rows);
                        MessageBox.Show("Match has been created");                           
                    }
                    conn.Close();
                    
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error Saving Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                notes = Convert.ToString(sSalesNotes_Box.Text)
            };
            return match; 
        }

    }    
}
