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

namespace StokKayit_W22
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-67PAP58\\SQLEXPRESS; Initial Catalog=Stock3; Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "Select * from giris where Ad=@adi AND Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Form1 fr5 = new Form1();
                    fr5.Show();
                    this.Hide();
                    
                }
            }
            catch (Exception)
            {

                Form3 fr1 = new Form3();
                fr1.Show();
                this.Hide();
                                                    
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fr55 = new Form4();
            fr55.Show();
            this.Hide();
        }
    }
}
