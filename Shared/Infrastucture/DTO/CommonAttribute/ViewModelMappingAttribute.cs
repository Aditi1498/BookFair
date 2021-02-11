namespace Shared
{
    using System;

    /// <summary>
    /// Contains/Represents/Provides ViewModel mapping attribute,
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ViewModelMappingAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappedViewModelTypeFullName">Full name of the mapped entity type.</param>
        /// <param name="mappingType">Type of the mapping.</param>
        public ViewModelMappingAttribute(string mappedViewModelTypeFullName, MappingType mappingType)
        {
            // private set value
            MappedViewModelTypeFullName = mappedViewModelTypeFullName;
            MappingType = mappingType;
        }

        #endregion

        #region ViewModelMappingAttribute Members

        /// <summary>
        /// Gets the full name of the mapped entity type.
        /// </summary>
        /// <value>The full name of the mapped entity type.</value>
        public string MappedViewModelTypeFullName { get; private set; }

        /// <summary>
        /// Gets the type of the mapping.
        /// </summary>
        /// <value>The type of the mapping.</value>
        public MappingType MappingType { get; private set; }

        #endregion
    }
}

