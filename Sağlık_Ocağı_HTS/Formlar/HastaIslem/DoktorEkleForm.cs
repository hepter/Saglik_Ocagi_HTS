using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class DoktorEkleForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        public DoktorEkleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saglikDBEntities_1 db = new saglikDBEntities_1();
            if (!YıldızlılarDolumu())
            {
                MessageBox.Show("Lütfen Yıdızlı Kısımları Doldurup Tekrar Deneyin!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (db.hasta.Any(a=>a.tckimlikno.ToString()==maskedTextBox3.Text.Trim()))
            {
                MessageBox.Show("Aynı Kimlik Numaralı hasta daha önce zaten eklenmiş!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }


            doktor doktor  = new doktor();

            doktor.tckimlikno= Int64.Parse(maskedTextBox3.Text);

            doktor.birey= new birey();
            doktor.birey.tckimlikno = Int64.Parse(maskedTextBox3.Text);
            doktor.birey.ad =  textBox5.Text ;
            doktor.birey.soyad =  textBox6.Text ;
            doktor.birey.cinsiyet = comboBox2.SelectedIndex.ToString();
            doktor.birey.dtarihi = dateTimePicker1.Value   ;
            doktor.birey.evtel  = maskedTextBox1.Text ;
            doktor.birey.ceptel = maskedTextBox2.Text ;
            doktor.birey.dogumyeri = textBox16.Text ;
            doktor.birey.anneadi = textBox15.Text ;
            doktor.birey.babaadi =  textBox17.Text ;
            doktor.birey.kangrubu = textBox18.Text  ;
            doktor.birey.medenihal = comboBox3.SelectedIndex.ToString();
            doktor.birey.adres  = richTextBox1.Text ;

            
            db.doktor.AddOrUpdate(doktor);
            db.SaveChanges();

            MessageBox.Show("Hasta Eklendi!","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;


        }
        bool YıldızlılarDolumu()
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
    }
}
