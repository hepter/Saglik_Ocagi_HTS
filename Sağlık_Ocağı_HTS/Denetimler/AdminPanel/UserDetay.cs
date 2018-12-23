using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            pictureBox1.Image = adminIcon.user;
            button1.Focus();
            label12.Text = "YENİ";

        }

        public UserDetay(kullanici kull) : this()
        {
            textBox2.Text=kull.username ;
            textBox3.Text=kull.sifre ;
            comboBox1.SelectedIndex = int.Parse(kull.yetki);
            textBox5.Text =kull.ad ;
            textBox6.Text=kull.soyad ;
            textBox1.Text=kull.tckimlikno ;
            comboBox2.SelectedIndex = int.Parse(kull.cinsiyet);
            dateTimePicker1.Value =kull.dogumtarihi ?? DateTime.Now  ;
            dateTimePicker2.Value =kull.isebaslama ?? DateTime.Now  ;
            textBox11.Text =kull.unvan;
            maskedTextBox1.Text =kull.evtel ;
            maskedTextBox2.Text=kull.ceptel ;
            textBox16.Text= kull.dogumyeri ;
            textBox15.Text =kull.anneadi ;
            textBox17.Text =kull.babaadi ;
            textBox18.Text =kull.kangrubu ;
            comboBox3.SelectedIndex = int.Parse(kull.medenihal);
            textBox19.Text =kull.maas;
            richTextBox1.Text=kull.adres ;

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

        }



        bool YıldızlılarDolumu()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
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


    }
}
