﻿using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Sağlık_Ocağı_HTS.Denetimler.AdminPanel;
using Sağlık_Ocağı_HTS.Formlar.Ekle;
using Sağlık_Ocağı_HTS.Formlar.HastaIslem;
using Sağlık_Ocağı_HTS.Properties;

namespace Sağlık_Ocağı_HTS
{
    public partial class MainForm : MaterialForm
    {
        private kullanicilar _aktifKullanici;
        private int aaa;

        private saglikDBEntities_1 db = new saglikDBEntities_1();
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private bool dragging;

        public EventHandler KapatEvent;

        public MainForm()
        {
            InitializeComponent();
            var db = new saglikDBEntities_1();
            var kull = db.kullanicilar.First(a => a.username == "hepter");
            db.Entry(kull).State = EntityState.Detached;
            aktifKullanici = kull;


            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Brown500, Primary.Brown700, Primary.LightBlue900,
                Accent.Green700, TextShade.WHITE);
        }

        public MainForm(kullanicilar kull) : this()
        {
            aktifKullanici = kull;
        }

        private kullanicilar aktifKullanici
        {
            get { return _aktifKullanici; }
            set
            {
                label1.Text = value.username;
                if (value.birey == null)
                {
                    var birey = db.birey.Where(a => a.tckimlikno == value.tckimlikno).First();
                    value.birey = birey;
                }

                label2.Text = value.birey.ad + " " + value.birey.soyad; //birey.ad + " "+ birey.soyad;
                pictureBox1.Image = value.yetki == "1" ? Resources.admin : Resources.user;
                _aktifKullanici = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem iss = new islem {birimfiyat = "500" + aaa, islemadi = "test" + ++aaa};


            db.islem.Add(iss);
            db.SaveChanges();

            MessageBox.Show(db.islem.Count().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HastaIslemPanel hastaIslemPanel =
                new HastaIslemPanel(tabloyuYazdırToolStripMenuItem, yazıcıÖnizlemeToolStripMenuItem);
            hastaIslemPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(hastaIslemPanel);
            // tabloyuYazdırToolStripMenuItem.Click += TabloyuYazdırToolStripMenuItemOnClick;
        }


        private void süzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Programı kapatmak istediğnize Emin misiniz?", "Uyarı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;
            Process.GetCurrentProcess().Kill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db = new saglikDBEntities_1();
            UserDetay detay = new UserDetay(db.kullanicilar.FirstOrDefault());
            detay.ShowDialog();
        }

        private void yöneticiPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelForm panel = new AdminPanelForm(aktifKullanici);
            if (panel.ShowDialog() == DialogResult.OK)
            {
                aktifKullanici = panel.aktifKullanici;
            }
        }

        private void poliklinikEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PoliklinikEkleForm ekleForm = new PoliklinikEkleForm();
            ekleForm.ShowDialog();
        }

        private void dosyaToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).ForeColor = Color.Black;
        }

        private void dosyaToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).ForeColor = Color.White;
        }

        private void doktorEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrVePersonelEkleForm form = new DrVePersonelEkleForm(DrVePersonelEkleForm.EklemeTürü.Doktor);
            form.ShowDialog();
        }

        private void oturumdanÇıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"'{aktifKullanici.username}'Kullanıcı hesabından çıkış yapılsın mı?",
                "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;
            KapatEvent(null, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void profilimiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetay form = new UserDetay(aktifKullanici);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                aktifKullanici = form.activeKullanici;
            }
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrVePersonelEkleForm form = new DrVePersonelEkleForm(DrVePersonelEkleForm.EklemeTürü.Personel);
            form.ShowDialog();
        }


        private void doktorYönetimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrVePersonelListeleForm form = new DrVePersonelListeleForm(DrVePersonelEkleForm.EklemeTürü.Doktor);
            form.ShowDialog();
        }

        private void personelYönetimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrVePersonelListeleForm form = new DrVePersonelListeleForm(DrVePersonelEkleForm.EklemeTürü.Personel);
            form.ShowDialog();
        }
    }
}