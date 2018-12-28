using System;
using System.Drawing;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Properties;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class DrVePersonelItem : UserControl
    {
        public DrVePersonelItem()
        {
            InitializeComponent();
            Seçilimi = false;
        }

        public DrVePersonelItem(personel var) : this()
        {
            materialLabel3.Text = var.birey.ad + " " + var.birey.soyad;
            materialLabel4.Text = var.birey.tckimlikno.ToString();
            pictureBox1.Image = Resources.person2;
            activeTCNO = var.tckimlikno.ToString();
        }

        public DrVePersonelItem(doktor var) : this()
        {
            materialLabel3.Text = var.birey.ad + " " + var.birey.soyad;
            materialLabel4.Text = var.birey.tckimlikno.ToString();
            pictureBox1.Image = Resources.person;
            activeTCNO = var.tckimlikno.ToString();
        }

        public string activeTCNO { get; set; }
        public bool Seçilimi { get; set; }
        public event EventHandler SelectedAksiyon;
        public event EventHandler SilEvent;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectedAksiyon(activeTCNO, null);
        }


        public void Kırmızı()
        {
            Seçilimi = true;
            BackColor = Color.Beige;
        }

        public void Mavi()
        {
            Seçilimi = false;
            BackColor = Color.White;
        }


        private void formActive(object sender, EventArgs e)
        {
            BackColor = SystemColors.GradientActiveCaption;
        }

        private void formDeactive(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
            if (Seçilimi)
            {
                BackColor = Color.Beige;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SilEvent(this, e);
        }
    }
}