using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class HastaIslemPanel : UserControl
    {
        private saglikDBEntities_1 db;
        public HastaIslemPanel()
        {
            InitializeComponent();
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }
        ContextForm form= new ContextForm();

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
               
           // form.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
             
        }

        private void materialSingleLineTextField1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&& materialSingleLineTextField1.Focused)
            {
                HastaBulDosyaID(materialSingleLineTextField1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaBulDosyaID(materialSingleLineTextField1.Text);
        }
        private hasta HastaBulDosyaID(string str)
        {
            db = new saglikDBEntities_1();
            return db.hasta.First(a => a.dosyaID == int.Parse(str));
        }


        private void HastaBilgiDoldur(hasta h)
        {
            textBox1.Text = h.birey.ad;
            textBox2.Text = h.birey.soyad;
            maskedTextBox1.Text = h.birey.ceptel;
            maskedTextBox2.Text = h.yakintel;
            maskedTextBox2.Text = h.kurumsicilno;
            maskedTextBox2.Text = h.kurumadi;

        }

        private void HastaIslemPanel_Load(object sender, EventArgs e)
        {
             db = new saglikDBEntities_1();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
