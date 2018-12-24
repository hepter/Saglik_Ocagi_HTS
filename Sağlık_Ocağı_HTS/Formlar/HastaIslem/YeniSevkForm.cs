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
        public hasta ActiveHasta { get; }
        private const string yeniStr = "Yeni Ekle...";
        private saglikDBEntities_1 db;
        public YeniSevkForm()
        {
            InitializeComponent();
            db= new saglikDBEntities_1();
        }

        public YeniSevkForm(hasta h):this()
        {
            ActiveHasta = h;

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
        void DrComboDoldur()
        {
            comboBox3.Items.Add(yeniStr);
            foreach (var item in db.doktor .Select(a=> new DrComboItem(){dr = a}).ToList())
            {
                comboBox3.Items.Add(item);
            }
            comboBox3.SelectedIndex = -1;
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
        public class DrComboItem
        {
            public doktor dr { get; set; }

            public override string ToString()
            {
                return $"{dr.doktorid} - Dr {dr.birey.ad}";
            }
        }


        private void YeniSevkForm_Load(object sender, EventArgs e)
        {

        }
        void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<SevkItem>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem islem =(comboBox1.SelectedItem as İşlemComboItem).islm;
            IslemItem item= new IslemItem(islem);
            flowLayoutPanel1.Controls.Add(item);

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }
    }
}
