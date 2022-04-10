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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }

        private void picCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_GunlukGider", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmGider_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_gunlukgider", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Gider";
            dataGridView1.Columns[2].HeaderText = "Açıklama";
            dataGridView1.Columns[3].HeaderText = "Tarih";
            dataGridView1.Columns[0].Visible = false;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into tbl_gunlukgider (Gider,Aciklama,Tarih) values (@k1,@k2,@k3)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@k1", txtGider.Text);
            ekle.Parameters.AddWithValue("@k2", richAciklama.Text);
            ekle.Parameters.AddWithValue("@k3", dateTarih.Text);
            ekle.ExecuteNonQuery();
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
            txtGider.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            richAciklama.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            dateTarih.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            SqlCommand duzenle = new SqlCommand("update tbl_gunlukgider set Gider=@p1,Aciklama=@p2,Tarih=@p3 where id=@p4", bgl.baglanti());
            duzenle.Parameters.AddWithValue("@p1", txtGider.Text);
            duzenle.Parameters.AddWithValue("@p2", richAciklama.Text);
            duzenle.Parameters.AddWithValue("@p3", dateTarih.Text);
            duzenle.Parameters.AddWithValue("@p4", txtid.Text);
            duzenle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("Delete from Tbl_gunlukgider where id=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Başarıyla Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("Select * From Tbl_gunlukgider where Tarih=@p1", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", dateTarih.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ara);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            MessageBox.Show("Arama başarıyla yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
