using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Shared
{
    /// <summary>
    /// Provides utility methods for Enum attribute,
    /// Author : Nagarro     
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
    public static class EnumAttributeUtility<TEnum, TAttribute>
        where TEnum : new()
        where TAttribute : Attribute
    {
        /// <summary>
        /// Local Cache
        /// </summary>
        private static readonly Dictionary<string, TAttribute> attrDict = new Dictionary<string, TAttribute>();

        /// <summary>
        /// Initializes the <see cref="EnumAttributeUtility&lt;TEnum, TAttribute&gt;"/> class.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static EnumAttributeUtility()
        {
            TEnum E = new TEnum();
            if (attrDict.Count == 0)
            {
                Type t = E.GetType();
                if (t.IsEnum)
                {
                    FieldInfo[] fields = t.GetFields();
                    foreach (FieldInfo fInfo in fields)
                    {
                        object[] attrs = fInfo.GetCustomAttributes(typeof(TAttribute), false);
                        if (attrs.Length == 1)
                        {
                            TAttribute fieldTagAttr = (TAttribute)attrs[0];
                            attrDict.Add(fInfo.GetValue(E).ToString(), fieldTagAttr);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the cache list.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, TAttribute> GetList()
        {
            return attrDict;
        }

        /// <summary>
        /// Gets the enum attribute.
        /// </summary>
        /// <param name="enumField">The enum field.</param>
        /// <returns></returns>

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static TAttribute GetEnumAttribute(string enumField)
        {
            if (attrDict.ContainsKey(enumField))
                return attrDict[enumField];
            else
                throw new AttributeNotDefinedException(enumField);
        }
    }
}
