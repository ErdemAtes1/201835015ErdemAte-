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

namespace StokKayit_W22
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
         
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-67PAP58\\SQLEXPRESS; Initial Catalog=Stock3; Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;//kullanıcı adi
            string t2 = textBox2.Text;//şifre
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO giris (Ad,Sifre) VALUES ('"+t1+ "','" + t2 + "')", baglanti);
            MessageBox.Show("Kayıt İşlemi Tamamlandı.");
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();

        }
    }
}
