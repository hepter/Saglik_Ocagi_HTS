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
using Sağlık_Ocağı_HTS.Denetimler.AdminPanel;

namespace Sağlık_Ocağı_HTS.Formlar
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        static  public MainForm form ;
        private void button1_Click(object sender, EventArgs e)
        {
            var db= new saglikDBEntities_1();
            int uye = db.kullanicilar.Count();
            if (uye==0)
            {
                MessageBox.Show("Veritabanında kayıtlı üye yok\n" +
                                "Yönetici Seviyesinde kullanıcı hesabı oluşturulmak üzere yeni bir forma yönlendirileceksiniz\n"
                    ,"Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                UserAddDialog frm = new UserAddDialog();
                Hide();
                DialogResult res = frm.ShowDialog();
                Show();
                if (res==DialogResult.OK)
                {
                    form= new MainForm(frm.aktifKullanıcı);
                    göster();
                }
                return;
            }

            var kullanıcı = db.kullanicilar.FirstOrDefault(a=>a.username==materialSingleLineTextField1.Text.Trim() &&  a.sifre==materialSingleLineTextField2.Text.Trim());
            if (kullanıcı==null)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            db.Entry(kullanıcı).State = EntityState.Detached;
            form= new MainForm(kullanıcı);
            göster();
        }

        void göster()
        {
            Hide();
            form.Show();
            form.KapatEvent += (sender, args) =>
            {
                this.Show();
                form.Hide();
                
            };
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
