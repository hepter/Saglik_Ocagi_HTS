﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.Ekle.PoliKlinik;
using Sağlık_Ocağı_HTS.Formlar.Poliklinik;

namespace Sağlık_Ocağı_HTS.Formlar.Ekle
{
    public partial class PoliklinikEkleForm : DialogBox
    {
        private string aramaCacheStr = "";
        private saglikDBEntities_1 db;
        private int toplamControl;

        public PoliklinikEkleForm()
        {
            db = new saglikDBEntities_1();
            InitializeComponent();
        }

        private void EkleTemplate_Load(object sender, EventArgs e)
        {
            PoliklinikDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (toplamControl == 1)
            {
                DüzenleButonAksiyon(flowLayoutPanel1.Controls.Cast<PoliklinikItem>().Single().activePoliklinik);
            }
            else if (toplamControl == 0)
            {
                poliklinik poli = new poliklinik();
                poli.poliklinikadi = materialSingleLineTextField1.Text.Trim();
                PoliklinikGöster pGöster = new PoliklinikGöster(poli);
                if (pGöster.ShowDialog() == DialogResult.OK)
                {
                    db = new saglikDBEntities_1();
                    PoliklinikDoldur();
                }
            }
        }

        private void PoliklinikDoldur(string arananMetin)
        {
            flowLayoutPanel1.SuspendLayout();
            aramaCacheStr = arananMetin;
            flowLayoutPanel1.Controls.Clear();
            toplamControl = 0;
            foreach (var entity in db.poliklinik.ToList())
            {
                if (string.IsNullOrWhiteSpace(aramaCacheStr) ||
                    entity.poliklinikadi.IndexOf(arananMetin, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    PoliklinikItem item = new PoliklinikItem(entity);
                    item.DüzenleEvent += DüzenleButonAksiyon;
                    item.SilEvent += SilButonAksiyon;
                    flowLayoutPanel1.Controls.Add(item);
                    toplamControl++;
                }
            }

            if (toplamControl == 1)
            {
                flowLayoutPanel1.Controls.Cast<PoliklinikItem>().First().BackColor = Color.Plum;
            }

            flowLayoutPanel1.ResumeLayout();
            if (toplamControl != 0)
            {
                ControlsYenidenBoyutla();
            }
        }

        private void PoliklinikDoldur()
        {
            PoliklinikDoldur(aramaCacheStr);
        }

        private void DüzenleButonAksiyon(poliklinik poli)
        {
            PoliklinikGöster pgöster = new PoliklinikGöster(poli);
            if (DialogResult.OK == pgöster.ShowDialog())
            {
                db = new saglikDBEntities_1();
                PoliklinikDoldur();
            }
        }

        private void SilButonAksiyon(poliklinik poli)
        {
            DialogResult res =
                MessageBox.Show($"'{poli.poliklinikadi}' isimli Polikliniği silmek istediğinize Emin misiniz?",
                    "Siliniyor...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res != DialogResult.Yes)
                return;
            db = new saglikDBEntities_1();
            var sevkler = db.sevk.FirstOrDefault(a => a.poliklinik == poli.poliklinikadi);
            if (sevkler != null)
            {
                MessageBox.Show("Kullanımda olan bir poliklinik silinemez!\nÖmce bağlı olduğu sevk silinmesi gerekli!",
                    "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            poliklinik pol = new poliklinik {poliklinikadi = poli.poliklinikadi};
            db.poliklinik.Attach(pol);
            db.poliklinik.Remove(pol);

            db.SaveChanges();
            PoliklinikDoldur();
            MessageBox.Show("Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            PoliklinikDoldur(materialSingleLineTextField1.Text.Trim());
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();
        }

        private void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<PoliklinikItem>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
        }
    }
}