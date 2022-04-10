
namespace DosyaTakip
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.picCikis = new System.Windows.Forms.PictureBox();
            this.btnIsTuru = new System.Windows.Forms.Button();
            this.btnCalisan = new System.Windows.Forms.Button();
            this.btnGider = new System.Windows.Forms.Button();
            this.btnIsBolumu = new System.Windows.Forms.Button();
            this.btnAylikGider = new System.Windows.Forms.Button();
            this.btnFinansal = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCikis)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCikis
            // 
            this.picCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCikis.Image = ((System.Drawing.Image)(resources.GetObject("picCikis.Image")));
            this.picCikis.Location = new System.Drawing.Point(375, -1);
            this.picCikis.Name = "picCikis";
            this.picCikis.Size = new System.Drawing.Size(24, 22);
            this.picCikis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCikis.TabIndex = 27;
            this.picCikis.TabStop = false;
            this.picCikis.Click += new System.EventHandler(this.picCikis_Click);
            // 
            // btnIsTuru
            // 
            this.btnIsTuru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.btnIsTuru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsTuru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIsTuru.Location = new System.Drawing.Point(8, 177);
            this.btnIsTuru.Name = "btnIsTuru";
            this.btnIsTuru.Size = new System.Drawing.Size(186, 69);
            this.btnIsTuru.TabIndex = 22;
            this.btnIsTuru.Text = "İŞ TÜRÜ LİSTESİ";
            this.btnIsTuru.UseVisualStyleBackColor = false;
            this.btnIsTuru.Click += new System.EventHandler(this.btnIsTuru_Click);
            // 
            // btnCalisan
            // 
            this.btnCalisan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.btnCalisan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalisan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalisan.Location = new System.Drawing.Point(8, 102);
            this.btnCalisan.Name = "btnCalisan";
            this.btnCalisan.Size = new System.Drawing.Size(186, 69);
            this.btnCalisan.TabIndex = 20;
            this.btnCalisan.Text = "ÇALIŞAN LİSTESİ";
            this.btnCalisan.UseVisualStyleBackColor = false;
            this.btnCalisan.Click += new System.EventHandler(this.btnCalisan_Click);
            // 
            // btnGider
            // 
            this.btnGider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.btnGider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGider.Location = new System.Drawing.Point(200, 27);
            this.btnGider.Name = "btnGider";
            this.btnGider.Size = new System.Drawing.Size(186, 69);
            this.btnGider.TabIndex = 19;
            this.btnGider.Text = "GİDER EKLE";
            this.btnGider.UseVisualStyleBackColor = false;
            this.btnGider.Click += new System.EventHandler(this.btnGelir_Click);
            // 
            // btnIsBolumu
            // 
            this.btnIsBolumu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.btnIsBolumu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsBolumu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIsBolumu.Location = new System.Drawing.Point(8, 27);
            this.btnIsBolumu.Name = "btnIsBolumu";
            this.btnIsBolumu.Size = new System.Drawing.Size(186, 69);
            this.btnIsBolumu.TabIndex = 18;
            this.btnIsBolumu.Text = "İŞ TAKİP";
            this.btnIsBolumu.UseVisualStyleBackColor = false;
            this.btnIsBolumu.Click += new System.EventHandler(this.btnIsBolumu_Click);
            // 
            // btnAylikGider
            // 
            this.btnAylikGider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.btnAylikGider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAylikGider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAylikGider.Location = new System.Drawing.Point(200, 102);
            this.btnAylikGider.Name = "btnAylikGider";
            this.btnAylikGider.Size = new System.Drawing.Size(186, 69);
            this.btnAylikGider.TabIndex = 28;
            this.btnAylikGider.Text = "AYLIK GİDERLER";
            this.btnAylikGider.UseVisualStyleBackColor = false;
            this.btnAylikGider.Click += new System.EventHandler(this.btnGider_Click);
            // 
            // btnFinansal
            // 
            this.btnFinansal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.btnFinansal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinansal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinansal.Location = new System.Drawing.Point(200, 177);
            this.btnFinansal.Name = "btnFinansal";
            this.btnFinansal.Size = new System.Drawing.Size(186, 69);
            this.btnFinansal.TabIndex = 29;
            this.btnFinansal.Text = "FİNANSAL RAPOR";
            this.btnFinansal.UseVisualStyleBackColor = false;
            this.btnFinansal.Click += new System.EventHandler(this.btnFinansal_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(172)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(8, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 30);
            this.panel2.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(288, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Version 1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Desing by Furkan İSLAM";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(398, 293);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFinansal);
            this.Controls.Add(this.btnAylikGider);
            this.Controls.Add(this.picCikis);
            this.Controls.Add(this.btnIsTuru);
            this.Controls.Add(this.btnCalisan);
            this.Controls.Add(this.btnGider);
            this.Controls.Add(this.btnIsBolumu);
            this.Font = new System.Drawing.Font("Fira Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü";
            ((System.ComponentModel.ISupportInitialize)(this.picCikis)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCikis;
        private System.Windows.Forms.Button btnIsTuru;
        private System.Windows.Forms.Button btnCalisan;
        private System.Windows.Forms.Button btnGider;
        private System.Windows.Forms.Button btnIsBolumu;
        private System.Windows.Forms.Button btnAylikGider;
        private System.Windows.Forms.Button btnFinansal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}