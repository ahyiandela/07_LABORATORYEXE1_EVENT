using System;
using System.Windows.Forms;

namespace RegistrationWithDB
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;
        private FrmUpdateMember frmUpdateMember;

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                clubRegistrationQuery = new ClubRegistrationQuery();
                count = clubRegistrationQuery.GetMaxId();
                RefreshListOfClubMembers();
            }
            catch (Exception ex)
            {
                try
                {
                    clubRegistrationQuery = new ClubRegistrationFileQuery();
                    count = clubRegistrationQuery.GetMaxId();
                    RefreshListOfClubMembers();

                    MessageBox.Show("SQL Server LocalDB was not found on this PC, so the program will save the records to a local file (ClubMembers.xml) instead.\n\n" + ex.Message,
                        "Using File Storage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Unable to connect to ahyian1234567891011.\n\n" + ex2.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView.DataSource = clubRegistrationQuery.bindingSource;
        }

        private int RegistrationID()
        {
            count++;
            return count;
        }

        private void ClearFields()
        {
            txtStudentId.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            txtStudentId.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!InputValidator.ValidateStudentId(txtStudentId) ||
                !InputValidator.ValidateDetails(txtLastName, txtFirstName, txtMiddleName, txtAge, cmbGender, cmbProgram))
            {
                return;
            }

            try
            {
                StudentId = long.Parse(txtStudentId.Text.Trim());

                if (clubRegistrationQuery.StudentExists(StudentId))
                {
                    MessageBox.Show("Student ID " + StudentId + " is already registered.", "Duplicate Student ID",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStudentId.Focus();
                    return;
                }

                LastName = txtLastName.Text.Trim();
                FirstName = txtFirstName.Text.Trim();
                MiddleName = txtMiddleName.Text.Trim();
                Age = int.Parse(txtAge.Text.Trim());
                Gender = cmbGender.SelectedItem.ToString();
                Program = cmbProgram.SelectedItem.ToString();
                ID = RegistrationID();

                clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);

                RefreshListOfClubMembers();

                if (frmUpdateMember != null && !frmUpdateMember.IsDisposed)
                {
                    frmUpdateMember.LoadStudentIds();
                }

                MessageBox.Show("Student registered successfully.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed.\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (frmUpdateMember != null && !frmUpdateMember.IsDisposed)
            {
                frmUpdateMember.Focus();
                return;
            }

            frmUpdateMember = new FrmUpdateMember(clubRegistrationQuery, RefreshListOfClubMembers);
            frmUpdateMember.Show(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshListOfClubMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to refresh the list.\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
