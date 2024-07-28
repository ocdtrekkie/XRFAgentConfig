namespace XRFAgentConfig
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            Database_FileURI = new TextBox();
            label3 = new Label();
            Sync_ServerURL = new TextBox();
            label4 = new Label();
            Sync_SandstormToken = new TextBox();
            label5 = new Label();
            Sync_AccessKey = new TextBox();
            SaveBtn = new Button();
            LoadBtn = new Button();
            label6 = new Label();
            lblServiceStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rubik", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(566, 44);
            label1.TabIndex = 0;
            label1.Text = "XRF Agent Configuration Tool";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 1;
            label2.Text = "Database File:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Database_FileURI
            // 
            Database_FileURI.Location = new Point(147, 73);
            Database_FileURI.Name = "Database_FileURI";
            Database_FileURI.Size = new Size(431, 23);
            Database_FileURI.TabIndex = 2;
            Database_FileURI.Text = "C:\\HAC\\HACdb.sqlite";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 177);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 3;
            label3.Text = "Sync Server URL:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Sync_ServerURL
            // 
            Sync_ServerURL.Location = new Point(147, 174);
            Sync_ServerURL.Name = "Sync_ServerURL";
            Sync_ServerURL.Size = new Size(431, 23);
            Sync_ServerURL.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 207);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 5;
            label4.Text = "Sandstorm Token:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Sync_SandstormToken
            // 
            Sync_SandstormToken.Location = new Point(147, 204);
            Sync_SandstormToken.Name = "Sync_SandstormToken";
            Sync_SandstormToken.Size = new Size(431, 23);
            Sync_SandstormToken.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 238);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 7;
            label5.Text = "Sync Access Key:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Sync_AccessKey
            // 
            Sync_AccessKey.Location = new Point(147, 235);
            Sync_AccessKey.Name = "Sync_AccessKey";
            Sync_AccessKey.Size = new Size(431, 23);
            Sync_AccessKey.TabIndex = 8;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(503, 264);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 9;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // LoadBtn
            // 
            LoadBtn.Location = new Point(503, 102);
            LoadBtn.Name = "LoadBtn";
            LoadBtn.Size = new Size(75, 23);
            LoadBtn.TabIndex = 10;
            LoadBtn.Text = "Load";
            LoadBtn.UseVisualStyleBackColor = true;
            LoadBtn.Click += LoadBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Rubik", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(147, 143);
            label6.Name = "label6";
            label6.Size = new Size(56, 23);
            label6.TabIndex = 11;
            label6.Text = "Sync";
            // 
            // lblServiceStatus
            // 
            lblServiceStatus.AutoSize = true;
            lblServiceStatus.Location = new Point(12, 319);
            lblServiceStatus.Name = "lblServiceStatus";
            lblServiceStatus.Size = new Size(79, 15);
            lblServiceStatus.TabIndex = 12;
            lblServiceStatus.Text = "Service Status";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 357);
            Controls.Add(lblServiceStatus);
            Controls.Add(label6);
            Controls.Add(LoadBtn);
            Controls.Add(SaveBtn);
            Controls.Add(Sync_AccessKey);
            Controls.Add(label5);
            Controls.Add(Sync_SandstormToken);
            Controls.Add(label4);
            Controls.Add(Sync_ServerURL);
            Controls.Add(label3);
            Controls.Add(Database_FileURI);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "XRF Agent Configuration Tool";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Database_FileURI;
        private Label label3;
        private TextBox Sync_ServerURL;
        private Label label4;
        private TextBox Sync_SandstormToken;
        private Label label5;
        private TextBox Sync_AccessKey;
        private Button SaveBtn;
        private Button LoadBtn;
        private Label label6;
        private Label lblServiceStatus;
    }
}
