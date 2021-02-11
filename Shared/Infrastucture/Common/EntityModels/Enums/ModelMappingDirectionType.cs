using System.Diagnostics.CodeAnalysis;

namespace Shared
{
    public enum ModelMappingDirectionType
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        DTOFromModel, // DB (Entity) to UI (DTO)
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        ModelFromDTO,// UI (DTO) to DB (Entity)
        /// <summary>
        /// 
        /// </summary>
        Both
    }
}
