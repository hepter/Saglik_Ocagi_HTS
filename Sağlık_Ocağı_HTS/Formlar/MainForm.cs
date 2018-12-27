using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using MaterialSkin;
using MaterialSkin.Controls;
using Sağlık_Ocağı_HTS.Denetimler.AdminPanel;
using Sağlık_Ocağı_HTS.Formlar;
using Sağlık_Ocağı_HTS.Formlar.Ekle;
using Sağlık_Ocağı_HTS.Formlar.HastaIslem;


namespace Sağlık_Ocağı_HTS
{
    public partial class MainForm : MaterialForm
    {
        private kullanicilar _aktifKullanici;
        private kullanicilar aktifKullanici
        {
            get { return _aktifKullanici; }
            set
            {
                label1.Text = value.username;
                var birey = db.birey.Where(a => a.tckimlikno == value.tckimlikno).First();
                label2.Text = birey.ad + " "+ birey.soyad;
                pictureBox1.Image = (value.yetki == "1") ? Properties.Resources.admin : Properties.Resources.user;
                _aktifKullanici = value;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
       
        public MainForm()
        {
            InitializeComponent();
            var db = new saglikDBEntities_1();
            var kull = db.kullanicilar.First(a=>a.username=="hepter");
            db.Entry(kull).State = EntityState.Detached;
            aktifKullanici = kull;


           
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Brown500, Primary.Brown700, Primary.LightBlue900, Accent.Green700, TextShade.WHITE);

           
        }

        public MainForm(kullanicilar kull):this()
        {
            aktifKullanici = kull;
        }

        private saglikDBEntities_1 db = new saglikDBEntities_1();
        int aaa = 0;
        private void button1_Click(object sender, EventArgs e)
       {


            islem iss = new islem() { birimfiyat = "500" + aaa, islemadi = "test" + ++aaa };


            db.islem.Add(iss);
            db.SaveChanges();

            MessageBox.Show(db.islem.Count().ToString());
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            TaburcuForm form= new TaburcuForm();
            
            AdminPanelForm AdminPanelForm= new AdminPanelForm();
            PoliklinikEkle userDetay= new PoliklinikEkle();
           form.Show();
          //  AdminPanelForm.Show();
           // userDetay.ShowDialog();
            HastaIslemPanel  hastaIslemPanel=  new HastaIslemPanel();
            hastaIslemPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(hastaIslemPanel);
        }

        private void süzenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill(); 
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //    int sonuc = 0;
        //    var bbb= new ObjectParameter("result",typeof(bool));
        //    db  = new saglikDBEntities_1();
        //    db.userCheck(textBox1.Text,bbb);

        //    if ((bool)bbb.Value)
        //    {
        //        MessageBox.Show("doğru");
        //    }
        //    else
        //    {
        //        MessageBox.Show("yanlış");
        //    }
           
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            db = new saglikDBEntities_1();
            UserDetay detay= new UserDetay(db.kullanicilar.FirstOrDefault());
            detay.ShowDialog();
        }

        private void yöneticiPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelForm panel =new AdminPanelForm(aktifKullanici);
            panel.ShowDialog();
        }

        private void poliklinikEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PoliklinikEkle ekle=new PoliklinikEkle();
            ekle.ShowDialog();
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
            DoktorEkleForm form=new DoktorEkleForm();
            form.ShowDialog();

        }

        private void oturumdanÇıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res=   MessageBox.Show($"{aktifKullanici.username} hesanbından çıkış yapılsın mı?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill(); 
        }
    }
}
