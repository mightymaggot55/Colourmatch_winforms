using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Colourmatch_winforms.SQLManager;
using static Colourmatch_winforms.FormFunctions;
using System.Linq.Expressions;

namespace Colourmatch_winforms
{
    public partial class ReviewMatch : Form
    {
        public ReviewMatch(string MatchNo)
        {
            InitializeComponent();
            SetIndexValues(MatchNo);
        }

        private void ReviewMatch_Load(object sender, EventArgs e)
        {
            List<Tuple<System.Windows.Forms.ComboBox, string>> dropdownLists = new List<Tuple<System.Windows.Forms.ComboBox, string>>
            {
                Tuple.Create(pReceivedBy_Box, SQLManager.SQLSelectSetDropDown_ReceivedBy),
                Tuple.Create(pHeatStabilityReceived_Box, SQLManager.SQLSelectSetDropDown_HeatStability),
                Tuple.Create(pLightFastnessReceived_Box, SQLManager.SQLSelectSetDropDown_LightFastness),
                Tuple.Create(pSupplier1_Box, SQLManager.SQLSelectSetDropDown_Supplier),
                Tuple.Create(sColour_Box, SQLManager.SelectSQLColour),
                Tuple.Create(sProcess_Box, SQLManager.SelectSQLProcess),
                Tuple.Create(sMouldingMaterial_Box, SQLManager.SelectSQLMouldingMaterial),
                Tuple.Create(sSalesContact_Box, SQLManager.SelectSalesContact),
                Tuple.Create(sColourPrefix2_Box, SQLManager.SelectSQLColourPrefix),
                Tuple.Create(sCustomer_Box, SQLManager.SelectSQLCustomers),
                Tuple.Create(pProcessedBy_Box, SQLManager.SelectSQLPurchasingContact),
                Tuple.Create(pMatchStatus_Box, SQLManager.SelectSQLMatchStatus),
                Tuple.Create(pMatchStatus2_Box, SQLManager.SelectSQLMatchStatus),
                Tuple.Create(pReceivedBy2_Box, SQLManager.SQLSelectSetDropDown_ReceivedBy),
                Tuple.Create(pHeatStabilityReceived2_Box, SQLManager.SQLSelectSetDropDown_HeatStability),
                Tuple.Create(pSupplier2_Box, SQLManager.SQLSelectSetDropDown_Supplier)
            };

            SetDropdownLists(dropdownLists);
        }

        private void SetDropdownLists(List<Tuple<System.Windows.Forms.ComboBox, string>> dropdownLists)
        {
            foreach (Tuple<System.Windows.Forms.ComboBox, string> dropdownlist in dropdownLists)
            {
                SetDropdownList(dropdownlist.Item1, dropdownlist.Item2);
            }
        }


        //private void SetIndexValues(string MatchNo)
        //{
        //    try
        //    {
        //        string SQLExtract = SQLManager.SQLSelectExtract(MatchNo);

        //        using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
        //        {
        //            using (var command = new SqlCommand(SQLExtract, conn))
        //            {
        //                conn.Open();
        //                var reader = command.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    List<Tuple<string, int>> TextboxData = new List<Tuple<string, int>>
        //                    {
        //                        Tuple.Create(sMatchRequestNo_Box.Text, 1),
        //                        Tuple.Create( sMatchStrokeNo_Box.Text, 2),
        //                        Tuple.Create(sCustomerContact_Box.Text, 7),
        //                        Tuple.Create(sProjectReference_Box.Text, 8),
        //                        Tuple.Create(sLightSource_Box.Text, 14),
        //                        Tuple.Create(sPlaques_Box.Text, 15),
        //                        Tuple.Create(sSalesNotes_Box.Text, 16),
        //                        Tuple.Create(sColourTarget_Box.Text, 17),
        //                        Tuple.Create(sPelletSize_Box.Text, 18),
        //                        Tuple.Create(sHeatStability_Box.Text, 19),
        //                        Tuple.Create(sSampleQuantity_Box.Text, 20),
        //                        Tuple.Create(sLightFastness_Box.Text,21),
        //                        Tuple.Create(sAdditionRate_Box.Text, 22),
        //                        Tuple.Create( sSalesContact_Box.Text, 5),
        //                        Tuple.Create(sCustomer_Box.Text, 6),
        //                        Tuple.Create(sProcess_Box.Text, 9),
        //                        Tuple.Create(sMouldingMaterial_Box.Text, 10),
        //                        Tuple.Create(sColour_Box.Text,11),
        //                        Tuple.Create(sColourPrefix1_Box.Text,12),
        //                        Tuple.Create(sColourPrefix2_Box.Text, 13),
        //                        Tuple.Create(sSampleType_Box.Text, 23)

