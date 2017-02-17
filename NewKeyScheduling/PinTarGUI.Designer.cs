namespace NewKeyScheduling
{
    partial class PinTarGUI
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtPlainText = new System.Windows.Forms.RichTextBox();
            this.btKeyStream = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtoutputKey = new System.Windows.Forms.RichTextBox();
            this.cbNumber = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RTauthenticationMessage = new System.Windows.Forms.RichTextBox();
            this.btcompareMessage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rthashDigest = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 421);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtPlainText);
            this.tabPage1.Controls.Add(this.btKeyStream);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.rtoutputKey);
            this.tabPage1.Controls.Add(this.cbNumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(738, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Message Digest Generation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtPlainText
            // 
            this.rtPlainText.Location = new System.Drawing.Point(152, 29);
            this.rtPlainText.Name = "rtPlainText";
            this.rtPlainText.Size = new System.Drawing.Size(521, 90);
            this.rtPlainText.TabIndex = 15;
            this.rtPlainText.Text = "";
            // 
            // btKeyStream
            // 
            this.btKeyStream.Location = new System.Drawing.Point(505, 143);
            this.btKeyStream.Name = "btKeyStream";
            this.btKeyStream.Size = new System.Drawing.Size(168, 21);
            this.btKeyStream.TabIndex = 14;
            this.btKeyStream.Text = "Generate Hash Digest";
            this.btKeyStream.UseVisualStyleBackColor = true;
            this.btKeyStream.Click += new System.EventHandler(this.btKeyStream_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hash Digest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Output Hash Digest size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enter Message";
            // 
            // rtoutputKey
            // 
            this.rtoutputKey.Location = new System.Drawing.Point(152, 200);
            this.rtoutputKey.Name = "rtoutputKey";
            this.rtoutputKey.Size = new System.Drawing.Size(521, 63);
            this.rtoutputKey.TabIndex = 10;
            this.rtoutputKey.Text = "";
            // 
            // cbNumber
            // 
            this.cbNumber.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.cbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumber.FormattingEnabled = true;
            this.cbNumber.Items.AddRange(new object[] {
            "512",
            "256",
            "128"});
            this.cbNumber.Location = new System.Drawing.Point(328, 142);
            this.cbNumber.Name = "cbNumber";
            this.cbNumber.Size = new System.Drawing.Size(89, 21);
            this.cbNumber.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RTauthenticationMessage);
            this.tabPage2.Controls.Add(this.btcompareMessage);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.rthashDigest);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message Authentication";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RTauthenticationMessage
            // 
            this.RTauthenticationMessage.Location = new System.Drawing.Point(140, 32);
            this.RTauthenticationMessage.Name = "RTauthenticationMessage";
            this.RTauthenticationMessage.Size = new System.Drawing.Size(565, 92);
            this.RTauthenticationMessage.TabIndex = 21;
            this.RTauthenticationMessage.Text = "";
            // 
            // btcompareMessage
            // 
            this.btcompareMessage.Location = new System.Drawing.Point(556, 252);
            this.btcompareMessage.Name = "btcompareMessage";
            this.btcompareMessage.Size = new System.Drawing.Size(149, 23);
            this.btcompareMessage.TabIndex = 20;
            this.btcompareMessage.Text = "Compare\r\n";
            this.btcompareMessage.UseVisualStyleBackColor = true;
            this.btcompareMessage.Click += new System.EventHandler(this.btcompareMessage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Hash Digest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Enter Message";
            // 
            // rthashDigest
            // 
            this.rthashDigest.Location = new System.Drawing.Point(140, 147);
            this.rthashDigest.Name = "rthashDigest";
            this.rthashDigest.Size = new System.Drawing.Size(565, 65);
            this.rthashDigest.TabIndex = 16;
            this.rthashDigest.Text = "";
            // 
            // PinTarGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 421);
            this.Controls.Add(this.tabControl1);
            this.Name = "PinTarGUI";
            this.Text = "PinTarGUI";
            this.Load += new System.EventHandler(this.PinTarGUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtPlainText;
        private System.Windows.Forms.Button btKeyStream;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtoutputKey;
        private System.Windows.Forms.ComboBox cbNumber;
        private System.Windows.Forms.RichTextBox RTauthenticationMessage;
        private System.Windows.Forms.Button btcompareMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rthashDigest;
    }
}