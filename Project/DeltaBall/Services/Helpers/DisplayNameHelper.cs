using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DeltaBall.Services.Helpers
{
    public static class AttributeHelper
    {
        public static string GetDisplayNameValue(PropertyInfo property)
        {
            var attribList = property
                .GetCustomAttributes(typeof(DisplayNameAttribute), true);
            var prop = attribList[0].GetType().GetProperty("DisplayName");
            var value = prop.GetValue(attribList[0], null).ToString();
			return !attribList.Any()
                ? "Элемент"
                : value;
        }

		public static string GetDisplayValue(PropertyInfo property)
		{
			var attribList = property
				.GetCustomAttributes(typeof(DisplayAttribute), true);
			var prop = attribList[0].GetType().GetProperty("Name");
			var value = prop.GetValue(attribList[0], null).ToString();
			return !attribList.Any()
				? "Элемент"
				: value;
		}
	}
}
