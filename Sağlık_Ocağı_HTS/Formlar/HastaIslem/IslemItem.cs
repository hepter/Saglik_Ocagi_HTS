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
        public islem ActiveIslem { get; }

        public IslemItem()
        {
            InitializeComponent();
        }
        public IslemItem(islem islm):this()
        {
            ActiveIslem = islm;
            materialLabel1.Text = islm.islemadi;
            materialLabel2.Text = islm.birimfiyat;

        }



    }
}
