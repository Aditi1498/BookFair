namespace Shared
{
    using System;

    /// <summary>
    /// Contains/Represents/Provides Entity property mapping attribute,
    /// Author		: Nagarro
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ModelPropertyMappingAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappingDirection">The mapping direction.</param>
        /// <param name="mappedModelPropertyName">Name of the mapped entity property.</param>
        public ModelPropertyMappingAttribute(ModelMappingDirectionType mappingDirection, string mappedModelPropertyName)
            : this(mappingDirection)
        {
            // private set value
            MappedModelPropertyName = mappedModelPropertyName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappingDirection">The mapping direction.</param>
        internal ModelPropertyMappingAttribute(ModelMappingDirectionType mappingDirection)
        {
            // private set value
            MappingDirection = mappingDirection;
        }

        #endregion

        #region EntityPropertyMappingAttribute Members

        /// <summary>
        /// Gets the name of the mapped entity property.
        /// </summary>
        /// <value>The name of the mapped entity property.</value>
        public string MappedModelPropertyName { get; private set; }

        /// <summary>
        /// Gets the mapping direction.
        /// </summary>
        /// <value>The mapping direction.</value>
        public ModelMappingDirectionType MappingDirection { get; private set; }

        #endregion
    }
}
