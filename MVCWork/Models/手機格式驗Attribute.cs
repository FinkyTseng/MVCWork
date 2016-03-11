using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVCWork.Models
{
    public class 手機格式驗證Attribute : DataTypeAttribute
    {
        public 手機格式驗證Attribute():base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var str = (string)value;
                string pattern = @"\d{4}-\d{6}";
                Regex rgx = new Regex(pattern);

                return rgx.IsMatch(str);
            }
            else
            {
                return true;
            }
        }
    }
}