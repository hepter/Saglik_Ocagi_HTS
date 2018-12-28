using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class DrVePersonelEkleForm : DialogBox
    {
        public enum EklemeTürü
        {
            Doktor,
            Personel
        }

        public string ActiveString;

        public DrVePersonelEkleForm(EklemeTürü tür)
        {
            InitializeComponent();
            activeEklemeTürü = tür;
            switch (tür)
            {
                case EklemeTürü.Doktor:
                    ActiveString = "Doktor";
                    break;
                case EklemeTürü.Personel:
                    ActiveString = "Personel";
                    break;
            }

            button1.Text = string.Format("Yeni {0} Ekle", ActiveString);
        }

        public EklemeTürü activeEklemeTürü { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            saglikDBEntities_1 db = new saglikDBEntities_1();
            if (!YıldızlılarDolumu())
            {
                MessageBox.Show("Lütfen Yıdızlı Kısımları Doldurup Tekrar Deneyin!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (db.hasta.Any(a => a.tckimlikno.ToString() == maskedTextBox3.Text.Trim()))
            {
                MessageBox.Show("Aynı Kimlik Numaralı hasta daha önce zaten eklenmiş!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            //TODO  Tekrarı düzelt
            switch (activeEklemeTürü)
            {
                case EklemeTürü.Doktor:
                    var entity = new doktor();
                    entity.tckimlikno = long.Parse(maskedTextBox3.Text);
                    entity.birey = new birey();
                    entity.birey.tckimlikno = long.Parse(maskedTextBox3.Text);
                    entity.birey.ad = textBox5.Text;
                    entity.birey.soyad = textBox6.Text;
                    entity.birey.cinsiyet = comboBox2.SelectedIndex.ToString();
                    entity.birey.dtarihi = dateTimePicker1.Value;
                    entity.birey.evtel = maskedTextBox1.Text;
                    entity.birey.ceptel = maskedTextBox2.Text;
                    entity.birey.dogumyeri = textBox16.Text;
                    entity.birey.anneadi = textBox15.Text;
                    entity.birey.babaadi = textBox17.Text;
                    entity.birey.kangrubu = textBox18.Text;
                    entity.birey.medenihal = comboBox3.SelectedIndex.ToString();
                    entity.birey.adres = richTextBox1.Text;
                    db.doktor.AddOrUpdate(entity);
                    db.SaveChanges();
                    break;
                case EklemeTürü.Personel:
                    var entity2 = new personel();
                    entity2.tckimlikno = long.Parse(maskedTextBox3.Text);
                    entity2.birey = new birey();
                    entity2.birey.tckimlikno = long.Parse(maskedTextBox3.Text);
                    entity2.birey.ad = textBox5.Text;
                    entity2.birey.soyad = textBox6.Text;
                    entity2.birey.cinsiyet = comboBox2.SelectedIndex.ToString();
                    entity2.birey.dtarihi = dateTimePicker1.Value;
                    entity2.birey.evtel = maskedTextBox1.Text;
                    entity2.birey.ceptel = maskedTextBox2.Text;
                    entity2.birey.dogumyeri = textBox16.Text;
                    entity2.birey.anneadi = textBox15.Text;
                    entity2.birey.babaadi = textBox17.Text;
                    entity2.birey.kangrubu = textBox18.Text;
                    entity2.birey.medenihal = comboBox3.SelectedIndex.ToString();
                    entity2.birey.adres = richTextBox1.Text;
                    db.personel.AddOrUpdate(entity2);
                    db.SaveChanges();
                    break;
            }


            MessageBox.Show($"{ActiveString} Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private bool YıldızlılarDolumu()
        {
            if (!maskedTextBox3.MaskCompleted ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                !maskedTextBox2.MaskCompleted)
            {
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoktorEkleForm_Load(object sender, EventArgs e)
        {
        }
    }
}