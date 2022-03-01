using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Extentions
{
    internal static class DateTimeExtensions
    {
        public static int DifferenceInYears(this DateTime dateTimeSource, DateTime dateTimeDiff)
        {
            int age = dateTimeDiff.Year - dateTimeSource.Year;

            if (dateTimeDiff.Month < dateTimeSource.Month || (dateTimeDiff.Month == dateTimeSource.Month && dateTimeDiff.Day < dateTimeSource.Day))
            {
                age--;
            }

            return age;
        }

        public static bool HasMinimalAge(this DateTime datetime)
        {
            return datetime.DifferenceInYears(DateTime.Today) >= 21;
        }
    }
}
