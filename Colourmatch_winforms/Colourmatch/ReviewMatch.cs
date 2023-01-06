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
            SetDropdownList(pReceivedBy_Box, SQLManager.SQLSelectSetDropDown_ReceivedBy);
            SetDropdownList(pHeatStabilityReceived_Box, SQLManager.SQLSelectSetDropDown_HeatStability);
            SetDropdownList(pLightFastnessReceived_Box, SQLManager.SQLSelectSetDropDown_LightFastness);
            SetDropdownList(pSupplier1_Box, SQLManager.SQLSelectSetDropDown_Supplier);
            SetDropdownList(sColour_Box, SQLManager.SelectSQLColour);
            SetDropdownList(sProcess_Box, SQLManager.SelectSQLProcess);
            SetDropdownList(sMouldingMaterial_Box, SQLManager.SelectSQLMouldingMaterial);
            SetDropdownList(sSalesContact_Box, SQLManager.SelectSalesContact);
            SetDropdownList(sColourPrefix2_Box, SQLManager.SelectSQLColourPrefix);
            SetDropdownList(sCustomer_Box, SQLManager.SelectSQLCustomers);
            SetDropdownList(pProcessedBy_Box, SQLManager.SelectSQLPurchasingContact);
            SetDropdownList(pMatchStatus_Box, SQLManager.SelectSQLMatchStatus);
            SetDropdownList(pMatchStatus2_Box, SQLManager.SelectSQLMatchStatus);
            SetDropdownList(pReceivedBy2_Box, SQLManager.SQLSelectSetDropDown_ReceivedBy);
            SetDropdownList(pLightFastnessReceived2_Box, SQLManager.SQLSelectSetDropDown_LightFastness);
            SetDropdownList(pHeatStabilityReceived2_Box, SQLManager.SQLSelectSetDropDown_HeatStability);
            SetDropdownList(pSupplier2_Box, SQLManager.SQLSelectSetDropDown_Supplier);
        }

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
                        while (reader.Read())
                        {
                            //Adds the values to the review match form
                            //Sales Form
                            sMatchRequestNo_Box.Text = Convert.ToString(reader[1]);
                            sMatchStrokeNo_Box.Text = Convert.ToString(reader[2]);
                            sSalesContact_Box.Text = Convert.ToString(reader[5]);
                            sCustomer_Box.Text = Convert.ToString(reader[6]);
                            sCustomerContact_Box.Text = Convert.ToString(reader[7]);
                            sProjectReference_Box.Text = Convert.ToString(reader[8]);
                            sProcess_Box.Text = Convert.ToString(reader[9]);
                            sMouldingMaterial_Box.Text = Convert.ToString(reader[10]);
                            sColour_Box.Text = Convert.ToString(reader[11]);
                            sColourPrefix1_Box.Text = Convert.ToString(reader[12]);
                            sColourPrefix2_Box.Text = Convert.ToString(reader[13]);
                            sLightSource_Box.Text = Convert.ToString(reader[14]);
                            sPlaques_Box.Text = Convert.ToString(reader[15]);
                            sSalesNotes_Box.Text = Convert.ToString(reader[16]);
                            sColourTarget_Box.Text = Convert.ToString(reader[17]);
                            sPelletSize_Box.Text = Convert.ToString(reader[18]);
                            sHeatStability_Box.Text = Convert.ToString(reader[19]);
                            sSampleQuantity_Box.Text = Convert.ToString(reader[20]);
                            sLightFastness_Box.Text = Convert.ToString(reader[21]);
                            sAdditionRate_Box.Text = Convert.ToString(reader[22]);
                            sSampleType_Box.Text = Convert.ToString(reader[23]);
                            
                            //Purchasing Tab - Sales Information
                            psMatchRequestNo_Box.Text = Convert.ToString(reader[1]);
                            psMatchStrokeNo_Box.Text = Convert.ToString(reader[2]);
                            psSalesContact_Box.Text = Convert.ToString(reader[5]);
                            psCustomer_Box.Text = Convert.ToString(reader[6]);
                            psCustomerContact_Box.Text = Convert.ToString(reader[7]);
                            psProjectReference_Box.Text = Convert.ToString(reader[8]);
                            psProcess_Box.Text = Convert.ToString(reader[9]);
                            psMouldingMaterial_Box.Text = Convert.ToString(reader[10]);
                            psColour_Box.Text = Convert.ToString(reader[11]);
                            psColourPrefix1_Box.Text = Convert.ToString(reader[12]);
                            psColourPrefix2_Box.Text = Convert.ToString(reader[13]);
                            psLightSource_Box.Text = Convert.ToString(reader[14]);
                            psPlaques_Box.Text = Convert.ToString(reader[15]);
                            psColourTarget_Box.Text = Convert.ToString(reader[17]);
                            psPelletSize_Box.Text = Convert.ToString(reader[18]);
                            psHeatStability_Box.Text = Convert.ToString(reader[19]);
                            psSampleQuantity_Box.Text = Convert.ToString(reader[20]);
                            psLightFastness_Box.Text = Convert.ToString(reader[21]);
                            psAdditionRate_Box.Text = Convert.ToString(reader[22]);
                            psSampleType_Box.Text = Convert.ToString(reader[23]);

                            //Purchasing Form
                            pMasterbatchReference_Box.Text = Convert.ToString(reader[27]);
                            pAdditionRateReceived_Box.Text = Convert.ToString(reader[28]);
                            pLightFastnessReceived_Box.Text = Convert.ToString(reader[29]);
                            pHeatStabilityReceived_Box.Text = Convert.ToString(reader[30]);
                            pMatchStatus_Box.Text = Convert.ToString(reader[32]);
                            pPurchasingNotes_Box.Text = Convert.ToString(reader[33]);
                            pSupplier1_Box.Text = Convert.ToString(reader[35]);
                            //pMultipleSuppliers_Checkbox.Checked = Convert.ToBoolean(reader[37]);
                            pReceivedBy_Box.Text = Convert.ToString(reader[38]);
                            pProcessedBy_Box.Text = Convert.ToString(reader[39]);
                            pSupplier2_Box.Text = Convert.ToString(reader[40]);
                            pReceivedBy2_Box.Text = Convert.ToString(reader[42]);
                            pMasterbatchRef2_Box.Text = Convert.ToString(reader[43]);
                            pHeatStabilityReceived2_Box.Text = Convert.ToString(reader[45]);
                            pAdditionRateReceived2_Box.Text = Convert.ToString(reader[46]);
                            pLightFastnessReceived2_Box.Text = Convert.ToString(reader[47]);
                            pMatchStatus2_Box.Text = Convert.ToString(reader[48]);
                            pSalesNotes_Box.Text = Convert.ToString(reader[16]); 

                            //Handle Date Formats
                            if (reader[3] != System.DBNull.Value)
                            {
                                sDate_Box.Value = Convert.ToDateTime(reader[3]);
                                psDate_Box.Value = Convert.ToDateTime(reader[3]);
                            }
                            else
                            {
                                sDate_Box.Text = string.Empty;
                                psDate_Box.Text = string.Empty;
                            }
                            if(reader[4] != System.DBNull.Value)
                            {
                                sDateRequired_Box.Value = Convert.ToDateTime(reader[4]);
                                psDateRequired_Box.Value = Convert.ToDateTime(reader[4]);
                            }
                            else
                            {
                                sDateRequired_Box.Text = string.Empty;
                                psDateRequired_Box.Text = string.Empty;
                            }
                            if (reader[31] != System.DBNull.Value)
                            {
                                pDateReceived_Box.Value = Convert.ToDateTime(reader[31]);
                            }
                            else
                            {
                                pDateReceived_Box.Text = string.Empty;
                            }
                            if (reader[36] != System.DBNull.Value)
                            {
                                pDateConfirmed1_Box.Value = Convert.ToDateTime(reader[36]);
                                sDateConfirmed1_Box.Value = Convert.ToDateTime(reader[36]);
                            }
                            else
                            {
                                pDateConfirmed1_Box.Text = string.Empty;
                                sDateConfirmed1_Box.Text = string.Empty;
                            }
                            if (reader[49] != System.DBNull.Value)
                            {
                                pDateConfirmed2_Box.Value = Convert.ToDateTime(reader[49]);
                                sDateConfirmed2_Box.Value = Convert.ToDateTime(reader[49]);
                            }
                            else
                            {
                                pDateConfirmed2_Box.Text = string.Empty;
                                sDateConfirmed2_Box.Text = string.Empty;
                            }
                            if (reader[44] != System.DBNull.Value)
                            {
                                pDateReceived2_Box.Value = Convert.ToDateTime(reader[44]);
                            }
                            else
                            {
                                pDateReceived2_Box.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            catch(SqlException ex)
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


