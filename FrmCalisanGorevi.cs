﻿using System;
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
    public partial class FrmCalisanGorevi : Form
    {
        public FrmCalisanGorevi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_calisanGorevleri", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmCalisanGorevi_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_calisangorevleri", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "GÖREV";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into Tbl_calisanGorevleri (calisanGorevleri) values (@p1)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", txtisAdi.Text);
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
            txtisAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            SqlCommand duzenle = new SqlCommand("update tbl_calisangorevleri set CalisanGorevleri=@p1 where id=@p2", bgl.baglanti());
            duzenle.Parameters.AddWithValue("@p1", txtisAdi.Text);
            duzenle.Parameters.AddWithValue("@p2", txtid.Text);
            duzenle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("Delete from Tbl_CalisanGorevleri where id=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Başarıyla Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmCalisan deneme = new FrmCalisan();
            deneme.Show();
        }
    }
}
