using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class Yeni_Hasta_Form : MaterialForm
    {
        public Yeni_Hasta_Form()
        {
            InitializeComponent();
        }

        public hasta ActiveHasta { get; set; }

        private void Yeni_Hasta_Form_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saglikDBEntities_1 db = new saglikDBEntities_1();
            if (!YıldızlılarDolumu())
            {
                MessageBox.Show("Lütfen Yıdızlı Kısımları Doldurup Tekrar Deneyin!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (db.hasta.Any(a => a.tckimlikno.ToString() == maskedTextBox4.Text.Trim()))
            {
                MessageBox.Show("Aynı Kimlik Numaralı hasta daha önce zaten eklenmiş!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DateTime aktifDosyaTarihi = DateTime.Now;
            birey birey = new birey();

            birey.tckimlikno = long.Parse(maskedTextBox4.Text);
            birey.ad = textBox5.Text;
            birey.soyad = textBox6.Text;
            birey.cinsiyet = comboBox2.SelectedIndex.ToString();
            birey.dtarihi = dateTimePicker1.Value;
            birey.evtel = maskedTextBox1.Text;
            birey.ceptel = maskedTextBox2.Text;
            birey.dogumyeri = textBox16.Text;
            birey.anneadi = textBox15.Text;
            birey.babaadi = textBox17.Text;
            birey.kangrubu = textBox18.Text;
            birey.medenihal = comboBox3.SelectedIndex.ToString();
            birey.adres = richTextBox1.Text;

            birey.hasta = new hasta();
            birey.hasta.tckimlikno = birey.tckimlikno;
            birey.hasta.kurumadi = textBox3.Text;
            birey.hasta.kurumsicilno = textBox2.Text;
            birey.hasta.yakinkurumadi = textBox4.Text;
            birey.hasta.yakinkurumsicilno = textBox11.Text;
            birey.hasta.yakintel = maskedTextBox3.Text;


            dosya dosya = new dosya();
            dosya.dosyatarihi = aktifDosyaTarihi;
            dosya.hastatckimlikno = birey.tckimlikno;

            birey.hasta.dosya = new List<dosya>();
            birey.hasta.dosya.Add(dosya);


            db.birey.AddOrUpdate(birey);
            db.SaveChanges();
            birey.hasta.dosyaID = dosya.dosyaid;
            db = new saglikDBEntities_1();
            db.hasta.AddOrUpdate(birey.hasta);
            db.SaveChanges();
            ActiveHasta = birey.hasta;
            MessageBox.Show("Hasta Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private bool YıldızlılarDolumu()
        {
            if (!maskedTextBox4.MaskCompleted ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                !maskedTextBox2.MaskCompleted ||
                !maskedTextBox3.MaskCompleted ||
                comboBox2.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();
            groupBox1.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}