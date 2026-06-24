using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IssueTracker.Models;

namespace IssueTracker.Services
{
    // generates reports from a list of issues
    // can export to txt file or return as string
    public class ReportGenerator
    {
      
        public static string IssuesPerDeveloper(List<Issue> issues, List<Developer> developers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== ISSUES PER DEVELOPER =====");
            sb.AppendLine("Generated: " + DateTime.Now);
            sb.AppendLine();

            foreach (Developer d in developers)
            {
                int count = 0;
                foreach (Issue i in issues)
                {
                    if (i.AssigneeId == d.DeveloperId)
                        count++;
                }

                sb.AppendLine(d.FirstName + " " + d.LastName + " (" + d.Specialization + "): " + count + " issues");
            }

            sb.AppendLine();
            sb.AppendLine("Total issues: " + issues.Count);
            sb.AppendLine("Total developers: " + developers.Count);

            return sb.ToString();
        }


        
        public static string SeverityDistribution(List<Issue> issues)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== SEVERITY DISTRIBUTION =====");
            sb.AppendLine("Generated: " + DateTime.Now);
            sb.AppendLine();

            int low = 0, medium = 0, high = 0, critical = 0;
            foreach (Issue i in issues)
            {
                if (i.Severity == Severity.Low) low++;
                else if (i.Severity == Severity.Medium) medium++;
                else if (i.Severity == Severity.High) high++;
                else if (i.Severity == Severity.Critical) critical++;
            }

            int total = issues.Count;
            sb.AppendLine("Low:      " + low + " (" + Percent(low, total) + "%)");
            sb.AppendLine("Medium:   " + medium + " (" + Percent(medium, total) + "%)");
            sb.AppendLine("High:     " + high + " (" + Percent(high, total) + "%)");
            sb.AppendLine("Critical: " + critical + " (" + Percent(critical, total) + "%)");
            sb.AppendLine();
            sb.AppendLine("Total: " + total);

            return sb.ToString();
        }


       
        public static string StatusSummary(List<Issue> issues)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== ISSUE STATUS SUMMARY =====");
            sb.AppendLine("Generated: " + DateTime.Now);
            sb.AppendLine();

            int open = 0, inProgress = 0, readyForQA = 0, testing = 0, reopened = 0, closed = 0;

            foreach (Issue i in issues)
            {
                switch (i.Status)
                {
                    case IssueStatus.Open: open++; break;
                    case IssueStatus.InProgress: inProgress++; break;
                    case IssueStatus.ReadyForQA: readyForQA++; break;
                    case IssueStatus.Testing: testing++; break;
                    case IssueStatus.Reopened: reopened++; break;
                    case IssueStatus.Closed: closed++; break;
                }
            }

            sb.AppendLine("Open:         " + open);
            sb.AppendLine("In Progress:  " + inProgress);
            sb.AppendLine("Ready for QA: " + readyForQA);
            sb.AppendLine("Testing:      " + testing);
            sb.AppendLine("Reopened:     " + reopened);
            sb.AppendLine("Closed:       " + closed);
            sb.AppendLine();
            sb.AppendLine("Total: " + issues.Count);

            int stillOpen = open + inProgress + readyForQA + testing + reopened;
            sb.AppendLine("Still open (not closed): " + stillOpen);

            return sb.ToString();
        }


       
        public static void SaveReportToTxt(string reportContent, string filePath)
        {
            File.WriteAllText(filePath, reportContent);
        }


        private static string Percent(int part, int total)
        {
            if (total == 0) return "0";
            double p = (double)part / total * 100;
            return p.ToString("0.0");
        }
    }
}