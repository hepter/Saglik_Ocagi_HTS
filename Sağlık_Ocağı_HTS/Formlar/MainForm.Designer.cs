namespace Sağlık_Ocağı_HTS
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oturumdanÇıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.süzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yöneticiPaneliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.poliklinikEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doktorEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görünümToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.süzenToolStripMenuItem,
            this.görünümToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1306, 39);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            this.menuStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseUp);
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oturumdanÇıkToolStripMenuItem,
            this.toolStripMenuItem1,
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(63, 39);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // oturumdanÇıkToolStripMenuItem
            // 
            this.oturumdanÇıkToolStripMenuItem.Name = "oturumdanÇıkToolStripMenuItem";
            this.oturumdanÇıkToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.oturumdanÇıkToolStripMenuItem.Text = "Oturumdan çık";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // süzenToolStripMenuItem
            // 
            this.süzenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yöneticiPaneliToolStripMenuItem,
            this.toolStripMenuItem2,
            this.poliklinikEkleToolStripMenuItem,
            this.doktorEkleToolStripMenuItem});
            this.süzenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.süzenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.süzenToolStripMenuItem.Name = "süzenToolStripMenuItem";
            this.süzenToolStripMenuItem.Size = new System.Drawing.Size(49, 39);
            this.süzenToolStripMenuItem.Text = "Ekle";
            this.süzenToolStripMenuItem.Click += new System.EventHandler(this.süzenToolStripMenuItem_Click);
            // 
            // yöneticiPaneliToolStripMenuItem
            // 
            this.yöneticiPaneliToolStripMenuItem.Name = "yöneticiPaneliToolStripMenuItem";
            this.yöneticiPaneliToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.yöneticiPaneliToolStripMenuItem.Text = "Yönetici Paneli";
            this.yöneticiPaneliToolStripMenuItem.Click += new System.EventHandler(this.yöneticiPaneliToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
            // 
            // poliklinikEkleToolStripMenuItem
            // 
            this.poliklinikEkleToolStripMenuItem.Name = "poliklinikEkleToolStripMenuItem";
            this.poliklinikEkleToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.poliklinikEkleToolStripMenuItem.Text = "Poliklinik Ekle";
            // 
            // doktorEkleToolStripMenuItem
            // 
            this.doktorEkleToolStripMenuItem.Name = "doktorEkleToolStripMenuItem";
            this.doktorEkleToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.doktorEkleToolStripMenuItem.Text = "Doktor Ekle";
            // 
            // görünümToolStripMenuItem
            // 
            this.görünümToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.görünümToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.görünümToolStripMenuItem.Name = "görünümToolStripMenuItem";
            this.görünümToolStripMenuItem.Size = new System.Drawing.Size(86, 39);
            this.görünümToolStripMenuItem.Text = "Görünüm";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "test";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 661);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "SOHTS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem süzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oturumdanÇıkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görünümToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem yöneticiPaneliToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem poliklinikEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doktorEkleToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

