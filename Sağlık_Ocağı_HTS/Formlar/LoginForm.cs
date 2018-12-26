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

        private void button1_Click(object sender, EventArgs e)
        {
            var db= new saglikDBEntities_1();
            var kullanıcı = db.kullanicilar.FirstOrDefault(a=>a.username==materialSingleLineTextField1.Text.Trim() &&  a.sifre==materialSingleLineTextField2.Text.Trim());
            if (kullanıcı==null)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
                
            }

            db.Entry(kullanıcı).State = EntityState.Detached;
            MainForm form= new MainForm(kullanıcı);
            //form.Closed += new EventHandler((o, args) => this.Close());
            Hide();
            form.ShowDialog();
            Show();
            materialSingleLineTextField1.Text = "";
            materialSingleLineTextField2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
