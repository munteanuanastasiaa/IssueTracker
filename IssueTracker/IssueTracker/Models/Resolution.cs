using System;

namespace IssueTracker.Models
{
    public class Resolution
    {
        private int resolutionId;
        private int issueId;
        private int developerId;
        private double hoursTaken;

        public int ResolutionId
        {
            get { return resolutionId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id-ul nu poate fi negativ.");
                resolutionId = value;
            }
        }

        public int IssueId
        {
            get { return issueId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("IssueId invalid.");
                issueId = value;
            }
        }

        public int DeveloperId
        {
            get { return developerId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("DeveloperId invalid.");
                developerId = value;
            }
        }

        public string Description { get; set; }
        public DateTime DateResolved { get; set; }

        public double HoursTaken
        {
            get { return hoursTaken; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Orele nu pot fi negative.");
                hoursTaken = value;
            }
        }

        public string PullRequestUrl { get; set; }


        public Resolution()
        {
            resolutionId = 0;
            issueId = 0;
            developerId = 0;
            Description = "";
            DateResolved = DateTime.Now;
            hoursTaken = 0;
            PullRequestUrl = "";
        }

        public Resolution(int id, int issueId, int devId, string desc)
        {
            ResolutionId = id;
            IssueId = issueId;
            DeveloperId = devId;
            Description = desc;
            DateResolved = DateTime.Now;
            HoursTaken = 0;
            PullRequestUrl = "";
        }

        public Resolution(int id, int issueId, int devId, string desc,
            DateTime dateResolved, double hours, string prUrl)
        {
            ResolutionId = id;
            IssueId = issueId;
            DeveloperId = devId;
            Description = desc;
            DateResolved = dateResolved;
            HoursTaken = hours;
            PullRequestUrl = prUrl;
        }


        public override string ToString()
        {
            return "Resolution #" + ResolutionId + " for Issue #" + IssueId;
        }
    }
}