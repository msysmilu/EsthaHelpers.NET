using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EsthaHelpers.Time
{
    public class DateTimeHelpers
    {
        private static string epoch_start_yyyyMMddHHmmss = "19700101000000";
        private static string epoch_start_yyyyMMdd = "19700101";
        private static string midnight_hhmmss = "000000";

        /// <summary>
        /// Returns a DateTime object by parsing the string in the parameter (yyyyMMddHHmmss, yyyyMMdd, hhmmss).
        /// </summary>
        /// <param name="dateTimeString">A strgin in the formats: yyyyMMddHHmmss, yyyyMMdd, hhmmss</param>
        /// <returns>A DateTime object from the parsed strings or Begining Of Epoch in case of error </returns>
        public static DateTime parseDateTime(String dateTimeString)
        {
            switch (dateTimeString.Length)
            {
                case 14: return parseDateTime_yyyyMMddHHmmss(dateTimeString);
                case 8: return parseDateTime_yyyyMMdd(dateTimeString);
                case 6: return parseTime_HHmmss(dateTimeString);
                default:
                    {
                        Console.WriteLine("{0} is not in the correct format.", dateTimeString);
                        return parseDateTime_yyyyMMddHHmmss(epoch_start_yyyyMMddHHmmss);
                    }
            }
        }

        /// <summary>
        /// Returns TRUE if the string is parsable by the methods of this class
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static Boolean isParsable(String dateString)
        {
            // eliminating the correct defaults: beggining of epoch / midnight
            if (epoch_start_yyyyMMddHHmmss == dateString) return true;
            if (midnight_hhmmss == dateString) return true;
            // these parsers will return "beggining of epoch" in case of error; hoping one will return different (TRUE, parsable)
            if (parseDateTime_yyyyMMddHHmmss(epoch_start_yyyyMMddHHmmss) != parseDateTime_yyyyMMddHHmmss(dateString)) return true;
            if (parseDateTime_yyyyMMddHHmmss(epoch_start_yyyyMMddHHmmss) != parseDateTime_yyyyMMdd(dateString)) return true;
            if (parseTime_HHmmss(midnight_hhmmss) != parseTime_HHmmss(dateString)) return true;
            return false;
        }

        public static DateTime parseDateTime_yyyyMMddHHmmss(String dateString)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String format = "yyyyMMddHHmmss";
            try
            {
                DateTime result = DateTime.ParseExact(dateString, format, provider);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", dateString);
                DateTime result = DateTime.ParseExact(epoch_start_yyyyMMddHHmmss, format, provider);
                return result;
            }
        }

        public static DateTime parseDateTime_yyyyMMdd(String dateString)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String format = "yyyyMMdd";
            try
            {
                DateTime result = DateTime.ParseExact(dateString, format, provider);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", dateString);
                DateTime result = DateTime.ParseExact(epoch_start_yyyyMMdd, format, provider);
                return result;
            }
        }

        public static DateTime parseTime_HHmmss(String timeString)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String format = "HHmmss";
            try
            {
                DateTime result = DateTime.ParseExact(timeString, format, provider);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", timeString);
                DateTime result = DateTime.ParseExact(midnight_hhmmss, format, provider);
                return result;
            }
        }

        public static long getUnixTimestampNow()
        {
            return getUnixTimestamp(DateTime.UtcNow);
        }

        public static long getUnixTimestamp(DateTime dt)
        {
            return (Int32)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime getEpochDatetime
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0);
            }
        }

    }
}