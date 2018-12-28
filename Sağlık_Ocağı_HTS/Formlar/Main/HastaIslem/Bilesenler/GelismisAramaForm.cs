using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class GelismisAramaForm : DialogBox
    {
        private saglikDBEntities_1 db = new saglikDBEntities_1();

        public GelismisAramaForm()
        {
            InitializeComponent();
        }

        public hasta activeHasta { get; set; }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            long tcno = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            activeHasta = db.hasta.Where(a => a.tckimlikno == tcno).Single();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void GelismisAramaForm_Load(object sender, EventArgs e)
        {
            int hastaSayı = 0;
            foreach (var hs in db.hasta)
            {
                dataGridView1.Rows.Add(
                    hs.tckimlikno,
                    hs.dosyaID,
                    hs.birey.ad,
                    hs.birey.soyad,
                    hs.kurumsicilno,
                    hs.birey.ceptel);
                hastaSayı++;
            }

            materialLabel1.Text = $"Kayıtlı Hasta:{hastaSayı}";
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!materialCheckBox1.Checked && !materialCheckBox2.Checked && !materialCheckBox3.Checked)
            {
                (sender as MaterialCheckBox).Checked = true;
            }

            Ara();
        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            Ara();
        }

        private void Ara()
        {
            int hastaSayı = 0;
            string str = materialSingleLineTextField1.Text;

            if (string.IsNullOrWhiteSpace(str))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    row.Visible = true;
                hastaSayı = dataGridView1.Rows.Count;
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool status = false;
                    if (materialCheckBox1.Checked && row.Cells[0].Value.ToString().IndexOf(str) != -1)
                    {
                        status = true;
                    }

                    if (materialCheckBox3.Checked && row.Cells[1].Value.ToString().IndexOf(str) != -1)
                    {
                        status = true;
                    }

                    if (materialCheckBox2.Checked &&
                        (row.Cells[2].Value + row.Cells[3].Value.ToString()).IndexOf(str) != -1)
                    {
                        status = true;
                    }

                    if (status)
                        hastaSayı++;
                    row.Visible = status;
                }
            }

            materialLabel2.Text = $"Bulunan Hasta:{hastaSayı}";
        }
    }
}