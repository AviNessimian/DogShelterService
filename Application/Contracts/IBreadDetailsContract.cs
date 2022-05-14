namespace Application.Contracts
{
    public interface IBreadDetailsContract
    {
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.Net.Http.HttpRequestExceptio"></exception>
        /// <returns>BreadDetails</returns>
        Task<BreadDetails> GetAsync(string breed, CancellationToken cancellationToken = default);
    }

    public class BreadDetails
    {
        public int Id { get; set; }
        public float AverageHeight { get; set; }
        public string[] Temperaments { get; set; }

    }
}
