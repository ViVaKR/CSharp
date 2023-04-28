namespace VivProcess
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
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Lbl_Status = new System.Windows.Forms.Label();
            this.Btn_KillProcess = new System.Windows.Forms.Button();
            this.Grp_ControlBox = new System.Windows.Forms.GroupBox();
            this.Grp_ControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Start.Location = new System.Drawing.Point(284, 37);
            this.Btn_Start.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(609, 66);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start Process Watcher";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Lbl_Status
            // 
            this.Lbl_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Status.Font = new System.Drawing.Font("KoPubWorldDotum Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_Status.Location = new System.Drawing.Point(0, 0);
            this.Lbl_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Status.Name = "Lbl_Status";
            this.Lbl_Status.Size = new System.Drawing.Size(896, 344);
            this.Lbl_Status.TabIndex = 1;
            this.Lbl_Status.Text = "...";
            this.Lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_KillProcess
            // 
            this.Btn_KillProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_KillProcess.Location = new System.Drawing.Point(3, 37);
            this.Btn_KillProcess.Name = "Btn_KillProcess";
            this.Btn_KillProcess.Size = new System.Drawing.Size(281, 66);
            this.Btn_KillProcess.TabIndex = 2;
            this.Btn_KillProcess.Text = "Kill Process";
            this.Btn_KillProcess.UseVisualStyleBackColor = true;
            this.Btn_KillProcess.Click += new System.EventHandler(this.Btn_KillProcess_Click);
            // 
            // Grp_ControlBox
            // 
            this.Grp_ControlBox.Controls.Add(this.Btn_Start);
            this.Grp_ControlBox.Controls.Add(this.Btn_KillProcess);
            this.Grp_ControlBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Grp_ControlBox.Location = new System.Drawing.Point(0, 344);
            this.Grp_ControlBox.Name = "Grp_ControlBox";
            this.Grp_ControlBox.Size = new System.Drawing.Size(896, 106);
            this.Grp_ControlBox.TabIndex = 3;
            this.Grp_ControlBox.TabStop = false;
            this.Grp_ControlBox.Text = "컨트롤";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Controls.Add(this.Lbl_Status);
            this.Controls.Add(this.Grp_ControlBox);
            this.Font = new System.Drawing.Font("KoPubWorldDotum Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Grp_ControlBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Label Lbl_Status;
        private System.Windows.Forms.Button Btn_KillProcess;
        private System.Windows.Forms.GroupBox Grp_ControlBox;
    }
}

