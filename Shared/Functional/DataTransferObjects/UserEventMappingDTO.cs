namespace Shared
{
    public class UserEventMappingDTO : DTOBase
    {
        [EntityMapping("UserEventMapping", MappingType.TotalExplicit)]
        [ModelMapping("UserEventMapping", MappingType.TotalExplicit)]
        public class UserDTO : DTOBase
        {
            [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
            [ModelPropertyMapping(ModelMappingDirectionType.Both, "UserId")]
            public int UserId { get; set; }


            [ModelPropertyMapping(ModelMappingDirectionType.Both, "EventId")]
            [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
            public int EventId { get; set; }

            //[EntityPropertyMapping(MappingDirectionType.Both, "Comments")]
            //public string Comments { get; set; }

        }
    }
}
