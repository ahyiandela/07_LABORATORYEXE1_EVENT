using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace RegistrationWithDB
{
    public class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;

        public DataTable dataTable;
        public BindingSource bindingSource;

        private string connectionString;

        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public int _Age;

       
        protected ClubRegistrationQuery(bool useFileStorage)
        {
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }

        public ClubRegistrationQuery()
        {
            string databaseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ahyian1234567891011.mdf");

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + databaseFile + ";Integrated Security=True;Connect Timeout=30";

            PrepareDatabase(databaseFile);

            sqlConnect = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }

        private void PrepareDatabase(string databaseFile)
        {
            if (!File.Exists(databaseFile))
            {
                string temporaryName = "ahyian1234567891011_" + Guid.NewGuid().ToString("N");

                using (SqlConnection master = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30"))
                {
                    master.Open();

                    using (SqlCommand create = new SqlCommand("CREATE DATABASE [" + temporaryName + "] ON (NAME = N'ahyian1234567891011', FILENAME = N'" + databaseFile.Replace("'", "''") + "')", master))
                    {
                        create.ExecuteNonQuery();
                    }

                    using (SqlCommand detach = new SqlCommand("EXEC sp_detach_db @dbname = N'" + temporaryName + "'", master))
                    {
                        detach.ExecuteNonQuery();
                    }
                }
            }

            string createTable = "IF OBJECT_ID(N'dbo.ClubMembers', N'U') IS NULL " +
                "CREATE TABLE dbo.ClubMembers (" +
                "ID INT NOT NULL PRIMARY KEY, " +
                "StudentId BIGINT NOT NULL UNIQUE, " +
                "FirstName VARCHAR(50) NOT NULL, " +
                "MiddleName VARCHAR(50) NOT NULL, " +
                "LastName VARCHAR(50) NOT NULL, " +
                "Age INT NOT NULL, " +
                "Gender VARCHAR(50) NOT NULL, " +
                "Program VARCHAR(50) NOT NULL)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public virtual bool DisplayList()
        {
            string ViewClubMembers = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";

            sqlAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnect);

            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            return true;
        }

        public virtual bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMembers (ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program) " +
                "VALUES (@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnect);

            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar, 50).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar, 50).Value = Program;

            try
            {
                sqlConnect.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnect.Close();
            }

            return true;
        }

        public virtual bool UpdateMember(long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            int affectedRows;

            sqlCommand = new SqlCommand("UPDATE ClubMembers SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                "Age = @Age, Gender = @Gender, Program = @Program WHERE StudentId = @StudentID", sqlConnect);

            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar, 50).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar, 50).Value = Program;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;

            try
            {
                sqlConnect.Open();
                affectedRows = sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnect.Close();
            }

            return affectedRows > 0;
        }

        public virtual bool StudentExists(long StudentID)
        {
            int total;

            sqlCommand = new SqlCommand("SELECT COUNT(*) FROM ClubMembers WHERE StudentId = @StudentID", sqlConnect);
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;

            try
            {
                sqlConnect.Open();
                total = (int)sqlCommand.ExecuteScalar();
            }
            finally
            {
                sqlConnect.Close();
            }

            return total > 0;
        }

        public virtual int GetMaxId()
        {
            int maxId;

            sqlCommand = new SqlCommand("SELECT ISNULL(MAX(ID), 0) FROM ClubMembers", sqlConnect);

            try
            {
                sqlConnect.Open();
                maxId = (int)sqlCommand.ExecuteScalar();
            }
            finally
            {
                sqlConnect.Close();
            }

            return maxId;
        }

        public virtual List<long> GetStudentIds()
        {
            List<long> studentIds = new List<long>();

            sqlCommand = new SqlCommand("SELECT StudentId FROM ClubMembers ORDER BY ID", sqlConnect);

            try
            {
                sqlConnect.Open();
                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    studentIds.Add(sqlReader.GetInt64(0));
                }

                sqlReader.Close();
            }
            finally
            {
                sqlConnect.Close();
            }

            return studentIds;
        }

        public virtual bool GetMember(long StudentID)
        {
            bool found = false;

            sqlCommand = new SqlCommand("SELECT FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers WHERE StudentId = @StudentID", sqlConnect);
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;

            try
            {
                sqlConnect.Open();
                sqlReader = sqlCommand.ExecuteReader();

                if (sqlReader.Read())
                {
                    _FirstName = sqlReader.GetString(0);
                    _MiddleName = sqlReader.GetString(1);
                    _LastName = sqlReader.GetString(2);
                    _Age = sqlReader.GetInt32(3);
                    _Gender = sqlReader.GetString(4);
                    _Program = sqlReader.GetString(5);
                    found = true;
                }

                sqlReader.Close();
            }
            finally
            {
                sqlConnect.Close();
            }

            return found;
        }
    }
}
