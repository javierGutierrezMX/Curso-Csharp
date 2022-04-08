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
        public RegistredWeeks   WeekInProgress { get; set; }
        public List<RegistredWeeks> RegistredWeeks { get; set; } = new List<RegistredWeeks>();
        public bool PendingHours {
            get
            {
                if (RegistredWeeks.Select(x => x.isChecked == false) != null)
                    return true;
                else return false;
            }
                }
        public void SetHoursOfWeek(int hours)
        {
            RegistredWeeks thisWeek = new RegistredWeeks() { AmountHours = hours, RegisDate = DateTime.Today, isChecked = false, isAproved = false };
            RegistredWeeks.Add(thisWeek);
        }
    }

    public class RegistredWeeks
    {
        public DateTime RegisDate { get; set; }
        public int AmountHours { get; set; }
        public bool  isAproved { get; set; }
        public bool isChecked { get; set; } = false;
    }
}
