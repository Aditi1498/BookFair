using System;

namespace Shared
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class QualifiedTypeNameAttribute : Attribute
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="QualifiedTypeNameAttribute"/> class.
        /// </summary>
        /// <param name="assemblyFileName">Name of the assembly file.</param>
        /// <param name="qualifiedTypeName">Name of the qualified type.</param>
        public QualifiedTypeNameAttribute(string assemblyFileName, string qualifiedTypeName)
        {
            this.AssemblyFileName = assemblyFileName;
            this.QualifiedTypeName = qualifiedTypeName;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the name of the assembly file.
        /// </summary>
        /// <value>The name of the assembly file.</value>
        public string AssemblyFileName { get; private set; }

        /// <summary>
        /// Gets the name of the qualified type.
        /// </summary>
        /// <value>The name of the qualified type.</value>
        public string QualifiedTypeName { get; private set; }

        #endregion

        /// <summary>
        /// Determines whether the specified attr is valid.
        /// </summary>
        /// <param name="attribute">The attr.</param>
        /// <returns>
        /// 	<c>true</c> if the specified attr is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValid(QualifiedTypeNameAttribute attribute)
        {
            return (attribute != null && !ValidatorUtility.IsNullOrEmpty(attribute.AssemblyFileName) && !ValidatorUtility.IsNullOrEmpty(attribute.QualifiedTypeName));
        }
    }
}
