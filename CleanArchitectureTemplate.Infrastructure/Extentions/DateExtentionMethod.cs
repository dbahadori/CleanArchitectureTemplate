using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Extentions
{
    public static class DateExtentionMethod
    {
        public static long ToTimeStampSeconds(this DateTime dateTime)
        {
            DateTimeOffset dto = new DateTimeOffset(dateTime.ToUniversalTime());
            return dto.ToUnixTimeSeconds();
        }

        public static long ToTimeStampMilliSeconds(this DateTime dateTime)
        {
            DateTimeOffset dto = new DateTimeOffset(dateTime.ToUniversalTime());
            return dto.ToUnixTimeMilliseconds();
        }

        public static DateTime ToDateTime(this long? timeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime DateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime = DateTime.AddSeconds(timeStamp!.Value).ToUniversalTime();

            return DateTime;
        }
    }
}