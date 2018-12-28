using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.Ekle;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class YeniSevkForm : DialogBox
    {
        private const string yeniStr = "Yeni Ekle...";
        private string aktifSaat;
        private DateTime aktifSevkTarihi;

        private saglikDBEntities_1 db;
        private bool DüzenlemeModu;
        private List<islemler> islemlerList = new List<islemler>();

        public YeniSevkForm()
        {
            InitializeComponent();
            db = new saglikDBEntities_1();
            aktifSevkTarihi = DateTime.Now;
            aktifSaat = aktifSevkTarihi.ToString("HH:mm:ss");

            PersonelComboDoldur();
            DrComboDoldur();
            PoliklinikComboDoldur();
            İşlemComboDoldur();
        }

        public YeniSevkForm(hasta h) : this() //yeni Kayıt
        {
            ActiveHasta = h;
            SevkİşlemControlsDoldur();
        }

        public YeniSevkForm(sevk s) : this() //Düzenleme
        {
            materialSingleLineTextField1.Text = s.sira;
            materialSingleLineTextField1.Enabled = false;
            ActiveSevk = s;

            ActiveHasta = db.sevk.ToList().Where(a => a.sevktarihi == s.sevktarihi).First().dosya.hasta;

            aktifSevkTarihi = s.sevktarihi;
            aktifSaat = aktifSevkTarihi.ToString("HH:mm:ss");

            SevkİşlemControlsDoldur();
            button2.Text = "Sevki Kaydet";
            DüzenlemeModu = true;
            SevktenPoliComboSec(s);
            SevktenDrComboSec(s);
        }

        public hasta ActiveHasta { get; set; }
        public sevk ActiveSevk { get; set; }


        private void YeniSevkForm_Load(object sender, EventArgs e)
        {
        }

        private void SevkİşlemControlsDoldur()
        {
            var islemlers = db.islemler.ToList().Where(a => a.sevktarihi == aktifSevkTarihi);
            if (islemlers == null || islemlers.Count() == 0)
                return;


            foreach (var islemler in islemlers)
            {
                IslemItem item = new IslemItem(islemler);
                item.silBtnEvent += IslemItemSilBtnAksiyon;
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void ControlsYenidenBoyutla()
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

        private void IslemItemSilBtnAksiyon(islem i)
        {
            DialogResult res = MessageBox.Show($"{i.islemadi} işlemini silmek istediğinize Emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;

            IslemItem silinecekitem = flowLayoutPanel1.Controls.Cast<IslemItem>()
                .Where(a => a.ActiveIslem.islemid == i.islemid).First();
            flowLayoutPanel1.Controls.Remove(silinecekitem);

            if (islemlerList.Contains(silinecekitem.ActiveIslemler))
            {
                islemlerList.Remove(silinecekitem.ActiveIslemler);
            }

            if (DüzenlemeModu)
            {
                db = new saglikDBEntities_1();
                islemler islm = db.islemler.ToList().Where(a => a.islemid == i.islemid).First();
                db.islemler.Remove(islm);
                db.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 || comboBox2.Items[comboBox2.SelectedIndex].ToString() == yeniStr)
            {
                MessageBox.Show("Lütfen İşlem Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox4.SelectedIndex == -1 || comboBox4.Items[comboBox4.SelectedIndex].ToString() == yeniStr)
            {
                MessageBox.Show("Lütfen Personel Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (flowLayoutPanel1.Controls.Cast<IslemItem>().Any(a =>
                a.ActiveIslem.islemid == (comboBox2.SelectedItem as İşlemComboItem).islm.islemid))
            {
                MessageBox.Show("Lütfen Aynı işlemi tekrar Eklemeyin!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            db = new saglikDBEntities_1();

            islem islem = (comboBox2.SelectedItem as İşlemComboItem).islm;


            //doktor dr =(comboBox3.SelectedItem as DrComboItem).dr;

            islemler islemler = new islemler();
            islemler.sevktarihi = aktifSevkTarihi;
            islemler.personelid = (comboBox4.SelectedItem as personel).personelid;
            islemler.miktar = (int) numericUpDown1.Value;
            islemler.islemid = islem.islemid;
            islemler.personel = comboBox4.SelectedItem as personel;
            islemler.islem = islem;

            islemlerList.Add(islemler);

            IslemItem item = new IslemItem(islemler);
            item.silBtnEvent += IslemItemSilBtnAksiyon;
            flowLayoutPanel1.Controls.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Kaydetmeniz için En az bir işlem eklemeniz gerekmektedir", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox1.Items[comboBox1.SelectedIndex].ToString() == yeniStr)
            {
                MessageBox.Show("Lütfen Poliklinik Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sıraNo;
            if (!int.TryParse(materialSingleLineTextField1.Text, out sıraNo) && sıraNo < 1)
            {
                MessageBox.Show("Geçerli bir Sıra numarası girin!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (comboBox3.SelectedIndex == -1 || comboBox3.Items[comboBox3.SelectedIndex].ToString() == yeniStr)
            {
                MessageBox.Show("Lütfen Doktor Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            doktor doktor = (comboBox3.SelectedItem as DrComboItem).dr;
            poliklinik poliklinik = (comboBox1.SelectedItem as PoliComboItem).poliklinik;

            db = new saglikDBEntities_1();
            if (!DüzenlemeModu)
            {
                sevk sevk = new sevk();
                sevk.poliklinik = poliklinik.poliklinikadi;
                sevk.sevktarihi = aktifSevkTarihi;
                sevk.saat = aktifSaat;
                sevk.sevkedendoktorid = doktor.doktorid;
                sevk.sira = sıraNo.ToString();
                sevk.dosyaid = ActiveHasta.dosyaID;

                sevk.taburcu = new taburcu();
                sevk.taburcu.taburcuoldumu = false;

                ActiveSevk = sevk;
                db.sevk.Add(sevk);
                db.SaveChanges();
            }


            db = new saglikDBEntities_1();
            foreach (var islems in islemlerList)
            {
                islems.sevktarihi = aktifSevkTarihi;

                islems.personel = null;
                islems.islem = null;

                db.islemler.AddOrUpdate(islems);
                db.SaveChanges();
            }


            MessageBox.Show($"Sevk başarıyla {(!DüzenlemeModu ? "oluşturuldu" : "kaydedildi")}!", "Başarılı",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void comboBox4_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.Value == yeniStr)
            {
                return;
            }

            var personel = e.ListItem as personel;

            e.Value = personel.birey.ad + " " + personel.birey.soyad;
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if (box.SelectedIndex != -1 && box.Items[box.SelectedIndex].ToString() == yeniStr)
            {
                DrVePersonelEkleForm form = new DrVePersonelEkleForm(DrVePersonelEkleForm.EklemeTürü.Personel);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db = new saglikDBEntities_1();
                    PersonelComboDoldur();
                }
            }
        }

        #region ComboboxFonksiyonlar Ve sınıfları

        private void SevktenPoliComboSec(sevk s)
        {
            for (int j = 0; j < comboBox1.Items.Count; j++)
            {
                if (comboBox1.Items[j] is PoliComboItem)
                {
                    var var = comboBox1.Items[j] as PoliComboItem;
                    if (var.poliklinik.poliklinikadi == s.poliklinik)
                    {
                        comboBox1.SelectedIndex = j;
                        comboBox1.Enabled = false;
                        break;
                    }
                }
            }
        }

        private void SevktenDrComboSec(sevk s)
        {
            for (int j = 0; j < comboBox3.Items.Count; j++)
            {
                if (comboBox3.Items[j] is DrComboItem)
                {
                    var var = comboBox3.Items[j] as DrComboItem;
                    if (var.dr.doktorid == s.sevkedendoktorid)
                    {
                        comboBox3.SelectedIndex = j;
                        comboBox3.Enabled = false;
                        break;
                    }
                }
            }
        }

        private void PoliklinikComboDoldur()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(yeniStr);
            if (db.poliklinik.Count() == 0)
                return;
            foreach (var item in db.poliklinik.Select(a => new PoliComboItem {poliklinik = a}).ToList())
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedIndex = -1;
        }


        private void İşlemComboDoldur()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add(yeniStr);
            if (db.islem.Count() == 0)
                return;
            foreach (var item in db.islem.Select(a => new İşlemComboItem {islm = a}).ToList())
            {
                comboBox2.Items.Add(item);
            }

            comboBox2.SelectedIndex = -1;
        }

        private void DrComboDoldur()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add(yeniStr);
            if (db.doktor.Count() == 0)
                return;
            foreach (var item in db.doktor.Select(a => new DrComboItem {dr = a}).ToList())
            {
                comboBox3.Items.Add(item);
            }

            comboBox3.SelectedIndex = -1;
        }

        private void PersonelComboDoldur()
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add(yeniStr);
            if (db.personel.Count() == 0)
                return;
            foreach (var item in db.personel)
            {
                comboBox4.Items.Add(item);
            }

            comboBox4.SelectedIndex = -1;
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

        #region Yeni işlem ekle Comboboxlar

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox box = comboBox1;
            if (box.SelectedIndex != -1 && box.Items[box.SelectedIndex].ToString() == yeniStr)
            {
                PoliklinikEkleForm ekleForm = new PoliklinikEkleForm();
                ekleForm.ShowDialog();
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
                DrVePersonelEkleForm form = new DrVePersonelEkleForm(DrVePersonelEkleForm.EklemeTürü.Doktor);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db = new saglikDBEntities_1();
                    DrComboDoldur();
                }
            }
        }

        #endregion
    }
}