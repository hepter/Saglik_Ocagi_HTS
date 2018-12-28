using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class DrVePersonelItem : UserControl
    {
        public event EventHandler SelectedAksiyon;
        public event EventHandler SilEvent;
        public string activeTCNO { get; set; }
        public bool Seçilimi { get; set; }

        public DrVePersonelItem()
        {
            InitializeComponent();
            Seçilimi = false;

        }

        public DrVePersonelItem(personel var) : this()
        {
            materialLabel3.Text = var.birey.ad+" "+ var.birey.soyad;
            materialLabel4.Text = var.birey.tckimlikno.ToString();
            pictureBox1.Image = Properties.Resources.person;
            activeTCNO = var.tckimlikno.ToString();
        }

        public DrVePersonelItem(doktor var) : this()
        {
            materialLabel3.Text = var.birey.ad+" "+ var.birey.soyad;
            materialLabel4.Text = var.birey.tckimlikno.ToString();
            pictureBox1.Image = Properties.Resources.person2;
            activeTCNO = var.tckimlikno.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectedAksiyon(activeTCNO, null);
        }

        Color color = Color.DodgerBlue;
        protected override void OnPaint(PaintEventArgs e)
        {
            //int borderWidth = 2;
              
            
            //ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, borderWidth, ButtonBorderStyle.Solid,
            //    color, borderWidth, ButtonBorderStyle.Solid, color, borderWidth,
            //    ButtonBorderStyle.Solid, color, borderWidth, ButtonBorderStyle.Solid);
        }

        public void Kırmızı()
        {
            Seçilimi = true;
            this.BackColor=Color.Beige;
            
            color = Color.Red;
        }
        public void Mavi()
        {
            Seçilimi = false;
            this.BackColor=Color.White;
            color = Color.DodgerBlue;
        }


        private void formActive(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.GradientActiveCaption;
        }

        private void formDeactive(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            if (Seçilimi)
            {
                this.BackColor=Color.Beige;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SilEvent(this, e);
        }
    }
}
