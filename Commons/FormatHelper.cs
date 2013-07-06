using System;
using System.Linq;

namespace Commons
{
    public class FormatHelper
    {
        public static Boolean StringToBoolean(String str)
        {
            return StringToBoolean(str, false);
        }

        public static Boolean StringToBoolean(String str, Boolean bDefault)
        {
            String[] BooleanStringOff = {"0", "off", "no"};

            if (str == null)
                return bDefault;
            else if (str.Equals(""))
                return bDefault;
            else if (BooleanStringOff.Contains(str, StringComparer.InvariantCultureIgnoreCase))
                return false;

            Boolean result;
            if (!Boolean.TryParse(str, out result))
                result = true;

            return result;
        }
    }
}