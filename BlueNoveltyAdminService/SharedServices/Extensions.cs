using System.ComponentModel;
using System.Runtime.Serialization;

namespace SharedServices
{
    public static class Extensions
    {
        public static string GetDescription(this Enum enumeration)
        {
            var fieldInfo = enumeration.GetType().GetField(enumeration.ToString());
            var descriptionAttribute = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (descriptionAttribute.FirstOrDefault() == null)
            {
                throw new InvalidOperationException("Enum does not have Description Attribute");
            }
            return descriptionAttribute.First().Description;
        }

        public static string GetDataMemberFieldName(this object obj, string fieldName)
        {
            if(obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            DataMemberAttribute dataMemberAttribute = obj.GetType().GetProperty(fieldName)?.GetCustomAttributes(typeof(DataMemberAttribute), inherit: true).FirstOrDefault() as DataMemberAttribute;
            if (dataMemberAttribute == null)
            {
                return fieldName;
            }
            return dataMemberAttribute.Name;
        }
    }
}
