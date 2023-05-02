namespace MarvelEntity.Entity
{
    public class TheaterType
    {
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public List<Theater> ListOfTheaters = new List<Theater>();
    }
}
