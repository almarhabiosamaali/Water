namespace Water
{
    partial class PartnersForm
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
            this.lblPartnerCode = new System.Windows.Forms.Label();
            this.txtPartnerCode = new System.Windows.Forms.TextBox();
            this.lblPartnerName = new System.Windows.Forms.Label();
            this.txtPartnerName = new System.Windows.Forms.TextBox();
            this.lblAllocatedHours = new System.Windows.Forms.Label();
            this.txtAllocatedHours = new System.Windows.Forms.TextBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.lblAvalibleHours = new System.Windows.Forms.Label();
            this.txtAvalibleHours = new System.Windows.Forms.TextBox();
            this.lblAvalibleMinutes = new System.Windows.Forms.Label();
            this.txtAvalibleMinutes = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPartnerCode
            // 
            this.lblPartnerCode.AutoSize = true;
            this.lblPartnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerCode.Location = new System.Drawing.Point(26, 24);
            this.lblPartnerCode.Name = "lblPartnerCode";
            this.lblPartnerCode.Size = new System.Drawing.Size(77, 20);
            this.lblPartnerCode.TabIndex = 0;
            this.lblPartnerCode.Text = "رقم الشريك:";
            // 
            // txtPartnerCode
            // 
            this.txtPartnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartnerCode.Location = new System.Drawing.Point(155, 21);
            this.txtPartnerCode.Name = "txtPartnerCode";
            this.txtPartnerCode.Size = new System.Drawing.Size(263, 26);
            this.txtPartnerCode.TabIndex = 1;
            // 
            // lblPartnerName
            // 
            this.lblPartnerName.AutoSize = true;
            this.lblPartnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerName.Location = new System.Drawing.Point(458, 24);
            this.lblPartnerName.Name = "lblPartnerName";
            this.lblPartnerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPartnerName.Size = new System.Drawing.Size(77, 20);
            this.lblPartnerName.TabIndex = 2;
            this.lblPartnerName.Text = "اسم الشريك:";
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartnerName.Location = new System.Drawing.Point(583, 21);
            this.txtPartnerName.Name = "txtPartnerName";
            this.txtPartnerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPartnerName.Size = new System.Drawing.Size(263, 26);
            this.txtPartnerName.TabIndex = 3;
            // 
            // lblAllocatedHours
            // 
            this.lblAllocatedHours.AutoSize = true;
            this.lblAllocatedHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocatedHours.Location = new System.Drawing.Point(26, 72);
            this.lblAllocatedHours.Name = "lblAllocatedHours";
            this.lblAllocatedHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllocatedHours.Size = new System.Drawing.Size(123, 20);
            this.lblAllocatedHours.TabIndex = 4;
            this.lblAllocatedHours.Text = "الساعات المخصصة:";
            // 
            // txtAllocatedHours
            // 
            this.txtAllocatedHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocatedHours.Location = new System.Drawing.Point(155, 69);
            this.txtAllocatedHours.Name = "txtAllocatedHours";
            this.txtAllocatedHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllocatedHours.Size = new System.Drawing.Size(263, 26);
            this.txtAllocatedHours.TabIndex = 5;
            this.txtAllocatedHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAllocatedHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAllocatedHours_KeyPress);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(458, 72);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(51, 20);
            this.lblMinutes.TabIndex = 6;
            this.lblMinutes.Text = "الدقائق:";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.Location = new System.Drawing.Point(583, 69);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutes.Size = new System.Drawing.Size(263, 26);
            this.txtMinutes.TabIndex = 7;
            this.txtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutes_KeyPress);
            // 
            // lblAvalibleHours
            // 
            this.lblAvalibleHours.AutoSize = true;
            this.lblAvalibleHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvalibleHours.Location = new System.Drawing.Point(26, 120);
            this.lblAvalibleHours.Name = "lblAvalibleHours";
            this.lblAvalibleHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAvalibleHours.Size = new System.Drawing.Size(103, 20);
            this.lblAvalibleHours.TabIndex = 8;
            this.lblAvalibleHours.Text = "الساعات المتاحة:";
            // 
            // txtAvalibleHours
            // 
            this.txtAvalibleHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvalibleHours.Location = new System.Drawing.Point(155, 117);
            this.txtAvalibleHours.Name = "txtAvalibleHours";
            this.txtAvalibleHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAvalibleHours.Size = new System.Drawing.Size(263, 26);
            this.txtAvalibleHours.TabIndex = 9;
            this.txtAvalibleHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAvalibleHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAvalibleHours_KeyPress);
            // 
            // lblAvalibleMinutes
            // 
            this.lblAvalibleMinutes.AutoSize = true;
            this.lblAvalibleMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvalibleMinutes.Location = new System.Drawing.Point(458, 120);
            this.lblAvalibleMinutes.Name = "lblAvalibleMinutes";
            this.lblAvalibleMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAvalibleMinutes.Size = new System.Drawing.Size(94, 20);
            this.lblAvalibleMinutes.TabIndex = 10;
            this.lblAvalibleMinutes.Text = "الدقائق المتاحة:";
            // 
            // txtAvalibleMinutes
            // 
            this.txtAvalibleMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvalibleMinutes.Location = new System.Drawing.Point(583, 117);
            this.txtAvalibleMinutes.Name = "txtAvalibleMinutes";
            this.txtAvalibleMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAvalibleMinutes.Size = new System.Drawing.Size(263, 26);
            this.txtAvalibleMinutes.TabIndex = 11;
            this.txtAvalibleMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAvalibleMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAvalibleMinutes_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(26, 168);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhone.Size = new System.Drawing.Size(50, 20);
            this.lblPhone.TabIndex = 12;
            this.lblPhone.Text = "الهاتف:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(155, 165);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(263, 26);
            this.txtPhone.TabIndex = 13;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(458, 168);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAddress.Size = new System.Drawing.Size(53, 20);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "العنوان:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(583, 165);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(263, 26);
            this.txtAddress.TabIndex = 15;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(26, 216);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNotes.Size = new System.Drawing.Size(66, 20);
            this.lblNotes.TabIndex = 16;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(155, 213);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.Size = new System.Drawing.Size(691, 80);
            this.txtNotes.TabIndex = 17;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(458, 311);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(51, 20);
            this.lblDate.TabIndex = 18;
            this.lblDate.Text = "التاريخ:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(583, 308);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(263, 26);
            this.dtpDate.TabIndex = 19;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(26, 360);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(74, 40);
            this.btnView.TabIndex = 18;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(109, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(74, 40);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(192, 360);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(74, 40);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(276, 360);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(74, 40);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(359, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(74, 40);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // PartnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 420);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtAvalibleMinutes);
            this.Controls.Add(this.lblAvalibleMinutes);
            this.Controls.Add(this.txtAvalibleHours);
            this.Controls.Add(this.lblAvalibleHours);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.txtAllocatedHours);
            this.Controls.Add(this.lblAllocatedHours);
            this.Controls.Add(this.txtPartnerName);
            this.Controls.Add(this.lblPartnerName);
            this.Controls.Add(this.txtPartnerCode);
            this.Controls.Add(this.lblPartnerCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartnersForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدخال بيانات الشريك";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPartnerCode;
        private System.Windows.Forms.TextBox txtPartnerCode;
        private System.Windows.Forms.Label lblPartnerName;
        private System.Windows.Forms.TextBox txtPartnerName;
        private System.Windows.Forms.Label lblAllocatedHours;
        private System.Windows.Forms.TextBox txtAllocatedHours;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label lblAvalibleHours;
        private System.Windows.Forms.TextBox txtAvalibleHours;
        private System.Windows.Forms.Label lblAvalibleMinutes;
        private System.Windows.Forms.TextBox txtAvalibleMinutes;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}

