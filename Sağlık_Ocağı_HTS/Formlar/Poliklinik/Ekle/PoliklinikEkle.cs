using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.Ekle.PoliKlinik;
using Sağlık_Ocağı_HTS.Formlar.Poliklinik;

namespace Sağlık_Ocağı_HTS.Formlar.Ekle
{
    public partial class PoliklinikEkle : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        private saglikDBEntities1 db;
        private int toplamControl = 0;
        public PoliklinikEkle()
        {
            db = new saglikDBEntities1();
            InitializeComponent();
        }

        private void EkleTemplate_Load(object sender, EventArgs e)
        {
            PoliklinikDoldur();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            if (toplamControl==1)
            {
                DüzenleButonAksiyon(flowLayoutPanel1.Controls.Cast<PoliklinikItem>().Single().activePoliklinik);
            }
            else if (toplamControl==0)
            {
                poliklinik poli= new poliklinik();
                poli.poliklinikadi = materialSingleLineTextField1.Text.Trim();
                PoliklinikGöster pGöster= new PoliklinikGöster(poli);
                pGöster.ShowDialog();
                db= new saglikDBEntities1();
                PoliklinikDoldur();
            }
        }

        private string aramaCacheStr="";
        void PoliklinikDoldur(string arananMetin)
        {
            aramaCacheStr = arananMetin;
            flowLayoutPanel1.Controls.Clear();
            toplamControl = 0;
            foreach (var entity in db.poliklinik.ToList())
            {
                if (string.IsNullOrWhiteSpace(aramaCacheStr) || entity.poliklinikadi.IndexOf(arananMetin,comparisonType:StringComparison.CurrentCultureIgnoreCase)!=-1)
                {
                    PoliklinikItem item= new PoliklinikItem(entity);
                    item.DüzenleEvent += DüzenleButonAksiyon;
                    item.SilEvent += SilButonAksiyon;
                    flowLayoutPanel1.Controls.Add(item);
                    toplamControl++;
                }
            }
            if (toplamControl==1)
            {
                flowLayoutPanel1.Controls.Cast<PoliklinikItem>().First().BackColor = Color.Plum;
            }

            if (toplamControl!=0)
            {
                ControlsYenidenBoyutla();
            }
        }

        void PoliklinikDoldur()
        {
            PoliklinikDoldur(aramaCacheStr);
        }

        private void DüzenleButonAksiyon(poliklinik poli)
        {
            PoliklinikGöster pgöster= new PoliklinikGöster(poli);
            pgöster.ShowDialog();
            db=new saglikDBEntities1();
          
        }

        private void SilButonAksiyon(poliklinik poli)
        {
            DialogResult res=  MessageBox.Show($"'{poli.poliklinikadi}' isimli Polikliniği silmek istediğinize Emin misiniz?","Siliniyor...",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (res==DialogResult.Yes)
            {
                db.poliklinik.Remove(poli);
                db=new saglikDBEntities1();
                PoliklinikDoldur();
            }

            MessageBox.Show($"Başarılı","Silindi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            PoliklinikDoldur(materialSingleLineTextField1.Text.Trim());
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();

        }

        void ControlsYenidenBoyutla()
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
