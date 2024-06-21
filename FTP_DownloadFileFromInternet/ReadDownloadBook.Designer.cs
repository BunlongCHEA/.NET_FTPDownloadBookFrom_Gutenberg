namespace FTP_DownloadFileFromInternet
{
    partial class ReadDownloadBook
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
            this.readContent = new System.Windows.Forms.RichTextBox();
            this.download_btn = new System.Windows.Forms.Button();
            this.coverPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.coverPic)).BeginInit();
            this.SuspendLayout();
            // 
            // readContent
            // 
            this.readContent.Location = new System.Drawing.Point(296, 12);
            this.readContent.Name = "readContent";
            this.readContent.ReadOnly = true;
            this.readContent.Size = new System.Drawing.Size(811, 525);
            this.readContent.TabIndex = 0;
            this.readContent.Text = "";
            // 
            // download_btn
            // 
            this.download_btn.Location = new System.Drawing.Point(12, 433);
            this.download_btn.Name = "download_btn";
            this.download_btn.Size = new System.Drawing.Size(264, 44);
            this.download_btn.TabIndex = 2;
            this.download_btn.Text = "Download";
            this.download_btn.UseVisualStyleBackColor = true;
            this.download_btn.Click += new System.EventHandler(this.download_btn_Click);
            // 
            // coverPic
            // 
            this.coverPic.Location = new System.Drawing.Point(12, 13);
            this.coverPic.Name = "coverPic";
            this.coverPic.Size = new System.Drawing.Size(264, 365);
            this.coverPic.TabIndex = 3;
            this.coverPic.TabStop = false;
            // 
            // ReadDownloadBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 549);
            this.Controls.Add(this.coverPic);
            this.Controls.Add(this.download_btn);
            this.Controls.Add(this.readContent);
            this.Name = "ReadDownloadBook";
            this.Text = "ReadDownloadBook";
            ((System.ComponentModel.ISupportInitialize)(this.coverPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox readContent;
        private System.Windows.Forms.Button download_btn;
        private System.Windows.Forms.PictureBox coverPic;
    }
}