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

namespace DosyaTakip
{
    public partial class FrmCalisan : Form
    {
        public FrmCalisan()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_calisan", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public string durum = "";
        private void FrmCalisan_Load(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select (calisangorevleri) From Tbl_calisangorevleri", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbGorev.Items.Add(dr1[0]);
            }
            listele();
            bgl.baglanti().Close();
            // DataGrid'e aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_calisan", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ADI";
            dataGridView1.Columns[2].HeaderText = "SOYADI";
            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "GÖREVİ";
            dataGridView1.Columns[5].HeaderText = "TELEFON";
            dataGridView1.Columns[6].HeaderText = "İŞE BAŞLAMA TARİHİ";
            dataGridView1.Columns[7].HeaderText = "İŞTEN AYRILIŞ TARİHİ";
            dataGridView1.Columns[8].HeaderText = "TELEFON";
            dataGridView1.Columns[9].HeaderText = "ADRES";
            dataGridView1.Columns[10].HeaderText = "DURUM";
            dataGridView1.Columns[0].Visible = false;
        }

        private void picCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGorevEkle_Click(object sender, EventArgs e)
        {
            FrmCalisanGorevi fcg = new FrmCalisanGorevi();
            fcg.Show();
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand kayit = new SqlCommand("insert into Tbl_calisan (CalisanAdi,CalisanSoyadi,CalisanTC,CalisanGorevi,CalisanTelefon,CalisaniseBaslama,CalisanistenAyrilma,CalisanMaas,CalisanAdres,Durum) values (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10)", bgl.baglanti());
            if (radioCalisiyor.Checked == true)
            {
                durum = "Çalışıyor";
            }
            if (RadioCalismiyor.Checked == true)
            {
                durum = "Çalışmıyor";
            }
            kayit.Parameters.AddWithValue("@k1", txtAd.Text.ToUpper());
            kayit.Parameters.AddWithValue("@k2", txtSoyad.Text.ToUpper());
            kayit.Parameters.AddWithValue("@k3", mskTC.Text);
            kayit.Parameters.AddWithValue("@k4", cmbGorev.Text);
            kayit.Parameters.AddWithValue("@k5", mskTelefon.Text);
            kayit.Parameters.AddWithValue("@k6", dateBaslama.Text);
            kayit.Parameters.AddWithValue("@k7", dateBitis.Text);
            kayit.Parameters.AddWithValue("@k8", txtMaas.Text);
            kayit.Parameters.AddWithValue("@k9", richAdres.Text);
            kayit.Parameters.AddWithValue("@k10", durum);
            kayit.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbGorev.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskTelefon.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            dateBaslama.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            dateBitis.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            richAdres.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[10].Value.ToString() == "Çalışıyor")
            {
                radioCalisiyor.Checked = true;
            }
            if (dataGridView1.Rows[secilen].Cells[10].Value.ToString() == "Çalışmıyor")
            {
                RadioCalismiyor.Checked = true;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("Select * From Tbl_calisan where calisanadi=@p1 or calisansoyadi=@p2 or calisantc=@p3 or calisangorevi=@p4 or calisanmaas=@p5 or durum=@p6", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", txtAd.Text.ToUpper());
            ara.Parameters.AddWithValue("@p2", txtSoyad.Text.ToUpper());
            ara.Parameters.AddWithValue("@p3", mskTC.Text);
            ara.Parameters.AddWithValue("@p4", cmbGorev.Text);
            ara.Parameters.AddWithValue("@p5", txtMaas.Text);      
            if (radioCalisiyor.Checked==true)
            {
                durum = "Çalışıyor";
            }
            if (RadioCalismiyor.Checked==true)
            {
                durum = "Çalışmıyor";
            }
            ara.Parameters.AddWithValue("@p6", durum);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ara);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            MessageBox.Show("Arama başarıyla yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            SqlCommand duzenle = new SqlCommand("update Tbl_calisan set calisanadi=@p1,calisansoyadi=@p2,calisantc=@p3,calisangorevi=@p4,calisantelefon=@p5,calisanisebaslama=@p6,calisanistenayrilma=@p7,calisanmaas=@p8,calisanadres=@p9,durum=@p10 where id=@p11", bgl.baglanti());
            duzenle.Parameters.AddWithValue("@p1", txtAd.Text.ToUpper());
            duzenle.Parameters.AddWithValue("@p2", txtSoyad.Text.ToUpper());
            duzenle.Parameters.AddWithValue("@p3", mskTC.Text.ToUpper());
            duzenle.Parameters.AddWithValue("@p4", cmbGorev.Text);
            duzenle.Parameters.AddWithValue("@p5", mskTelefon.Text);
            duzenle.Parameters.AddWithValue("@p6", dateBaslama.Text);
            duzenle.Parameters.AddWithValue("@p7", dateBitis.Text);
            duzenle.Parameters.AddWithValue("@p8", txtMaas.Text);
            duzenle.Parameters.AddWithValue("@p9", richAdres.Text);
            if (radioCalisiyor.Checked == true)
            {
                duzenle.Parameters.AddWithValue("@p10", "Çalışıyor");
            }
            if (RadioCalismiyor.Checked == true)
            {
                duzenle.Parameters.AddWithValue("@p10", "Çalışmıyor");
            }
            duzenle.Parameters.AddWithValue("@p11", txtid.Text);
            duzenle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("Delete from Tbl_calisan where id=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Başarıyla Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void cmbGorev_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Select CalisanGorevleri From Tbl_CalisanGorevleri where id=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbGorev.Text);
            komut3.Parameters.AddWithValue("@p2", txtgorevid.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbGorev.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
