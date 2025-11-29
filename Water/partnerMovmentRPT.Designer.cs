namespace Water
{
    partial class partnerMovmentRPT
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
            this.txtPartnerID = new System.Windows.Forms.TextBox();
            this.btnShowRPT = new System.Windows.Forms.Button();
            this.anly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPartnerID
            // 
            this.txtPartnerID.Location = new System.Drawing.Point(263, 33);
            this.txtPartnerID.Name = "txtPartnerID";
            this.txtPartnerID.Size = new System.Drawing.Size(259, 24);
            this.txtPartnerID.TabIndex = 0;
            // 
            // btnShowRPT
            // 
            this.btnShowRPT.Location = new System.Drawing.Point(263, 129);
            this.btnShowRPT.Name = "btnShowRPT";
            this.btnShowRPT.Size = new System.Drawing.Size(258, 34);
            this.btnShowRPT.TabIndex = 1;
            this.btnShowRPT.Text = "عرض";
            this.btnShowRPT.UseVisualStyleBackColor = true;
            this.btnShowRPT.Click += new System.EventHandler(this.btnShowRPT_Click);
            // 
            // anly
            // 
            this.anly.AutoSize = true;
            this.anly.Location = new System.Drawing.Point(158, 33);
            this.anly.Name = "anly";
            this.anly.Size = new System.Drawing.Size(73, 21);
            this.anly.TabIndex = 2;
            this.anly.Text = "تحليلي";
            this.anly.UseVisualStyleBackColor = true;
            // 
            // partnerMovmentRPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 342);
            this.Controls.Add(this.anly);
            this.Controls.Add(this.btnShowRPT);
            this.Controls.Add(this.txtPartnerID);
            this.Name = "partnerMovmentRPT";
            this.Text = "partnerMovmentRPT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartnerID;
        private System.Windows.Forms.Button btnShowRPT;
        private System.Windows.Forms.CheckBox anly;
    }
}