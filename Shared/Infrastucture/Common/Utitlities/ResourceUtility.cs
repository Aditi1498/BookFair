namespace Shared
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// ResourceUtility reads resource constants.
    /// </summary>
    public static class ResourceUtility
    {
        private static ResourceManager ResourceManager = new ResourceManager("Resources.Resource", Assembly.Load("App_GlobalResources"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCaptionFor(string key)
        {
            string retVal = string.Empty;

            retVal = ResourceManager.GetString(key);

            return retVal;
        }

        /// <summary>
        /// Enum added must have attribute for Display Text Key
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetCaptionFromEnum<TEnum>(TEnum value) where TEnum : new()
        {
            DisplayTextKeyAttribute displayTextKeyAttribute = EnumAttributeUtility<TEnum, DisplayTextKeyAttribute>.GetEnumAttribute(value.ToString());
            return ResourceUtility.GetCaptionFor(displayTextKeyAttribute.Key);
        }

        /// <summary>
        /// Get all values from Enum 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IList<string> GetValueListFromEnum<TEnum>() where TEnum : new()
        {
            IList<string> enumValueList = new List<string>();
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                if (item.GetHashCode() != 0)
                    enumValueList.Add(Convert.ToString(item.GetHashCode()));
            }
            return enumValueList;
        }

    }
}
