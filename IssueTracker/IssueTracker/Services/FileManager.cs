using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web.Script.Serialization;
using IssueTracker.Models;

namespace IssueTracker.Services
{
    // class that handles file I/O for issues
    // supports CSV, JSON and binary formats
    public class FileManager
    {
      

        public static void SaveIssuesToCsv(List<Issue> issues, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("IssueId,Title,Description,Severity,Status,Environment,DateReported,ReporterId,AssigneeId,HoursSpent");

            foreach (Issue i in issues)
            {
                string line = i.IssueId + "," +
                              EscapeCsv(i.Title) + "," +
                              EscapeCsv(i.Description) + "," +
                              i.Severity + "," +
                              i.Status + "," +
                              i.Environment + "," +
                              i.DateReported.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                              i.ReporterId + "," +
                              i.AssigneeId + "," +
                              i.HoursSpent;
                sb.AppendLine(line);
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        public static List<Issue> LoadIssuesFromCsv(string filePath)
        {
            List<Issue> result = new List<Issue>();

            if (!File.Exists(filePath))
                return result;

            string[] lines = File.ReadAllLines(filePath);

            // skip header (first line)
            for (int idx = 1; idx < lines.Length; idx++)
            {
                string[] parts = lines[idx].Split(',');
                if (parts.Length < 10) continue;

                Issue i = new Issue();
                i.IssueId = int.Parse(parts[0]);
                i.Title = UnescapeCsv(parts[1]);
                i.Description = UnescapeCsv(parts[2]);
                i.Severity = (Severity)Enum.Parse(typeof(Severity), parts[3]);
                i.Status = (IssueStatus)Enum.Parse(typeof(IssueStatus), parts[4]);
                i.Environment = (IssueEnvironment)Enum.Parse(typeof(IssueEnvironment), parts[5]);
                i.DateReported = DateTime.Parse(parts[6]);
                i.ReporterId = int.Parse(parts[7]);
                i.AssigneeId = int.Parse(parts[8]);
                i.HoursSpent = double.Parse(parts[9]);

                result.Add(i);
            }

            return result;
        }

        // helpers for CSV escaping (handles commas inside titles, etc.)
        private static string EscapeCsv(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            string escaped = s.Replace("\"", "\"\"").Replace(",", ";");
            return escaped;
        }

        private static string UnescapeCsv(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\"\"", "\"").Replace(";", ",");
        }


        // ===== JSON =====

        public static void SaveIssuesToJson(List<Issue> issues, string filePath)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(issues);
            File.WriteAllText(filePath, json);
        }

        public static List<Issue> LoadIssuesFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Issue>();

            string json = File.ReadAllText(filePath);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<Issue>>(json);
        }


        // ===== Binary =====

        public static void SaveIssuesToBinary(List<Issue> issues, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, issues);
            }
        }

        public static List<Issue> LoadIssuesFromBinary(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Issue>();

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Issue>)formatter.Deserialize(fs);
            }
        }
    }
}
