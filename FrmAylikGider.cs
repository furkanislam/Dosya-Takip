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
    public partial class FrmAylikGider : Form
    {
        public FrmAylikGider()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_AylikGider", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void picCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAylikGider_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_AylikGider", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Kira";
            dataGridView1.Columns[2].HeaderText = "Bağkur-Ssk";
            dataGridView1.Columns[3].HeaderText = "Muhasebe";
            dataGridView1.Columns[4].HeaderText = "Vergiler";
            dataGridView1.Columns[5].HeaderText = "Yakıt";
            dataGridView1.Columns[6].HeaderText = "Diğer Giderler";
            dataGridView1.Columns[7].HeaderText = "Elektrik";
            dataGridView1.Columns[8].HeaderText = "Doğalgaz";
            dataGridView1.Columns[9].HeaderText = "Su";
            dataGridView1.Columns[10].HeaderText = "İnternet";
            dataGridView1.Columns[11].HeaderText = "Telefon";
            dataGridView1.Columns[12].HeaderText = "Çalışan Maaşları";
            dataGridView1.Columns[13].HeaderText = "Tarih";
            dataGridView1.Columns[14].HeaderText = "Toplam Aylık Gider";
            dataGridView1.Columns[15].HeaderText = "Açıklama";
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into tbl_aylikgider (Kira,Bagkur,Muhasebe,Vergi,Yakit,Diger,Elektrik,Dogalgaz,Su,Internet,Telefon,Calisan,Tarih,ToplamGider,Aciklama) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)", bgl.baglanti());
            double kira = Convert.ToDouble(txtKira.Text);
            double bagkur = Convert.ToDouble(txtBagkur.Text);
            double muhasebe = Convert.ToDouble(txtMuhasebe.Text);
            double vergi = Convert.ToDouble(txtVergi.Text);
            double yakit = Convert.ToDouble(txtYakit.Text);
            double diger = Convert.ToDouble(txtDiger.Text);
            double elektrik = Convert.ToDouble(txtElektrik.Text);
            double dogalgaz = Convert.ToDouble(txtDogalgaz.Text);
            double su = Convert.ToDouble(txtSu.Text);
            double internet = Convert.ToDouble(txtInternet.Text);
            double telefon = Convert.ToDouble(txtTelefon.Text);
            double calisan = Convert.ToDouble(txtCalisan.Text);
            txtToplam.Text = Convert.ToString(kira + bagkur + muhasebe + vergi + yakit + diger + elektrik + dogalgaz + su + internet + telefon + calisan);
            ekle.Parameters.AddWithValue("@p1", txtKira.Text);
            ekle.Parameters.AddWithValue("@p2", txtBagkur.Text);
            ekle.Parameters.AddWithValue("@p3", txtMuhasebe.Text);
            ekle.Parameters.AddWithValue("@p4", txtVergi.Text);
            ekle.Parameters.AddWithValue("@p5", txtYakit.Text);
            ekle.Parameters.AddWithValue("@p6", txtDiger.Text);     
            ekle.Parameters.AddWithValue("@p7", txtElektrik.Text);
            ekle.Parameters.AddWithValue("@p8", txtDogalgaz.Text);
            ekle.Parameters.AddWithValue("@p9", txtSu.Text);
            ekle.Parameters.AddWithValue("@p10", txtInternet.Text);
            ekle.Parameters.AddWithValue("@p11", txtTelefon.Text);
            ekle.Parameters.AddWithValue("@p12", txtCalisan.Text);
            ekle.Parameters.AddWithValue("@p13", dateTarih.Text);
            ekle.Parameters.AddWithValue("@p14", txtToplam.Text);
            ekle.Parameters.AddWithValue("@p15", richAciklama.Text);
            ekle.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKira.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtBagkur.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtMuhasebe.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtVergi.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtYakit.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtDiger.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtElektrik.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtDogalgaz.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txtSu.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            txtInternet.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            txtTelefon.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            txtCalisan.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            dateTarih.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            txtToplam.Text = dataGridView1.Rows[secilen].Cells[14].Value.ToString();
            richAciklama.Text = dataGridView1.Rows[secilen].Cells[15].Value.ToString();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("Select * From Tbl_AylikGider where Tarih=@p1", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", dateTarih.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ara);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            MessageBox.Show("Arama başarıyla yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            SqlCommand duzenle = new SqlCommand("update tbl_aylikgider set Kira=@p1,Bagkur=@p2,Muhasebe=@p3,Vergi=@p4,Yakit=@p5,Diger=@p6,Elektrik=@p7,Dogalgaz=@p8,Su=@p9,Internet=@p10,Telefon=@p11,Calisan=@p12,Tarih=@p13,ToplamGider=@p14,Aciklama=@p15 where id=@p16", bgl.baglanti());
            double kira = Convert.ToDouble(txtKira.Text);
            double bagkur = Convert.ToDouble(txtBagkur.Text);
            double muhasebe = Convert.ToDouble(txtMuhasebe.Text);
            double vergi = Convert.ToDouble(txtVergi.Text);
            double yakit = Convert.ToDouble(txtYakit.Text);
            double diger = Convert.ToDouble(txtDiger.Text);
            double elektrik = Convert.ToDouble(txtElektrik.Text);
            double dogalgaz = Convert.ToDouble(txtDogalgaz.Text);
            double su = Convert.ToDouble(txtSu.Text);
            double internet = Convert.ToDouble(txtInternet.Text);
            double telefon = Convert.ToDouble(txtTelefon.Text);
            double calisan = Convert.ToDouble(txtCalisan.Text);
            txtToplam.Text = Convert.ToString(kira + bagkur + muhasebe + vergi + yakit + diger + elektrik + dogalgaz + su + internet + telefon + calisan);
            duzenle.Parameters.AddWithValue("@p1", txtKira.Text);
            duzenle.Parameters.AddWithValue("@p2", txtBagkur.Text);
            duzenle.Parameters.AddWithValue("@p3", txtMuhasebe.Text);
            duzenle.Parameters.AddWithValue("@p4", txtVergi.Text);
            duzenle.Parameters.AddWithValue("@p5", txtYakit.Text);
            duzenle.Parameters.AddWithValue("@p6", txtDiger.Text);
            duzenle.Parameters.AddWithValue("@p7", txtElektrik.Text);
            duzenle.Parameters.AddWithValue("@p8", txtDogalgaz.Text);
            duzenle.Parameters.AddWithValue("@p9", txtSu.Text);
            duzenle.Parameters.AddWithValue("@p10", txtInternet.Text);
            duzenle.Parameters.AddWithValue("@p11", txtTelefon.Text);
            duzenle.Parameters.AddWithValue("@p12", txtCalisan.Text);
            duzenle.Parameters.AddWithValue("@p13", dateTarih.Text);
            duzenle.Parameters.AddWithValue("@p14", txtToplam.Text);
            duzenle.Parameters.AddWithValue("@p15", richAciklama.Text);
            duzenle.Parameters.AddWithValue("@p16", txtid.Text);
            duzenle.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla gücellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("Delete from Tbl_aylikgider where id=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Başarıyla Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }
    }
}
