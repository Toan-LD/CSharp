namespace Doanqlchdt.GUI
{
    partial class nhacungcap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nhacungcap));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttondau = new System.Windows.Forms.Button();
            this.buttonpress = new System.Windows.Forms.Button();
            this.buttonnext = new System.Windows.Forms.Button();
            this.buttoncuoi = new System.Windows.Forms.Button();
            this.buttonthem = new System.Windows.Forms.Button();
            this.flowLayoutPanelpage = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelfilter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnxem = new System.Windows.Forms.Button();
            this.comboBoxsxlc = new System.Windows.Forms.ComboBox();
            this.comboBoxsx = new System.Windows.Forms.ComboBox();
            this.buttonfilter = new System.Windows.Forms.Button();
            this.comboboxtimkiem = new System.Windows.Forms.ComboBox();
            this.buttonxoa = new System.Windows.Forms.Button();
            this.buttontimkiemm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxtimkiem = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelpage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttondau
            // 
            this.buttondau.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttondau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttondau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttondau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttondau.ForeColor = System.Drawing.SystemColors.Window;
            this.buttondau.Location = new System.Drawing.Point(3, 3);
            this.buttondau.Name = "buttondau";
            this.buttondau.Size = new System.Drawing.Size(48, 41);
            this.buttondau.TabIndex = 3;
            this.buttondau.Text = "<<";
            this.buttondau.UseVisualStyleBackColor = false;
            this.buttondau.Click += new System.EventHandler(this.buttontrangdau_Click);
            // 
            // buttonpress
            // 
            this.buttonpress.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonpress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonpress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonpress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonpress.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonpress.Location = new System.Drawing.Point(57, 3);
            this.buttonpress.Name = "buttonpress";
            this.buttonpress.Size = new System.Drawing.Size(48, 41);
            this.buttonpress.TabIndex = 0;
            this.buttonpress.Text = "<";
            this.buttonpress.UseVisualStyleBackColor = false;
            this.buttonpress.Click += new System.EventHandler(this.buttonprevious_Click_1);
            // 
            // buttonnext
            // 
            this.buttonnext.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonnext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonnext.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonnext.Location = new System.Drawing.Point(111, 3);
            this.buttonnext.Name = "buttonnext";
            this.buttonnext.Size = new System.Drawing.Size(48, 41);
            this.buttonnext.TabIndex = 1;
            this.buttonnext.Text = ">";
            this.buttonnext.UseVisualStyleBackColor = false;
            this.buttonnext.Click += new System.EventHandler(this.buttonnext_Click);
            // 
            // buttoncuoi
            // 
            this.buttoncuoi.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttoncuoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttoncuoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoncuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttoncuoi.ForeColor = System.Drawing.SystemColors.Window;
            this.buttoncuoi.Location = new System.Drawing.Point(165, 3);
            this.buttoncuoi.Name = "buttoncuoi";
            this.buttoncuoi.Size = new System.Drawing.Size(48, 41);
            this.buttoncuoi.TabIndex = 2;
            this.buttoncuoi.Text = ">>";
            this.buttoncuoi.UseVisualStyleBackColor = false;
            this.buttoncuoi.Click += new System.EventHandler(this.buttontrangcuoi_Click_2);
            // 
            // buttonthem
            // 
            this.buttonthem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonthem.BackColor = System.Drawing.SystemColors.Window;
            this.buttonthem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonthem.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonthem.FlatAppearance.BorderSize = 3;
            this.buttonthem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonthem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonthem.Location = new System.Drawing.Point(1082, 79);
            this.buttonthem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonthem.Name = "buttonthem";
            this.buttonthem.Size = new System.Drawing.Size(191, 41);
            this.buttonthem.TabIndex = 36;
            this.buttonthem.Text = "Thêm";
            this.buttonthem.UseVisualStyleBackColor = false;
            this.buttonthem.Click += new System.EventHandler(this.buttonthem_Click);
            // 
            // flowLayoutPanelpage
            // 
            this.flowLayoutPanelpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelpage.Controls.Add(this.buttondau);
            this.flowLayoutPanelpage.Controls.Add(this.buttonpress);
            this.flowLayoutPanelpage.Controls.Add(this.buttonnext);
            this.flowLayoutPanelpage.Controls.Add(this.buttoncuoi);
            this.flowLayoutPanelpage.Location = new System.Drawing.Point(785, 574);
            this.flowLayoutPanelpage.Name = "flowLayoutPanelpage";
            this.flowLayoutPanelpage.Size = new System.Drawing.Size(478, 123);
            this.flowLayoutPanelpage.TabIndex = 21;
            this.flowLayoutPanelpage.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.buttonthem);
            this.panel1.Controls.Add(this.flowLayoutPanelpage);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboboxtimkiem);
            this.panel1.Controls.Add(this.buttonxoa);
            this.panel1.Controls.Add(this.buttontimkiemm);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBoxtimkiem);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 697);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panelfilter);
            this.panel2.Controls.Add(this.buttonfilter);
            this.panel2.Location = new System.Drawing.Point(580, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 231);
            this.panel2.TabIndex = 19;
            // 
            // panelfilter
            // 
            this.panelfilter.BackColor = System.Drawing.SystemColors.Window;
            this.panelfilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelfilter.Controls.Add(this.label1);
            this.panelfilter.Controls.Add(this.btnxem);
            this.panelfilter.Controls.Add(this.comboBoxsxlc);
            this.panelfilter.Controls.Add(this.comboBoxsx);
            this.panelfilter.Location = new System.Drawing.Point(3, 43);
            this.panelfilter.MaximumSize = new System.Drawing.Size(490, 175);
            this.panelfilter.Name = "panelfilter";
            this.panelfilter.Size = new System.Drawing.Size(490, 0);
            this.panelfilter.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Sắp xếp";
            // 
            // btnxem
            // 
            this.btnxem.BackColor = System.Drawing.SystemColors.Window;
            this.btnxem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxem.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnxem.FlatAppearance.BorderSize = 3;
            this.btnxem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnxem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnxem.Location = new System.Drawing.Point(184, 105);
            this.btnxem.Margin = new System.Windows.Forms.Padding(4);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(127, 41);
            this.btnxem.TabIndex = 34;
            this.btnxem.Text = "Xem";
            this.btnxem.UseVisualStyleBackColor = false;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // comboBoxsxlc
            // 
            this.comboBoxsxlc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxsxlc.FormattingEnabled = true;
            this.comboBoxsxlc.Items.AddRange(new object[] {
            "MaNCC",
            "TenNCC",
            "SDT",
            "Email",
            "DiaChi"});
            this.comboBoxsxlc.Location = new System.Drawing.Point(3, 53);
            this.comboBoxsxlc.Name = "comboBoxsxlc";
            this.comboBoxsxlc.Size = new System.Drawing.Size(220, 33);
            this.comboBoxsxlc.TabIndex = 1;
            // 
            // comboBoxsx
            // 
            this.comboBoxsx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxsx.FormattingEnabled = true;
            this.comboBoxsx.Items.AddRange(new object[] {
            "Tất cả",
            "Sắp xếp tăng dần",
            "Sắp xếp giảm dần"});
            this.comboBoxsx.Location = new System.Drawing.Point(260, 53);
            this.comboBoxsx.Name = "comboBoxsx";
            this.comboBoxsx.Size = new System.Drawing.Size(223, 33);
            this.comboBoxsx.TabIndex = 0;
            this.comboBoxsx.SelectedIndexChanged += new System.EventHandler(this.comboBoxloaisxtangdanhoacgiamdan_SelectedIndexChanged);
            // 
            // buttonfilter
            // 
            this.buttonfilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonfilter.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonfilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonfilter.FlatAppearance.BorderSize = 0;
            this.buttonfilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonfilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonfilter.Image")));
            this.buttonfilter.Location = new System.Drawing.Point(444, 4);
            this.buttonfilter.Name = "buttonfilter";
            this.buttonfilter.Size = new System.Drawing.Size(49, 34);
            this.buttonfilter.TabIndex = 17;
            this.buttonfilter.UseVisualStyleBackColor = false;
            this.buttonfilter.Click += new System.EventHandler(this.buttonfilter_Click);
            // 
            // comboboxtimkiem
            // 
            this.comboboxtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboboxtimkiem.FormattingEnabled = true;
            this.comboboxtimkiem.Items.AddRange(new object[] {
            "MaNCC",
            "TenNCC",
            "SDT",
            "Email",
            "DiaChi"});
            this.comboboxtimkiem.Location = new System.Drawing.Point(381, 69);
            this.comboboxtimkiem.Name = "comboboxtimkiem";
            this.comboboxtimkiem.Size = new System.Drawing.Size(174, 33);
            this.comboboxtimkiem.TabIndex = 16;
            // 
            // buttonxoa
            // 
            this.buttonxoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonxoa.BackColor = System.Drawing.SystemColors.Window;
            this.buttonxoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonxoa.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonxoa.Location = new System.Drawing.Point(1082, 25);
            this.buttonxoa.Name = "buttonxoa";
            this.buttonxoa.Size = new System.Drawing.Size(191, 38);
            this.buttonxoa.TabIndex = 9;
            this.buttonxoa.Text = "Xóa";
            this.buttonxoa.UseVisualStyleBackColor = false;
            this.buttonxoa.Click += new System.EventHandler(this.buttonxoa_Click);
            // 
            // buttontimkiemm
            // 
            this.buttontimkiemm.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttontimkiemm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttontimkiemm.FlatAppearance.BorderSize = 0;
            this.buttontimkiemm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttontimkiemm.Image = ((System.Drawing.Image)(resources.GetObject("buttontimkiemm.Image")));
            this.buttontimkiemm.Location = new System.Drawing.Point(260, 68);
            this.buttontimkiemm.Name = "buttontimkiemm";
            this.buttontimkiemm.Size = new System.Drawing.Size(49, 36);
            this.buttontimkiemm.TabIndex = 7;
            this.buttontimkiemm.UseVisualStyleBackColor = false;
            this.buttontimkiemm.Click += new System.EventHandler(this.buttontimkiem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(327, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 36);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonrefresh_Click);
            // 
            // textBoxtimkiem
            // 
            this.textBoxtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxtimkiem.Location = new System.Drawing.Point(28, 69);
            this.textBoxtimkiem.Multiline = true;
            this.textBoxtimkiem.Name = "textBoxtimkiem";
            this.textBoxtimkiem.Size = new System.Drawing.Size(238, 33);
            this.textBoxtimkiem.TabIndex = 5;
            this.textBoxtimkiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxtimkiem_KeyPress);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(53, 262);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1210, 306);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nhacungcap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 697);
            this.Controls.Add(this.panel1);
            this.Name = "nhacungcap";
            this.Text = "nhacungcap";
            this.flowLayoutPanelpage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelfilter.ResumeLayout(false);
            this.panelfilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttondau;
        private System.Windows.Forms.Button buttonpress;
        private System.Windows.Forms.Button buttonnext;
        private System.Windows.Forms.Button buttoncuoi;
        private System.Windows.Forms.Button buttonthem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelpage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelfilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnxem;
        private System.Windows.Forms.ComboBox comboBoxsxlc;
        private System.Windows.Forms.ComboBox comboBoxsx;
        private System.Windows.Forms.Button buttonfilter;
        private System.Windows.Forms.ComboBox comboboxtimkiem;
        private System.Windows.Forms.Button buttonxoa;
        private System.Windows.Forms.Button buttontimkiemm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxtimkiem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer1;
    }
}