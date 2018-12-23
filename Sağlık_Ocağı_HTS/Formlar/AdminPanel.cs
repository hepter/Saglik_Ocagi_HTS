using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Sağlık_Ocağı_HTS.Denetimler.AdminPanel;

namespace Sağlık_Ocağı_HTS.Formlar
{
    public partial class AdminPanel : MaterialForm
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var db = new saglikDBEntities1();

            foreach (var kull in db.kullanici.ToList())
            {
                User user = new User(kull, SilAksiyon, DetayAksiyon);
                flowLayoutPanel1.Controls.Add(user);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void SilAksiyon(kullanici kull )
        {
            foreach (var user in flowLayoutPanel1.Controls.Cast<User>())
            {
                if (kull.id==user.EntityKullanici.id)
                {
                    new saglikDBEntities1().kullanici.Remove(user.EntityKullanici);
                    flowLayoutPanel1.Controls.Remove(user);
                    break;
                }
            }

        }
        public void DetayAksiyon(kullanici kull)
        {
          
            UserDetay detay= new UserDetay(kull);
            detay.ShowDialog();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            UserDetay dialog = new UserDetay();
            dialog.ShowDialog();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<User>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }
    }
}