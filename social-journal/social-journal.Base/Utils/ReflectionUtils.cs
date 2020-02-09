using System;
using System.ComponentModel;
using System.Linq;

namespace social_journal.Base.Utils
{
    public static class ReflectionUtils
    {
        public static string GetDescription(this Enum enumeration)
        {
            var descrAttribute = enumeration.GetType().CustomAttributes
                .FirstOrDefault(attr => string.Equals(attr.Constructor.Name, nameof(DescriptionAttribute)));
            if (descrAttribute == null)
                return string.Empty;
            var constructorArg = descrAttribute.ConstructorArguments[0];
            if (constructorArg == null)
                return string.Empty;

            return constructorArg.Value == null
                ? string.Empty
                : constructorArg.Value.ToString();
        }
    }
}
