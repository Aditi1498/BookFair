namespace Shared
{
    using System;

    /// <summary>
    /// Contains/Represents/Provides Entity property mapping attribute,
    /// Author		: Nagarro
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class EntityPropertyMappingAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappingDirection">The mapping direction.</param>
        /// <param name="mappedEntityPropertyName">Name of the mapped entity property.</param>
        public EntityPropertyMappingAttribute(MappingDirectionType mappingDirection, string mappedEntityPropertyName)
            : this(mappingDirection)
        {
            // private set value
            MappedEntityPropertyName = mappedEntityPropertyName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappingDirection">The mapping direction.</param>
        internal EntityPropertyMappingAttribute(MappingDirectionType mappingDirection)
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
        public string MappedEntityPropertyName { get; private set; }

        /// <summary>
        /// Gets the mapping direction.
        /// </summary>
        /// <value>The mapping direction.</value>
        public MappingDirectionType MappingDirection { get; private set; }

        #endregion
    }
}
