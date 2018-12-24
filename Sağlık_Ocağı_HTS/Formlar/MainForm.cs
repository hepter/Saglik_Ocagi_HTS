using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using MaterialSkin;
using MaterialSkin.Controls;
using Nevron.Nov;
using Nevron.Nov.Dom;
using Nevron.Nov.Graphics;
using Nevron.Nov.Text;
using Nevron.Nov.UI;
using Sağlık_Ocağı_HTS.Denetimler.AdminPanel;
using Sağlık_Ocağı_HTS.Formlar;
using Sağlık_Ocağı_HTS.Formlar.Ekle;


namespace Sağlık_Ocağı_HTS
{
    public partial class MainForm : MaterialForm
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
       
        public MainForm()
        {
    
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Brown500, Primary.Brown700, Primary.LightBlue900, Accent.Green700, TextShade.WHITE);

           
        }

        private saglikDBEntities1 db = new saglikDBEntities1();
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
            LoginForm form= new LoginForm();
            
            AdminPanelForm AdminPanelForm= new AdminPanelForm();
            PoliklinikEkle userDetay= new PoliklinikEkle();
          //  form.Show();
          //  AdminPanelForm.Show();
           // userDetay.ShowDialog();
    
        }

        private void nTextBoxControl1_TextChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {

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
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int sonuc = 0;
            var bbb= new ObjectParameter("result",typeof(bool));
            db  = new saglikDBEntities1();
            db.userCheck(textBox1.Text,bbb);

            if ((bool)bbb.Value)
            {
                MessageBox.Show("doğru");
            }
            else
            {
                MessageBox.Show("yanlış");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db = new saglikDBEntities1();
            UserDetay detay= new UserDetay(db.kullanici.FirstOrDefault());
            detay.ShowDialog();
        }

        private void yöneticiPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelForm panel =new AdminPanelForm();
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
    }
}
