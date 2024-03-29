﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Properties;

namespace Sağlık_Ocağı_HTS.Denetimler.AdminPanel
{
    public enum UserSeviye
    {
        User,
        Admin
    }

    public partial class User : UserControl
    {
        public delegate void AksiyonHandler(kullanicilar user);

        public User()
        {
            InitializeComponent();
            pictureBox1.Image = Resources.user;
            label4.Text = "User";
        }

        public User(kullanicilar kull, AksiyonHandler Sil, AksiyonHandler Detay, bool aktifKullaniciMi = false) : this()
        {
            this.aktifKullaniciMi = aktifKullaniciMi;
            switch ((UserSeviye) int.Parse(kull.yetki))
            {
                case UserSeviye.Admin:
                    pictureBox1.Image = Resources.admin;
                    break;
                case UserSeviye.User:
                    pictureBox1.Image = Resources.user;
                    break;
            }


            List<birey> bireyler = new saglikDBEntities_1().birey.ToList();
            birey birey = bireyler.First(a => a.tckimlikno == kull.tckimlikno);
            SilEvent = Sil;
            DetayEvent = Detay;
            EntityKullanici = kull;
            label4.Text = kull.username;
            materialLabel1.Text = birey.ad;
            materialLabel3.Text = birey.soyad;
            label5.Text = "Ünvan:" + kull.unvan;
            label1.Text = "USER ID:" + kull.id;
        }

        public kullanicilar EntityKullanici { get; }
        public bool aktifKullaniciMi { get; set; }
        public event AksiyonHandler SilEvent;
        public event AksiyonHandler DetayEvent;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 2;
            if (aktifKullaniciMi)
            {
                Color color = Color.MediumVioletRed;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, borderWidth, ButtonBorderStyle.Solid,
                    color, borderWidth, ButtonBorderStyle.Solid, color, borderWidth,
                    ButtonBorderStyle.Solid, color, borderWidth, ButtonBorderStyle.Solid);
            }
            else
            {
                Color color = Color.Green;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, borderWidth, ButtonBorderStyle.Solid,
                    color, borderWidth, ButtonBorderStyle.Solid, color, borderWidth,
                    ButtonBorderStyle.Solid, color, borderWidth, ButtonBorderStyle.Solid);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SilEvent(EntityKullanici);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetayEvent(EntityKullanici);
        }
    }
}