        //                };
        //                    //Adds the values to the review match form
        //                    //Sales Form - Textboxes
        //                    sMatchRequestNo_Box.Text = Convert.ToString(reader[1]);
        //                    sMatchStrokeNo_Box.Text = Convert.ToString(reader[2]);
        //                    sCustomerContact_Box.Text = Convert.ToString(reader[7]);
        //                    sProjectReference_Box.Text = Convert.ToString(reader[8]);
        //                    sLightSource_Box.Text = Convert.ToString(reader[14]);
        //                    sPlaques_Box.Text = Convert.ToString(reader[15]);
        //                    sSalesNotes_Box.Text = Convert.ToString(reader[16]);
        //                    sColourTarget_Box.Text = Convert.ToString(reader[17]);
        //                    sPelletSize_Box.Text = Convert.ToString(reader[18]);
        //                    sHeatStability_Box.Text = Convert.ToString(reader[19]);
        //                    sSampleQuantity_Box.Text = Convert.ToString(reader[20]);
        //                    sLightFastness_Box.Text = Convert.ToString(reader[21]);
        //                    sAdditionRate_Box.Text = Convert.ToString(reader[22]);
        //                    //Comboboxes
        //                    sSalesContact_Box.Text = Convert.ToString(reader[5]);
        //                    sCustomer_Box.Text = Convert.ToString(reader[6]);
        //                    sProcess_Box.Text = Convert.ToString(reader[9]);
        //                    sMouldingMaterial_Box.Text = Convert.ToString(reader[10]);
        //                    sColour_Box.Text = Convert.ToString(reader[11]);
        //                    sColourPrefix1_Box.Text = Convert.ToString(reader[12]);
        //                    sColourPrefix2_Box.Text = Convert.ToString(reader[13]);
        //                    sSampleType_Box.Text = Convert.ToString(reader[23]);

        //                    //Purchasing Tab - Sales Information - Textboxes
        //                    psMatchRequestNo_Box.Text = Convert.ToString(reader[1]);
        //                    psMatchStrokeNo_Box.Text = Convert.ToString(reader[2]);
        //                    psCustomerContact_Box.Text = Convert.ToString(reader[7]);
        //                    psProjectReference_Box.Text = Convert.ToString(reader[8]);
        //                    psLightSource_Box.Text = Convert.ToString(reader[14]);
        //                    psPlaques_Box.Text = Convert.ToString(reader[15]);
        //                    psColourTarget_Box.Text = Convert.ToString(reader[17]);
        //                    psPelletSize_Box.Text = Convert.ToString(reader[18]);
        //                    psHeatStability_Box.Text = Convert.ToString(reader[19]);
        //                    psSampleQuantity_Box.Text = Convert.ToString(reader[20]);
        //                    psLightFastness_Box.Text = Convert.ToString(reader[21]);
        //                    psAdditionRate_Box.Text = Convert.ToString(reader[22]);
        //                    //ComboBoxes
        //                    psSalesContact_Box.Text = Convert.ToString(reader[5]);
        //                    psCustomer_Box.Text = Convert.ToString(reader[6]);
        //                    psProcess_Box.Text = Convert.ToString(reader[9]);
        //                    psMouldingMaterial_Box.Text = Convert.ToString(reader[10]);
        //                    psColour_Box.Text = Convert.ToString(reader[11]);
        //                    psColourPrefix1_Box.Text = Convert.ToString(reader[12]);
        //                    psColourPrefix2_Box.Text = Convert.ToString(reader[13]);
        //                    psSampleType_Box.Text = Convert.ToString(reader[23]);

