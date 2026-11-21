namespace RegistrationWithDB
{
    partial class FrmUpdateMember
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStudentId = new System.Windows.Forms.Label();
            this.cmbStudentId = new System.Windows.Forms.ComboBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(12, 12);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Text = "Student ID:";
            this.cmbStudentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudentId.FormattingEnabled = true;
            this.cmbStudentId.Location = new System.Drawing.Point(15, 30);
            this.cmbStudentId.Name = "cmbStudentId";
            this.cmbStudentId.Size = new System.Drawing.Size(190, 21);
            this.cmbStudentId.TabIndex = 0;
            this.cmbStudentId.SelectedIndexChanged += new System.EventHandler(this.cmbStudentId_SelectedIndexChanged);
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 62);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Text = "Last name:";
            this.txtLastName.Location = new System.Drawing.Point(15, 80);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(175, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowNameCharacters);
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 112);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Text = "First Name:";
            this.txtFirstName.Location = new System.Drawing.Point(15, 130);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(175, 20);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowNameCharacters);
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(12, 162);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Text = "Middle name:";
            this.txtMiddleName.Location = new System.Drawing.Point(15, 180);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(175, 20);
            this.txtMiddleName.TabIndex = 3;
            this.txtMiddleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowNameCharacters);
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(12, 212);
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "Age:";
            this.txtAge.Location = new System.Drawing.Point(15, 230);
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(110, 20);
            this.txtAge.TabIndex = 4;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowDigitsOnly);
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(12, 262);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Gender:";
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(15, 280);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(130, 21);
            this.cmbGender.TabIndex = 5;
            this.lblProgram.AutoSize = true;
            this.lblProgram.Location = new System.Drawing.Point(12, 312);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Text = "Program:";
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Items.AddRange(new object[] {
            "BS in Computer Science",
            "BS in Information Technology",
            "BS in Business Administration",
            "BS in Hospitality Management"});
            this.cmbProgram.Location = new System.Drawing.Point(15, 330);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(190, 21);
            this.cmbProgram.TabIndex = 6;
            this.btnConfirm.Location = new System.Drawing.Point(65, 372);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 30);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 418);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.cmbStudentId);
            this.Controls.Add(this.lblStudentId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmUpdateMember";
            this.Load += new System.EventHandler(this.FrmUpdateMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.ComboBox cmbStudentId;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Button btnConfirm;
    }
}
