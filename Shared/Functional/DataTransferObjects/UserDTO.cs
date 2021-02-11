namespace Shared
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    [ModelMapping("User", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        [ModelPropertyMapping(ModelMappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        
        [ModelPropertyMapping(ModelMappingDirectionType.Both, "EmailId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "EmailId")]
        public string EmailID { get; set; }

        
        [ModelPropertyMapping(ModelMappingDirectionType.Both, "Name")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        
        [ModelPropertyMapping(ModelMappingDirectionType.Both, "Password")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password { get; set; }
    }
}
