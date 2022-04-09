using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using System.Threading;

namespace SistemaControlEmpleados
{
     public class Employee : User
    {
        public RegistredWeeks   WeekInProgress {
            get
            {
                if (RegistredWeeks.Any())
                {
                    return RegistredWeeks.Where(x => x.isChecked == false).OrderByDescending(x => x.RegisDate).FirstOrDefault();
                }
                return null;
            }
            }
        public List<RegistredWeeks> RegistredWeeks { get; set; } = new List<RegistredWeeks>();
        public bool PendingHours
        {
            get
            {
                if (RegistredWeeks.Any())
                {
                    return RegistredWeeks.Where(x => x.isChecked == false).Count() > 0 ? true : false;
                }
                return false;
            }
        } 
        public void SetHoursOfWeek(int hours, string description)
        {
            RegistredWeeks thisWeek = new RegistredWeeks() { AmountHours = hours, RegisDate = DateTime.Today, isChecked = false, isAproved = false, Description = description };
            RegistredWeeks.Add(thisWeek);
        }
    }

    public class RegistredWeeks
    {
        public DateTime RegisDate { get; set; }
        public int AmountHours { get; set; }
        public string Description { get; set; }
        public bool  isAproved { get; set; }
        public bool isChecked { get; set; } = false;
    }
}
