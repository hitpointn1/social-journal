using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace social_journal.Base.Utils
{
    public static class ReflectionUtils
    {
        public static string GetJsonProperty<TJsonEntity>(string filePath, string property)
            where TJsonEntity : class
        {
            string file = File.ReadAllText(filePath);
            var appSettings = JsonSerializer.Deserialize<TJsonEntity>(file);
            PropertyInfo propInfo = appSettings.GetType()
                .GetProperty(property);
            if (propInfo == null)
                return string.Empty;
            return propInfo.GetValue(appSettings)
                .ToString();
        }

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
