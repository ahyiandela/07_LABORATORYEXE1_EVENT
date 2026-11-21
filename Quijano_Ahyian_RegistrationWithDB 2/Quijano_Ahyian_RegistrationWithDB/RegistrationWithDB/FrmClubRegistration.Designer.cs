namespace RegistrationWithDB
{
    partial class FrmClubRegistration
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
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpInformation.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            this.grpInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInformation.Controls.Add(this.lblStudentId);
            this.grpInformation.Controls.Add(this.txtStudentId);
            this.grpInformation.Controls.Add(this.lblProgram);
            this.grpInformation.Controls.Add(this.cmbProgram);
            this.grpInformation.Controls.Add(this.lblLastName);
            this.grpInformation.Controls.Add(this.txtLastName);
            this.grpInformation.Controls.Add(this.lblFirstName);
            this.grpInformation.Controls.Add(this.txtFirstName);
            this.grpInformation.Controls.Add(this.lblMiddleName);
            this.grpInformation.Controls.Add(this.txtMiddleName);
            this.grpInformation.Controls.Add(this.lblAge);
            this.grpInformation.Controls.Add(this.txtAge);
            this.grpInformation.Controls.Add(this.lblGender);
            this.grpInformation.Controls.Add(this.cmbGender);
            this.grpInformation.Location = new System.Drawing.Point(12, 12);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(618, 180);
            this.grpInformation.TabIndex = 0;
            this.grpInformation.TabStop = false;
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(10, 16);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Text = "Student ID:";
            this.txtStudentId.Location = new System.Drawing.Point(10, 36);
            this.txtStudentId.MaxLength = 11;
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(160, 20);
            this.txtStudentId.TabIndex = 0;
            this.txtStudentId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowDigitsOnly);
            this.lblProgram.AutoSize = true;
            this.lblProgram.Location = new System.Drawing.Point(400, 16);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Text = "Program:";
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Items.AddRange(new object[] {
            "BS in Computer Science",
            "BS in Information Technology",
            "BS in Business Administration",
            "BS in Hospitality Management"});
            this.cmbProgram.Location = new System.Drawing.Point(400, 36);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(200, 21);
            this.cmbProgram.TabIndex = 6;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(10, 70);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Text = "Last name:";
            this.txtLastName.Location = new System.Drawing.Point(10, 90);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(170, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowNameCharacters);
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(200, 70);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Text = "First Name:";
            this.txtFirstName.Location = new System.Drawing.Point(200, 90);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(170, 20);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowNameCharacters);
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(400, 70);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Text = "Middle name:";
            this.txtMiddleName.Location = new System.Drawing.Point(400, 90);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(170, 20);
            this.txtMiddleName.TabIndex = 3;
            this.txtMiddleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowNameCharacters);
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(10, 124);
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "Age:";
            this.txtAge.Location = new System.Drawing.Point(10, 144);
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(110, 20);
            this.txtAge.TabIndex = 4;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(InputValidator.AllowDigitsOnly);
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(200, 124);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Gender:";
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(200, 144);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(120, 21);
            this.cmbGender.TabIndex = 5;
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Location = new System.Drawing.Point(642, 12);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 32);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(642, 50);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.grpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpList.Controls.Add(this.dataGridView);
            this.grpList.Location = new System.Drawing.Point(12, 200);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(618, 233);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            this.grpList.Text = "List Of Club Members";
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 20);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(598, 203);
            this.dataGridView.TabIndex = 0;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(642, 220);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 445);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.grpInformation);
            this.MinimumSize = new System.Drawing.Size(761, 484);
            this.Name = "FrmClubRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClubRegistration";
            this.Load += new System.EventHandler(this.FrmClubRegistration_Load);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.ComboBox cmbProgram;
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
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnRefresh;
    }
}
