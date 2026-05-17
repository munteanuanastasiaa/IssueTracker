using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    
      [Serializable]
    public class Issue
    {
      
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; }
        public IssueStatus Status { get; set; }
        public IssueEnvironment Environment { get; set; }
        public DateTime DateReported { get; set; }
        public int ReporterId { get; set; }
        public int AssigneeId { get; set; }
        public double HoursSpent { get; set; }
        public string[] Labels { get; set; }
        public int[] AffectedVersions { get; set; }

      //def const
        public Issue()
        {
            IssueId = 0;
            Title = string.Empty;
            Description = string.Empty;
            Severity = Severity.Low;
            Status = IssueStatus.Open;
            Environment = IssueEnvironment.Local;
            DateReported = DateTime.Now;
            ReporterId = 0;
            AssigneeId = 0;
            HoursSpent = 0.0;
            Labels = new string[0];
            AffectedVersions = new int[0];
        }

       //low ef const
        public Issue(int issueId, string title, string description, Severity severity, int reporterId)
        {
            IssueId = issueId;
            Title = title;
            Description = description;
            Severity = severity;
            Status = IssueStatus.Open;            
            Environment = IssueEnvironment.Local;
            DateReported = DateTime.Now;        
            ReporterId = reporterId;
            AssigneeId = 0;                      
            HoursSpent = 0.0;
            Labels = new string[0];
            AffectedVersions = new int[0];
        }

        //Full const
        public Issue(
            int issueId,
            string title,
            string description,
            Severity severity,
            IssueStatus status,
            IssueEnvironment environment,
            DateTime dateReported,
            int reporterId,
            int assigneeId,
            double hoursSpent,
            string[] labels,
            int[] affectedVersions)
        {
            IssueId = issueId;
            Title = title;
            Description = description;
            Severity = severity;
            Status = status;
            Environment = environment;
            DateReported = dateReported;
            ReporterId = reporterId;
            AssigneeId = assigneeId;
            HoursSpent = hoursSpent;
            Labels = labels;
            AffectedVersions = affectedVersions;
        }
    }
}