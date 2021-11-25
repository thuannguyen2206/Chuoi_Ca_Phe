using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Helper
{
    public static class EnumExtentions
    {
        public static string GetDisplayName(this Enum enumValue)
        { 
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();

            if (string.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}
