using System.ComponentModel;

namespace AdminService.SharedServices
{
    public static class EnumExtensions
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
    }
}
