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
            this.lbDLL = new System.Windows.Forms.Label();
            this.txtDLL = new System.Windows.Forms.TextBox();
            this.lbOther = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinutesForDeleteUpdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMinutesForUpdate
            // 
            this.txtMinutesForUpdate.Location = new System.Drawing.Point(156, 9);
            this.txtMinutesForUpdate.MaxLength = 2;
            this.txtMinutesForUpdate.Name = "txtMinutesForUpdate";
            this.txtMinutesForUpdate.Size = new System.Drawing.Size(36, 23);
            this.txtMinutesForUpdate.TabIndex = 0;
            // 
            // lbMinutes
            // 
            this.lbMinutes.Location = new System.Drawing.Point(3, 9);
            this.lbMinutes.Name = "lbMinutes";
            this.lbMinutes.Size = new System.Drawing.Size(147, 23);
            this.lbMinutes.TabIndex = 1;
            this.lbMinutes.Text = "Ponovi update za";
            this.lbMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(296, 136);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Upisati";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbDLL
            // 
            this.lbDLL.Location = new System.Drawing.Point(3, 63);
            this.lbDLL.Name = "lbDLL";
            this.lbDLL.Size = new System.Drawing.Size(147, 23);
            this.lbDLL.TabIndex = 4;
            this.lbDLL.Text = "Putanja do DLL fajlova";
            this.lbDLL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDLL
            // 
            this.txtDLL.Location = new System.Drawing.Point(156, 63);
            this.txtDLL.MaxLength = 4000;
            this.txtDLL.Name = "txtDLL";
            this.txtDLL.Size = new System.Drawing.Size(599, 23);
            this.txtDLL.TabIndex = 3;
            // 
            // lbOther
            // 
            this.lbOther.Location = new System.Drawing.Point(3, 90);
            this.lbOther.Name = "lbOther";
            this.lbOther.Size = new System.Drawing.Size(147, 23);
            this.lbOther.TabIndex = 5;
            this.lbOther.Text = "Putanja do ostalih fajlova";
            this.lbOther.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(156, 90);
            this.txtOther.MaxLength = 4000;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(599, 23);
            this.txtOther.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(377, 136);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Odustati";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Brisanje fajlova za update svakih";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMinutesForDeleteUpdate
            // 
            this.txtMinutesForDeleteUpdate.Location = new System.Drawing.Point(156, 36);
            this.txtMinutesForDeleteUpdate.MaxLength = 2;
            this.txtMinutesForDeleteUpdate.Name = "txtMinutesForDeleteUpdate";
            this.txtMinutesForDeleteUpdate.Size = new System.Drawing.Size(36, 23);
            this.txtMinutesForDeleteUpdate.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(196, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "minuta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(196, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "minuta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmImelUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 171);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMinutesForDeleteUpdate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtOther);
            this.Controls.Add(this.lbOther);
            this.Controls.Add(this.lbDLL);
            this.Controls.Add(this.txtDLL);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lbMinutes);
            this.Controls.Add(this.txtMinutesForUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImelUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imel Update";
            this.Load += new System.EventHandler(this.frmImelUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtMinutesForUpdate;
        private Label lbMinutes;
        private Button btnAccept;
        private Label lbDLL;
        private TextBox txtDLL;
        private Label lbOther;
        private TextBox txtOther;
        private Button btnExit;
        private Label label1;
        private TextBox txtMinutesForDeleteUpdate;
        private Label label2;
        private Label label3;
    }
}