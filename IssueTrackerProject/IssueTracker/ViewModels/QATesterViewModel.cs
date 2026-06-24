using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models;

namespace IssueTracker.ViewModels
{
   
    public class QATesterViewModel : BindableObject
    {
        private QATester qa;

        public QATesterViewModel()
        {
            qa = new QATester();
        }

        public QATesterViewModel(QATester existing)
        {
            qa = existing;
        }

        public QATester GetQATester()
        {
            return qa;
        }


        public int QATesterId
        {
            get { return qa.QATesterId; }
            set
            {
                qa.QATesterId = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return qa.FirstName; }
            set
            {
                qa.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return qa.LastName; }
            set
            {
                qa.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return qa.Email; }
            set
            {
                qa.Email = value;
                OnPropertyChanged();
            }
        }

        public string[] TestingTools
        {
            get { return qa.TestingTools; }
            set
            {
                qa.TestingTools = value;
                OnPropertyChanged();
            }
        }

        public string[] Certifications
        {
            get { return qa.Certifications; }
            set
            {
                qa.Certifications = value;
                OnPropertyChanged();
            }
        }

        public int BugsFoundCount
        {
            get { return qa.BugsFoundCount; }
            set
            {
                qa.BugsFoundCount = value;
                OnPropertyChanged();
            }
        }

        public DateTime HireDate
        {
            get { return qa.HireDate; }
            set
            {
                qa.HireDate = value;
                OnPropertyChanged();
            }
        }
    }
}
