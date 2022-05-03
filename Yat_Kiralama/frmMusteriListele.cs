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
    public partial class frmMusteriListele : Form
    {
        Yat_Kiralama yatkiralama = new Yat_Kiralama();
        public frmMusteriListele()
        {
            InitializeComponent();
        }

        private void frmMusteriListele_Load(object sender, EventArgs e)
        {
            yenileListe();
        }

        private void yenileListe()
        {
            string cumle = "select *from musteri_ekle";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = yatkiralama.listele(adtr2, cumle);
            dataGridView1.Columns[0].HeaderText = "TC NO";
            dataGridView1.Columns[1].HeaderText = "ADI";
            dataGridView1.Columns[2].HeaderText = "SOYADI";
            dataGridView1.Columns[3].HeaderText = "KULLANICI ADI";
            dataGridView1.Columns[4].HeaderText = "ŞİFRE";
            dataGridView1.Columns[5].HeaderText = "DOĞUM TARİHİ";
            dataGridView1.Columns[6].HeaderText = "E-MAİL";
            dataGridView1.Columns[7].HeaderText = "TELEFON NO";
            dataGridView1.Columns[8].HeaderText = "KAYIR TARİHİ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cumle = "delete from musteri_ekle where tcNo='"+satır.Cells["tcNo"].Value.ToString()+"'";
            SqlCommand komut2 = new SqlCommand();
            yatkiralama.ekle_sil_güncelle(komut2, cumle);
            //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            yenileListe();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select *from musteri_ekle where tcNo like '%"+textBox10.Text+"%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            

            dataGridView1.DataSource = yatkiralama.listele(adtr2, cumle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            textBox1.Text = satır.Cells[0].Value.ToString();
            textBox2.Text = satır.Cells[1].Value.ToString();
            textBox3.Text = satır.Cells[2].Value.ToString();
            textBox4.Text = satır.Cells[3].Value.ToString();
            textBox5.Text = satır.Cells[4].Value.ToString();
            textBox6.Text = satır.Cells[5].Value.ToString();
            textBox7.Text = satır.Cells[6].Value.ToString();
            textBox8.Text = satır.Cells[7].Value.ToString();
            textBox9.Text = satır.Cells[8].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "update musteri_ekle set ad=@ad,soyad=@soyad,kullanıcıAdı=@kullanıcıAdı,sifre=@sifre,dogumTarihi=@dogumTarihi,e_mail=@e_mail,telNo=@telNo,kayıttarihi=@kayıttarihi where tcNo=@tcNo";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tcNo", textBox1.Text);
            komut2.Parameters.AddWithValue("@ad", textBox2.Text);
            komut2.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut2.Parameters.AddWithValue("@kullanıcıAdı", textBox4.Text);
            komut2.Parameters.AddWithValue("@sifre", textBox5.Text);
            komut2.Parameters.AddWithValue("@dogumTarihi", textBox6.Text);
            komut2.Parameters.AddWithValue("@e_mail", textBox7.Text);
            komut2.Parameters.AddWithValue("@telNo", textBox8.Text);
            komut2.Parameters.AddWithValue("@kayıttarihi", textBox9.Text);
            yatkiralama.ekle_sil_güncelle(komut2, cumle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            yenileListe();
        }
    }
}
