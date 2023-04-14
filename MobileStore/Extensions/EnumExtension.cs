using System.ComponentModel.DataAnnotations;

namespace MobileStore.Extensions;

public static class EnumExtension
{
    public static string GetDisplayName(this Enum enumVal)
    {
        var field = enumVal.GetType().GetField(enumVal.ToString());
        var displayAttr = field.CustomAttributes
            .FirstOrDefault(c => c.AttributeType == typeof(DisplayAttribute));
        string displayName = displayAttr.NamedArguments
            .FirstOrDefault(a => a.MemberName == "Name")
            .TypedValue.Value.ToString() ?? enumVal.ToString();
        return displayName;
    }
}