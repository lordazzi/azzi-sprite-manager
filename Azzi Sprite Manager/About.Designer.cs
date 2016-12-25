namespace Azzi_Sprite_Manager
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.donation = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 158);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Developed by Lord Azzi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 91);
            this.label3.TabIndex = 3;
            this.label3.Text = "A guerra dos seres humanos\r\nnão é um contra o outro, mas\r\nde cada um contra si me" +
                "smo,\r\ncom o objetivo de nos livrarmos\r\nda escravidão da maldade e do\r\negoísmo im" +
                "pregnado em\r\nnossos espíritos.\r\n";
            // 
            // donation
            // 
            this.donation.ActiveLinkColor = System.Drawing.Color.Blue;
            this.donation.AutoSize = true;
            this.donation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.donation.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.donation.LinkColor = System.Drawing.Color.Blue;
            this.donation.Location = new System.Drawing.Point(166, 126);
            this.donation.Name = "donation";
            this.donation.Size = new System.Drawing.Size(77, 20);
            this.donation.TabIndex = 4;
            this.donation.TabStop = true;
            this.donation.Text = "DOAÇÃO (:";
            this.donation.VisitedLinkColor = System.Drawing.Color.Blue;
            this.donation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.donation_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 191);
            this.Controls.Add(this.donation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(293, 215);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(293, 215);
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About :: Azzi Sprite Manager 1.0";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel donation;
    }
}