namespace Shared
{
    [EntityMapping("Comments", MappingType.TotalExplicit)]
    [ModelMapping("Comments", MappingType.TotalExplicit)]
    public class CommentsDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "CommentId")]
        [ModelPropertyMapping(ModelMappingDirectionType.Both, "CommentId")]
        public int CommentId { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "EventId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int EventId { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "UserId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "UserName")]
        [EntityPropertyMapping(MappingDirectionType.Both, "UserName")]
        public string UserName { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "Comment")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Comment")]
        public string Comment { get; set; }
    }
}
