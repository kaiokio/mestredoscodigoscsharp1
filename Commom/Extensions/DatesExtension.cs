using System;
using System.Collections.Generic;
using System.Text;

namespace Commom.Extensions
{
    public static class DatesExtension
    {
        public static int CalculateAgeCurrentDate(this DateTime birthDate)
        {
            var currentDate = DateTime.Today;
            var age = currentDate.Year - birthDate.Year;

            if (birthDate.Date > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
