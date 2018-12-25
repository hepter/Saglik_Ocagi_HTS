using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.Ekle;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class YeniSevkForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        public hasta ActiveHasta { get; }
        private const string yeniStr = "Yeni Ekle...";
        private DateTime aktifSevkTarihi;
        private string aktifSaat;
        private sevk aktifSevk= new sevk();

        private saglikDBEntities_1 db;
        public YeniSevkForm()
        {
            InitializeComponent();
            db= new saglikDBEntities_1();
            aktifSevkTarihi = DateTime.Now;
            aktifSaat = DateTime.Now.ToString("HH:mm:ss");
        }

        public YeniSevkForm(hasta h):this()
        {
            ActiveHasta = h;
           
            SevkİşlemControlsDoldur();
        }

        void PoliklinikComboDoldur()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(yeniStr);
            if (db.poliklinik.Count() == 0) 
                return;  
            foreach (var item in db.poliklinik.Select(a=> new PoliComboItem(){poliklinik = a}).ToList())
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = -1;
        }


        void İşlemComboDoldur()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add(yeniStr);
            if (db.islem.Count() == 0) 
                return;  
            foreach (var item in db.islem .Select(a=> new İşlemComboItem(){islm = a}).ToList())
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.SelectedIndex = -1;
        }
        void DrComboDoldur()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add(yeniStr);
            if (db.doktor.Count() == 0) 
                return;  
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

            DrComboDoldur();
            PoliklinikComboDoldur();
            İşlemComboDoldur();
          
        }

        void SevkİşlemControlsDoldur()
        {
            db.sevk.Find(aktifSevkTarihi);

            IslemItem item= new IslemItem(islem);
            flowLayoutPanel1.Controls.Add(item);



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
           
            if (comboBox1.SelectedIndex==-1 || comboBox1.Items[comboBox1.SelectedIndex].ToString()==yeniStr )
            {
                MessageBox.Show("Lütfen Poliklinik Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (comboBox2.SelectedIndex==-1 || comboBox2.Items[comboBox2.SelectedIndex].ToString()==yeniStr )
            {
                MessageBox.Show("Lütfen İşlem Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (comboBox3.SelectedIndex==-1 || comboBox3.Items[comboBox3.SelectedIndex].ToString()==yeniStr )
            {
                MessageBox.Show("Lütfen Doktor Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            

            islem islem =(comboBox2.SelectedItem as İşlemComboItem).islm;
            IslemItem item= new IslemItem(islem);
            flowLayoutPanel1.Controls.Add(item);

            islemler islemler= new islemler();
            islemler.sevktarihi = aktifSevkTarihi;
            islemler.islemid = islem.islemid;
            aktifSevk.islemler.Add(islemler);

        }

        #region Yeni işlem ekle Comboboxlar
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox box = comboBox1;
            if (box.SelectedIndex != -1 && box.Items[box.SelectedIndex].ToString() == yeniStr)
            {
                PoliklinikEkle ekle = new PoliklinikEkle();
                ekle.ShowDialog();
                db = new saglikDBEntities_1();
                PoliklinikComboDoldur();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox box = comboBox2;
            if (box.SelectedIndex != -1 && box.Items[box.SelectedIndex].ToString() == yeniStr)
            {
                IslemEkleForm form = new IslemEkleForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db = new saglikDBEntities_1();
                    İşlemComboDoldur();
                }
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox box = comboBox3;
            if (box.SelectedIndex != -1 && box.Items[box.SelectedIndex].ToString() == yeniStr)
            {

                DoktorEkleForm form = new DoktorEkleForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db = new saglikDBEntities_1();
                    DrComboDoldur();
                }

            }
        } 
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count==0)
            {
                MessageBox.Show("Kaydetmeniz için En az bir işlem eklemeniz gerekmektedir","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            int sıraNo;
            if (!int.TryParse(materialSingleLineTextField1.Text,out sıraNo) && sıraNo<1)
            {
                MessageBox.Show("Geçerli bir Sıra numarası girin!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            db= new saglikDBEntities_1();
            islem islem =(comboBox2.SelectedItem as İşlemComboItem).islm;
            IslemItem item= new IslemItem(islem);
            flowLayoutPanel1.Controls.Add(item);


            doktor doktor = (comboBox2.SelectedItem as DrComboItem).dr;
            poliklinik poliklinik = (comboBox2.SelectedItem as PoliComboItem).poliklinik;
            sevk sevk= new sevk();
            sevk.poliklinik1 = poliklinik;
            sevk.doktor = doktor;  
            sevk.sevktarihi = aktifSevkTarihi;
            sevk.saat = aktifSaat;
            sevk.sevkedendoktorid = doktor.doktorid;
            sevk.sira = sıraNo.ToString();

            taburcu taburcu= new taburcu();
            taburcu.taburcuoldumu = "0";
            sevk.taburcu = taburcu;
            sevk.islemler = aktifSevk.islemler;

            db.sevk.Add(sevk);
            db.SaveChanges();


        }
    }
}
