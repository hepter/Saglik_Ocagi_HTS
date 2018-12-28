using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sağlık_Ocağı_HTS.Formlar.HastaIslem
{
    public partial class HastaIslemPanel : UserControl
    {
        private int sağClickRowSıra = -1;
        private saglikDBEntities_1 db;
        public hasta ActiveHasta { get; set; }
        public sevk ActiveSevk { get; set; }
        public List<islemler> ActiveIslemler { get; set; }


        public HastaIslemPanel()
        {
            InitializeComponent();
            ActiveIslemler =new List<islemler>();
        }
        public HastaIslemPanel(object yaz,object önizle):this()
        {
            (yaz as ToolStripMenuItem).Click += button4_Click;
            (önizle as ToolStripMenuItem).Click += button5_Click;
        }

        private void materialSingleLineTextField1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)// && materialSingleLineTextField1.Text.Trim()!="")//&& materialSingleLineTextField1.f)
            {
                TextboxEnterSorgula();
            }
        }

        private void TextboxEnterSorgula()
        {
            
            string aranan = materialSingleLineTextField1.Text;
            Int64 sayi;
            if (!Int64.TryParse(aranan,out sayi))
            {
                hastaEkleFlipFlop();
                return;
            }

            hasta hasta = HastaBulDosyaID(aranan) ?? HastaBulTC(aranan);
           
            HastaBilgiDoldur(hasta);
            ActiveHasta = hasta;

            if (hasta==null)
                hastaEkleFlipFlop();
            
        }

        void hastaEkleFlipFlop()
        {
            Task.Run(delegate
            {
                for (int i = 0; i < 3; i++)
                {
                    button3.Invoke((Action) delegate { button3.BackColor = Color.FromArgb(82, 155, 41); });
                    Thread.Sleep(150);
                    button3.Invoke((Action) delegate { button3.BackColor = Color.FromArgb(82, 41, 41); });
                    Thread.Sleep(150);
                }
                    
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            GelismisAramaForm form= new GelismisAramaForm();
            DialogResult res= form.ShowDialog();
            if (res == DialogResult.OK)
            {
                ActiveHasta = form.activeHasta;
                HastaBilgiDoldur(ActiveHasta);
            }
        }
        private hasta HastaBulDosyaID(string str)
        {
            db = new saglikDBEntities_1();
            Int64 sayi =Int64.Parse(str);
            hasta hasta = db.hasta.ToList().Where(a=>a.dosyaID==sayi).FirstOrDefault();
            return hasta; //(a => a.dosyaID == int.Parse(str));
        }

        private hasta HastaBulTC(string str)
        {
            db = new saglikDBEntities_1();
            Int64 tc = Int64.Parse(str);
            return db.hasta.ToList().Where(a=>a.tckimlikno==tc).FirstOrDefault();
        }

        private void HastaBilgiDoldur(hasta h)
        {

            textBox1.Text = h?.birey.ad ?? "";
            textBox2.Text = h?.birey.soyad?? "";
            maskedTextBox1.Text = h?.birey.ceptel?? "";
            maskedTextBox2.Text = h?.yakintel?? "";
            textBox3.Text = h?.kurumsicilno?? "";
            textBox4.Text = h?.tckimlikno.ToString()?? "";
            sevkIslemDoldur(h);

        }
        
        void sevkIslemDoldur(hasta h)
        {

            if (h == null)
                return;
            flowLayoutPanel1.Controls.Clear();
            //ActiveSevkler = db.sevkler.ToList();
            int sevkSayi = 0;
            foreach (var sevk in db.dosya.Where(a => a.dosyaid == h.dosyaID).First().sevk)
            {
                SevkItem item = new SevkItem(sevk);
                item.GörüntüleEvent += SevkGörüntüleOrtakButton;
                item.DüzenleEvent += SevkDüzenleOrtakButton;
                item.TaburcuEvent += SevkTaburcuOrtakButton;
                flowLayoutPanel1.Controls.Add(item);
                sevkSayi++;
            }

            materialLabel8.Text = (sevkSayi == 0) ? "Sevk Bulunamadı!" : sevkSayi+" Adet Sevk Bulundu";
        }

      
        void SevkTaburcuOrtakButton(sevk s)
        {
            TaburcuForm form= new TaburcuForm(s);
            DialogResult res= form.ShowDialog();
            if (res==DialogResult.OK)
            {
                db=new saglikDBEntities_1();

                ActiveHasta = db.hasta.Where(a => a.dosyaID == ActiveHasta.dosyaID).First();
                db.Entry(ActiveHasta).State = EntityState.Detached;
                sevkIslemDoldur(ActiveHasta);
            }

        } 
      
        
        void SevkDüzenleOrtakButton(sevk s)
        {
            if (s.taburcu.taburcuoldumu)
            {
              
                MessageBox.Show("Sevk Taburcu Edilmiş Düzenleme Yapılamaz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            YeniSevkForm form= new YeniSevkForm(s);
            form.ShowDialog();
        } 


        public void SevkGörüntüleOrtakButton(sevk s)
        {
            ActiveSevk = s;
            db = new saglikDBEntities_1();
            List<islemler> islmler = new List<islemler>();
            islmler = db.islemler.ToList().Where(a=>a.sevktarihi == s.sevktarihi).ToList();
            ActiveIslemler = islmler;
            int toplamMaliyet=0;
     
            dataGridView1.Rows.Clear();

            foreach (var var in islmler)
            {
                int maliyet = int.Parse(var.islem.birimfiyat);
                string  islemYapanPersonel = var.personel.birey.ad+" "+var.personel.birey.soyad;

                dataGridView1.Rows.Add(s.poliklinik,
                    s.sevktarihi.ToString("dd-MM-yyyy"),
                    s.sira,
                    s.saat,
                    var.islem.islemid,
                    var.islem.islemadi,
                    var.personel.personelid,
                    islemYapanPersonel,
                    maliyet,
                    var.miktar
                    );

                toplamMaliyet += maliyet*var.miktar??1;
            }

            label1.Text = toplamMaliyet+" TL";
        }

       

     
        private void HastaIslemPanel_Load(object sender, EventArgs e)
        {
            Button btn = button4;
            btn.Image = (Image)(new Bitmap(btn.Image, new Size(btn.Size.Height,btn.Size.Height)));

            btn = button5;
            btn.Image = (Image)(new Bitmap(btn.Image, new Size(btn.Size.Height,btn.Size.Height)));

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
                user.Width = flowLayoutPanel1.Width - 33;
            flowLayoutPanel1.ResumeLayout();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            ControlsYenidenBoyutla();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ActiveHasta == null)
            {
                MessageBox.Show("Seçili Bir hasta yok\nSevk eklenemez!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            YeniSevkForm form = new YeniSevkForm(ActiveHasta);
            DialogResult res =  form.ShowDialog();
            db = new saglikDBEntities_1();
            if (res ==DialogResult.OK)
            {   
                sevkIslemDoldur(ActiveHasta);
            }
        }

      
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int satır = dataGridView1.HitTest(e.X,e.Y).RowIndex;
                sağClickRowSıra= satır;
                if (satır >= 0)
                {
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                }
                
                
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniSevkForm form= new YeniSevkForm(sağClickAktifSevk);
            DialogResult res =  form.ShowDialog();
            db = new saglikDBEntities_1();
            if (res ==DialogResult.OK)
            {   
                sevkIslemDoldur(ActiveHasta);
            }
        }

        private int seciliIslemID
        {
            get
            {
                if (sağClickRowSıra <0)
                    return -1;
                return int.Parse(dataGridView1.Rows[sağClickRowSıra].Cells[4].Value.ToString());
            }
        }

        private sevk sağClickAktifSevk
        {
            get
            {
                if (sağClickRowSıra < 0)
                    return null;
                db= new saglikDBEntities_1();
                DataGridView dgw = dataGridView1;
                string SatırTarihi = dgw.Rows[sağClickRowSıra].Cells[1].Value + " " + dgw.Rows[sağClickRowSıra].Cells[3].Value;
                sevk svk=  db.sevk.ToList().SingleOrDefault(a => a.sevktarihi.ToString("dd-MM-yyyy HH:mm:ss") == SatırTarihi);
                return svk;
            }
        }

        private void kaydıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db= new saglikDBEntities_1();
            if (seciliIslemID<0)
                return;
            islemler islm = db.islemler.ToList().Where(a => a.islemid == seciliIslemID).First();

            DialogResult res=   MessageBox.Show($"'{islm.islem.islemadi}' işlemini silmek istediğinize Emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;
            
            
            db.islemler.Remove(islm);
            db.SaveChanges();
            dataGridView1.Rows.RemoveAt(sağClickRowSıra);
            db= new saglikDBEntities_1();
            ActiveIslemler = db.islemler.ToList();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Tablo boş iken önizleme açılamaz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }


            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Margin=new Padding(20,20,20,20);
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.Size=new Size(1200,800);
            printPreviewDialog1.ShowDialog();
        }

      
        private void printDocument11_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
        {
          
             
            string başMesaj = "Sağlık Ocağı Hasta Sevk Raporu";
            string doktorİsim = string.Format("Dr. {0} {1}",ActiveSevk.doktor.birey.ad,ActiveSevk.doktor.birey.soyad);
            string toplamStr = $"Toplam Maliyet: {label1.Text}";

            int iLeftMargin = e.MarginBounds.Left-50;
            //Set the top margin
            int iTopMargin = e.MarginBounds.Top-50;
            //Whether more pages have to print or not
            bool bMorePagesToPrint = false;
            int iTmpWidth = 0;             

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 22;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth+12);
                        iLeftMargin += iTmpWidth+12;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 10;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {


                            e.Graphics.DrawImage(Properties.Resources.header,new Rectangle(0,0,e.PageBounds.Width,80));

                        
                            //Draw Header
                            e.Graphics.DrawString(
                                başMesaj,
                                new Font(dataGridView1.Font.FontFamily,18, FontStyle.Bold),
                                Brushes.White,
                                e.MarginBounds.Left-20,-60+
                                e.MarginBounds.Top -e.Graphics.MeasureString(başMesaj, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13
                                );

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font.FontFamily,10, FontStyle.Regular),
                                    Brushes.White, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width),-50+ e.MarginBounds.Top -
                                    e.Graphics.MeasureString(başMesaj, new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {                               
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;                    
                }                

            

            iTopMargin += iCellHeight;       
            e.Graphics.DrawString(toplamStr, new Font(dataGridView1.Font, FontStyle.Bold),Brushes.Red,e.PageBounds.Width/10 *7,iTopMargin);
            iTopMargin += iCellHeight; 
            e.Graphics.DrawString(doktorİsim, new Font(dataGridView1.Font, FontStyle.Bold),Brushes.Black,e.PageBounds.Width/5*3,iTopMargin);
            e.Graphics.DrawImage(Properties.Resources.imza,new Rectangle(e.PageBounds.Width/5*3,iTopMargin+11,120,100));
            
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
        }

                 
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
     
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Near;
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Trimming = StringTrimming.EllipsisCharacter;

            arrColumnLefts.Clear();
            arrColumnWidths.Clear();
            iCellHeight = 0;
            iRow = 0;
            bFirstPage = true;
            bNewPage = true;

            // Calculating Total Widths
            iTotalWidth = 0;
            foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
            {
                iTotalWidth += dgvGridCol.Width;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat() 
            { 
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center, 
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Tablo boş iken yazdırılamaz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            PrintDialog printDialog = new PrintDialog();            
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;    
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName ="SEVK RAPOR";          
                printDocument1.Print();
            }
           
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yeni_Hasta_Form form= new Yeni_Hasta_Form();
            DialogResult res= form.ShowDialog();
            if (res == DialogResult.OK)
            {
                ActiveHasta = form.ActiveHasta;
                HastaBilgiDoldur(ActiveHasta);
            }
        }
    }

}

