using System.Diagnostics.CodeAnalysis;

namespace Shared
{
    /// <summary>
    /// 
    /// </summary>
    public enum MappingDirectionType
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        DTOFromEntity, // DB (Entity) to UI (DTO)
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        EntityFromDTO,// UI (DTO) to DB (Entity)
        /// <summary>
        /// 
        /// </summary>
        Both
    }
}
