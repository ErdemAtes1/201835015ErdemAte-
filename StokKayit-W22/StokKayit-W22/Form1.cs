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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-67PAP58\\SQLEXPRESS; Initial Catalog=Stock3; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {//ekle
            String t1 = textBox1.Text; //mlzmKod
            String t2 = textBox2.Text; //malzemeAdi
            String t3 = textBox3.Text; //yillikSatis
            String t4 = textBox4.Text; //brmFyt
            String t5 = textBox5.Text; //minStock
            String t6 = textBox6.Text; //Tsure

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("INSERT INTO Malzemeler (MalzemeKodu, MalzemeAdi, YillikSatis, BirimFiyat, MinStok, TSuresi) VALUES('"+t1+ "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()//kayıtların görüntülenmesi
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Malzemeler",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {//DELETE
            String t1 = textBox1.Text; //seçilen satırın mlzm kdu
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('"+t1+"')",baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {//update
            String t1 = textBox1.Text; //mlzmKod
            String t2 = textBox2.Text; //malzemeAdi
            String t3 = textBox3.Text; //yillikSatis
            String t4 = textBox4.Text; //brmFyt
            String t5 = textBox5.Text; //minStock
            String t6 = textBox6.Text; //Tsure

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='"+t1+ "', MalzemeAdi='" + t2 + "',YillikSatis='" + t3 + "',BirimFiyat='" + t4 + "', MinStok='" + t5 + "', TSuresi='" + t6 + "' WHERE MalzemeKodu='"+t1+"'  ", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            listele();


        }
    }
}
