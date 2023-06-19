namespace CustomerCare
{
    partial class MainForm
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
            this.Lbl_Title = new System.Windows.Forms.Label();
            this.Group_Search = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Btn_ClearFilter = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TxtScr_Name = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbScr_Sex = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtScr_Phone = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Splite_Panel = new System.Windows.Forms.SplitContainer();
            this.Grid_Customer = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Sex = new System.Windows.Forms.ComboBox();
            this.Txt_ID = new System.Windows.Forms.TextBox();
            this.Txt_Name = new System.Windows.Forms.TextBox();
            this.Txt_Region = new System.Windows.Forms.TextBox();
            this.Txt_Phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Memo = new System.Windows.Forms.TextBox();
            this.Group_Buttons = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Btn_New = new System.Windows.Forms.Button();
            this.Group_Search.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splite_Panel)).BeginInit();
            this.Splite_Panel.Panel1.SuspendLayout();
            this.Splite_Panel.Panel2.SuspendLayout();
            this.Splite_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Customer)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Group_Buttons.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Title
            // 
            this.Lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_Title.Font = new System.Drawing.Font("S-Core Dream 9 Black", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.Lbl_Title.Name = "Lbl_Title";
            this.Lbl_Title.Size = new System.Drawing.Size(1849, 100);
            this.Lbl_Title.TabIndex = 0;
            this.Lbl_Title.Text = "고 객 관 리";
            this.Lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Group_Search
            // 
            this.Group_Search.Controls.Add(this.panel5);
            this.Group_Search.Controls.Add(this.Btn_ClearFilter);
            this.Group_Search.Controls.Add(this.groupBox4);
            this.Group_Search.Controls.Add(this.panel3);
            this.Group_Search.Controls.Add(this.groupBox3);
            this.Group_Search.Controls.Add(this.panel2);
            this.Group_Search.Controls.Add(this.groupBox2);
            this.Group_Search.Controls.Add(this.panel1);
            this.Group_Search.Controls.Add(this.panel4);
            this.Group_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.Group_Search.ForeColor = System.Drawing.Color.Gray;
            this.Group_Search.Location = new System.Drawing.Point(0, 100);
            this.Group_Search.Margin = new System.Windows.Forms.Padding(0);
            this.Group_Search.Name = "Group_Search";
            this.Group_Search.Padding = new System.Windows.Forms.Padding(0);
            this.Group_Search.Size = new System.Drawing.Size(1849, 110);
            this.Group_Search.TabIndex = 1;
            this.Group_Search.TabStop = false;
            this.Group_Search.Text = "[ 검색 ]";
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(840, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(729, 79);
            this.panel5.TabIndex = 14;
            // 
            // Btn_ClearFilter
            // 
            this.Btn_ClearFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_ClearFilter.ForeColor = System.Drawing.Color.Teal;
            this.Btn_ClearFilter.Location = new System.Drawing.Point(1569, 31);
            this.Btn_ClearFilter.Name = "Btn_ClearFilter";
            this.Btn_ClearFilter.Size = new System.Drawing.Size(250, 79);
            this.Btn_ClearFilter.TabIndex = 3;
            this.Btn_ClearFilter.Text = "필터지움";
            this.Btn_ClearFilter.UseVisualStyleBackColor = true;
            this.Btn_ClearFilter.Click += new System.EventHandler(this.Btn_ClearFilter_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TxtScr_Name);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(590, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 79);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "이름";
            // 
            // TxtScr_Name
            // 
            this.TxtScr_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtScr_Name.Location = new System.Drawing.Point(3, 34);
            this.TxtScr_Name.Name = "TxtScr_Name";
            this.TxtScr_Name.Size = new System.Drawing.Size(244, 38);
            this.TxtScr_Name.TabIndex = 2;
            this.TxtScr_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(560, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 79);
            this.panel3.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbScr_Sex);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(310, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 79);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "성별";
            // 
            // CmbScr_Sex
            // 
            this.CmbScr_Sex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbScr_Sex.FormattingEnabled = true;
            this.CmbScr_Sex.Location = new System.Drawing.Point(3, 34);
            this.CmbScr_Sex.Name = "CmbScr_Sex";
            this.CmbScr_Sex.Size = new System.Drawing.Size(244, 39);
            this.CmbScr_Sex.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(280, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 79);
            this.panel2.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtScr_Phone);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(30, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 79);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "전화번호";
            // 
            // TxtScr_Phone
            // 
            this.TxtScr_Phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtScr_Phone.Location = new System.Drawing.Point(3, 34);
            this.TxtScr_Phone.Name = "TxtScr_Phone";
            this.TxtScr_Phone.Size = new System.Drawing.Size(244, 38);
            this.TxtScr_Phone.TabIndex = 0;
            this.TxtScr_Phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 79);
            this.panel1.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1819, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(30, 79);
            this.panel4.TabIndex = 13;
            // 
            // Splite_Panel
            // 
            this.Splite_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splite_Panel.Location = new System.Drawing.Point(0, 210);
            this.Splite_Panel.Name = "Splite_Panel";
            // 
            // Splite_Panel.Panel1
            // 
            this.Splite_Panel.Panel1.Controls.Add(this.Grid_Customer);
            // 
            // Splite_Panel.Panel2
            // 
            this.Splite_Panel.Panel2.Controls.Add(this.groupBox5);
            this.Splite_Panel.Panel2.Controls.Add(this.Group_Buttons);
            this.Splite_Panel.Size = new System.Drawing.Size(1849, 683);
            this.Splite_Panel.SplitterDistance = 766;
            this.Splite_Panel.TabIndex = 2;
            // 
            // Grid_Customer
            // 
            this.Grid_Customer.AllowUserToAddRows = false;
            this.Grid_Customer.AllowUserToDeleteRows = false;
            this.Grid_Customer.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Customer.Location = new System.Drawing.Point(0, 0);
            this.Grid_Customer.Name = "Grid_Customer";
            this.Grid_Customer.ReadOnly = true;
            this.Grid_Customer.RowHeadersWidth = 62;
            this.Grid_Customer.RowTemplate.Height = 30;
            this.Grid_Customer.Size = new System.Drawing.Size(766, 683);
            this.Grid_Customer.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1079, 560);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "데이터";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cmb_Sex, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Txt_ID, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Name, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Region, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Phone, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 523);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(26, 43);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label2.Size = new System.Drawing.Size(147, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "성별: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cmb_Sex
            // 
            this.Cmb_Sex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cmb_Sex.FormattingEnabled = true;
            this.Cmb_Sex.Location = new System.Drawing.Point(179, 46);
            this.Cmb_Sex.Name = "Cmb_Sex";
            this.Cmb_Sex.Size = new System.Drawing.Size(351, 39);
            this.Cmb_Sex.TabIndex = 1;
            // 
            // Txt_ID
            // 
            this.Txt_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_ID.Location = new System.Drawing.Point(179, 6);
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.Size = new System.Drawing.Size(351, 38);
            this.Txt_ID.TabIndex = 2;
            this.Txt_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Name
            // 
            this.Txt_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Name.Location = new System.Drawing.Point(689, 6);
            this.Txt_Name.Name = "Txt_Name";
            this.Txt_Name.Size = new System.Drawing.Size(351, 38);
            this.Txt_Name.TabIndex = 3;
            this.Txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Region
            // 
            this.Txt_Region.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Region.Location = new System.Drawing.Point(689, 46);
            this.Txt_Region.Name = "Txt_Region";
            this.Txt_Region.Size = new System.Drawing.Size(351, 38);
            this.Txt_Region.TabIndex = 4;
            this.Txt_Region.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Phone
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Txt_Phone, 3);
            this.Txt_Phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Phone.Location = new System.Drawing.Point(179, 86);
            this.Txt_Phone.Name = "Txt_Phone";
            this.Txt_Phone.Size = new System.Drawing.Size(861, 38);
            this.Txt_Phone.TabIndex = 5;
            this.Txt_Phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(26, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label3.Size = new System.Drawing.Size(147, 40);
            this.label3.TabIndex = 6;
            this.label3.Text = "고객코드: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(536, 3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label4.Size = new System.Drawing.Size(147, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "성명: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(26, 83);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label5.Size = new System.Drawing.Size(147, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "전화번호: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(536, 43);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label6.Size = new System.Drawing.Size(147, 40);
            this.label6.TabIndex = 9;
            this.label6.Text = "지역: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.Txt_Memo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(26, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 391);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "비고";
            // 
            // Txt_Memo
            // 
            this.Txt_Memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Memo.Location = new System.Drawing.Point(3, 34);
            this.Txt_Memo.Multiline = true;
            this.Txt_Memo.Name = "Txt_Memo";
            this.Txt_Memo.Size = new System.Drawing.Size(1008, 354);
            this.Txt_Memo.TabIndex = 0;
            // 
            // Group_Buttons
            // 
            this.Group_Buttons.Controls.Add(this.tableLayoutPanel2);
            this.Group_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Group_Buttons.Location = new System.Drawing.Point(0, 560);
            this.Group_Buttons.Name = "Group_Buttons";
            this.Group_Buttons.Size = new System.Drawing.Size(1079, 123);
            this.Group_Buttons.TabIndex = 0;
            this.Group_Buttons.TabStop = false;
            this.Group_Buttons.Text = "신규 / 수정 / 삭제 / 자료갱신";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.Btn_Save, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Delete, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Update, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_New, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1073, 86);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Save.Font = new System.Drawing.Font("S-Core Dream 5 Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Save.Location = new System.Drawing.Point(797, 3);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(252, 80);
            this.Btn_Save.TabIndex = 3;
            this.Btn_Save.Text = "Save (2)";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Delete.Font = new System.Drawing.Font("S-Core Dream 5 Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Btn_Delete.Location = new System.Drawing.Point(539, 3);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(252, 80);
            this.Btn_Delete.TabIndex = 2;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Update
            // 
            this.Btn_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Update.Font = new System.Drawing.Font("S-Core Dream 5 Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Btn_Update.Location = new System.Drawing.Point(281, 3);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(252, 80);
            this.Btn_Update.TabIndex = 1;
            this.Btn_Update.Text = "Update";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Btn_New
            // 
            this.Btn_New.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_New.Font = new System.Drawing.Font("S-Core Dream 5 Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_New.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Btn_New.Location = new System.Drawing.Point(23, 3);
            this.Btn_New.Name = "Btn_New";
            this.Btn_New.Size = new System.Drawing.Size(252, 80);
            this.Btn_New.TabIndex = 0;
            this.Btn_New.Text = "Add New (1)";
            this.Btn_New.UseVisualStyleBackColor = true;
            this.Btn_New.Click += new System.EventHandler(this.Btn_New_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1849, 893);
            this.Controls.Add(this.Splite_Panel);
            this.Controls.Add(this.Group_Search);
            this.Controls.Add(this.Lbl_Title);
            this.Font = new System.Drawing.Font("S-Core Dream 5 Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "고객관리";
            this.Group_Search.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Splite_Panel.Panel1.ResumeLayout(false);
            this.Splite_Panel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splite_Panel)).EndInit();
            this.Splite_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Customer)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Group_Buttons.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Title;
        private System.Windows.Forms.GroupBox Group_Search;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtScr_Name;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbScr_Sex;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtScr_Phone;
        private System.Windows.Forms.Button Btn_ClearFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer Splite_Panel;
        private System.Windows.Forms.DataGridView Grid_Customer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_Sex;
        private System.Windows.Forms.TextBox Txt_ID;
        private System.Windows.Forms.TextBox Txt_Name;
        private System.Windows.Forms.TextBox Txt_Region;
        private System.Windows.Forms.TextBox Txt_Phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox Group_Buttons;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Button Btn_New;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_Memo;
    }
}

