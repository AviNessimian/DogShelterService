namespace Infrastructure.TheDogApi.Models
{
    internal class DogBreedsSearchResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Temperament { get; set; }

        public DogBreedsSize Weight { get; set; }
        public DogBreedsSize Height { get; set; }


        public string[] Temperaments => Temperament?.Split(',')?.Select(x => x.Trim())?.ToArray() ?? new string[0];

        public float CalcAverageHeight()
        {
            var metrics = Height?.Metric?.Split('-')?.Select(x => x.Trim())?.Sum(x => float.Parse(x)) ?? 0;
            if (metrics != 0)
            {
                return metrics / 2;
            }

            return metrics;
        }
    }
}
