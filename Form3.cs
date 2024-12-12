using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogubsapp
{

    public partial class Form3 : Form
    {
        

        public Form3()
        {

            InitializeComponent();
            string connectionString = "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;";
            string query = "SELECT DersID, DersAdı, Kredi, Kontenjan, Mevcut FROM Dersler";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dgv1.Rows.Add(
                        reader["DersID"],
                        reader["DersAdı"],
                        reader["Kredi"],
                        reader["Kontenjan"],
                        reader["Mevcut"]
                    );
                }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void Form3_Load(object sender, EventArgs e)
        {
            this.coursesTableAdapter2.Fill(this.ogubsDataSet2.Courses);
            this.coursesTableAdapter1.Fill(this.ogubsDataSet1.Courses);
            this.coursesTableAdapter.Fill(this.ogubsDataSet.Courses);

        }
        private void CheckSelectionRules()
        {
            int toplamKredi = 0;
            double gano = GetGano();

            foreach (DataGridViewRow row in dgv1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seçildi"].Value) == true)
                {
                    int kredi = Convert.ToInt32(row.Cells["Kredi"].Value);
                    toplamKredi += kredi;
                }
            }

            if ((gano < 3.00 && toplamKredi > 21) || (gano >= 3.00 && toplamKredi > 30))
            {
                MessageBox.Show("Kredi limitinizi aşıyorsunuz!");
            }
        }
        private bool IsKontenjanAvailable(DataGridViewRow row)
        {
            int kontenjan = Convert.ToInt32(row.Cells["Kontenjan"].Value);
            int mevcut = Convert.ToInt32(row.Cells["Mevcut"].Value);
            return mevcut < kontenjan;
        }

        private void button1_Click(object sender, EventArgs e)
        { }
            private void btnKaydet_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO OgrenciDersleri (OgrenciID, DersID) VALUES (@OgrenciID, @DersID)";
            string connectionString = "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                connection.Open();

                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Seçildi"].Value) == true)
                    {
                        if (!IsKontenjanAvailable(row))
                        {
                            MessageBox.Show($"{row.Cells["DersAdı"].Value} dersinin kontenjanı dolmuştur.");
                            continue;
                        }

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@OgrenciID", CurrentStudentID);
                        command.Parameters.AddWithValue("@DersID", row.Cells["DersID"].Value);
                        command.ExecuteNonQuery();

                        string updateQuery = "UPDATE Dersler SET Mevcut = Mevcut + 1 WHERE DersID = @DersID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@DersID", row.Cells["DersID"].Value);
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Seçimler başarıyla kaydedildi.");
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.coursesTableAdapter2.FillBy(this.ogubsDataSet2.Courses);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    }
}

