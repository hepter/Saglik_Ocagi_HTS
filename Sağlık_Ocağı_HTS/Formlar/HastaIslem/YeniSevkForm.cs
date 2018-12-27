using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.Ekle;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class YeniSevkForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        public hasta ActiveHasta { get;  set; }
        public sevk ActiveSevk { get; set; }
        private const string yeniStr = "Yeni Ekle...";
        private DateTime aktifSevkTarihi;
        private string aktifSaat;
        private List<islemler> islemlerList=new List<islemler>();
        private bool DüzenlemeModu;

        private saglikDBEntities_1 db;
        public YeniSevkForm()
        {
            InitializeComponent();
            db= new saglikDBEntities_1();
            aktifSevkTarihi = DateTime.Now;
            aktifSaat = aktifSevkTarihi.ToString("HH:mm:ss");
            
            DrComboDoldur();
            PoliklinikComboDoldur();
            İşlemComboDoldur();
        }

        public YeniSevkForm(hasta h):this()//yeni Kayıt
        {

            //todo aktifsevk tarih yap
            ActiveHasta = h;
           // aktifSevkTarihi=db.dosya.Where(a=>a.hastatckimlikno==h.tckimlikno).First().
            SevkİşlemControlsDoldur();
        }

        public YeniSevkForm(sevk s):this()//Düzenleme
        {
            materialSingleLineTextField1.Text = s.sira;
            ActiveSevk = s;

           // ActiveHasta = db.dosya.ToList().First(a =>a.dosyaid == db.sevkler.ToList().First(b =>b.sevktarihi == s.sevktarihi).dosyaID).hasta;
               
            ActiveHasta = db.sevk.Where(a => a.sevktarihi == s.sevktarihi).First().dosya.hasta;

            aktifSevkTarihi = s.sevktarihi;
            aktifSaat = aktifSevkTarihi.ToString("HH:mm:ss");

            SevkİşlemControlsDoldur();
            button2.Text = "Sevki Kaydet";
            DüzenlemeModu = true;
            SevktenPoliComboSec(s);
        }

        #region ComboboxFonksiyonlar Ve sınıfları
        void SevktenPoliComboSec(sevk s)
        {
            for (int j = 0; j < comboBox1.Items.Count; j++)
            {
                if (comboBox1.Items[j] is PoliComboItem)
                {
                    var var = comboBox1.Items[j] as PoliComboItem;
                    if (var.poliklinik.poliklinikadi == s.poliklinik)
                    {
                        comboBox1.SelectedIndex = j;
                        break;
                    }
                }
            }
        }
        void PoliklinikComboDoldur()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(yeniStr);
            if (db.poliklinik.Count() == 0)
                return;
            foreach (var item in db.poliklinik.Select(a => new PoliComboItem() { poliklinik = a }).ToList())
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
            foreach (var item in db.islem.Select(a => new İşlemComboItem() { islm = a }).ToList())
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
            foreach (var item in db.doktor.Select(a => new DrComboItem() { dr = a }).ToList())
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
                return poliklinik.poliklinikadi + "(" + poliklinik.poliklinik_isim.isim + ")";
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
        #endregion


        private void YeniSevkForm_Load(object sender, EventArgs e)
        {

        }

        void SevkİşlemControlsDoldur()
        {
            var islemlers =db.islemler.ToList().Where(a=>a.sevktarihi==aktifSevkTarihi);
            if (islemlers == null || islemlers.Count() == 0)
                return;


            foreach (var islemler in islemlers)
            {
                IslemItem item= new IslemItem(islemler.islem);
                item.silBtnEvent += IslemItemSilBtnAksiyon;
                flowLayoutPanel1.Controls.Add(item);
            }
        }
        void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<IslemItem>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            ControlsYenidenBoyutla();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();
        }

        void IslemItemSilBtnAksiyon(islem i)
        {
            DialogResult res=   MessageBox.Show($"{i.islemadi} işlemini silmek istediğinize Emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;

            db= new saglikDBEntities_1();
            islemler islm = db.islemler.ToList().Where(a => a.islemid == i.islemid).First();
            db.islemler.Remove(islm);
            db.SaveChanges();
            
            IslemItem silinecekitem = flowLayoutPanel1.Controls.Cast<IslemItem>()
                .Where(a => a.ActiveIslem.islemid == i.islemid).First();
            flowLayoutPanel1.Controls.Remove(silinecekitem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
         
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

            if (flowLayoutPanel1.Controls.Cast<IslemItem>().Any(a=>a.ActiveIslem.islemid==(comboBox2.SelectedItem as İşlemComboItem).islm.islemid)  )
            {
                MessageBox.Show("Lütfen Aynı işlemi tekrar Eklemeyin!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            db=new saglikDBEntities_1();
            
            islem islem =(comboBox2.SelectedItem as İşlemComboItem).islm;

            IslemItem item= new IslemItem(islem);
            item.silBtnEvent += IslemItemSilBtnAksiyon;
            flowLayoutPanel1.Controls.Add(item);

            
        
            doktor dr =(comboBox3.SelectedItem as DrComboItem).dr;

            islemler islemler= new islemler();
            islemler.sevktarihi = aktifSevkTarihi;
            islemler.doktorid = dr.doktorid;
            islemler.miktar = (int)numericUpDown1.Value;
            islemler.islemid = islem.islemid;
            islemlerList.Add(islemler);
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
            if (comboBox1.SelectedIndex==-1 || comboBox1.Items[comboBox1.SelectedIndex].ToString()==yeniStr )
            {
                MessageBox.Show("Lütfen Poliklinik Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            int sıraNo;
            if (!int.TryParse(materialSingleLineTextField1.Text,out sıraNo) && sıraNo<1)
            {
                MessageBox.Show("Geçerli bir Sıra numarası girin!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (comboBox3.SelectedIndex==-1 || comboBox3.Items[comboBox3.SelectedIndex].ToString()==yeniStr )
            {
                MessageBox.Show("Lütfen Doktor Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            doktor doktor = (comboBox3.SelectedItem as DrComboItem).dr;
            poliklinik poliklinik = (comboBox1.SelectedItem as PoliComboItem).poliklinik;

            db= new saglikDBEntities_1();
            if (!DüzenlemeModu)
            {
                sevk sevk= new sevk();
                sevk.poliklinik = poliklinik.poliklinikadi;
                sevk.sevktarihi = aktifSevkTarihi;
                sevk.saat = aktifSaat;
                sevk.sevkedendoktorid = doktor.doktorid;
                sevk.sira = sıraNo.ToString();
                sevk.dosyaid = ActiveHasta.dosyaID;

                sevk.taburcu=new taburcu();
                sevk.taburcu.taburcuoldumu =false;

                ActiveSevk = sevk;
                db.sevk.Add(sevk);
                db.SaveChanges();

         
            }
            else
            { 
               
              
                sevk sevk= db.sevk.Where(a=>ActiveSevk.sevktarihi==a.sevktarihi).FirstOrDefault();
                sevk.sevktarihi = aktifSevkTarihi;
                sevk.poliklinik =poliklinik.poliklinikadi;
                sevk.sira = sıraNo.ToString();
                db.Entry(sevk).State = EntityState.Modified;
                
                db.SaveChanges();
                db.Dispose();
            }
           


            db= new saglikDBEntities_1();
            foreach (var islems in islemlerList)
            {
                islems.sevktarihi = aktifSevkTarihi;
                db.islemler.AddOrUpdate(islems);
                db.SaveChanges();
            }

            
            MessageBox.Show($"Sevk başarıyla {((!DüzenlemeModu)?"oluşturuldu":"kaydedildi")}!","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;

        }
    }
}
