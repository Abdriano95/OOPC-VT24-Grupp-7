namespace Bilverkstad.Presentationslager.MVVM.Converters
{
    public static class EnumUtil
    {
        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (System.ComponentModel.DescriptionAttribute)field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false).FirstOrDefault();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
