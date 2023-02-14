namespace Application
{
    partial class frmImelUpdate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMinutesForUpdate = new System.Windows.Forms.TextBox();
            this.lbMinutes = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbDLLServer = new System.Windows.Forms.Label();
            this.txtDLL = new System.Windows.Forms.TextBox();
            this.lbOtherServer = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinutesForDeleteUpdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDLL = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.gbLocal = new System.Windows.Forms.GroupBox();
            this.btnOtherLocal = new System.Windows.Forms.Button();
            this.btnDLLLocal = new System.Windows.Forms.Button();
            this.txtOtherLocal = new System.Windows.Forms.TextBox();
            this.lbOtherLocal = new System.Windows.Forms.Label();
            this.lbDLLLocal = new System.Windows.Forms.Label();
            this.txtDLLLocal = new System.Windows.Forms.TextBox();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.gbLocal.SuspendLayout();
            this.gbServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMinutesForUpdate
            // 
            this.txtMinutesForUpdate.Location = new System.Drawing.Point(175, 22);
            this.txtMinutesForUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMinutesForUpdate.MaxLength = 2;
            this.txtMinutesForUpdate.Name = "txtMinutesForUpdate";
            this.txtMinutesForUpdate.Size = new System.Drawing.Size(41, 27);
            this.txtMinutesForUpdate.TabIndex = 0;
            this.txtMinutesForUpdate.TextChanged += new System.EventHandler(this.txtMinutesForUpdate_TextChanged);
            // 
            // lbMinutes
            // 
            this.lbMinutes.Location = new System.Drawing.Point(0, 22);
            this.lbMinutes.Name = "lbMinutes";
            this.lbMinutes.Size = new System.Drawing.Size(168, 31);
            this.lbMinutes.TabIndex = 1;
            this.lbMinutes.Text = "Ponovi update za";
            this.lbMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(327, 300);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(86, 31);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Upisati";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbDLLServer
            // 
            this.lbDLLServer.Location = new System.Drawing.Point(0, 94);
            this.lbDLLServer.Name = "lbDLLServer";
            this.lbDLLServer.Size = new System.Drawing.Size(168, 31);
            this.lbDLLServer.TabIndex = 4;
            this.lbDLLServer.Text = "Putanja do DLL fajlova";
            this.lbDLLServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDLL
            // 
            this.txtDLL.Location = new System.Drawing.Point(175, 94);
            this.txtDLL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDLL.MaxLength = 4000;
            this.txtDLL.Name = "txtDLL";
            this.txtDLL.Size = new System.Drawing.Size(605, 27);
            this.txtDLL.TabIndex = 2;
            this.txtDLL.TextChanged += new System.EventHandler(this.txtDLL_TextChanged);
            // 
            // lbOtherServer
            // 
            this.lbOtherServer.Location = new System.Drawing.Point(0, 130);
            this.lbOtherServer.Name = "lbOtherServer";
            this.lbOtherServer.Size = new System.Drawing.Size(168, 31);
            this.lbOtherServer.TabIndex = 5;
            this.lbOtherServer.Text = "Putanja do ostalih fajlova";
            this.lbOtherServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(175, 130);
            this.txtOther.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOther.MaxLength = 4000;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(605, 27);
            this.txtOther.TabIndex = 3;
            this.txtOther.TextChanged += new System.EventHandler(this.txtOther_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(420, 300);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 31);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Odustati";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Brisanje fajlova za update svakih";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMinutesForDeleteUpdate
            // 
            this.txtMinutesForDeleteUpdate.Location = new System.Drawing.Point(175, 58);
            this.txtMinutesForDeleteUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMinutesForDeleteUpdate.MaxLength = 2;
            this.txtMinutesForDeleteUpdate.Name = "txtMinutesForDeleteUpdate";
            this.txtMinutesForDeleteUpdate.Size = new System.Drawing.Size(41, 27);
            this.txtMinutesForDeleteUpdate.TabIndex = 1;
            this.txtMinutesForDeleteUpdate.TextChanged += new System.EventHandler(this.txtMinutesForDeleteUpdate_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(221, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "minuta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(221, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "minuta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDLL
            // 
            this.btnDLL.Location = new System.Drawing.Point(788, 94);
            this.btnDLL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDLL.Name = "btnDLL";
            this.btnDLL.Size = new System.Drawing.Size(63, 31);
            this.btnDLL.TabIndex = 12;
            this.btnDLL.Text = "PATH";
            this.btnDLL.UseVisualStyleBackColor = true;
            this.btnDLL.Click += new System.EventHandler(this.btnDLL_Click);
            // 
            // btnOther
            // 
            this.btnOther.Location = new System.Drawing.Point(788, 129);
            this.btnOther.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(63, 31);
            this.btnOther.TabIndex = 13;
            this.btnOther.Text = "PATH";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // gbLocal
            // 
            this.gbLocal.Controls.Add(this.btnOtherLocal);
            this.gbLocal.Controls.Add(this.btnDLLLocal);
            this.gbLocal.Controls.Add(this.txtOtherLocal);
            this.gbLocal.Controls.Add(this.lbOtherLocal);
            this.gbLocal.Controls.Add(this.lbDLLLocal);
            this.gbLocal.Controls.Add(this.txtDLLLocal);
            this.gbLocal.Location = new System.Drawing.Point(4, 191);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Size = new System.Drawing.Size(852, 102);
            this.gbLocal.TabIndex = 14;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "Lokalno";
            // 
            // btnOtherLocal
            // 
            this.btnOtherLocal.Location = new System.Drawing.Point(788, 62);
            this.btnOtherLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOtherLocal.Name = "btnOtherLocal";
            this.btnOtherLocal.Size = new System.Drawing.Size(63, 31);
            this.btnOtherLocal.TabIndex = 19;
            this.btnOtherLocal.Text = "PATH";
            this.btnOtherLocal.UseVisualStyleBackColor = true;
            this.btnOtherLocal.Click += new System.EventHandler(this.btnOtherLocal_Click);
            // 
            // btnDLLLocal
            // 
            this.btnDLLLocal.Location = new System.Drawing.Point(788, 27);
            this.btnDLLLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDLLLocal.Name = "btnDLLLocal";
            this.btnDLLLocal.Size = new System.Drawing.Size(63, 31);
            this.btnDLLLocal.TabIndex = 18;
            this.btnDLLLocal.Text = "PATH";
            this.btnDLLLocal.UseVisualStyleBackColor = true;
            this.btnDLLLocal.Click += new System.EventHandler(this.btnDLLLocal_Click);
            // 
            // txtOtherLocal
            // 
            this.txtOtherLocal.Location = new System.Drawing.Point(175, 63);
            this.txtOtherLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOtherLocal.MaxLength = 4000;
            this.txtOtherLocal.Name = "txtOtherLocal";
            this.txtOtherLocal.Size = new System.Drawing.Size(605, 27);
            this.txtOtherLocal.TabIndex = 5;
            // 
            // lbOtherLocal
            // 
            this.lbOtherLocal.Location = new System.Drawing.Point(0, 63);
            this.lbOtherLocal.Name = "lbOtherLocal";
            this.lbOtherLocal.Size = new System.Drawing.Size(168, 31);
            this.lbOtherLocal.TabIndex = 16;
            this.lbOtherLocal.Text = "Putanja do ostalih fajlova";
            this.lbOtherLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDLLLocal
            // 
            this.lbDLLLocal.Location = new System.Drawing.Point(0, 27);
            this.lbDLLLocal.Name = "lbDLLLocal";
            this.lbDLLLocal.Size = new System.Drawing.Size(168, 31);
            this.lbDLLLocal.TabIndex = 15;
            this.lbDLLLocal.Text = "Putanja do DLL fajlova";
            this.lbDLLLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDLLLocal
            // 
            this.txtDLLLocal.Location = new System.Drawing.Point(175, 27);
            this.txtDLLLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDLLLocal.MaxLength = 4000;
            this.txtDLLLocal.Name = "txtDLLLocal";
            this.txtDLLLocal.Size = new System.Drawing.Size(605, 27);
            this.txtDLLLocal.TabIndex = 4;
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.txtDLL);
            this.gbServer.Controls.Add(this.txtMinutesForUpdate);
            this.gbServer.Controls.Add(this.btnOther);
            this.gbServer.Controls.Add(this.lbMinutes);
            this.gbServer.Controls.Add(this.btnDLL);
            this.gbServer.Controls.Add(this.lbDLLServer);
            this.gbServer.Controls.Add(this.label3);
            this.gbServer.Controls.Add(this.lbOtherServer);
            this.gbServer.Controls.Add(this.label2);
            this.gbServer.Controls.Add(this.txtOther);
            this.gbServer.Controls.Add(this.label1);
            this.gbServer.Controls.Add(this.txtMinutesForDeleteUpdate);
            this.gbServer.Location = new System.Drawing.Point(4, 12);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(851, 173);
            this.gbServer.TabIndex = 15;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Server";
            // 
            // frmImelUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 336);
            this.Controls.Add(this.gbServer);
            this.Controls.Add(this.gbLocal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImelUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imel Update";
            this.Load += new System.EventHandler(this.frmImelUpdate_Load);
            this.gbLocal.ResumeLayout(false);
            this.gbLocal.PerformLayout();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtMinutesForUpdate;
        private Label lbMinutes;
        private Button btnAccept;
        private Label lbDLLServer;
        private TextBox txtDLL;
        private Label lbOtherServer;
        private TextBox txtOther;
        private Button btnExit;
        private Label label1;
        private TextBox txtMinutesForDeleteUpdate;
        private Label label2;
        private Label label3;
        private Button btnDLL;
        private Button btnOther;
        private GroupBox gbLocal;
        private Button btnOtherLocal;
        private Button btnDLLLocal;
        private TextBox txtOtherLocal;
        private Label lbOtherLocal;
        private Label lbDLLLocal;
        private TextBox txtDLLLocal;
        private GroupBox gbServer;
    }
}