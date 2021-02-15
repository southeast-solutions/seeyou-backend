namespace Domain.DTO
{
    public static class DtoExtensions
    {
        public static TestEntity ToModel(this TestEntityDto dto)
        {
            return new TestEntity()
            {
                MyProperty = dto.MyProperty
            };
        }
    }
}