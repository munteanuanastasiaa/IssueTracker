using System;

namespace IssueTracker.Models
{
    public class QATester
    {
        private int qaId;
        private string firstName;
        private string lastName;

        public static int TotalQACount = 0;
        public const int MAX_CERTIFICATIONS = 3;

        public int QATesterId
        {
            get { return qaId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Not able to have a negative ID.");
                qaId = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Needs to have a first name.");
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Needs to have a last name.");
                lastName = value;
            }
        }

        public string Email { get; set; }
        public string[] TestingTools { get; set; }
        public string[] Certifications { get; set; }
        public int BugsFoundCount { get; set; }
        public DateTime HireDate { get; set; }


        public QATester()
        {
            qaId = 0;
            firstName = "Unknown";
            lastName = "Unknown";
            Email = "";
            TestingTools = new string[0];
            Certifications = new string[MAX_CERTIFICATIONS];
            BugsFoundCount = 0;
            HireDate = DateTime.Now;
            TotalQACount++;
        }

        public QATester(int id, string firstName, string lastName, string email)
        {
            QATesterId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TestingTools = new string[0];
            Certifications = new string[MAX_CERTIFICATIONS];
            BugsFoundCount = 0;
            HireDate = DateTime.Now;
            TotalQACount++;
        }

        public QATester(int id, string firstName, string lastName, string email,
            string[] tools, string[] certs, int bugsFound, DateTime hireDate)
        {
            QATesterId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TestingTools = tools;
            Certifications = certs;
            BugsFoundCount = bugsFound;
            HireDate = hireDate;
            TotalQACount++;
        }


        public override string ToString()
        {
            return FirstName + " " + LastName + " (QA)";
        }
    }
}
