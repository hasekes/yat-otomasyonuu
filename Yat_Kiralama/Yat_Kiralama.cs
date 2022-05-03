using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Yat_Kiralama
{
    class Yat_Kiralama
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-46185O2\VT_SQL;Initial Catalog=Yat_Kiralama;Integrated Security=True");
        DataTable table;
        public void ekle_sil_güncelle(SqlCommand komut, String sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataTable listele(SqlDataAdapter adtr, string sorgu)
        {
            table = new DataTable();
            adtr = new SqlDataAdapter(sorgu, baglanti);
            adtr.Fill(table);
            baglanti.Close();
            return table;
        }

    }
}
