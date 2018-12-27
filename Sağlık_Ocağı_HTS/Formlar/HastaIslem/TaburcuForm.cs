using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class TaburcuForm : Sağlık_Ocağı_HTS.Formlar.DialogBox
    {
        public sevk aktifSevk { get; set; }

        private int tutar = -1;
        private int toplamTutar
        {
            get
            {
                if (tutar==-1)
                {
                    tutar = 0;
                    foreach (var islem in db.islemler.ToList().Where(a=>a.sevktarihi==aktifSevk.sevktarihi))
                        tutar += (islem.miktar ?? 1) * int.Parse(islem.islem.birimfiyat);
                }
                return tutar;
            }
        }


        private bool taburcuOldumu
        {
            get { return aktifSevk.taburcu.taburcuoldumu; }
        }
        private saglikDBEntities_1 db= new saglikDBEntities_1();
        public TaburcuForm()
        {
            InitializeComponent();
        }
        public TaburcuForm(sevk s):this()
        {
            aktifSevk = s;
            comboDoldur();
            if (taburcuOldumu)
            {
                button3.Enabled = false;
            }


            textBox1.Text = s.dosyaid.ToString();
            textBox2.Text = s.doktor.birey.ad + " " + s.doktor.birey.soyad;
            textBox3.Text = s.sevktarihi.ToString("dd-MM-yyyy HH:mm:ss");
            textBox4.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            textBox5.Text = toplamTutar.ToString();

        }

        
        void comboDoldur()
        {
            foreach (odeme o in db.odeme)
                comboBox1.Items.Add(o);
            if (taburcuOldumu)
            {
                int i=0;
                foreach (var item in  comboBox1.Items)
                {
                    odeme o = item as odeme;
                    if (o.odemeid==aktifSevk.taburcu.odemeid)
                    {
                        comboBox1.SelectedIndex = i;
                        comboBox1.Enabled = false;
                        break;
                    }
                    i++;
                }
            }
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
           
                odeme o = e.ListItem as odeme;
                e.Value = o.yontemadi;
            
        }

        private void TaburcuForm_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"'{aktifSevk.dosya.hasta.birey.ad} {aktifSevk.dosya.hasta.birey.soyad}' isimli hastanın çıkışı yapılacak.Çıkışı yapılan hasta geri alınamaz\n\nDevam etmek istediğinize Emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;


           

            

            var taburcu = db.taburcu.Where(a => a.taburcuid == aktifSevk.taburcuid).First();
            taburcu.cikisSaati = DateTime.Now;
            taburcu.odemeid = ((odeme) comboBox1.SelectedItem).odemeid;
            taburcu.taburcuoldumu = true;
            taburcu.toplamtutar = toplamTutar.ToString();
            db.Entry(taburcu).State = EntityState.Modified;
            db.SaveChanges();


            DialogResult = DialogResult.OK;
            MessageBox.Show("Hasta Taburcu Edildi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
