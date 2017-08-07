using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleRDS.Utils
{
    [Flags]
    public enum ValidateType : short
    {
        None = 0,
        NotEmpty = 1,
        NumericOnly = NotEmpty | 2,
        Phone = NumericOnly, 
        Email = NotEmpty | 4
    }

    public static class Validator
    {
        public static bool IsInvalid(this string str, ValidateType type = ValidateType.NotEmpty, int min = 0, int max = 32767)
        {
            return !Valid(str, type, min, max);
        }


        public static bool Valid(this string str, ValidateType type = ValidateType.NotEmpty, int min = 0, int max = 32767)
        {
            if (type == ValidateType.None)
                return true;

            if (string.IsNullOrEmpty(str))
                return false;

            if (type.HasFlag(ValidateType.NotEmpty) && string.IsNullOrEmpty(str))
                return false;

            if (type.HasFlag(ValidateType.NumericOnly) && !str.All(char.IsDigit))
                return false;

            if (type.HasFlag(ValidateType.Email) && !Regex.IsMatch(str, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*" +
                                                                        @"@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                return false;

            return true;
        }
    }

}
