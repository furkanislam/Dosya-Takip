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
    public partial class FrmIsler : Form
    {
        public FrmIsler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,IL,ILCE,MAHALLE,ADA,PARSEL,TUR,UCRET,ALINAN_UCRET,KALAN_UCRET,GELIS_TARIHI,BITIS_TARIHI,ACIKLAMA,DURUM From Tbl_Isler", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public string durum = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand kayit = new SqlCommand("insert into Tbl_Isler(IL,ILCE,MAHALLE,ADA,PARSEL,TUR,UCRET,ALINAN_UCRET,KALAN_UCRET,GELIS_TARIHI,BITIS_TARIHI,ACIKLAMA,DURUM) values(@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10,@k11,@k12,@k13)", bgl.baglanti());
            if (RadioDevam.Checked == true)
            {
                durum = "Devam Ediyor";
            }
            if (RadioTamam.Checked == true)
            {
                durum = "Tamamlandı";
            }
            double ucret = Convert.ToDouble(txtUcret.Text);
            double alinan = Convert.ToDouble(txtAlinan.Text);
            txtKalan.Text = Convert.ToString(ucret - alinan);
            kayit.Parameters.AddWithValue("@k1", txtIl.Text.ToUpper());
            kayit.Parameters.AddWithValue("@k2", txtIlce.Text.ToUpper());
            kayit.Parameters.AddWithValue("@k3", txtMahalle.Text.ToUpper());
            kayit.Parameters.AddWithValue("@k4", txtAda.Text);
            kayit.Parameters.AddWithValue("@k5", txtParsel.Text);
            kayit.Parameters.AddWithValue("@k6", cmbTur.Text);
            kayit.Parameters.AddWithValue("@k7", txtUcret.Text);
            kayit.Parameters.AddWithValue("@k8", txtAlinan.Text);
            kayit.Parameters.AddWithValue("@k9", txtKalan.Text);
            kayit.Parameters.AddWithValue("@k10", dateGelis.Text);
            kayit.Parameters.AddWithValue("@k11", dateBitis.Text);
            kayit.Parameters.AddWithValue("@k12", richTextBox1.Text);
            kayit.Parameters.AddWithValue("@k13", durum);
            kayit.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmIsler_Load(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select TUR From Tbl_Isturu", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbTur.Items.Add(dr1[0]);
            }
            listele();
            bgl.baglanti().Close();
            // DataGrid'e aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,IL,ILCE,MAHALLE,ADA,PARSEL,TUR,UCRET,ALINAN_UCRET,KALAN_UCRET,GELIS_TARIHI,BITIS_TARIHI,ACIKLAMA,DURUM From Tbl_Isler", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "İL";
            dataGridView1.Columns[2].HeaderText = "İLÇE";
            dataGridView1.Columns[3].HeaderText = "MAHALLE";
            dataGridView1.Columns[4].HeaderText = "ADA";
            dataGridView1.Columns[5].HeaderText = "PARSEL";
            dataGridView1.Columns[6].HeaderText = "İŞ TÜRÜ";
            dataGridView1.Columns[7].HeaderText = "İŞ ÜCRETİ";
            dataGridView1.Columns[8].HeaderText = "ALINAN ÜCRET";
            dataGridView1.Columns[9].HeaderText = "KALAN ÜCRET";
            dataGridView1.Columns[10].HeaderText = "İŞİN GELİŞ TARİHİ";
            dataGridView1.Columns[11].HeaderText = "İŞİN BİTİŞ TARİHİ";
            dataGridView1.Columns[12].HeaderText = "AÇIKLAMA";
            dataGridView1.Columns[13].HeaderText = "İŞ DURUMU";
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtIl.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtIlce.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtMahalle.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtAda.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtParsel.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            cmbTur.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtUcret.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtAlinan.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txtKalan.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            dateGelis.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            dateBitis.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[13].Value.ToString() == "Devam Ediyor")
            {
                RadioDevam.Checked = true;
            }
            if (dataGridView1.Rows[secilen].Cells[13].Value.ToString() == "Tamamlandı")
            {
                RadioTamam.Checked = true;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("Select * From Tbl_Isler where IL=@p1 or ILCE=@p2 or MAHALLE=@p3 or ADA=@p4 or PARSEL=@p5", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", txtIl.Text.ToUpper());
            ara.Parameters.AddWithValue("@p2", txtIlce.Text.ToUpper());
            ara.Parameters.AddWithValue("@p3", txtMahalle.Text.ToUpper());
            ara.Parameters.AddWithValue("@p4", txtAda.Text);
            ara.Parameters.AddWithValue("@p5", txtParsel.Text);
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
            SqlCommand duzenle = new SqlCommand("update Tbl_Isler set IL=@p1,ILCE=@p2,MAHALLE=@p3,ADA=@p4,PARSEL=@p5,TUR=@p6,UCRET=@p7,ALINAN_UCRET=@p8,KALAN_UCRET=@p9,GELIS_TARIHI=@p10,BITIS_TARIHI=@p11,ACIKLAMA=@p12,DURUM=@p13 where ID=@p14", bgl.baglanti());
            double ucret = Convert.ToDouble(txtUcret.Text);
            double alinan = Convert.ToDouble(txtAlinan.Text);
            txtKalan.Text = Convert.ToString(ucret - alinan);
            duzenle.Parameters.AddWithValue("@p1", txtIl.Text.ToUpper());
            duzenle.Parameters.AddWithValue("@p2", txtIlce.Text.ToUpper());
            duzenle.Parameters.AddWithValue("@p3", txtMahalle.Text.ToUpper());
            duzenle.Parameters.AddWithValue("@p4", txtAda.Text);
            duzenle.Parameters.AddWithValue("@p5", txtParsel.Text);
            duzenle.Parameters.AddWithValue("@p6", cmbTur.Text);
            duzenle.Parameters.AddWithValue("@p7", txtUcret.Text);
            duzenle.Parameters.AddWithValue("@p8", txtAlinan.Text);
            duzenle.Parameters.AddWithValue("@p9", txtKalan.Text);
            duzenle.Parameters.AddWithValue("@p10", dateGelis.Text);
            duzenle.Parameters.AddWithValue("@p11", dateBitis.Text);
            duzenle.Parameters.AddWithValue("@p12", richTextBox1.Text);
            if (RadioDevam.Checked == true)
            {
                duzenle.Parameters.AddWithValue("@p13", "Devam Ediyor");
            }
            if (RadioTamam.Checked == true)
            {
                duzenle.Parameters.AddWithValue("@p13", "Tamamlandı");
            }
            duzenle.Parameters.AddWithValue("@p14", txtID.Text);
            duzenle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("Delete from Tbl_Isler where ID=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtID.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Başarıyla Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void txtKalan_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
