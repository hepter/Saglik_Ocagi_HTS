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
    public partial class IslemItem : UserControl
    {
        public delegate void islemHandler(islem i);
        public event islemHandler silBtnEvent;
        public islem ActiveIslem { get; }
        public islemler ActiveIslemler { get; }

        public IslemItem()
        {
            InitializeComponent();
        }
        public IslemItem(islemler islm):this()
        {
            ActiveIslem = islm.islem;
            ActiveIslemler = islm;
            materialLabel1.Text = islm.islem.islemadi;
            materialLabel2.Text = islm.islem.birimfiyat;
            materialLabel3.Text = islm.personel.birey.ad+" "+islm.personel.birey.soyad;
            materialLabel4.Text = islm.miktar.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            silBtnEvent(ActiveIslem);
        }
    }
}
