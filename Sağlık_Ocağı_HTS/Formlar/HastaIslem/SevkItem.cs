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
    public partial class SevkItem : UserControl
    {
        public delegate void SevkAksiyonHandler(sevk sevk);
        public event SevkAksiyonHandler GörüntüleEvent;
        public event SevkAksiyonHandler DüzenleEvent;
        private sevk ActiveSevk;
      

        public SevkItem()
        {
            InitializeComponent();
        }

        public SevkItem(sevk sevk) : this()
        {
            materialLabel2.Text = sevk.sevktarihi.ToString("dd-MM-yyyy dddd");
            materialLabel4.Text = sevk.doktor.birey.ad;
            label1.Text = (sevk.taburcu.taburcuoldumu == "1") ? "TABURCU" : "TABURCU DEĞİL";
          
            ActiveSevk = sevk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GörüntüleEvent(ActiveSevk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DüzenleEvent(ActiveSevk);
        }
    }
}
