using Domain.Attributes;

namespace Domain
{
    [BsonCollection("experiences")]
    public class ExperienceEntity : Document
    {
        public string Name { get; set; }
    }
}
