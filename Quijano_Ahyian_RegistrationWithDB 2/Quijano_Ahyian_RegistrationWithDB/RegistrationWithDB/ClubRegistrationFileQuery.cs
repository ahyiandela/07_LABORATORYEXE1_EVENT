using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace RegistrationWithDB
{
    
    public class ClubRegistrationFileQuery : ClubRegistrationQuery
    {
        private DataTable members;
        private string filePath;

        public ClubRegistrationFileQuery() : base(true)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClubMembers.xml");

            members = new DataTable("ClubMembers");
            members.Columns.Add("ID", typeof(int));
            members.Columns.Add("StudentId", typeof(long));
            members.Columns.Add("FirstName", typeof(string));
            members.Columns.Add("MiddleName", typeof(string));
            members.Columns.Add("LastName", typeof(string));
            members.Columns.Add("Age", typeof(int));
            members.Columns.Add("Gender", typeof(string));
            members.Columns.Add("Program", typeof(string));

            if (File.Exists(filePath))
            {
                members.ReadXml(filePath);
            }

            dataTable.Columns.Add("StudentId", typeof(long));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("MiddleName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("Program", typeof(string));
        }

        private void Save()
        {
            members.WriteXml(filePath, XmlWriteMode.WriteSchema);
        }

        private DataRow FindMember(long StudentID)
        {
            foreach (DataRow row in members.Rows)
            {
                if ((long)row["StudentId"] == StudentID)
                {
                    return row;
                }
            }

            return null;
        }

        public override bool DisplayList()
        {
            dataTable.Clear();

            foreach (DataRow row in members.Rows)
            {
                dataTable.Rows.Add(row["StudentId"], row["FirstName"], row["MiddleName"],
                    row["LastName"], row["Age"], row["Gender"], row["Program"]);
            }

            bindingSource.DataSource = dataTable;

            return true;
        }

        public override bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            if (FindMember(StudentID) != null)
            {
                throw new InvalidOperationException("Student ID " + StudentID + " is already registered.");
            }

            members.Rows.Add(ID, StudentID, FirstName, MiddleName, LastName, Age, Gender, Program);
            Save();

            return true;
        }

        public override bool UpdateMember(long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            DataRow row = FindMember(StudentID);

            if (row == null)
            {
                return false;
            }

            row["FirstName"] = FirstName;
            row["MiddleName"] = MiddleName;
            row["LastName"] = LastName;
            row["Age"] = Age;
            row["Gender"] = Gender;
            row["Program"] = Program;
            Save();

            return true;
        }

        public override bool StudentExists(long StudentID)
        {
            return FindMember(StudentID) != null;
        }

        public override int GetMaxId()
        {
            int maxId = 0;

            foreach (DataRow row in members.Rows)
            {
                if ((int)row["ID"] > maxId)
                {
                    maxId = (int)row["ID"];
                }
            }

            return maxId;
        }

        public override List<long> GetStudentIds()
        {
            List<long> studentIds = new List<long>();

            foreach (DataRow row in members.Select("", "ID ASC"))
            {
                studentIds.Add((long)row["StudentId"]);
            }

            return studentIds;
        }

        public override bool GetMember(long StudentID)
        {
            DataRow row = FindMember(StudentID);

            if (row == null)
            {
                return false;
            }

            _FirstName = (string)row["FirstName"];
            _MiddleName = (string)row["MiddleName"];
            _LastName = (string)row["LastName"];
            _Age = (int)row["Age"];
            _Gender = (string)row["Gender"];
            _Program = (string)row["Program"];

            return true;
        }
    }
}
