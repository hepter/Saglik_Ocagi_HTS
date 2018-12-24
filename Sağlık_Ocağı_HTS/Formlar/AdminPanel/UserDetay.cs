
using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Denetimler.AdminPanel
{
    public partial class UserDetay : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        private bool editMode;
        private int activeUserID;
        public UserDetay()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.user;
            button1.Focus();
            label12.Text = "YENİ";

        }

        public UserDetay(kullanicilar kull) : this()
        {
            birey birey  = new saglikDBEntities_1().birey.First(a=>a.tckimlikno==kull.tckimlikno);

            textBox2.Text=kull.username ;
            textBox3.Text=kull.sifre ;
            comboBox1.SelectedIndex = int.Parse(kull.yetki);
            textBox5.Text =birey.ad ;
            textBox6.Text=birey.soyad ;
            textBox1.Text=kull.tckimlikno.ToString() ;
            comboBox2.SelectedIndex = int.Parse(birey.cinsiyet);
            dateTimePicker1.Value =birey.dtarihi ?? DateTime.Now  ;
            dateTimePicker2.Value =kull.isebaslama ?? DateTime.Now  ;
            textBox11.Text =kull.unvan;
            maskedTextBox1.Text =birey.evtel ;
            maskedTextBox2.Text=birey.ceptel ;
            textBox16.Text= birey.dogumyeri ;
            textBox15.Text =birey.anneadi ;
            textBox17.Text =birey.babaadi ;
            textBox18.Text =birey.kangrubu ;
            comboBox3.SelectedIndex = int.Parse(birey.medenihal);
            textBox19.Text =kull.maas;
            richTextBox1.Text=birey.adres ;

            activeUserID = kull.id;
            label12.Text = activeUserID.ToString();
            editMode = true;
            button1.Text = "Değişiklikleri Kaydet";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saglikDBEntities_1 db = new saglikDBEntities_1();
            if (!YıldızlılarDolumu())
            {
                MessageBox.Show("Lütfen Yıdızlı Kısımları Doldurup Tekrar Deneyin!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
         

            var userCheck= new ObjectParameter("result",typeof(int));
            db.userCheck(textBox2.Text, userCheck);
            if ((bool)userCheck.Value && !editMode)
            {
                MessageBox.Show("Zaten Böyle Bir kullanıcı Adı mevcut!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            birey birey  = new birey();
            kullanicilar kull = new kullanicilar();
            kull.username = textBox2.Text ;
            kull.sifre = textBox3.Text ;
            kull.yetki = comboBox1.SelectedIndex.ToString();
            birey.ad =  textBox5.Text ;
            birey.soyad =  textBox6.Text ;
            kull.tckimlikno = int.Parse(textBox1.Text);
            birey.cinsiyet = comboBox2.SelectedIndex.ToString();
            birey.dtarihi = dateTimePicker1.Value   ;
            kull.isebaslama =  dateTimePicker2.Value ;
            kull.unvan = textBox11.Text ;
            birey.evtel  = maskedTextBox1.Text ;
            birey.ceptel = maskedTextBox2.Text ;
            birey.dogumyeri = textBox16.Text ;
            birey.anneadi = textBox15.Text ;
            birey.babaadi =  textBox17.Text ;
            birey.kangrubu = textBox18.Text  ;
            birey.medenihal = comboBox3.SelectedIndex.ToString();
            kull.maas = textBox19.Text;
            birey.adres  = richTextBox1.Text ;

            if (editMode)
            {
                 kull.id =activeUserID;
                 birey.tckimlikno = kull.tckimlikno;
                 //db.birey.AddOrUpdate(birey);
                 db.kullanicilar.AddOrUpdate(kull);
                 
            }
            else
            {
                  birey.tckimlikno = kull.tckimlikno;
                  db.birey.AddOrUpdate(birey);
                  db.kullanicilar.AddOrUpdate(kull);
            }
          
            
            db.SaveChanges();
            if (!editMode)
                MessageBox.Show("Kayıt Eklendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("Kayıt Güncellendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            Close();
        }



        bool YıldızlılarDolumu()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox11.Text) ||
                !maskedTextBox2.MaskCompleted ||
                comboBox1.SelectedIndex ==-1)
            {

                return false;
            }
            return true;
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();
            groupBox1.Width = flowLayoutPanel1.Width-30;
            flowLayoutPanel1.ResumeLayout();
        }

        private void UserDetay_Load(object sender, EventArgs e)
        {

        }
        #region Tab Label Sürüklenme

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void tabMove_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void tabMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void tabMove_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                pictureBox1.Image = Properties.Resources.user;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.admin;
            }
        }
    }
}
