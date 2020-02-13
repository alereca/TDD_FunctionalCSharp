using System;
using LaYumba.Functional;

namespace Functions.Chapter4
{
    public class Employee
    {
        public Employee(string id, Option<WorkPermit> workPermit, DateTime joinedOn, Option<DateTime> leftOn)
        {
            Id = id;
            WorkPermit = workPermit;
            JoinedOn = joinedOn;
            LeftOn = leftOn;
        }

        public string Id { get; set; }
        public Option<WorkPermit> WorkPermit { get; set; }
        public DateTime JoinedOn { get; }
        public Option<DateTime> LeftOn { get; }
    }

    public struct WorkPermit
   {
        public WorkPermit(string number, DateTime expiry)
        {
            Number = number;
            Expiry = expiry;
        }

        public string Number { get; set; }
      public DateTime Expiry { get; set; }
   }
}