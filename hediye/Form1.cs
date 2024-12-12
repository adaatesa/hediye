using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hediye
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Yeni bir isim eklemek için bir buton olayı
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    // Veritabanı bağlantısını oluştur
                    string connectionString = "Data Source=SERVER_ADRESI;Initial Catalog=DATABASE_ADI;Integrated Security=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Veriyi eklemek için SQL komutu
                        string query = "INSERT INTO Participants (Name) VALUES (@Name)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("İsim başarıyla kaydedildi!");
                    textBox1.Clear(); // TextBox'ı temizle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir isim girin.");
            }
        }

    }
}
