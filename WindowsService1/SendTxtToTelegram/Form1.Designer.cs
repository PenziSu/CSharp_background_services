namespace SendTxtToTelegram
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.MsgFrom = new System.Windows.Forms.TextBox();
            this.MsgTo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(12, 46);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(228, 22);
            this.FirstName.TabIndex = 1;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(12, 74);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(228, 22);
            this.UserName.TabIndex = 1;
            // 
            // MsgFrom
            // 
            this.MsgFrom.Location = new System.Drawing.Point(12, 102);
            this.MsgFrom.Multiline = true;
            this.MsgFrom.Name = "MsgFrom";
            this.MsgFrom.Size = new System.Drawing.Size(600, 64);
            this.MsgFrom.TabIndex = 2;
            // 
            // MsgTo
            // 
            this.MsgTo.Location = new System.Drawing.Point(447, 46);
            this.MsgTo.Name = "MsgTo";
            this.MsgTo.Size = new System.Drawing.Size(165, 22);
            this.MsgTo.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(380, 49);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 19);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "MsgTo";
//            this.Label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "ParserHTML";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 295);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.MsgTo);
            this.Controls.Add(this.MsgFrom);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox MsgFrom;
        private System.Windows.Forms.TextBox MsgTo;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button button2;
    }
}

