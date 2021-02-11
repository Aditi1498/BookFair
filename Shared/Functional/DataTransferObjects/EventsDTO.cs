using System;

namespace Shared
{
    [EntityMapping("Event",MappingType.TotalExplicit)]
    [ModelMapping("Event", MappingType.TotalExplicit)]
    public class EventsDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "EventID")]
        [ModelPropertyMapping(ModelMappingDirectionType.Both, "EventID")]
        public int EventID { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "BookTitle")]
        [EntityPropertyMapping(MappingDirectionType.Both, "BookTitle")]
        public string BookTitle { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "StartDate")]
        [EntityPropertyMapping(MappingDirectionType.Both, "StartDate")]
        public DateTime StartDate { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "Location")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Location")]
        public string Location { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "Duration")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Duration")]
        public int Duration { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "EventType")]
        [EntityPropertyMapping(MappingDirectionType.Both, "EventType")]
        public string EventType { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "CreatedBy")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedBy")]
        public int CreatedBy { get; set; }

        [ModelPropertyMapping(ModelMappingDirectionType.Both, "Description")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }



    }
}
 