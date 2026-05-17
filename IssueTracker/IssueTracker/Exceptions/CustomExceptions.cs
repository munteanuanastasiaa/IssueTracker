using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IssueTracker.Exceptions
{
    // exceptie aruncata cand un issue cautat dupa id nu exista
    public class IssueNotFoundException : Exception
    {
        public IssueNotFoundException(int id)
            : base("No issue with this ID " + id + ".")
        {
        }

        public IssueNotFoundException(string message) : base(message)
        {
        }
    }

    // exceptie aruncata cand incerci sa adaugi ceva cu un id deja folosit
    public class DuplicateIdException : Exception
    {
        public DuplicateIdException(int id)
            : base("Alr an element with this ID " + id + ".")
        {
        }

        public DuplicateIdException(string message) : base(message)
        {
        }
    }

    // exceptie aruncata cand tranzitia statusului unui issue nu e permisa
    public class InvalidStatusTransitionException : Exception
    {
        public InvalidStatusTransitionException(string fromStatus, string toStatus)
            : base("Can t get past  " + fromStatus + " to " + toStatus + ".")
        {
        }

        public InvalidStatusTransitionException(string message) : base(message)
        {
        }
    }
}