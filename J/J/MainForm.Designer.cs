namespace J
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            textEdit1 = new TextEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            comboBoxEdit1 = new ComboBoxEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            dateEdit1 = new DateEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            pictureEdit1 = new PictureEdit();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            memoEdit1 = new MemoEdit();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(textEdit1);
            layoutControl1.Controls.Add(comboBoxEdit1);
            layoutControl1.Controls.Add(dateEdit1);
            layoutControl1.Controls.Add(pictureEdit1);
            layoutControl1.Controls.Add(memoEdit1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1053, 470);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem4, layoutControlItem5, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new Size(1053, 470);
            Root.TextVisible = false;
            // 
            // textEdit1
            // 
            textEdit1.Location = new Point(176, 12);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new Size(176, 28);
            textEdit1.StyleController = layoutControl1;
            textEdit1.TabIndex = 0;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = textEdit1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(344, 32);
            layoutControlItem1.TextSize = new Size(152, 22);
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.Location = new Point(520, 12);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit1.Size = new Size(176, 28);
            comboBoxEdit1.StyleController = layoutControl1;
            comboBoxEdit1.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = comboBoxEdit1;
            layoutControlItem2.Location = new Point(344, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(344, 32);
            layoutControlItem2.TextSize = new Size(152, 22);
            // 
            // dateEdit1
            // 
            dateEdit1.EditValue = null;
            dateEdit1.Location = new Point(864, 12);
            dateEdit1.Name = "dateEdit1";
            dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Size = new Size(177, 28);
            dateEdit1.StyleController = layoutControl1;
            dateEdit1.TabIndex = 3;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = dateEdit1;
            layoutControlItem3.Location = new Point(688, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(345, 32);
            layoutControlItem3.TextSize = new Size(152, 22);
            // 
            // pictureEdit1
            // 
            pictureEdit1.Location = new Point(176, 44);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Size = new Size(865, 264);
            pictureEdit1.StyleController = layoutControl1;
            pictureEdit1.TabIndex = 1;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = pictureEdit1;
            layoutControlItem4.Location = new Point(0, 32);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(1033, 268);
            layoutControlItem4.TextSize = new Size(152, 22);
            // 
            // memoEdit1
            // 
            memoEdit1.Location = new Point(176, 312);
            memoEdit1.Name = "memoEdit1";
            memoEdit1.Size = new Size(865, 146);
            memoEdit1.StyleController = layoutControl1;
            memoEdit1.TabIndex = 4;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = memoEdit1;
            layoutControlItem5.Location = new Point(0, 300);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(1033, 150);
            layoutControlItem5.TextSize = new Size(152, 22);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 470);
            Controls.Add(layoutControl1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private TextEdit textEdit1;
        private ComboBoxEdit comboBoxEdit1;
        private DateEdit dateEdit1;
        private PictureEdit pictureEdit1;
        private MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

