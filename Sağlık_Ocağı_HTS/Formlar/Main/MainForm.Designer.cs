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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.süzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.görünümToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.oturumdanÇıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yöneticiPaneliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poliklinikEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doktorEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilimiDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabloyuYazdırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yazıcıÖnizlemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.doktorYönetimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelYönetimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.menuStrip1.Size = new System.Drawing.Size(1375, 39);
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
            this.dosyaToolStripMenuItem.DropDownClosed += new System.EventHandler(this.dosyaToolStripMenuItem_DropDownClosed);
            this.dosyaToolStripMenuItem.DropDownOpened += new System.EventHandler(this.dosyaToolStripMenuItem_DropDownOpened);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // süzenToolStripMenuItem
            // 
            this.süzenToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.süzenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yöneticiPaneliToolStripMenuItem,
            this.toolStripMenuItem2,
            this.poliklinikEkleToolStripMenuItem,
            this.doktorEkleToolStripMenuItem,
            this.personelEkleToolStripMenuItem,
            this.toolStripMenuItem4,
            this.doktorYönetimToolStripMenuItem,
            this.personelYönetimToolStripMenuItem});
            this.süzenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.süzenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.süzenToolStripMenuItem.Name = "süzenToolStripMenuItem";
            this.süzenToolStripMenuItem.Size = new System.Drawing.Size(49, 39);
            this.süzenToolStripMenuItem.Text = "Ekle";
            this.süzenToolStripMenuItem.DropDownClosed += new System.EventHandler(this.dosyaToolStripMenuItem_DropDownClosed);
            this.süzenToolStripMenuItem.DropDownOpened += new System.EventHandler(this.dosyaToolStripMenuItem_DropDownOpened);
            this.süzenToolStripMenuItem.Click += new System.EventHandler(this.süzenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Coral;
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // görünümToolStripMenuItem
            // 
            this.görünümToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilimiDüzenleToolStripMenuItem,
            this.toolStripMenuItem3,
            this.tabloyuYazdırToolStripMenuItem,
            this.yazıcıÖnizlemeToolStripMenuItem});
            this.görünümToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.görünümToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.görünümToolStripMenuItem.Name = "görünümToolStripMenuItem";
            this.görünümToolStripMenuItem.Size = new System.Drawing.Size(86, 39);
            this.görünümToolStripMenuItem.Text = "Görünüm";
            this.görünümToolStripMenuItem.DropDownClosed += new System.EventHandler(this.dosyaToolStripMenuItem_DropDownClosed);
            this.görünümToolStripMenuItem.DropDownOpened += new System.EventHandler(this.dosyaToolStripMenuItem_DropDownOpened);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1352, 626);
            this.panel1.TabIndex = 4;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeToolStripMenuItem,
            this.effeToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(111, 52);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.testeToolStripMenuItem.Text = "teste";
            // 
            // effeToolStripMenuItem
            // 
            this.effeToolStripMenuItem.Name = "effeToolStripMenuItem";
            this.effeToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.effeToolStripMenuItem.Text = "effe";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(1162, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "nickname";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(1163, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "isim";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(199, 6);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.pictureBox1.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.admin;
            this.pictureBox1.Location = new System.Drawing.Point(1126, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // oturumdanÇıkToolStripMenuItem
            // 
            this.oturumdanÇıkToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.account;
            this.oturumdanÇıkToolStripMenuItem.Name = "oturumdanÇıkToolStripMenuItem";
            this.oturumdanÇıkToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.oturumdanÇıkToolStripMenuItem.Text = "Oturumdan çık";
            this.oturumdanÇıkToolStripMenuItem.Click += new System.EventHandler(this.oturumdanÇıkToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.logout;
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // yöneticiPaneliToolStripMenuItem
            // 
            this.yöneticiPaneliToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.yöneticiPaneliToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.edit;
            this.yöneticiPaneliToolStripMenuItem.Name = "yöneticiPaneliToolStripMenuItem";
            this.yöneticiPaneliToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.yöneticiPaneliToolStripMenuItem.Text = "Yönetici Paneli";
            this.yöneticiPaneliToolStripMenuItem.Click += new System.EventHandler(this.yöneticiPaneliToolStripMenuItem_Click);
            // 
            // poliklinikEkleToolStripMenuItem
            // 
            this.poliklinikEkleToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.poliklinikEkleToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.hosp;
            this.poliklinikEkleToolStripMenuItem.Name = "poliklinikEkleToolStripMenuItem";
            this.poliklinikEkleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.poliklinikEkleToolStripMenuItem.Text = "Poliklinik Ekle";
            this.poliklinikEkleToolStripMenuItem.Click += new System.EventHandler(this.poliklinikEkleToolStripMenuItem_Click);
            // 
            // doktorEkleToolStripMenuItem
            // 
            this.doktorEkleToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.doktorEkleToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.doktor;
            this.doktorEkleToolStripMenuItem.Name = "doktorEkleToolStripMenuItem";
            this.doktorEkleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.doktorEkleToolStripMenuItem.Text = "Doktor Ekle";
            this.doktorEkleToolStripMenuItem.Click += new System.EventHandler(this.doktorEkleToolStripMenuItem_Click);
            // 
            // personelEkleToolStripMenuItem
            // 
            this.personelEkleToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.doktor;
            this.personelEkleToolStripMenuItem.Name = "personelEkleToolStripMenuItem";
            this.personelEkleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.personelEkleToolStripMenuItem.Text = "Personel Ekle";
            this.personelEkleToolStripMenuItem.Click += new System.EventHandler(this.personelEkleToolStripMenuItem_Click);
            // 
            // profilimiDüzenleToolStripMenuItem
            // 
            this.profilimiDüzenleToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.user;
            this.profilimiDüzenleToolStripMenuItem.Name = "profilimiDüzenleToolStripMenuItem";
            this.profilimiDüzenleToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.profilimiDüzenleToolStripMenuItem.Text = "Profilimi Düzenle";
            this.profilimiDüzenleToolStripMenuItem.Click += new System.EventHandler(this.profilimiDüzenleToolStripMenuItem_Click);
            // 
            // tabloyuYazdırToolStripMenuItem
            // 
            this.tabloyuYazdırToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.print;
            this.tabloyuYazdırToolStripMenuItem.Name = "tabloyuYazdırToolStripMenuItem";
            this.tabloyuYazdırToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.tabloyuYazdırToolStripMenuItem.Text = "Tabloyu Yazdır";
            // 
            // yazıcıÖnizlemeToolStripMenuItem
            // 
            this.yazıcıÖnizlemeToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.print_preview256;
            this.yazıcıÖnizlemeToolStripMenuItem.Name = "yazıcıÖnizlemeToolStripMenuItem";
            this.yazıcıÖnizlemeToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.yazıcıÖnizlemeToolStripMenuItem.Text = "Yazıcı Önizleme";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(213, 6);
            // 
            // doktorYönetimToolStripMenuItem
            // 
            this.doktorYönetimToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.person;
            this.doktorYönetimToolStripMenuItem.Name = "doktorYönetimToolStripMenuItem";
            this.doktorYönetimToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.doktorYönetimToolStripMenuItem.Text = "Doktor Yönetim";
            this.doktorYönetimToolStripMenuItem.Click += new System.EventHandler(this.doktorYönetimToolStripMenuItem_Click);
            // 
            // personelYönetimToolStripMenuItem
            // 
            this.personelYönetimToolStripMenuItem.Image = global::Sağlık_Ocağı_HTS.Properties.Resources.person2;
            this.personelYönetimToolStripMenuItem.Name = "personelYönetimToolStripMenuItem";
            this.personelYönetimToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.personelYönetimToolStripMenuItem.Text = "Personel Yönetim";
            this.personelYönetimToolStripMenuItem.Click += new System.EventHandler(this.personelYönetimToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 705);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOHTS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem süzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oturumdanÇıkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görünümToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yöneticiPaneliToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem poliklinikEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doktorEkleToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem profilimiDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tabloyuYazdırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yazıcıÖnizlemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem doktorYönetimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelYönetimToolStripMenuItem;
    }
}

