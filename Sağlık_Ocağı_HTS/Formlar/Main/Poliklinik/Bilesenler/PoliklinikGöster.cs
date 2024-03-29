﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.Poliklinik
{
    public partial class PoliklinikGöster : DialogBox
    {
        private poliklinik activePoliklinik;
        private saglikDBEntities_1 db = new saglikDBEntities_1();
        private bool editMode;

        public PoliklinikGöster()
        {
            InitializeComponent();
        }

        public PoliklinikGöster(poliklinik poli) : this()
        {
            editMode = true;
            button1.Text = "Güncelle";
            richTextBox1.Text = poli.aciklama;
            materialSingleLineTextField1.Text = poli.poliklinikadi;
            activePoliklinik = poli;
            materialCheckBox1.Checked = (poli.durum ?? "0") == "1" ? true : false;
            if (poli.aciklama != null)
            {
                materialSingleLineTextField1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PoliklinikGöster_Load(object sender, EventArgs e)
        {
            PoliklinikComboDoldur();
            if (editMode)
            {
                int sayar = 0;
                foreach (var item in comboBox1.Items.Cast<PoliklinikComboItem>().Select(a => a.poliklinikİsim))
                {
                    if (item.id == activePoliklinik.bolumid)
                    {
                        comboBox1.SelectedIndex = sayar;
                        break;
                    }

                    sayar++;
                }
            }
        }

        private void PoliklinikComboDoldur()
        {
            foreach (var item in db.poliklinik_isim.Select(a => new PoliklinikComboItem {poliklinikİsim = a}).ToList())
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO Hata Muhtemel Kontrol
            poliklinik poli = new poliklinik();
            poli.aciklama = richTextBox1.Text;
            poli.bolumid = (comboBox1.SelectedItem as PoliklinikComboItem).poliklinikİsim.id;
            poli.poliklinikadi = materialSingleLineTextField1.Text;
            poli.durum = materialCheckBox1.Checked ? "1" : "0";

            db.poliklinik.AddOrUpdate(poli);
            db.SaveChanges();
            MessageBox.Show("İşlem Tamamlandı", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }


    public class PoliklinikComboItem
    {
        public poliklinik_isim poliklinikİsim { get; set; }

        public override string ToString()
        {
            return poliklinikİsim.isim;
        }
    }
}