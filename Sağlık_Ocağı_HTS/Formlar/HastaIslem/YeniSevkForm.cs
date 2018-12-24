using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class YeniSevkForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        private saglikDBEntities_1 db;
        public YeniSevkForm()
        {
            InitializeComponent();
            db= new saglikDBEntities_1();
        }



        void PoliklinikComboDoldur()
        {
            foreach (var item in db.poliklinik.Select(a=> new PoliComboItem(){poliklinik = a}).ToList())
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = -1;
        }


        void İşlemComboDoldur()
        {
            foreach (var item in db.islem .Select(a=> new İşlemComboItem(){islm = a}).ToList())
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.SelectedIndex = -1;
        }
        public class PoliComboItem
        {
            public poliklinik poliklinik { get; set; }

            public override string ToString()
            {
                return poliklinik.poliklinikadi+"("+poliklinik.poliklinik_isim.isim+")";
            }
        }
        public class İşlemComboItem
        {
            public islem islm { get; set; }

            public override string ToString()
            {
                return islm.islemadi + $"({islm.birimfiyat}) TL";
            }
        }

        private void YeniSevkForm_Load(object sender, EventArgs e)
        {

        }
    }
}
