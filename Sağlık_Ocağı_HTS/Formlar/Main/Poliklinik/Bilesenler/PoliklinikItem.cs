using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Denetimler.AdminPanel;

namespace Sağlık_Ocağı_HTS.Formlar.Ekle.PoliKlinik
{
    public partial class PoliklinikItem : UserControl
    {
        public delegate void PoliklinikItemHandler(poliklinik poli);
        public event PoliklinikItemHandler DüzenleEvent,SilEvent;
        public poliklinik activePoliklinik { get; }

        public PoliklinikItem()
        {
            InitializeComponent();
        }



        public PoliklinikItem(poliklinik poli):this()
        {
            materialLabel1.Text = poli.poliklinikadi;
            label1.Text = poli.poliklinik_isim.isim;
            activePoliklinik = poli;

        }
        private void PoliklinikItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DüzenleEvent(activePoliklinik);
        }

        private void formActive(object sender, EventArgs e)
        {
           this.BackColor = SystemColors.GradientActiveCaption;
        }

        private void formDeactive(object sender, EventArgs e)
        {
           this.BackColor = SystemColors.Control;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            SilEvent(activePoliklinik);
        }
    }
}
