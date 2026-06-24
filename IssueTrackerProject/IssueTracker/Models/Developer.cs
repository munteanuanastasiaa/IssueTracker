using System;

namespace IssueTracker.Models
{
    public class Developer
    {
      
        private int developerId;
        private string firstName;
        private string lastName;
        public static int TotalDeveloperCount = 0;
        public const int MAX_LANGUAGES = 5;

        public int DeveloperId
        {
            get { return developerId; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "DeveloperId cannot be negative.");
                developerId = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("FirstName cannot be empty.", nameof(value));
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("LastName cannot be empty.", nameof(value));
                lastName = value;
            }
        }

        public string Email { get; set; }
        public Specialization Specialization { get; set; }
        public string[] Languages { get; set; }
        public int BugsFixedCount { get; set; }
        public DateTime HireDate { get; set; }

        //consts
        public Developer()
        {
            developerId = 0;
            firstName = "Unknown";
            lastName = "Unknown";
            Email = string.Empty;
            Specialization = Specialization.FullStack;
            Languages = new string[MAX_LANGUAGES];
            BugsFixedCount = 0;
            HireDate = DateTime.Now;
            TotalDeveloperCount++;
        }

        public Developer(int developerId, string firstName, string lastName, string email, Specialization specialization)
        {
            DeveloperId = developerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Specialization = specialization;
            Languages = new string[MAX_LANGUAGES];
            BugsFixedCount = 0;
            HireDate = DateTime.Now;
            TotalDeveloperCount++;
        }

        public Developer(int developerId, string firstName, string lastName, string email,
            Specialization specialization, string[] languages, int bugsFixedCount, DateTime hireDate)
        {
            DeveloperId = developerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Specialization = specialization;
            Languages = languages;
            BugsFixedCount = bugsFixedCount;
            HireDate = hireDate;
            TotalDeveloperCount++;
        }

      
        public override string ToString()
        {
            return FirstName + " " + LastName + " (" + Specialization + ")";
        }
    }
}
