using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;


namespace Sağlık_Ocağı_HTS.Denetimler.AdminPanel
{
    public partial class AdminPanelForm : MaterialForm
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private saglikDBEntities_1 db;
        private void LoginForm_Load(object sender, EventArgs e)
        {
            ControlsYenile();
        }

        void ControlsYenile()
        {
            db = new saglikDBEntities_1();
            flowLayoutPanel1.Controls.Clear();
            SuspendLayout();
            foreach (var kull in db.kullanicilar.ToList())
            {
                User user = new User(kull, SilAksiyon, DetayAksiyon);
                flowLayoutPanel1.Controls.Add(user);
            }
            ResumeLayout();
            ControlsYenidenBoyutla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void SilAksiyon(kullanicilar kull )
        {
            
            db = new saglikDBEntities_1();
            foreach (var user in flowLayoutPanel1.Controls.Cast<User>())
            {
                if (kull.id==user.EntityKullanici.id)
                {
                    db.Entry(new kullanicilar()
                    {
                        id=user.EntityKullanici.id,
                        username = user.EntityKullanici.username

                    }).State = EntityState.Deleted;
                    db.SaveChanges();
                    //new saglikDBEntities_1().kullanici.Remove(user.EntityKullanici);
                    flowLayoutPanel1.Controls.Remove(user);
                    break;
                }
            }

        }
        public void DetayAksiyon(kullanicilar kull)
        {
            UserDetay detay= new UserDetay(kull);
            detay.ShowDialog();
            ControlsYenile();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            UserDetay dialog = new UserDetay();
            dialog.ShowDialog();
            ControlsYenile();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();
        }


        void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<User>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }
    }
}