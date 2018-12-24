using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sağlık_Ocağı_HTS.Formlar.AdminPanel;

namespace Sağlık_Ocağı_HTS.Denetimler.AdminPanel
{
    public enum UserSeviye
    {
        Admin,
        User
    }
 
    public partial class User : UserControl
    {
        public delegate void AksiyonHandler(kullanici user);
        public kullanici EntityKullanici { get;}

        public event AksiyonHandler SilEvent;
        public event AksiyonHandler DetayEvent;

        public User()
        {
            InitializeComponent();
            pictureBox1.Image = adminIcon.user;
            label4.Text = "User";
        }
        public User(kullanici kull,AksiyonHandler Sil,AksiyonHandler Detay):this()
        {
           
            switch ((UserSeviye)int.Parse(kull.yetki))
            {
                case UserSeviye.Admin:
                    pictureBox1.Image = adminIcon.admin;
                    break;
                case UserSeviye.User:
                    pictureBox1.Image = adminIcon.user;
                    break;
            }

         
            SilEvent = Sil;
            DetayEvent = Detay;
            EntityKullanici = kull;
            label4.Text = kull.username;
            materialLabel2.Text = kull.ad;
            materialLabel4.Text = kull.soyad;
            label6.Text = kull.unvan;
            label3.Text = kull.id.ToString();
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes==MessageBox.Show("Silmek istediğinize Emin Misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
            {
                SilEvent(EntityKullanici);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                DetayEvent(EntityKullanici);
        }
    }
}
