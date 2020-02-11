using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter3
{
    public static class MethodSignatures
    {
        public enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

        public static Option<DayOfWeek> DayOfWeekParse(string day)
        {
            return day switch
            {
                "Monday" => Some(DayOfWeek.Monday),
                "Tuesday" => Some(DayOfWeek.Tuesday),
                "Wednesday" => Some(DayOfWeek.Wednesday),
                "Thursday" => Some(DayOfWeek.Thursday),
                "Friday" => Some(DayOfWeek.Friday),
                "Saturday" => Some(DayOfWeek.Saturday),
                "Sunday" => Some(DayOfWeek.Sunday),
                _ => None
            };
        }

        public static Option<T> Lookup<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (T t in list)
            {
                if (predicate(t))
                {
                    return Some(t);
                }
            }

            return None;
        }
    }
}