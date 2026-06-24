using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models;

namespace IssueTracker.ViewModels
{
    // ViewModel pentru Developer
    public class DeveloperViewModel : BindableObject
    {
        private Developer dev;

        public DeveloperViewModel()
        {
            dev = new Developer();
        }

        public DeveloperViewModel(Developer existing)
        {
            dev = existing;
        }

        public Developer GetDeveloper()
        {
            return dev;
        }


        public int DeveloperId
        {
            get { return dev.DeveloperId; }
            set
            {
                dev.DeveloperId = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return dev.FirstName; }
            set
            {
                dev.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return dev.LastName; }
            set
            {
                dev.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return dev.Email; }
            set
            {
                dev.Email = value;
                OnPropertyChanged();
            }
        }

        public Specialization Specialization
        {
            get { return dev.Specialization; }
            set
            {
                dev.Specialization = value;
                OnPropertyChanged();
            }
        }

        public string[] Languages
        {
            get { return dev.Languages; }
            set
            {
                dev.Languages = value;
                OnPropertyChanged();
            }
        }

        public int BugsFixedCount
        {
            get { return dev.BugsFixedCount; }
            set
            {
                dev.BugsFixedCount = value;
                OnPropertyChanged();
            }
        }

        public DateTime HireDate
        {
            get { return dev.HireDate; }
            set
            {
                dev.HireDate = value;
                OnPropertyChanged();
            }
        }
    }
}