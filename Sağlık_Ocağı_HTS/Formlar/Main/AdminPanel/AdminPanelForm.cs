using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Sağlık_Ocağı_HTS.Denetimler.AdminPanel
{
    public partial class AdminPanelForm : MaterialForm
    {
        private saglikDBEntities_1 db;

        public AdminPanelForm()
        {
            InitializeComponent();
        }

        public AdminPanelForm(kullanicilar kull) : this()
        {
            aktifKullanici = kull;
        }

        public kullanicilar aktifKullanici { get; set; }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ControlsYenile();
        }

        private void ControlsYenile()
        {
            db = new saglikDBEntities_1();
            flowLayoutPanel1.Controls.Clear();
            SuspendLayout();
            foreach (var kull in db.kullanicilar.ToList())
            {
                bool aktifKullanicininHesabimi = false;
                if (aktifKullanici.username == kull.username)
                    aktifKullanicininHesabimi = true;
                User user = new User(kull, SilAksiyon, DetayAksiyon, aktifKullanicininHesabimi);
                flowLayoutPanel1.Controls.Add(user);
            }

         
            ResumeLayout();
            ControlsYenidenBoyutla();
        }

        public void SilAksiyon(kullanicilar kull)
        {
            db = new saglikDBEntities_1();

            if (aktifKullanici.username == kull.username)
            {
                MessageBox.Show("Kendi Hesabınızı silemezsiniz!", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show($"'{kull.username}' kullanıcısını silmek istediğinize Emin misiniz?",
                "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;

            foreach (var user in flowLayoutPanel1.Controls.Cast<User>())
            {
                if (kull.id == user.EntityKullanici.id)
                {
                    db.Entry(new kullanicilar
                    {
                        id = user.EntityKullanici.id,
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
            UserDetay detay = new UserDetay(kull);

            if (detay.ShowDialog() == DialogResult.OK)
            {
                if (aktifKullanici.id == detay.activeKullanici.id)
                {
                    aktifKullanici = detay.activeKullanici;
                    DialogResult = DialogResult.OK;
                }

                ControlsYenile();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            UserDetay dialog = new UserDetay();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ControlsYenile();
            }
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            ControlsYenidenBoyutla();
        }


        private void ControlsYenidenBoyutla()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var user in flowLayoutPanel1.Controls.Cast<User>())
                user.Width = flowLayoutPanel1.Width - 30;
            flowLayoutPanel1.ResumeLayout();
        }
    }
}