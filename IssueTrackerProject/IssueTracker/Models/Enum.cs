using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
  
    public enum Severity
    {
        Low,        // cosmetic, doesn't affect functionality
        Medium,     // affects functionality but workaround exists
        High,       // major functionality broken
        Critical    // app crashes / data loss / blocks all users
    }

    // Where is the issue in its lifecycle?
    public enum IssueStatus
    {
        Open,         // reported, not picked up yet
        InProgress,   // a developer is actively working on it
        ReadyForQA,   // dev finished, PR done, waiting for QA
        Testing,      // QA actively testing
        Reopened,     // QA found the fix doesn't work -> back to devs
        Closed        // QA confirmed it works -> done
    }

    // Which env was the bug found in?
    // IssueEnvironment to avoid conflict with System.Environment
    public enum IssueEnvironment
    {
        Local,        // dev's own machine
        Dev,          // dev server
        Staging,      // pre-production
        Production    // live, users affected
    }

    // Kind of dev?
    public enum Specialization
    {
        Frontend,
        Backend,
        FullStack,
        Mobile,
        DevOps,
        Database
    }
}
