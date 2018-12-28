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
    public partial class IslemEkleForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        public IslemEkleForm()
        {
            InitializeComponent();
            db= new saglikDBEntities_1();
        }
        saglikDBEntities_1 db;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db= new saglikDBEntities_1();
            int test;
            if (!int.TryParse(materialSingleLineTextField2.Text,out test))
            {
                MessageBox.Show("Lütfen Geçerli bir ücret yazınız!","Geçersiz Rakamlar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            materialSingleLineTextField1.Text = materialSingleLineTextField1.Text.Trim();
            if (db.islem.Any(a=>a.islemadi == materialSingleLineTextField1.Text))
            {
                MessageBox.Show("Lütfen Öncekilerden Farklı bir isim belirtin","Geçersiz İsim",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            islem islem= new islem();
            islem.birimfiyat = test.ToString();
            islem.islemadi = materialSingleLineTextField1.Text;

            db.islem.Add(islem);
            db.SaveChanges();

            MessageBox.Show("İşlem Başarıyla Eklendi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
