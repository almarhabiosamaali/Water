namespace Water
{
    partial class AccountForm
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
            this.lblAccountCode = new System.Windows.Forms.Label();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountCode.Location = new System.Drawing.Point(30, 30);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(100, 20);
            this.lblAccountCode.TabIndex = 0;
            this.lblAccountCode.Text = "كود الحساب:";
            this.lblAccountCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountCode.Location = new System.Drawing.Point(150, 27);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(300, 26);
            this.txtAccountCode.TabIndex = 1;
            this.txtAccountCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(30, 70);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(100, 20);
            this.lblAccountName.TabIndex = 2;
            this.lblAccountName.Text = "اسم الحساب:";
            this.lblAccountName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(150, 67);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(300, 26);
            this.txtAccountName.TabIndex = 3;
            this.txtAccountName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(30, 110);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(100, 20);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "ملاحظات:";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(150, 107);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(300, 120);
            this.txtNotes.TabIndex = 5;
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(30, 250);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 40);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(125, 250);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 40);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(220, 250);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 40);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(315, 250);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 40);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(410, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 310);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.txtAccountCode);
            this.Controls.Add(this.lblAccountCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدخال بيانات الحساب";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountCode;
        private System.Windows.Forms.TextBox txtAccountCode;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}


