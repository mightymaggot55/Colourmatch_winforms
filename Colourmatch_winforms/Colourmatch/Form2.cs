using Npgsql;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Colourmatch_winforms.ConnectionManager;
using Colourmatch_winforms.DataSets;

namespace Colourmatch_winforms
{
    public partial class Form2 : Form
    {        

        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.MatchRequestDataTable.Rows[e.RowIndex];
            //Name of the Match No Column in the datagrid
            string MatchNo = row.Cells["matchNoDataGridViewTextBoxColumn2"].Value.ToString();
            var form = new ReviewMatch(MatchNo);
            form.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'colourmatch_Sales_DS.MatchRequest_Sales' table. You can move, or remove it, as needed.
            this.matchRequest_SalesTableAdapter.Fill(this.colourmatch_Sales_DS.MatchRequest_Sales);
            try
            {
                Load_Form();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HomeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void CreateRequestLinkedLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var form1 = new Colourmatch_winforms.ColourmatchDatabase_form();
            //form1.ShowDialog();
            var createRequestForm = new Colourmatch_winforms.CreateMatch();
            createRequestForm.ShowDialog();
        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.matchRequest_SalesTableAdapter.FillBy(this.colourmatch_Sales_DS.MatchRequest_Sales);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection(ConnectionManager.ConnectionString);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT TOP (100) [Match No], [Match Request No], [Match Stroke No], [Date Created], [Date Required], [Sales Contact], [Customer], [Customer Contact], [Project Reference], [Process], [Moulding Material], [Colour], [Colour Prefix One], [Colour Prefix Two], [Light Source], [Plaques], [Notes], [Colour Target], [Pellet Size], [Heat Stability], [Sample Quantity], [Light Fastness], [Sample Type] FROM Colourmatch.dbo.[MatchRequest_Sales] ORDER BY [Match Request No];", conn);
                //DataTable dataTable = new DataTable();
                //dataAdapter.Fill(dataTable);
                Load_Form();

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Load_Form()
        {
            SqlConnection conn = new SqlConnection(ConnectionManager.ConnectionString);
            conn.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT TOP (100) [Match No], [Match Request No], [Match Stroke No], [Date Created], [Date Required], [Sales Contact], [Customer], [Customer Contact], [Project Reference], [Process], [Moulding Material], [Colour], [Colour Prefix One], [Colour Prefix Two], [Light Source], [Plaques], [Notes], [Colour Target], [Pellet Size], [Heat Stability], [Sample Quantity], [Light Fastness], [Sample Type] FROM Colourmatch.dbo.[MatchRequest_Sales] ORDER BY [Match Request No];", conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            MatchRequestDataTable.DataSource = dataTable;

            BindingSource source = new BindingSource();
            source.DataSource = dataTable;
            MatchRequestDataTable.DataSource = source;

            MatchRequestDataTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
