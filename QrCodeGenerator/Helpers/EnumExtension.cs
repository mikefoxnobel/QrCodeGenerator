using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeGenerator.Helpers
{
    public static class EnumExtension
    {
        public static string GetEnumDescription<TEnum>(this TEnum eValue)
        {
            var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (nAttributes.Any())
                return (nAttributes.First() as DescriptionAttribute).Description;

            // If no description is found, the least we can do is replace underscores with spaces
            // You can add your own custom default formatting logic here
            TextInfo oTI = CultureInfo.CurrentCulture.TextInfo;
            return oTI.ToTitleCase(oTI.ToLower(eValue.ToString().Replace("_", " ")));
        }

        public static IEnumerable<KeyValuePair<TEnum, string>> GetAllValuesAndDescriptions<TEnum>()
        {
            Type t = typeof(TEnum);
            if (!t.IsEnum)
                throw new ArgumentException("t must be an enum type");

            return from e in Enum.GetValues(t).Cast<Enum>()
                select new KeyValuePair<TEnum, string>((TEnum)Enum.Parse(t, e.ToString()), e.GetEnumDescription());
        }
    }
}
