using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegistrationWithDB
{
    public static class InputValidator
    {
        private const int MinAge = 15;
        private const int MaxAge = 80;
        private static readonly Regex StudentIdPattern = new Regex(@"^[0-9]{11}$");
        private static readonly Regex NamePattern = new Regex(@"^[A-Za-z\u00D1\u00F1]+([ '\-.]+[A-Za-z\u00D1\u00F1]+)*\.?$");

        public static void AllowDigitsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void AllowNameCharacters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && " .'-".IndexOf(e.KeyChar) < 0)
            {
                e.Handled = true;
            }
        }

        public static bool ValidateStudentId(TextBox txtStudentId)
        {
            string value = txtStudentId.Text.Trim();

            if (value.Length == 0)
            {
                return Fail("Student ID is required.", txtStudentId);
            }

            if (!StudentIdPattern.IsMatch(value))
            {
                return Fail("Student ID must be exactly 11 digits.", txtStudentId);
            }

            return true;
        }

        public static bool ValidateDetails(TextBox txtLastName, TextBox txtFirstName, TextBox txtMiddleName,
            TextBox txtAge, ComboBox cmbGender, ComboBox cmbProgram)
        {
            return CheckName(txtLastName, "Last name", true)
                && CheckName(txtFirstName, "First name", true)
                && CheckName(txtMiddleName, "Middle name", false)
                && CheckAge(txtAge)
                && CheckSelection(cmbGender, "gender")
                && CheckSelection(cmbProgram, "program");
        }

        private static bool CheckName(TextBox textBox, string label, bool required)
        {
            string value = textBox.Text.Trim();

            if (value.Length == 0)
            {
                return required ? Fail(label + " is required.", textBox) : true;
            }

            if (!NamePattern.IsMatch(value))
            {
                return Fail(label + " must contain letters only. Spaces, hyphens, apostrophes and periods are allowed between letters.", textBox);
            }

            return true;
        }

        private static bool CheckAge(TextBox textBox)
        {
            string value = textBox.Text.Trim();
            int age;

            if (value.Length == 0)
            {
                return Fail("Age is required.", textBox);
            }

            if (!int.TryParse(value, out age))
            {
                return Fail("Age must be a whole number.", textBox);
            }

            if (age < MinAge || age > MaxAge)
            {
                return Fail("Age must be between " + MinAge + " and " + MaxAge + ".", textBox);
            }

            return true;
        }

        private static bool CheckSelection(ComboBox comboBox, string label)
        {
            if (comboBox.SelectedIndex < 0)
            {
                return Fail("Please select a " + label + ".", comboBox);
            }

            return true;
        }

        private static bool Fail(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }
    }
}
