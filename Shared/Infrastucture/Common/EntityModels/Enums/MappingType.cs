namespace Shared
{
    /// <summary>
    /// Enumeration to define Mapping Strategy of Data with Entity.
    /// </summary>
    public enum MappingType
    {
        /// <summary>
        /// All the properties of Data object should support EntityPropertyMappingAttribute.
        /// Only those properties will be mapped which has skipMapping to false.
        /// </summary>
        TotalExplicit,

        /// <summary>
        /// All the properties of Data object will be mapped to entity object which has skipmapping to false.
        /// </summary>
        TotalImplicit,

        /// <summary>
        /// All the properties which has EntityPropertyMappingAttribute will be mapped accordingly.
        /// All the properties which have EntityPropertyMappingAttribute will be mapped implicitly.
        /// </summary>
        Hybrid
    }
}
