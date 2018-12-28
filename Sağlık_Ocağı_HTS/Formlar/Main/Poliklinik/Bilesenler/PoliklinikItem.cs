using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.Ekle.PoliKlinik
{
    public partial class PoliklinikItem : UserControl
    {
        public delegate void PoliklinikItemHandler(poliklinik poli);

        public PoliklinikItem()
        {
            InitializeComponent();
        }


        public PoliklinikItem(poliklinik poli) : this()
        {
            materialLabel1.Text = poli.poliklinikadi;
            label1.Text = poli.poliklinik_isim.isim;
            activePoliklinik = poli;
        }

        public poliklinik activePoliklinik { get; }
        public event PoliklinikItemHandler DüzenleEvent, SilEvent;

        private void PoliklinikItem_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DüzenleEvent(activePoliklinik);
        }

        private void formActive(object sender, EventArgs e)
        {
            BackColor = SystemColors.GradientActiveCaption;
        }

        private void formDeactive(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SilEvent(activePoliklinik);
        }
    }
}