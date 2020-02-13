using System;
using System.Collections;
using System.Collections.Generic;
using Functions.Chapter4;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Tests.Chapter4
{
    public class GetWorkPermitTestData : IEnumerable<object[]>
    {
        private List<object[]> _data = new List<object[]>
        {
            new object[] {GetPeople(), EmployeeWithValidWorkPermit.Id, EmployeeWithValidWorkPermit.WorkPermit},
            new object[] {GetPeople(), EmployeeWithoutWorkPermit.Id, None},
            new object[] {GetPeople(), EmployeeWithInvalidWorkPermit.Id, None}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static Employee EmployeeWithValidWorkPermit = new Employee("abc", 
            new WorkPermit("411", DateTime.Now.AddMonths(2)), DateTime.Now.AddMonths(-11), None);
        private static Employee EmployeeWithoutWorkPermit = new Employee("xfc", None, DateTime.Now, None);
        private static Employee EmployeeWithInvalidWorkPermit = new Employee("hgs", 
            new WorkPermit("787", DateTime.Now.AddMonths(-2)), DateTime.Now.AddMonths(-8), None);

        private static Dictionary<string, Employee> GetPeople()
        {
            return new Dictionary<string, Employee> {
                {"pedro", EmployeeWithValidWorkPermit},
                {"juan", EmployeeWithoutWorkPermit},
                {"santiago", EmployeeWithInvalidWorkPermit}
            };
        }
    }
}