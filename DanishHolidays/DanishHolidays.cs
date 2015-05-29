using System;
using System.Collections.Generic;
using System.Linq;

namespace DanishHolidays
{
    public static class DanishHoliday
    {
        private static void EasterSunday(int year, ref int month, ref int day)
        {
            int g = year % 19;
            int c = year / 100;
            int h = h= (c - (int)(c / 4) - (int)((8 * c + 13) / 25)
                                                + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) *
                        (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) +
                          i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }
        }
        private static DateTime EasterSunday(int year)
        {
            int month = 0;
            int day = 0;
            EasterSunday(year, ref month, ref day);

            return new DateTime(year, month, day);
        }

        public static bool IsHoliday(this DateTime date)
        {
           var holiday = GetHolidays(date.Year).First(h => h.Date.ToShortDateString() == date.ToShortDateString());
           if (holiday != null) return true;
           return false;
        }

        public static bool IsHoliday(this DateTime date, out HolidayModel holiday)
        {
            var _holiday = GetHolidays(date.Year).First(h => h.Date.ToShortDateString() == date.ToShortDateString());
            if (_holiday != null)
            {
                holiday = _holiday;
                return true;
            }
      
            holiday = null;
            return false;
        }

        public static List<HolidayModel> GetHolidays()
        {
           return GetHolidays((DateTime.Now.Year));
        }
        public static List<HolidayModel> GetHolidays(int year)
        {
            var A_DAY = 86400;
            var leapYear = DateTime.IsLeapYear(year);
            var fastelavn = leapYear ? 49 : 48;
            var easterSunday = EasterSunday(year);

            var holidays = new List<HolidayModel>();
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year,1,1),
                Name = "Nytårsdag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.SubstractSeconds(3*A_DAY),
                Name = "Skærtorsdag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.SubstractSeconds(2 * A_DAY),
                Name = "Langfredag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday,
                Name = "Påskedag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.AddSeconds(1 * A_DAY),
                Name = "2. Påskedag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.AddSeconds(26 * A_DAY),
                Name = "Store bededag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.AddSeconds(39 * A_DAY),
                Name = "Kr. himmelfartsdag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.AddSeconds(49 * A_DAY),
                Name = "Pinsedag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.AddSeconds(50 * A_DAY),
                Name = "2. Pinsedag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year, 6, 5),
                Name = "Grundlovsdag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year, 12, 24),
                Name = "Juleaften",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year, 12, 25),
                Name = "1. Juledag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year, 12, 26),
                Name = "2. Juledag",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year, 12, 31),
                Name = "Nytårsaften",
                IsDayOff = true
            });
            holidays.Add(new HolidayModel
            {
                Date = easterSunday.SubstractSeconds(fastelavn*A_DAY),
                Name = "Fastelavn",
                IsDayOff = false
            });
            holidays.Add(new HolidayModel
            {
                Date = new DateTime(year,1,6),
                Name = "Hellig 3 Konger",
                IsDayOff = false
            });

            return holidays;
        }
    }

    internal static class extensions
    {
        internal static DateTime SubstractSeconds(this DateTime date, int seconds)
        {
            return date.AddSeconds(-seconds);
        }
    }
}