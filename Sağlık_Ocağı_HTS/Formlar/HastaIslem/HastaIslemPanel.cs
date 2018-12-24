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
            
            string aranan = materialSingleLineTextField1.Text;
            hasta hasta = HastaBulDosyaID(aranan) ?? HastaBulTC(aranan);
            if (hasta!=null)
                HastaBilgiDoldur(hasta);
        }
        private hasta HastaBulDosyaID(string str)
        {
            db = new saglikDBEntities_1();
            return db.hasta.FirstOrDefault(a => a.dosyaID == int.Parse(str));
        }

        private hasta HastaBulTC(string str)
        {
            db = new saglikDBEntities_1();
            return db.hasta.FirstOrDefault(a => a.tckimlikno == int.Parse(str));
        }

        private void HastaBilgiDoldur(hasta h)
        {

            textBox1.Text = h.birey.ad;
            textBox2.Text = h.birey.soyad;
            maskedTextBox1.Text = h.birey.ceptel;
            maskedTextBox2.Text = h.yakintel;
            maskedTextBox2.Text = h.kurumsicilno;
            maskedTextBox2.Text = h.kurumadi;
            HastaSevkDoldur(h);
        }

        private void HastaSevkDoldur(hasta h)
        {
            var sevks = h.dosya.First(a => a.dosyaid == h.dosyaID).sevkler;
            List<sevk> sss = sevks.Select(a => a.sevk).ToList();
            foreach (var sevk in sss)
            {
                SevkItem sItem=new SevkItem(sevk);
                flowLayoutPanel1.Controls.Add(sItem);
            }
        }

        public void SevkGörüntüleOrtakButton(sevk s)
        {



        }


        private void HastaIslemPanel_Load(object sender, EventArgs e)
        {
             db = new saglikDBEntities_1();
            gridButtn.Click += GridButtons_Click;
            dataGridView1.Rows.Add("kbb", "114","10-10-2017", "17:55" ,  gridButtn,"hüseyin","1156");
            dataGridView1.Rows.Add("kbb", "114","10-10-2017", "17:55" ,  gridButtn,"hüseyin","1156");
            dataGridView1.Rows.Add("kbb", "114","10-10-2017", "17:55" ,  gridButtn,"hüseyin","1156");


        }
        Button gridButtn= new Button();
        private void GridButtons_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
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

        public delegate void dataGridButtonHandler(sevk s);

        public event dataGridButtonHandler dataGridButtonEvent;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgw = sender as DataGridView;
            var tip = dgw.Columns[e.ColumnIndex].CellType;
            if ( dgw.Columns[e.ColumnIndex].CellType  == typeof(DataGridViewButtonCell) && e.RowIndex >= 0)
            {
                db = new saglikDBEntities_1();
                if (db.sevk.Count()==0)
                {
                    return;
                }
                sevk svk=  db.sevk.SingleOrDefault(a => a.sevktarihi.ToString("dd-MM-yyyy") == dgw.Rows[e.RowIndex].Cells[1].Value);
                if (dataGridButtonEvent !=null)
                    dataGridButtonEvent(svk);

            }
        }
    }
}
