using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkz_school_service.Utility
{
    public class UGuid
    {
        public static object GuidOrNull(Guid value)
        {
            object GuidResult = DBNull.Value;

            if (value != Guid.Empty)
            {
                GuidResult = (object)value;
            }

            return GuidResult;
        }
    }
}
