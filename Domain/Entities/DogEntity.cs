using Domain.Bases;
using Domain.Enums;

namespace Domain.Entities
{
    public class DogEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ExternalId { get; set; }
        public string Breed { get; set; }
        public float AverageHeight { get; set; }
        public string[] Temperaments { get; set; }

        public DogSizeTypes Size => AverageHeight switch
        {
            (> 0 and <= 35) => DogSizeTypes.Small,
            (> 35 and <= 55) => DogSizeTypes.Medium,
            (> 55) => DogSizeTypes.Large,
            _ => DogSizeTypes.None
        };

        public static class Factory
        {
            public static DogEntity Create(
                string name,
                string breed,
                int externalId,
                float averageHeight,
                string[] temperaments)
            {
                return new DogEntity
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    ExternalId = externalId,
                    Name = name,
                    Breed = breed,  
                    AverageHeight = averageHeight,
                    Temperaments = temperaments
                };
            }
        }
    }
}
