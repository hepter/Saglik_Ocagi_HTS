using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.Ekle.PoliKlinik;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class DrVePersonelListeleForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {

        saglikDBEntities_1 db= new saglikDBEntities_1();
        private DrVePersonelEkleForm.EklemeTürü aktifTür;

        public DrVePersonelListeleForm(DrVePersonelEkleForm.EklemeTürü Tür)
        {
            aktifTür = Tür;      
            InitializeComponent();
            Yenile();
        }

        void Yenile()
        {
            switch (aktifTür)
            {
                case DrVePersonelEkleForm.EklemeTürü.Doktor:
                    groupBox1.Text = "Doktorlar";
                    DrEkle();
                    break;
                case DrVePersonelEkleForm.EklemeTürü.Personel:
                    groupBox1.Text = "Personeller";
                    PersonelEkle();
                    break;
            }
        }


        void ClickAksiyon(object o, EventArgs e)
        {
            foreach (var var in flowLayoutPanel1.Controls)
            {
                DrVePersonelItem item = (var as DrVePersonelItem);
                if (o.ToString()== item.activeTCNO)
                {
                    item.Kırmızı();
                }
                else
                {
                    item.Mavi();
                }
            }

        }


        void DrEkle()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var var in db.doktor)
            {
                DrVePersonelItem item= new DrVePersonelItem(var);
                item.SelectedAksiyon += ClickAksiyon;
                item.SilEvent += Sil;

                flowLayoutPanel1.Controls.Add(item);

            }
        }
        void PersonelEkle()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var var in db.personel)
            {
                DrVePersonelItem item= new DrVePersonelItem(var);
                item.SelectedAksiyon += ClickAksiyon;
                item.SilEvent += Sil;
                flowLayoutPanel1.Controls.Add(item);

            }
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            ControlsYenidenBoyutla();

        }

        void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
        
         
            foreach (var user in flowLayoutPanel1.Controls.Cast<DrVePersonelItem>())
                user.Width = flowLayoutPanel1.Width - 33;
            flowLayoutPanel1.ResumeLayout();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();
        }

        private void DrVePersonelListeleForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrVePersonelEkleForm form =new DrVePersonelEkleForm(aktifTür);
            if (form.ShowDialog()==DialogResult.OK)
            {
                Yenile();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {




        }

        void Sil(object o ,EventArgs e)
        {




            DialogResult res=   MessageBox.Show("Seçili Nesneyi silmek istediğinize Emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;
            var nesne = o as DrVePersonelItem;
            Int64 tcno = Int64.Parse(nesne.activeTCNO);

            if (db.sevk.Any(a=>a.doktor.tckimlikno==tcno) || db.islemler.Any(a=>a.personel.tckimlikno==tcno))
            {
                MessageBox.Show("Şu anda bu kişi kullanımda Silinemez!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            db = new saglikDBEntities_1();

            switch (aktifTür)
            {
                case DrVePersonelEkleForm.EklemeTürü.Doktor:
                    doktor dr = db.doktor.Where(a => a.tckimlikno == tcno).FirstOrDefault();
                    db.Entry(dr).State = EntityState.Deleted;

                    break;
                case DrVePersonelEkleForm.EklemeTürü.Personel:
                    personel persn = db.personel.Where(a => a.tckimlikno == tcno).FirstOrDefault();
                   
                    db.Entry(persn).State = EntityState.Deleted;
                    break;
            }

            db.SaveChanges();
            db= new saglikDBEntities_1();
            MessageBox.Show("Silme işlemi başarılı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Yenile();


        }
    }
}
