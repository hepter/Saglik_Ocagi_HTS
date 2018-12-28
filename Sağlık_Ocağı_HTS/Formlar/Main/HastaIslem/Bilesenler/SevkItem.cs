using System;
using System.Drawing;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Properties;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class SevkItem : UserControl
    {
        public delegate void SevkAksiyonHandler(sevk sevk);
        private sevk ActiveSevk;


        public SevkItem()
        {
            InitializeComponent();
        }

        public SevkItem(sevk sevk) : this()
        {
            materialLabel1.Text = "  Tarih: " + sevk.sevktarihi.ToString("dd-MM-yyyy dddd");
            materialLabel2.Text = "Bölüm: " + sevk.poliklinik1.poliklinik_isim.isim;
            materialLabel3.Text = "Doktor: " + sevk.doktor.birey.ad + " " + sevk.doktor.birey.soyad;
            pictureBox1.Image = sevk.taburcu.taburcuoldumu ? Resources.taburcu2 : Resources.taburcu;
            ActiveSevk = sevk;
        }

        public event SevkAksiyonHandler GörüntüleEvent;
        public event SevkAksiyonHandler DüzenleEvent;
        public event SevkAksiyonHandler TaburcuEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            GörüntüleEvent(ActiveSevk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DüzenleEvent(ActiveSevk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaburcuEvent(ActiveSevk);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int borderWidth = 2;

            Color color = Color.DodgerBlue;
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, borderWidth, ButtonBorderStyle.Solid,
                color, borderWidth, ButtonBorderStyle.Solid, color, borderWidth,
                ButtonBorderStyle.Solid, color, borderWidth, ButtonBorderStyle.Solid);
        }
    }
}