        //                    //Purchasing Form
        //                    pMasterbatchReference_Box.Text = Convert.ToString(reader[27]);
        //                    pAdditionRateReceived_Box.Text = Convert.ToString(reader[28]);
        //                    pLightFastnessReceived_Box.Text = Convert.ToString(reader[29]);
        //                    pHeatStabilityReceived_Box.Text = Convert.ToString(reader[30]);
        //                    pMatchStatus_Box.Text = Convert.ToString(reader[32]);
        //                    pPurchasingNotes_Box.Text = Convert.ToString(reader[33]);
        //                    pSupplier1_Box.Text = Convert.ToString(reader[35]);
        //                    //pMultipleSuppliers_Checkbox.Checked = Convert.ToBoolean(reader[37]);
        //                    pReceivedBy_Box.Text = Convert.ToString(reader[38]);
        //                    pProcessedBy_Box.Text = Convert.ToString(reader[39]);
        //                    pSupplier2_Box.Text = Convert.ToString(reader[40]);
        //                    pReceivedBy2_Box.Text = Convert.ToString(reader[42]);
        //                    pMasterbatchRef2_Box.Text = Convert.ToString(reader[43]);
        //                    pHeatStabilityReceived2_Box.Text = Convert.ToString(reader[45]);
        //                    pAdditionRateReceived2_Box.Text = Convert.ToString(reader[46]);
        //                    pLightFastnessReceived2_Box.Text = Convert.ToString(reader[47]);
        //                    pMatchStatus2_Box.Text = Convert.ToString(reader[48]);
        //                    pSalesNotes_Box.Text = Convert.ToString(reader[16]);

