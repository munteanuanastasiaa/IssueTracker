using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using IssueTracker.Models;

namespace IssueTracker.Services
{
    // handles all database operations using SQLite
    // CRUD for Issues and Developers
    public class DatabaseManager
    {
        private string connectionString;
        private string dbPath;

        public DatabaseManager(string databaseFile)
        {
            dbPath = databaseFile;
            connectionString = "Data Source=" + dbPath + ";Version=3;";
            EnsureDatabase();
        }

        // creates the file and tables if they don't exist
        private void EnsureDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createIssues = @"
                    CREATE TABLE IF NOT EXISTS Issues (
                        IssueId INTEGER PRIMARY KEY,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        Severity INTEGER,
                        Status INTEGER,
                        Environment INTEGER,
                        DateReported TEXT,
                        ReporterId INTEGER,
                        AssigneeId INTEGER,
                        HoursSpent REAL
                    );";

                string createDevelopers = @"
                    CREATE TABLE IF NOT EXISTS Developers (
                        DeveloperId INTEGER PRIMARY KEY,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        Email TEXT,
                        Specialization INTEGER,
                        BugsFixedCount INTEGER,
                        HireDate TEXT
                    );";

                using (SQLiteCommand cmd = new SQLiteCommand(createIssues, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createDevelopers, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }


        // ===== ISSUES CRUD =====

        public void InsertIssue(Issue i)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Issues
                    (IssueId, Title, Description, Severity, Status, Environment, DateReported, ReporterId, AssigneeId, HoursSpent)
                    VALUES (@id, @title, @desc, @sev, @st, @env, @date, @rep, @ass, @hrs);";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", i.IssueId);
                    cmd.Parameters.AddWithValue("@title", i.Title);
                    cmd.Parameters.AddWithValue("@desc", i.Description);
                    cmd.Parameters.AddWithValue("@sev", (int)i.Severity);
                    cmd.Parameters.AddWithValue("@st", (int)i.Status);
                    cmd.Parameters.AddWithValue("@env", (int)i.Environment);
                    cmd.Parameters.AddWithValue("@date", i.DateReported.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@rep", i.ReporterId);
                    cmd.Parameters.AddWithValue("@ass", i.AssigneeId);
                    cmd.Parameters.AddWithValue("@hrs", i.HoursSpent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateIssue(Issue i)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Issues SET
                    Title=@title, Description=@desc, Severity=@sev, Status=@st,
                    Environment=@env, DateReported=@date, ReporterId=@rep,
                    AssigneeId=@ass, HoursSpent=@hrs
                    WHERE IssueId=@id;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", i.IssueId);
                    cmd.Parameters.AddWithValue("@title", i.Title);
                    cmd.Parameters.AddWithValue("@desc", i.Description);
                    cmd.Parameters.AddWithValue("@sev", (int)i.Severity);
                    cmd.Parameters.AddWithValue("@st", (int)i.Status);
                    cmd.Parameters.AddWithValue("@env", (int)i.Environment);
                    cmd.Parameters.AddWithValue("@date", i.DateReported.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@rep", i.ReporterId);
                    cmd.Parameters.AddWithValue("@ass", i.AssigneeId);
                    cmd.Parameters.AddWithValue("@hrs", i.HoursSpent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteIssue(int issueId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Issues WHERE IssueId=@id;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", issueId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Issue> GetAllIssues()
        {
            List<Issue> result = new List<Issue>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Issues;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Issue i = new Issue();
                        i.IssueId = Convert.ToInt32(reader["IssueId"]);
                        i.Title = reader["Title"].ToString();
                        i.Description = reader["Description"].ToString();
                        i.Severity = (Severity)Convert.ToInt32(reader["Severity"]);
                        i.Status = (IssueStatus)Convert.ToInt32(reader["Status"]);
                        i.Environment = (IssueEnvironment)Convert.ToInt32(reader["Environment"]);
                        i.DateReported = DateTime.Parse(reader["DateReported"].ToString());
                        i.ReporterId = Convert.ToInt32(reader["ReporterId"]);
                        i.AssigneeId = Convert.ToInt32(reader["AssigneeId"]);
                        i.HoursSpent = Convert.ToDouble(reader["HoursSpent"]);
                        result.Add(i);
                    }
                }
            }

            return result;
        }


        // ===== DEVELOPERS CRUD =====

        public void InsertDeveloper(Developer d)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Developers
                    (DeveloperId, FirstName, LastName, Email, Specialization, BugsFixedCount, HireDate)
                    VALUES (@id, @fn, @ln, @em, @sp, @bf, @hd);";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", d.DeveloperId);
                    cmd.Parameters.AddWithValue("@fn", d.FirstName);
                    cmd.Parameters.AddWithValue("@ln", d.LastName);
                    cmd.Parameters.AddWithValue("@em", d.Email);
                    cmd.Parameters.AddWithValue("@sp", (int)d.Specialization);
                    cmd.Parameters.AddWithValue("@bf", d.BugsFixedCount);
                    cmd.Parameters.AddWithValue("@hd", d.HireDate.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDeveloper(Developer d)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Developers SET
                    FirstName=@fn, LastName=@ln, Email=@em, Specialization=@sp,
                    BugsFixedCount=@bf, HireDate=@hd
                    WHERE DeveloperId=@id;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", d.DeveloperId);
                    cmd.Parameters.AddWithValue("@fn", d.FirstName);
                    cmd.Parameters.AddWithValue("@ln", d.LastName);
                    cmd.Parameters.AddWithValue("@em", d.Email);
                    cmd.Parameters.AddWithValue("@sp", (int)d.Specialization);
                    cmd.Parameters.AddWithValue("@bf", d.BugsFixedCount);
                    cmd.Parameters.AddWithValue("@hd", d.HireDate.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDeveloper(int developerId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Developers WHERE DeveloperId=@id;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", developerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Developer> GetAllDevelopers()
        {
            List<Developer> result = new List<Developer>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Developers;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Developer d = new Developer();
                        d.DeveloperId = Convert.ToInt32(reader["DeveloperId"]);
                        d.FirstName = reader["FirstName"].ToString();
                        d.LastName = reader["LastName"].ToString();
                        d.Email = reader["Email"].ToString();
                        d.Specialization = (Specialization)Convert.ToInt32(reader["Specialization"]);
                        d.BugsFixedCount = Convert.ToInt32(reader["BugsFixedCount"]);
                        d.HireDate = DateTime.Parse(reader["HireDate"].ToString());
                        result.Add(d);
                    }
                }
            }

            return result;
        }
    }
}