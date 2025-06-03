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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listeYenile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void listeYenile()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=localhost;Database=ProjectDB;Integrated Security=true;");
                baglanti.Open();
                SqlCommand komut = baglanti.CreateCommand();
                //komut.CommandType = CommandType.Text;
                //komut.CommandText = "SELECT * FROM Sahtecilik_Raporu ORDER BY Rapor_Kodu";
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "udp_Sahtecilik";
                komut.Parameters.AddWithValue("@TestParameter", 10);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            listeYenile();
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            Form2 stForm = new Form2();
            if (stForm.ShowDialog() == DialogResult.OK) listeYenile();
        }

        private void degistir_Click(object sender, EventArgs e)
        {
            //upload data to form3 from dataGridView1
            if (dataGridView1.SelectedRows.Count != 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append(dataGridView1.SelectedRows[0].Index.ToString());
                sb.Append(dataGridView1.SelectedRows[0].Cells["Rapor Kodu"].Value.ToString());
                String rapor_kodu = sb.ToString();
                
                System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
                sb1.Append(dataGridView1.SelectedRows[0].Cells["Tespit"].Value.ToString());
                String tespit = sb1.ToString();
                
                System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
                sb2.Append(dataGridView1.SelectedRows[0].Cells["Banknot Cinsi"].Value.ToString());
                String banknot_cinsi = sb2.ToString();

                System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                sb3.Append(dataGridView1.SelectedRows[0].Cells["Banknot Adedi"].Value.ToString());
                String banknot_adedi = sb3.ToString();

                System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                sb4.Append(dataGridView1.SelectedRows[0].Cells["Nominal Değer"].Value.ToString());
                String nominal_deger = sb4.ToString();

                System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                sb5.Append(dataGridView1.SelectedRows[0].Cells["Seri-Sıra No"].Value.ToString());
                String seri_sira_no = sb5.ToString();

                System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
                sb6.Append(dataGridView1.SelectedRows[0].Cells["Rapor Tarihi"].Value.ToString());
                String temp_rapor_tarihi = sb6.ToString();
                DateTime tempDate = Convert.ToDateTime(temp_rapor_tarihi);
                String rapor_tarihi = tempDate.ToString("dd.MM.yyyy");
     
          
                //MessageBox.Show(rapor_tarihi);
                //MessageBox.Show(rapor_kodu + " " + tespit + " " + banknot_cinsi + " " + banknot_adedi + " " + nominal_deger + " " + seri_sira_no + " " + rapor_tarihi, "Seçili Satır");

                Form3 stForm = new Form3();
                stForm.label9.Text = rapor_kodu.Trim();
                stForm.textBox1.Text = rapor_kodu.Trim();
                stForm.textBox2.Text = tespit.Trim();
                stForm.textBox3.Text = banknot_cinsi.Trim();
                stForm.textBox4.Text = banknot_adedi.Trim();
                stForm.textBox5.Text = nominal_deger.Trim();
                stForm.textBox6.Text = seri_sira_no.Trim();
                stForm.textBox7.Text = rapor_tarihi.Trim();
                if (stForm.ShowDialog() == DialogResult.OK) listeYenile();

            }

        }
        private void sil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                string rapor_kodu = dataGridView1.SelectedRows[0].Cells["Rapor Kodu"].Value.ToString();

                DialogResult dr = MessageBox.Show(
                    "Rapor kodu " + rapor_kodu + " olan kaydı veri tabanından silmek istediğinize emin misiniz?",
                    "Sahtecilik Projesi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    bool f_tamam = true;

                    try
                    {
                        SqlConnection baglanti = new SqlConnection("Server=localhost;Database=ProjectDB;Integrated Security=true;");
                        baglanti.Open();

                        SqlCommand komut = baglanti.CreateCommand();
                        komut.CommandType = CommandType.StoredProcedure;
                        komut.CommandText = "udp_Sahtecilik_Sil";
                        komut.Parameters.AddWithValue("@Rapor_Kodu", rapor_kodu);

                        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                        DataTable tablo = new DataTable();
                        adaptor.Fill(tablo);

                        if (tablo.Rows[0]["Sonuc"].ToString().Trim() != "0")
                        {
                            f_tamam = false;
                            MessageBox.Show(
                                tablo.Rows[0]["Mesaj"].ToString(),
                                "Sahtecilik Projesi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        baglanti.Close();
                    }
                    catch (Exception exp)
                    {
                        f_tamam = false;
                        MessageBox.Show(
                            "Sistemsel hata: " + exp.Message,
                            "Sahtecilik Projesi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    if (f_tamam)
                    {
                        listeYenile();

                        MessageBox.Show(
                            tablo.Rows[0]["Mesaj"].ToString(),
                            "Sahtecilik Projesi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
