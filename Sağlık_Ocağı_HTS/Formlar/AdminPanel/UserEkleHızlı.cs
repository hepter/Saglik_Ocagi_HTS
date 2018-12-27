using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar;

namespace Sağlık_Ocağı_HTS.Denetimler.AdminPanel
{
    public partial class UserAddDialog : DialogBox
    {
        public kullanicilar aktifKullanıcı { get; set; }

        public UserAddDialog()
        {
            InitializeComponent();
        }

        private void UserAddDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!maskedTextBox1.MaskCompleted || string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text)|| string.IsNullOrWhiteSpace(materialSingleLineTextField2.Text))
            {
                MessageBox.Show("Boş yerileri uygun şekilde doldurup tekrar deneyin!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            saglikDBEntities_1 db= new saglikDBEntities_1();
            kullanicilar kull= new kullanicilar();
            kull.tckimlikno = Int64.Parse(maskedTextBox1.Text);
            kull.username = materialSingleLineTextField1.Text;
            kull.sifre = materialSingleLineTextField2.Text;
            kull.yetki = "1";
            kull.birey= new birey();
            kull.birey.tckimlikno=Int64.Parse(maskedTextBox1.Text);
            db.kullanicilar.Add(kull);
            db.SaveChanges();
            db.Entry(kull).State = EntityState.Detached;
            aktifKullanıcı = kull;
            DialogResult = DialogResult.OK;
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
