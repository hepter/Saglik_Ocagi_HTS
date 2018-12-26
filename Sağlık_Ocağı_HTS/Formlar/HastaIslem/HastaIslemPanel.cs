using System;

using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class HastaIslemPanel : UserControl
    {
        private int sağClickRowSıra = -1;
        private saglikDBEntities_1 db;
        public hasta ActiveHasta { get; set; }
        public sevk ActiveSevk { get; set; }
       // public List<sevkler> ActiveSevkler { get; set; }
        public List<islemler> ActiveIslemler { get; set; }
        public HastaIslemPanel()
        {
            InitializeComponent();
           // ActiveSevkler =  new List<sevkler>();
            ActiveIslemler =new List<islemler>();
        }


        private void materialSingleLineTextField1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && materialSingleLineTextField1.Text.Trim()!="")//&& materialSingleLineTextField1.f)
            {
                TextboxEnterSorgula();
            }
        }

        private void TextboxEnterSorgula()
        {
            
            string aranan = materialSingleLineTextField1.Text;
            int sayi;
            if (!int.TryParse(aranan,out sayi))
                return;
            hasta hasta = HastaBulDosyaID(aranan) ?? HastaBulTC(aranan);
            if (hasta!=null)
            {
                HastaBilgiDoldur(hasta);
                ActiveHasta = hasta;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
           

            Yeni_Hasta_Form form= new Yeni_Hasta_Form();
            DialogResult res= form.ShowDialog();
            if (res == DialogResult.OK)
            {
                ActiveHasta = form.ActiveHasta;
                HastaBilgiDoldur(ActiveHasta);
            }
        }
        private hasta HastaBulDosyaID(string str)
        {
            db = new saglikDBEntities_1();
            hasta hasta = db.hasta.Find(int.Parse(str));
            return hasta; //(a => a.dosyaID == int.Parse(str));
        }

        private hasta HastaBulTC(string str)
        {
            db = new saglikDBEntities_1();
            return db.hasta.Find(int.Parse(str));
        }

        private void HastaBilgiDoldur(hasta h)
        {

            textBox1.Text = h.birey.ad;
            textBox2.Text = h.birey.soyad;
            maskedTextBox1.Text = h.birey.ceptel;
            maskedTextBox2.Text = h.yakintel;
            textBox3.Text = h.kurumsicilno;
            textBox4.Text = h.kurumadi;
            sevkIslemDoldur(h);

        }
        
        void sevkIslemDoldur(hasta h)
        {

            if (h == null)
                return;
            flowLayoutPanel1.Controls.Clear();
            //ActiveSevkler = db.sevkler.ToList();
           
            foreach (var sevk in db.dosya.Where(a => a.dosyaid == h.dosyaID).First().sevk)
            {
                SevkItem item = new SevkItem(sevk);
                item.GörüntüleEvent += SevkGörüntüleOrtakButton;
                item.DüzenleEvent += SevkDüzenleOrtakButton;
                flowLayoutPanel1.Controls.Add(item);

            }
        }

      

      
        
        void SevkDüzenleOrtakButton(sevk s)
        {
            YeniSevkForm form= new YeniSevkForm(s);
            form.ShowDialog();
        } 

     


        public void SevkGörüntüleOrtakButton(sevk s)
        {

            db = new saglikDBEntities_1();
            List<islemler> islmler = new List<islemler>();
            islmler = db.islemler.ToList().Where(a=>a.sevktarihi == s.sevktarihi).ToList();
            ActiveIslemler = islmler;
            int toplamMaliyet=0;
     
            dataGridView1.Rows.Clear();

            foreach (var var in islmler)
            {
                int maliyet = int.Parse(var.islem.birimfiyat);
                string  sevkYapanDr = "Dr. " + var.doktor.birey.ad;

                dataGridView1.Rows.Add(s.poliklinik,
                    s.sevktarihi.ToString("dd-MM-yyyy"),
                    s.sira,
                    s.saat,
                    var.islem.islemid,
                    var.islem.islemadi,
                    var.doktor.doktorid,
                    sevkYapanDr,
                    maliyet,
                    var.miktar
                    );

                toplamMaliyet += maliyet*var.miktar??1;
            }

            label1.Text = toplamMaliyet.ToString();
        }

       


        private void HastaIslemPanel_Load(object sender, EventArgs e)
        {
             db = new saglikDBEntities_1();
         
            //dataGridView1.Rows.Add("kbb", "114","10-10-2017", "17:55" ,  "a","hüseyin","1156");
            //dataGridView1.Rows.Add("kbb", "114","10-10-2017", "17:55" ,  "b","hüseyin","1156");
            //dataGridView1.Rows.Add("kbb", "114","10-10-2017", "17:55" ,  "c","hüseyin","1156");

            return;
            sevk sevk= new sevk();//db.sevk.FirstOrDefault();
            sevk.poliklinik = "K.b.b.2";//poliklinik.poliklinikadi;
            sevk.sevktarihi=DateTime.Now;
            sevk.dosyaid=16;
            sevk.sevkedendoktorid = 3;
            sevk.taburcuid = 1;
           
            
            //db.sevk.Remove(sevk);
            db.sevk.Add(sevk);
            db.SaveChanges();

            db = new saglikDBEntities_1();
            sevk= db.sevk.FirstOrDefault();
            sevk.taburcuid = 2;
            
            db.Entry(sevk).State = EntityState.Modified;
            db.SaveChanges();
        }
        
      
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();
        }
        void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<SevkItem>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            ControlsYenidenBoyutla();
        }

        //public delegate void dataGridButtonHandler(sevk s);

        //public event dataGridButtonHandler dataGridButtonEvent;
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridView dgw = sender as DataGridView;
        //  //  var tip = dgw.Columns[e.ColumnIndex].CellType;
        //    if (dgw.Columns[e.ColumnIndex].CellType  == typeof(DataGridViewButtonCell) && e.RowIndex >= 0)
        //    {
        //        db = new saglikDBEntities_1();
        //        if (db.sevk.Count()==0)
        //        {
        //            return;
        //        }

        //        string SatırTarihi = dgw.Rows[e.RowIndex].Cells[1].Value + " " + dgw.Rows[e.RowIndex].Cells[3].Value;
        //        sevk svk=  db.sevk.ToList().SingleOrDefault(a => a.sevktarihi.ToString("dd-MM-yyyy HH:mm:ss") == SatırTarihi);
        //        if (dataGridButtonEvent !=null)
        //            dataGridButtonEvent(svk);

        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (ActiveHasta == null)
                return;

            YeniSevkForm form = new YeniSevkForm(ActiveHasta);
            DialogResult res =  form.ShowDialog();
            db = new saglikDBEntities_1();
            if (res ==DialogResult.OK)
            {   
                sevkIslemDoldur(ActiveHasta);
            }
        }

      
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int satır = dataGridView1.HitTest(e.X,e.Y).RowIndex;
                sağClickRowSıra= satır;
                if (satır >= 0)
                {
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                }
                
                
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniSevkForm form= new YeniSevkForm(sağClickAktifSevk);
            DialogResult res =  form.ShowDialog();
            db = new saglikDBEntities_1();
            if (res ==DialogResult.OK)
            {   
                sevkIslemDoldur(ActiveHasta);
            }
        }

        private int seciliIslemID
        {
            get
            {
                if (sağClickRowSıra <0)
                    return -1;
                return int.Parse(dataGridView1.Rows[sağClickRowSıra].Cells[4].Value.ToString());
            }
        }

        private sevk sağClickAktifSevk
        {
            get
            {
                if (sağClickRowSıra < 0)
                    return null;
                db= new saglikDBEntities_1();
                DataGridView dgw = dataGridView1;
                string SatırTarihi = dgw.Rows[sağClickRowSıra].Cells[1].Value + " " + dgw.Rows[sağClickRowSıra].Cells[3].Value;
                sevk svk=  db.sevk.ToList().SingleOrDefault(a => a.sevktarihi.ToString("dd-MM-yyyy HH:mm:ss") == SatırTarihi);
                return svk;
            }
        }

        private void kaydıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db= new saglikDBEntities_1();
            if (seciliIslemID<0)
                return;
            islemler islm = db.islemler.ToList().Where(a => a.islemid == seciliIslemID).First();

            DialogResult res=   MessageBox.Show($"{islm.islem.islemadi} işlemini silmek istediğinize Emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;
            
            
            db.islemler.Remove(islm);
            db.SaveChanges();
            dataGridView1.Rows.RemoveAt(sağClickRowSıra);
            db= new saglikDBEntities_1();
            ActiveIslemler = db.islemler.ToList();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

      

        
    }
}
