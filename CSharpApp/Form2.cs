using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool f_tamam = true;
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=localhost;Database=ProjectDB;Integrated Security=true;");
                baglanti.Open();
                SqlCommand komut = baglanti.CreateCommand();
                //komut.CommandType = CommandType.Text;
                //komut.CommandText = "SELECT * FROM Bolum ORDER BY Bolum_Kodu";
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "udp_Sahtecilik_Ekle";
                komut.Parameters.AddWithValue("@Rapor_Kodu", textBox1.Text);
                komut.Parameters.AddWithValue("@Tespit", textBox2.Text);
                komut.Parameters.AddWithValue("@Banknot_Cinsi", textBox3.Text);
                komut.Parameters.AddWithValue("@Banknot_Adedi", textBox4.Text);
                komut.Parameters.AddWithValue("@Nominal_Deger", textBox5.Text);
                komut.Parameters.AddWithValue("@Seri_Sira_No", textBox6.Text);
                if (String.IsNullOrEmpty(textBox7.Text))
                {
                    komut.Parameters.AddWithValue("@Rapor_Tarihi", "1900-01-01");
                }
                else
                {
                    komut.Parameters.AddWithValue("@Rapor_Tarihi", DateTime.Parse(textBox7.Text));
                }

                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                if (tablo.Rows[0]["Sonuc"].ToString().Trim() != "0")
                {
                    f_tamam = false;
                    //MessageBox.Show("test1", "Test");
                    MessageBox.Show(tablo.Rows[0]["Mesaj"].ToString());
                }
                baglanti.Close();
            }
            catch (Exception exp)
            {
                //MessageBox.Show("test2", "Test");
                MessageBox.Show(exp.Message);
            }


            if (f_tamam)
            {
                Form1 f = new Form1();
                f.listeYenile();

                this.DialogResult = DialogResult.OK;
                //MessageBox.Show("test3", "Test");
                Close();
            }
        }

    }
}
