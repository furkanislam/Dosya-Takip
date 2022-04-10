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
    public partial class FrmFinansalRapor : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmFinansalRapor()
        {
            InitializeComponent();
        }

        private void FrmFinansalRapor_Load(object sender, EventArgs e)
        {
            SqlCommand gunlukgider = new SqlCommand("select sum(gider) from Tbl_GunlukGider", bgl.baglanti());
            SqlDataReader dr = gunlukgider.ExecuteReader();
            if (dr.Read())
            {
                lbldeneme.Text = dr[0].ToString();
            }
            double gunlukgiderlbl = Convert.ToDouble(lbldeneme.Text);

            SqlCommand aylikgider = new SqlCommand("select sum(toplamgider) from Tbl_aylikgider", bgl.baglanti());
            SqlDataReader dr2 = aylikgider.ExecuteReader();
            if (dr2.Read())
            {
                label8.Text = dr2[0].ToString();
            }
            double aylikgiderlbl = Convert.ToDouble(label8.Text);
            lblToplamGider.Text = Convert.ToString(gunlukgiderlbl - aylikgiderlbl)+" TL";
            bgl.baglanti().Close();

            SqlCommand alinanucret = new SqlCommand("select sum(ALINAN_UCRET) from Tbl_Isler", bgl.baglanti());
            SqlDataReader dr3 = alinanucret.ExecuteReader();
            if (dr3.Read())
            {
                lblToplamGelir.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand kalanucret = new SqlCommand("select sum (KALAN_UCRET) from Tbl_Isler", bgl.baglanti());
            SqlDataReader dr4 = kalanucret.ExecuteReader();
            if (dr4.Read())
            {
                lblToplamAlacak.Text = dr4[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand calisansayisi = new SqlCommand("select count(*) from tbl_calisan", bgl.baglanti());
            SqlDataReader dr5 = calisansayisi.ExecuteReader();
            if (dr5.Read())
            {
                lblCalisanSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand devamedeis = new SqlCommand("select count(*) from Tbl_Isler where DURUM=@p1", bgl.baglanti());
            devamedeis.Parameters.AddWithValue("@p1", "Devam Ediyor");
            SqlDataReader dr6 = devamedeis.ExecuteReader();
            if (dr6.Read())
            {
                lblDevamEden.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand tamamlananis = new SqlCommand("select count(*) from Tbl_Isler where DURUM=@p1", bgl.baglanti());
            tamamlananis.Parameters.AddWithValue("@p1", "Tamamlandı");
            SqlDataReader dr7 = tamamlananis.ExecuteReader();
            if (dr7.Read())
            {
                lblTamamlanan.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand encokyapilanis = new SqlCommand("SELECT TOP 1 TUR FROM Tbl_Isler GROUP BY TUR ORDER BY COUNT(*) DESC", bgl.baglanti());
            SqlDataReader dr8 = encokyapilanis.ExecuteReader();
            if (dr8.Read())
            {
                lblEnCokis.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();


            SqlCommand iscesiti = new SqlCommand("select count(*) from Tbl_Isturu", bgl.baglanti());
            SqlDataReader dr9 = iscesiti.ExecuteReader();
            if (dr9.Read())
            {
                lbliscesiti.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
