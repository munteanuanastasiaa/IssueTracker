using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models;

namespace IssueTracker.ViewModels
{
    // ViewModel pentru Issue
    // expune campurile cu notificare ca sa mearga data binding pe form
    public class IssueViewModel : BindableObject
    {
        private Issue issue;

        public IssueViewModel()
        {
            issue = new Issue();
        }

        public IssueViewModel(Issue existing)
        {
            issue = existing;
        }

        // returneaza modelul de dedesubt (folosit la save)
        public Issue GetIssue()
        {
            return issue;
        }


        public int IssueId
        {
            get { return issue.IssueId; }
            set
            {
                issue.IssueId = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return issue.Title; }
            set
            {
                issue.Title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return issue.Description; }
            set
            {
                issue.Description = value;
                OnPropertyChanged();
            }
        }

        public Severity Severity
        {
            get { return issue.Severity; }
            set
            {
                issue.Severity = value;
                OnPropertyChanged();
            }
        }

        public IssueStatus Status
        {
            get { return issue.Status; }
            set
            {
                issue.Status = value;
                OnPropertyChanged();
            }
        }

        public IssueEnvironment Environment
        {
            get { return issue.Environment; }
            set
            {
                issue.Environment = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateReported
        {
            get { return issue.DateReported; }
            set
            {
                issue.DateReported = value;
                OnPropertyChanged();
            }
        }

        public int ReporterId
        {
            get { return issue.ReporterId; }
            set
            {
                issue.ReporterId = value;
                OnPropertyChanged();
            }
        }

        public int AssigneeId
        {
            get { return issue.AssigneeId; }
            set
            {
                issue.AssigneeId = value;
                OnPropertyChanged();
            }
        }

        public double HoursSpent
        {
            get { return issue.HoursSpent; }
            set
            {
                issue.HoursSpent = value;
                OnPropertyChanged();
            }
        }

        public string[] Labels
        {
            get { return issue.Labels; }
            set
            {
                issue.Labels = value;
                OnPropertyChanged();
            }
        }

        public int[] AffectedVersions
        {
            get { return issue.AffectedVersions; }
            set
            {
                issue.AffectedVersions = value;
                OnPropertyChanged();
            }
        }
    }
}