namespace MarvelEntity.Entity
{
    public class Blob
    {
        public Guid BlobId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public List<Cinema> ListOfCinemas { get; set; } = new List<Cinema>();
        public string? MIME { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
