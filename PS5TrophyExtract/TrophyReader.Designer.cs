
namespace PS5TrophyExtract
{
    partial class TrophyReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrophyReader));
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.openTrophys = new System.Windows.Forms.Button();
            this.trophyDataFiles = new System.Windows.Forms.ListBox();
            this.extractFile = new System.Windows.Forms.Button();
            this.extractAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("previewBox.ErrorImage")));
            this.previewBox.Location = new System.Drawing.Point(12, 12);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(510, 473);
            this.previewBox.TabIndex = 1;
            this.previewBox.TabStop = false;
            // 
            // openTrophys
            // 
            this.openTrophys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openTrophys.Location = new System.Drawing.Point(12, 694);
            this.openTrophys.Name = "openTrophys";
            this.openTrophys.Size = new System.Drawing.Size(510, 23);
            this.openTrophys.TabIndex = 2;
            this.openTrophys.Text = "Open trophy00.ucp";
            this.openTrophys.UseVisualStyleBackColor = true;
            this.openTrophys.Click += new System.EventHandler(this.openTrophys_Click);
            // 
            // trophyDataFiles
            // 
            this.trophyDataFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trophyDataFiles.FormattingEnabled = true;
            this.trophyDataFiles.Location = new System.Drawing.Point(12, 491);
            this.trophyDataFiles.Name = "trophyDataFiles";
            this.trophyDataFiles.Size = new System.Drawing.Size(510, 134);
            this.trophyDataFiles.TabIndex = 3;
            this.trophyDataFiles.SelectedIndexChanged += new System.EventHandler(this.trophyDataFiles_SelectedIndexChanged);
            // 
            // extractFile
            // 
            this.extractFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractFile.Enabled = false;
            this.extractFile.Location = new System.Drawing.Point(12, 636);
            this.extractFile.Name = "extractFile";
            this.extractFile.Size = new System.Drawing.Size(510, 23);
            this.extractFile.TabIndex = 4;
            this.extractFile.Text = "Extract File";
            this.extractFile.UseVisualStyleBackColor = true;
            this.extractFile.Click += new System.EventHandler(this.extractFile_Click);
            // 
            // extractAll
            // 
            this.extractAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractAll.Enabled = false;
            this.extractAll.Location = new System.Drawing.Point(12, 665);
            this.extractAll.Name = "extractAll";
            this.extractAll.Size = new System.Drawing.Size(510, 23);
            this.extractAll.TabIndex = 5;
            this.extractAll.Text = "Extract All Files";
            this.extractAll.UseVisualStyleBackColor = true;
            this.extractAll.Click += new System.EventHandler(this.extractAll_Click);
            // 
            // TrophyReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 723);
            this.Controls.Add(this.extractAll);
            this.Controls.Add(this.extractFile);
            this.Controls.Add(this.trophyDataFiles);
            this.Controls.Add(this.openTrophys);
            this.Controls.Add(this.previewBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrophyReader";
            this.Text = "Trophy Data Reader";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Button openTrophys;
        private System.Windows.Forms.ListBox trophyDataFiles;
        private System.Windows.Forms.Button extractFile;
        private System.Windows.Forms.Button extractAll;
    }
}

