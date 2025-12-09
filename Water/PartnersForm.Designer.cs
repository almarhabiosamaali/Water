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
            this.components = new System.ComponentModel.Container();
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPartnerCode
            // 
            this.lblPartnerCode.AutoSize = true;
            this.lblPartnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerCode.Location = new System.Drawing.Point(33, 108);
            this.lblPartnerCode.Name = "lblPartnerCode";
            this.lblPartnerCode.Size = new System.Drawing.Size(77, 20);
            this.lblPartnerCode.TabIndex = 0;
            this.lblPartnerCode.Text = "رقم الشريك:";
            // 
            // txtPartnerCode
            // 
            this.txtPartnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartnerCode.Location = new System.Drawing.Point(162, 105);
            this.txtPartnerCode.Name = "txtPartnerCode";
            this.txtPartnerCode.ReadOnly = true;
            this.txtPartnerCode.Size = new System.Drawing.Size(263, 26);
            this.txtPartnerCode.TabIndex = 1;
            this.txtPartnerCode.TabStop = false;
            this.txtPartnerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPartnerName
            // 
            this.lblPartnerName.AutoSize = true;
            this.lblPartnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerName.Location = new System.Drawing.Point(465, 108);
            this.lblPartnerName.Name = "lblPartnerName";
            this.lblPartnerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPartnerName.Size = new System.Drawing.Size(77, 20);
            this.lblPartnerName.TabIndex = 2;
            this.lblPartnerName.Text = "اسم الشريك:";
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartnerName.Location = new System.Drawing.Point(590, 105);
            this.txtPartnerName.Name = "txtPartnerName";
            this.txtPartnerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPartnerName.Size = new System.Drawing.Size(263, 26);
            this.txtPartnerName.TabIndex = 1;
            // 
            // lblAllocatedHours
            // 
            this.lblAllocatedHours.AutoSize = true;
            this.lblAllocatedHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocatedHours.Location = new System.Drawing.Point(33, 156);
            this.lblAllocatedHours.Name = "lblAllocatedHours";
            this.lblAllocatedHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAllocatedHours.Size = new System.Drawing.Size(123, 20);
            this.lblAllocatedHours.TabIndex = 4;
            this.lblAllocatedHours.Text = "الساعات المخصصة:";
            // 
            // txtAllocatedHours
            // 
            this.txtAllocatedHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocatedHours.Location = new System.Drawing.Point(162, 153);
            this.txtAllocatedHours.Name = "txtAllocatedHours";
            this.txtAllocatedHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllocatedHours.Size = new System.Drawing.Size(263, 26);
            this.txtAllocatedHours.TabIndex = 2;
            this.txtAllocatedHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAllocatedHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAllocatedHours_KeyPress);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(465, 156);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(51, 20);
            this.lblMinutes.TabIndex = 6;
            this.lblMinutes.Text = "الدقائق:";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.Location = new System.Drawing.Point(590, 153);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutes.Size = new System.Drawing.Size(263, 26);
            this.txtMinutes.TabIndex = 3;
            this.txtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutes_KeyPress);
            // 
            // lblAvalibleHours
            // 
            this.lblAvalibleHours.AutoSize = true;
            this.lblAvalibleHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvalibleHours.Location = new System.Drawing.Point(33, 204);
            this.lblAvalibleHours.Name = "lblAvalibleHours";
            this.lblAvalibleHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAvalibleHours.Size = new System.Drawing.Size(103, 20);
            this.lblAvalibleHours.TabIndex = 8;
            this.lblAvalibleHours.Text = "الساعات المتاحة:";
            // 
            // txtAvalibleHours
            // 
            this.txtAvalibleHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvalibleHours.Location = new System.Drawing.Point(162, 201);
            this.txtAvalibleHours.Name = "txtAvalibleHours";
            this.txtAvalibleHours.ReadOnly = true;
            this.txtAvalibleHours.Size = new System.Drawing.Size(263, 26);
            this.txtAvalibleHours.TabIndex = 9;
            this.txtAvalibleHours.TabStop = false;
            this.txtAvalibleHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAvalibleHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAvalibleHours_KeyPress);
            // 
            // lblAvalibleMinutes
            // 
            this.lblAvalibleMinutes.AutoSize = true;
            this.lblAvalibleMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvalibleMinutes.Location = new System.Drawing.Point(465, 204);
            this.lblAvalibleMinutes.Name = "lblAvalibleMinutes";
            this.lblAvalibleMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAvalibleMinutes.Size = new System.Drawing.Size(94, 20);
            this.lblAvalibleMinutes.TabIndex = 10;
            this.lblAvalibleMinutes.Text = "الدقائق المتاحة:";
            // 
            // txtAvalibleMinutes
            // 
            this.txtAvalibleMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvalibleMinutes.Location = new System.Drawing.Point(590, 201);
            this.txtAvalibleMinutes.Name = "txtAvalibleMinutes";
            this.txtAvalibleMinutes.ReadOnly = true;
            this.txtAvalibleMinutes.Size = new System.Drawing.Size(263, 26);
            this.txtAvalibleMinutes.TabIndex = 11;
            this.txtAvalibleMinutes.TabStop = false;
            this.txtAvalibleMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAvalibleMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAvalibleMinutes_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(33, 252);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhone.Size = new System.Drawing.Size(50, 20);
            this.lblPhone.TabIndex = 12;
            this.lblPhone.Text = "الهاتف:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(162, 249);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(263, 26);
            this.txtPhone.TabIndex = 4;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(465, 252);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAddress.Size = new System.Drawing.Size(53, 20);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "العنوان:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(590, 249);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(263, 26);
            this.txtAddress.TabIndex = 5;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(33, 300);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNotes.Size = new System.Drawing.Size(66, 20);
            this.lblNotes.TabIndex = 16;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(162, 297);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.Size = new System.Drawing.Size(691, 80);
            this.txtNotes.TabIndex = 6;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(465, 395);
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
            this.dtpDate.Location = new System.Drawing.Point(590, 392);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(263, 26);
            this.dtpDate.TabIndex = 7;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::Water.Properties.Resources.icons8_search_24_8;
            this.btnView.Location = new System.Drawing.Point(338, 42);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(60, 40);
            this.btnView.TabIndex = 18;
            this.btnView.TabStop = false;
            this.toolTip1.SetToolTip(this.btnView, "عرض");
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Water.Properties.Resources.icons8_add_24;
            this.btnAdd.Location = new System.Drawing.Point(406, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(60, 40);
            this.btnAdd.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnAdd, "إضافة");
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Water.Properties.Resources.icons8_edit_24_5;
            this.btnEdit.Location = new System.Drawing.Point(472, 42);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(60, 40);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEdit, "تعديل");
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Water.Properties.Resources.icons8_delete_24;
            this.btnDelete.Location = new System.Drawing.Point(538, 42);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(60, 40);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Water.Properties.Resources.icons8_save_24_9;
            this.btnSave.Location = new System.Drawing.Point(604, 42);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 40);
            this.btnSave.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "ادخال بيانات الشركاء";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Water.Properties.Resources.icons8_exit_24;
            this.btnExit.Location = new System.Drawing.Point(670, 42);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(70, 40);
            this.btnExit.TabIndex = 38;
            this.btnExit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PartnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 423);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnExit;
    }
}

