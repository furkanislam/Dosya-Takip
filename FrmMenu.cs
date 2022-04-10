using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosyaTakip
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnIsBolumu_Click(object sender, EventArgs e)
        {
            FrmIsler fi = new FrmIsler();
            fi.Show();
        }

        private void btnGelir_Click(object sender, EventArgs e)
        {
            FrmGider fg = new FrmGider();
            fg.Show();
        }

        private void picCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalisan_Click(object sender, EventArgs e)
        {
            FrmCalisan fc = new FrmCalisan();
            fc.Show();
        }

        private void btnIsTuru_Click(object sender, EventArgs e)
        {
            FrmIsTuru fit = new FrmIsTuru();
            fit.Show();
        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            FrmAylikGider fg = new FrmAylikGider();
            fg.Show();
        }

        private void btnFinansal_Click(object sender, EventArgs e)
        {
            FrmFinansalRapor ffr = new FrmFinansalRapor();
            ffr.Show();
        }
    }
}