        //                    //Handle Date Formats
        //                    if (reader[3] != System.DBNull.Value)
        //                    {
        //                        sDate_Box.Value = Convert.ToDateTime(reader[3]);
        //                        psDate_Box.Value = Convert.ToDateTime(reader[3]);
        //                    }
        //                    else
        //                    {
        //                        sDate_Box.Text = string.Empty;
        //                        psDate_Box.Text = string.Empty;
        //                    }
        //                    if (reader[4] != System.DBNull.Value)
        //                    {
        //                        sDateRequired_Box.Value = Convert.ToDateTime(reader[4]);
        //                        psDateRequired_Box.Value = Convert.ToDateTime(reader[4]);
        //                    }
        //                    else
        //                    {
        //                        sDateRequired_Box.Text = string.Empty;
        //                        psDateRequired_Box.Text = string.Empty;
        //                    }
        //                    if (reader[31] != System.DBNull.Value)
        //                    {
        //                        pDateReceived_Box.Value = Convert.ToDateTime(reader[31]);
        //                    }
        //                    else
        //                    {
        //                        pDateReceived_Box.Text = string.Empty;
        //                    }
        //                    if (reader[36] != System.DBNull.Value)
        //                    {
        //                        pDateConfirmed1_Box.Value = Convert.ToDateTime(reader[36]);
        //                        sDateConfirmed1_Box.Value = Convert.ToDateTime(reader[36]);
        //                    }
        //                    else
        //                    {
        //                        pDateConfirmed1_Box.Text = string.Empty;
        //                        sDateConfirmed1_Box.Text = string.Empty;
        //                    }
        //                    if (reader[49] != System.DBNull.Value)
        //                    {
        //                        pDateConfirmed2_Box.Value = Convert.ToDateTime(reader[49]);
        //                        sDateConfirmed2_Box.Value = Convert.ToDateTime(reader[49]);
        //                    }
        //                    else
        //                    {
        //                        pDateConfirmed2_Box.Text = string.Empty;
        //                        sDateConfirmed2_Box.Text = string.Empty;
        //                    }
        //                    if (reader[44] != System.DBNull.Value)
        //                    {
        //                        pDateReceived2_Box.Value = Convert.ToDateTime(reader[44]);
        //                    }
        //                    else
        //                    {
        //                        pDateReceived2_Box.Text = string.Empty;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void SetIndexValues(string MatchNo)
        {
            try
            {
                string SQLExtract = SQLManager.SQLSelectExtract(MatchNo);

                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    using (var command = new SqlCommand(SQLExtract, conn))
                    {
                        conn.Open();
                        var reader = command.ExecuteReader();

                        List<Tuple<System.Windows.Forms.TextBox, int>> SalesTextBoxData = new List<Tuple<System.Windows.Forms.TextBox, int>>
                        {
                            Tuple.Create(sMatchRequestNo_Box, 1),
                            Tuple.Create(sMatchStrokeNo_Box, 2),
                            Tuple.Create(sCustomerContact_Box, 7),
                            Tuple.Create(sProjectReference_Box, 8),
                            Tuple.Create(sLightSource_Box, 14),
                            Tuple.Create(sPlaques_Box, 15),
                            Tuple.Create(sColourTarget_Box, 17),
                            Tuple.Create(sPelletSize_Box, 18),
                            Tuple.Create(sHeatStability_Box, 19),
                            Tuple.Create(sSampleQuantity_Box, 20),
                            Tuple.Create(sLightFastness_Box,21),
                            Tuple.Create(sAdditionRate_Box, 22),
                        };

                        List<Tuple<System.Windows.Forms.ComboBox, int>> SalesComboBoxData = new List<Tuple<System.Windows.Forms.ComboBox, int>>
                        {
                            Tuple.Create(sSalesContact_Box, 5),
                            Tuple.Create(sCustomer_Box, 6),
                            Tuple.Create(sProcess_Box, 9),
                            Tuple.Create(sMouldingMaterial_Box, 10),
                            Tuple.Create(sColour_Box, 11),
                            Tuple.Create(sColourPrefix1_Box,12),
                            Tuple.Create(sColourPrefix2_Box, 13),
                            Tuple.Create(sSampleType_Box, 23)

                        };

                        List<Tuple<System.Windows.Forms.ComboBox, int>> PurchasingComboData = new List<Tuple<System.Windows.Forms.ComboBox, int>>
                        {
                            Tuple.Create(psSalesContact_Box, 5),
                            Tuple.Create(psCustomer_Box, 6),
                            Tuple.Create(psProcess_Box, 9),
                            Tuple.Create(psMouldingMaterial_Box, 10),
                            Tuple.Create(psColour_Box, 11),
                            Tuple.Create(psColourPrefix1_Box, 12),
                            Tuple.Create(psColourPrefix2_Box, 13),
                            Tuple.Create(psSampleType_Box, 23),
                            Tuple.Create(pAdditionRateReceived_Box, 28),
                            Tuple.Create(pLightFastnessReceived_Box, 29),
                            Tuple.Create(pHeatStabilityReceived_Box, 30),
                            Tuple.Create(pMatchStatus_Box, 32),
                            Tuple.Create(pSupplier1_Box, 35),
                            Tuple.Create(pReceivedBy_Box, 38),
                            Tuple.Create(pProcessedBy_Box, 39),
                            Tuple.Create(pSupplier2_Box, 40),
                            Tuple.Create(pReceivedBy2_Box, 42),
                            Tuple.Create(pHeatStabilityReceived2_Box , 45),
                            Tuple.Create(pAdditionRateReceived2_Box , 46),
                            Tuple.Create(pLightFastnessReceived2_Box , 47),
                            Tuple.Create(pMatchStatus2_Box , 48),
                        };

                        List<Tuple<System.Windows.Forms.TextBox, int>> PurchasingTextData = new List<Tuple<System.Windows.Forms.TextBox, int>>
                        {
                            Tuple.Create(pMasterbatchReference_Box, 27),
                            Tuple.Create(pMasterbatchRef2_Box, 43),
                            Tuple.Create(psMatchRequestNo_Box, 1),
                            Tuple.Create(psMatchStrokeNo_Box, 2),
                            Tuple.Create(psCustomerContact_Box, 7),
                            Tuple.Create(psProjectReference_Box, 8),
                            Tuple.Create(psLightSource_Box, 14),
                            Tuple.Create(psPlaques_Box, 15),
                            Tuple.Create(psColourTarget_Box, 17),
                            Tuple.Create(psPelletSize_Box, 18),
                            Tuple.Create(psHeatStability_Box, 19),
                            Tuple.Create(psSampleQuantity_Box, 20),
                            Tuple.Create(psLightFastness_Box, 21),
                            Tuple.Create(psAdditionRate_Box, 22),
                        };

                        List <Tuple<System.Windows.Forms.RichTextBox, int>> PurchasingRichTextData = new List<Tuple<System.Windows.Forms.RichTextBox, int>>
                        {
                            Tuple.Create(pSalesNotes_Box, 16),
                            Tuple.Create(pPurchasingNotes_Box, 33)

                        };

                        List<Tuple<System.Windows.Forms.RichTextBox, int>> SalesRichTextData = new List<Tuple<System.Windows.Forms.RichTextBox, int>>
                        {
                            Tuple.Create(sSalesNotes_Box, 16)
                        };

                        while (reader.Read())
                        {
                            SetTextBoxValues(reader, SalesTextBoxData, PurchasingTextData, SalesComboBoxData, PurchasingComboData, SalesRichTextData, PurchasingRichTextData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void SetTextBoxValues(SqlDataReader reader, List<Tuple<System.Windows.Forms.TextBox, int>> salesTextData, List<Tuple<System.Windows.Forms.TextBox, int>> purchasingTextData, List<Tuple<System.Windows.Forms.ComboBox, int>> SalesComboData, List<Tuple<System.Windows.Forms.ComboBox, int>> purchasingComboData, List<Tuple<System.Windows.Forms.RichTextBox, int>> salesRichTextData, List<Tuple<System.Windows.Forms.RichTextBox, int>> purchasingRichTextData)
        {
            foreach (Tuple<System.Windows.Forms.TextBox, int> data in salesTextData)
            {
                data.Item1.Text = Convert.ToString(reader[data.Item2]);
            }
            foreach(Tuple<System.Windows.Forms.ComboBox, int> data in SalesComboData )
            {
                data.Item1.Text = Convert.ToString(reader[data.Item2]);
            }
            foreach(Tuple<System.Windows.Forms.RichTextBox, int> data in salesRichTextData)
            {
                data.Item1.Text = Convert.ToString(reader[data.Item2]);
            }
            foreach(Tuple<System.Windows.Forms.TextBox, int> data in purchasingTextData)
            {
                data.Item1.Text = Convert.ToString(reader[data.Item2]);
            }
            foreach (Tuple<System.Windows.Forms.ComboBox, int> data in purchasingComboData)
            {
                data.Item1.Text = Convert.ToString(reader[data.Item2]);
            }
            foreach (Tuple<System.Windows.Forms.RichTextBox, int> data in purchasingRichTextData)
            {
                data.Item1.Text = Convert.ToString(reader[data.Item2]);
            }
        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void sSaveChanges_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSalesChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pSaveChanges_button_Click(object sender, EventArgs e)
        {
            try
            {
                SavePurchasingChanges();
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

        private void pSalesNotes_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void sRematchButton_Click(object sender, EventArgs e)
        {
            Rematch();
        }

        public void Rematch()
        {
            string MaxStrokeSQL = SQLManager.SQLGetMaxStroke(psMatchRequestNo_Box.Text);

            try
            {
                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    //Add 1 to current Stroke No
                    int NewStrokeNo = GetMaxStroke(conn, MaxStrokeSQL);

                    //Insert Match No into the MatchRequest_Sales
                    string newMatchNo = psMatchRequestNo_Box.Text + "-" + NewStrokeNo.ToString();
                    string InsertSalesRematch = SQLManager.SQLInsertRematch(newMatchNo, psMatchRequestNo_Box.Text, NewStrokeNo);
                    FormFunctions.RunSQLCommand(conn, InsertSalesRematch);

                    //Insert Match No into the MatchRequest_Purchasing - Ensures that record is in both Sales and Purchasing Table
                    string InsertPurchasingRematch = SQLManager.SQLInsertPurchasingRematch(newMatchNo, psMatchRequestNo_Box.Text, NewStrokeNo);
                    FormFunctions.RunSQLCommand(conn, InsertPurchasingRematch);

                    //Retrieve Sales Information using SELECT(Match Request No and Match Stroke No)
                    string RetrieveSalesInformation = SQLManager.SQLSelectSalesInformation(sMatchRequestNo_Box.Text, sMatchStrokeNo_Box.Text);
                    string[] salesInfo = new string[4];
                    salesInfo = SelectSalesInfo(conn, RetrieveSalesInformation);

                    //Update the Sales information - Copy across required information from previous match to new match
                    string UpdateSalesInformation = SQLManager.SQLUpdateSalesInformation(salesInfo[0], salesInfo[1], salesInfo[2], salesInfo[3], sMatchRequestNo_Box.Text, NewStrokeNo);
                    FormFunctions.RunSQLCommand(conn, UpdateSalesInformation);

                    MessageBox.Show("Rematch has been completed");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private int GetMaxStroke(SqlConnection conn, string SQL)
        {
            int newStrokeNo;
            using (var command = new SqlCommand(SQL, conn))
            {
                conn.Open();
                var result = command.ExecuteReader();
                int i = 0;
                var strokeNo = 0;
                while (result.Read())
                {
                    strokeNo = Convert.ToInt32(result[i]);
                    Console.WriteLine(strokeNo);
                }
                newStrokeNo = strokeNo + 1;
                conn.Close();
            }
            return newStrokeNo;
        }

        private string[] SelectSalesInfo(SqlConnection conn, string SQL)
        {
            string[] salesInfo = new string[4];
            using (var command = new SqlCommand(SQL, conn))
            {
                conn.Open();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    salesInfo[0] = result[0].ToString();
                    salesInfo[1] = result[1].ToString();
                    salesInfo[2] = result[2].ToString();
                    salesInfo[3] = result[3].ToString();
                }
                conn.Close();
            }
            return salesInfo;
        }

        //Set values on Process box change
        public void sProcess_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessBox_Changed();
        }

        public void ProcessBox_Changed()
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

        public void MaterialBox_Changed()
        {
            try
            {
                FormFunctions.ChangeMaterialValues(sMouldingMaterial_Box, sSampleQuantity_Box);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sMouldingMaterial_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaterialBox_Changed();
        }

        private void SavePurchasingChanges()
        {
            string updateSupplierOne = SQLManager.SQLUpdatePurchasing(pMasterbatchRef2_Box.Text, pAdditionRateReceived2_Box.Text, pLightFastnessReceived2_Box.Text, pHeatStabilityReceived2_Box.Text, pDateReceived2_Box.Text, pMatchStatus_Box.Text, pPurchasingNotes_Box.Text, pReceivedBy2_Box.Text, pProcessedBy_Box.Text, pSupplier2_Box.Text, pDateConfirmed2_Box.Text, sMatchRequestNo_Box.Text, sMatchStrokeNo_Box.Text);
            string updateSupplierTwo = SQLManager.SQLUpdatePurchasingTwo(pMasterbatchReference_Box.Text, pAdditionRateReceived_Box.Text, pLightFastnessReceived_Box.Text, pHeatStabilityReceived_Box.Text, pDateReceived_Box.Text, pMatchStatus_Box.Text, pPurchasingNotes_Box.Text, pReceivedBy_Box.Text, pProcessedBy_Box.Text, pSupplier1_Box.Text, pDateConfirmed1_Box.Text, sMatchRequestNo_Box.Text, sMatchStrokeNo_Box.Text);
            Console.WriteLine(updateSupplierOne);

            using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
            {
                using (var command = new SqlCommand(updateSupplierOne, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                using (var command = new SqlCommand(updateSupplierTwo, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            MessageBox.Show("Changes have been saved");
        }

        private void SaveSalesChanges()
        {
            string UpdateSQL = SQLManager.SQLUpdateSalesButton(sDate_Box.Text, sDateRequired_Box.Text, sSalesContact_Box.Text, sCustomer_Box.Text, sCustomerContact_Box.Text, sProjectReference_Box.Text, sProcess_Box.Text, sMouldingMaterial_Box.Text, sColour_Box.Text, sColourPrefix1_Box.Text, sColourPrefix2_Box.Text, sLightSource_Box.Text, sPlaques_Box.Text, sSalesNotes_Box.Text, sColourTarget_Box.Text, sPelletSize_Box.Text, sHeatStability_Box.Text, sSampleQuantity_Box.Text, sLightFastness_Box.Text, sAdditionRate_Box.Text, sSampleType_Box.Text, sMatchRequestNo_Box.Text.ToString() + "-" + sMatchStrokeNo_Box.Text.ToString());
            using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
            {
                FormFunctions.RunSQLCommand(conn, UpdateSQL);
                MessageBox.Show("Changes have been saved");
            }
        }
    }
}


