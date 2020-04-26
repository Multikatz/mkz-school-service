using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkz_school_service.Utility
{
    public class UDate
    {
        public static DateTime? ConvertDateOrNull(string value)
        {
            DateTime? convertDate = null;

            if (string.IsNullOrWhiteSpace(value))
            {
                convertDate = DateTime.Parse(value);
            }

            return convertDate;
        }
    }
}
