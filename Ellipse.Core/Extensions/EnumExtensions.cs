using Ellipse.Shared.Enums;
using System.ComponentModel;

namespace Ellipse.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            if (type == null)
            {
                return string.Empty;
            }

            var name = Enum.GetName(type, value);

            if (name != null)
            {
                var field = type.GetField(name);

                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }

                    return field.Name;
                }
            }

            return string.Empty;
        }

        public static IList<KeyValuePair<T, string>> GetListOfDescription<T>() where T : Enum
        {
            var type = typeof(T);

            return Enum.GetValues(type).Cast<T>().Select(o => new KeyValuePair<T, string>(o, o.GetDescription())).ToList();
        }

        public static ApproverActionType GetApproverActionTypeValueFromDescription(this string description)
        {
            if (string.IsNullOrEmpty(description))
                return default;

            var fields = typeof(ApproverActionType).GetFields();

            foreach (var field in fields)
            {
                if (field == null) continue;

                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (ApproverActionType)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (ApproverActionType)field.GetValue(null);
                }
            }

            throw new ArgumentException("Approver Action Type Type Not found.", nameof(description));
        }

        public static ApproverType GetApproverTypeValueFromDescription(this string description)
        {
            if (string.IsNullOrEmpty(description))
                return default;

            var fields = typeof(ApproverType).GetFields();

            foreach (var field in fields)
            {
                if (field == null) continue;

                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (ApproverType)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (ApproverType)field.GetValue(null);
                }
            }

            throw new ArgumentException("Approver Type Not found.", nameof(description));
        }
    }
}
