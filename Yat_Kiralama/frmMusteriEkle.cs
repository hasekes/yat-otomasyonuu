using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yat_Kiralama
{
    public partial class frmMusteriEkle : Form
    {
        Yat_Kiralama yat_kiralama = new Yat_Kiralama();
        public frmMusteriEkle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "insert into musteri_ekle(tcNo,ad,soyad,kullanıcıAdı,sifre,kayıttarihi, dogumTarihi, e_mail, telNo) values(@tcNo,@ad,@soyad,@kullanıcıAdı,@sifre,@kayıttarihi, @dogumTarihi,@e_mail, @telNo)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tcNo",textBox1.Text);
            komut2.Parameters.AddWithValue("@ad", textBox2.Text);
            komut2.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut2.Parameters.AddWithValue("@kullanıcıAdı", textBox4.Text);
            komut2.Parameters.AddWithValue("@sifre", textBox5.Text);
            komut2.Parameters.AddWithValue("@dogumTarihi", textBox6.Text);
            komut2.Parameters.AddWithValue("@e_mail", textBox7.Text);
            komut2.Parameters.AddWithValue("@telNo", textBox8.Text);
            komut2.Parameters.AddWithValue("@kayıttarihi", textBox9.Text);
            yat_kiralama.ekle_sil_güncelle(komut2,cumle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
