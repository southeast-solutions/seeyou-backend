using Domain.Attributes;

namespace Domain
{
    [BsonCollection("test")]
    public class TestEntity : Document
    {
        public string MyProperty { get; set; }
    }
}