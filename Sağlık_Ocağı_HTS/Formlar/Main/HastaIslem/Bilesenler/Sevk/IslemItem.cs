using System;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class IslemItem : UserControl
    {
        public delegate void islemHandler(islem i);

        public IslemItem()
        {
            InitializeComponent();
        }

        public IslemItem(islemler islm) : this()
        {
            ActiveIslem = islm.islem;
            ActiveIslemler = islm;
            materialLabel1.Text = islm.islem.islemadi;
            materialLabel2.Text = islm.islem.birimfiyat;
            materialLabel3.Text = islm.personel.birey.ad + " " + islm.personel.birey.soyad;
            materialLabel4.Text = islm.miktar.ToString();
        }

        public islem ActiveIslem { get; }
        public islemler ActiveIslemler { get; }
        public event islemHandler silBtnEvent;

        private void button2_Click(object sender, EventArgs e)
        {
            silBtnEvent(ActiveIslem);
        }
    }
}