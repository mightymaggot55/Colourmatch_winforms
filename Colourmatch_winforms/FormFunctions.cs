using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Colourmatch_winforms.SQLManager;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Colourmatch_winforms
{
    public class FormFunctions
    {
        public static void ChangeProcessValues(ComboBox processBox, TextBox addRate, TextBox pelletSize, TextBox lightFastness, TextBox heatStability)
        {
            //Read Process Name
            //string SQLExtractProcesses = "SELECT Process FROM Colourmatch.dbo.[Process Specifications]";
            //string[] data = new string[4];
            //int i = 0;
            using (var connection = new SqlConnection(ConnectionManager.ConnectionString))
            {
                //using (var command = new SqlCommand(SQLExtractProcesses, connection))
                //{
                //    connection.Open();
                //    var reader = command.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        data[i] = (string)reader[0];
                //        Console.WriteLine(data[i].ToString());
                //        i++;
                //    }
                //    reader.Close();
                //}

                //string process = CheckData(data, processBox.Text);
                string SQLSelectDetails = "SELECT [Addition Rate], [Pellet Size], [Light Fastness], [Heat Stability] FROM Colourmatch.dbo.[Process Specifications] WHERE Process = '" + processBox.Text + "'";
                using (var command = new SqlCommand(SQLSelectDetails, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    string[] details = new string[4];

                    while (reader.Read())
                    {
                        for (int j = 0; j <= reader.FieldCount - 1; j++)
                        {
                            details[j] = reader[j].ToString();
                            Console.WriteLine(details[j]);
                        }                        
                        addRate.Text = details[0];
                        pelletSize.Text = details[1];
                        lightFastness.Text = details[2];
                        heatStability.Text = details[3];
                        break;
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }

        public static string CheckData(string[] data, string temp)
        {
            string process = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ToString() == temp)
                {
                    Console.WriteLine(data[i].ToString());
                    process = data[i];
                    return process;
                }
            }
            return process;
        }

        public static void RunSQLCommand(SqlConnection conn, string SQL)
        {
            using (var command = new SqlCommand(SQL, conn))
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows.ToString() + " Rows Ammended");
                conn.Close();
            }
        }

        public static void ChangeMaterialValues(ComboBox mouldingMaterial,TextBox sampleQuantity) 
        {
            using (var conn = new SqlConnection(ConnectionManager.ConnectionString))
            {
                //using (var command = new SqlCommand(SQLMaterialExtract, conn))
                //{
                //    conn.Open();
                //    var reader = command.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        data[i] = (string)reader[0];
                //        Console.WriteLine(data[i].ToString());
                //        i++;
                //    }
                //    conn.Close();
                //}
                //string material = CheckData(data, mouldingMaterial.Text);
                string SQLSelectDetails = "SELECT [Sample Quantity] FROM Colourmatch.dbo.[Material Specifications] WHERE [Moulding Material] = '" + mouldingMaterial.Text + "'";

                using (var command = new SqlCommand(SQLSelectDetails, conn))
                {
                    conn.Open();
                    var reader = command.ExecuteReader();
                    string sampleQTY;

                    while (reader.Read())
                    {
                        sampleQTY = (string)reader[0];
                        sampleQuantity.Text = sampleQTY;
                        Console.WriteLine(sampleQTY);
                        break;
                    }
                    reader.Close();                    
                    conn.Close();
                }
            }
        }
    }
}
