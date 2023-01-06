using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Colourmatch_winforms.ConnectionManager;

namespace Colourmatch_winforms
{
    public partial class MatchReview : Form
    {
        public MatchReview(string MatchNo)
        {
            InitializeComponent();
            SetIndexValues(MatchNo);
        }

        private void SetIndexValues(string MatchNo)
        {
            try
            {
                string SQLExtract = "SELECT * FROM(SELECT * FROM[MatchRequest_Sales]) A LEFT JOIN(SELECT * FROM MatchRequest_Purchasing) B ON A.[Match No] = B.[Match No] WHERE A.[Match No] = '" + MatchNo + "';";
                using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    using (var command = new SqlCommand(SQLExtract, conn))
                    {
                        conn.Open();
                        var reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            MatchRequestNo_box.Text = Convert.ToString(reader[1]);
                            MatchStrokeNo_box.Text = Convert.ToString(reader[2]);
                            DateCreated_box.Text = Convert.ToString(reader[3]);
                            DateRequired_box.Text = Convert.ToString(reader[4]);
                            SalesContact_box.Text = Convert.ToString(reader[5]);
                            Customer_box.Text = Convert.ToString(reader[6]);
                            CustomerContact_box.Text = Convert.ToString(reader[7]);
                            ProjectReference_box.Text = Convert.ToString(reader[8]);
                            Process_box.Text = Convert.ToString(reader[9]);
                            MouldingMaterial_box.Text = Convert.ToString(reader[10]);
                            Colour_box.Text = Convert.ToString(reader[11]);
                            ColourPrefixOne_box.Text = Convert.ToString(reader[12]);
                            ColourPrefixTwo_box.Text = Convert.ToString(reader[13]);
                            LightSource_box.Text = Convert.ToString(reader[14]);
                            Plaques_box.Text = Convert.ToString(reader[15]);
                            SalesNotes_textbox.Text = Convert.ToString(reader[16]);
                            ColourTarget_box.Text = Convert.ToString(reader[17]);
                            PelletSize_box.Text = Convert.ToString(reader[18]);
                            HeatStability_box.Text = Convert.ToString(reader[19]);
                            SampleQuantity_box.Text = Convert.ToString(reader[20]);
                            LightFastness_box.Text = Convert.ToString(reader[21]);
                            AdditionRate_box.Text = Convert.ToString(reader[0]);
                            AdditionRateReceived1_box.Text = Convert.ToString(reader[0]);
                            //LightFastness_box.Text=(Convert.ToString(reader[26]);
                            //HeatStability_box.Text=(Convert.ToString(reader[27]);
                            //HeatStabilityReceived_box.Text=(Convert.ToString(reader[28]);
                            DateReceived1_box.Text = Convert.ToString(reader[30]);
                            MatchStatus1_box.Text = Convert.ToString(reader[31]);
                            //PelletSize_box.Text = Convert.ToString(reader[31];
                            PurchasingNotes_textbox.Text = Convert.ToString(reader[32]);
                            AdditionRateReceived1_box.Text = Convert.ToString(reader[33]);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
