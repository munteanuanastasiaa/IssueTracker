using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models;

namespace IssueTracker.ViewModels
{
    // ViewModel pentru Project
    public class ProjectViewModel : BindableObject
    {
        private Project project;

        public ProjectViewModel()
        {
            project = new Project();
        }

        public ProjectViewModel(Project existing)
        {
            project = existing;
        }

        public Project GetProject()
        {
            return project;
        }


        public int ProjectId
        {
            get { return project.ProjectId; }
            set
            {
                project.ProjectId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return project.Name; }
            set
            {
                project.Name = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreationDate
        {
            get { return project.CreationDate; }
            set
            {
                project.CreationDate = value;
                OnPropertyChanged();
            }
        }

        public string[] Modules
        {
            get { return project.Modules; }
            set
            {
                project.Modules = value;
                OnPropertyChanged();
            }
        }

        public List<Issue> Issues
        {
            get { return project.Issues; }
            set
            {
                project.Issues = value;
                OnPropertyChanged();
            }
        }


        public int IssueCount
        {
            get { return project.IssueCount(); }
        }
    }
}
