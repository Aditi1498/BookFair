using System;

namespace Shared
{
    /// <summary>
    /// Represent a DisplayTextKey attribute,
    /// Author : Nagarro     
    /// </summary>        
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DisplayTextKeyAttribute : Attribute
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="QualifiedTypeNameAttribute"/> class.
        /// </summary>
        /// <param name="assemblyFileName">Name of the assembly file.</param>
        /// <param name="qualifiedTypeName">Name of the qualified type.</param>
        public DisplayTextKeyAttribute(string key)
        {
            this.Key = key;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the key for display text.
        /// </summary>
        /// <value>The name of the assembly file.</value>
        public string Key { get; private set; }

        #endregion

        /// <summary>
        /// Determines whether the specified attr is valid.
        /// </summary>
        /// <param name="attribute">The attr.</param>
        /// <returns>
        /// 	<c>true</c> if the specified attr is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValid(DisplayTextKeyAttribute attribute)
        {
            return (attribute != null && !ValidatorUtility.IsNullOrEmpty(attribute.Key));
        }
    }
}
