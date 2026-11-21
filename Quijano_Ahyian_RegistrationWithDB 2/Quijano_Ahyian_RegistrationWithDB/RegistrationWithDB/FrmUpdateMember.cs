using System;
using System.Windows.Forms;

namespace RegistrationWithDB
{
    public partial class FrmUpdateMember : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private Action refreshList;

        public FrmUpdateMember(ClubRegistrationQuery query, Action refresh)
        {
            InitializeComponent();
            clubRegistrationQuery = query;
            refreshList = refresh;
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStudentIds();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the student list.\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (cmbStudentId.Items.Count == 0)
            {
                MessageBox.Show("There are no registered members to update.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        public void LoadStudentIds()
        {
            object selected = cmbStudentId.SelectedItem;

            cmbStudentId.Items.Clear();

            foreach (long studentId in clubRegistrationQuery.GetStudentIds())
            {
                cmbStudentId.Items.Add(studentId);
            }

            if (selected != null && cmbStudentId.Items.Contains(selected))
            {
                cmbStudentId.SelectedItem = selected;
            }
        }

        private void ClearFields()
        {
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
        }

        private void cmbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentId.SelectedIndex < 0)
            {
                ClearFields();
                return;
            }

            try
            {
                if (clubRegistrationQuery.GetMember((long)cmbStudentId.SelectedItem))
                {
                    txtLastName.Text = clubRegistrationQuery._LastName;
                    txtFirstName.Text = clubRegistrationQuery._FirstName;
                    txtMiddleName.Text = clubRegistrationQuery._MiddleName;
                    txtAge.Text = clubRegistrationQuery._Age.ToString();
                    cmbGender.SelectedIndex = cmbGender.FindStringExact(clubRegistrationQuery._Gender);
                    cmbProgram.SelectedIndex = cmbProgram.FindStringExact(clubRegistrationQuery._Program);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the member information.\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbStudentId.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Student ID first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStudentId.Focus();
                return;
            }

            if (!InputValidator.ValidateDetails(txtLastName, txtFirstName, txtMiddleName, txtAge, cmbGender, cmbProgram))
            {
                return;
            }

            DialogResult answer = MessageBox.Show("Do you want to save the changes for Student ID " + cmbStudentId.SelectedItem + "?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                clubRegistrationQuery.UpdateMember(
                    (long)cmbStudentId.SelectedItem,
                    txtFirstName.Text.Trim(),
                    txtMiddleName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    int.Parse(txtAge.Text.Trim()),
                    cmbGender.SelectedItem.ToString(),
                    cmbProgram.SelectedItem.ToString());

                refreshList();

                MessageBox.Show("Member information updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
