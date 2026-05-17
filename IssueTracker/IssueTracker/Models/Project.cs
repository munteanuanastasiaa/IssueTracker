using System;
using System.Collections.Generic;

namespace IssueTracker.Models
{
    public class Project
    {
        private int projectId;
        private string name;

        public const int MAX_MODULES = 5;

        public int ProjectId
        {
            get { return projectId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id-ul nu poate fi negativ.");
                projectId = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Numele proiectului nu poate fi gol.");
                name = value;
            }
        }

        public DateTime CreationDate { get; set; }
        public string[] Modules { get; set; }
        public List<Issue> Issues { get; set; }


        public Project()
        {
            projectId = 0;
            name = "New Project";
            CreationDate = DateTime.Now;
            Modules = new string[MAX_MODULES];
            Issues = new List<Issue>();
        }

        public Project(int id, string name)
        {
            ProjectId = id;
            Name = name;
            CreationDate = DateTime.Now;
            Modules = new string[MAX_MODULES];
            Issues = new List<Issue>();
        }

        public Project(int id, string name, DateTime creationDate, string[] modules, List<Issue> issues)
        {
            ProjectId = id;
            Name = name;
            CreationDate = creationDate;
            Modules = modules;
            Issues = issues;
        }


        // indexator - acces la issue dupa pozitie
        public Issue this[int index]
        {
            get
            {
                if (index < 0 || index >= Issues.Count)
                    throw new IndexOutOfRangeException("Index in afara limitelor.");
                return Issues[index];
            }
        }

        public void AddIssue(Issue issue)
        {
            Issues.Add(issue);
        }

        public int IssueCount()
        {
            return Issues.Count;
        }


        public override string ToString()
        {
            return Name + " (" + Issues.Count + " issues)";
        }
    }
}
