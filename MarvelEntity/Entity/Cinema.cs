using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelEntity.Entity
{
    public class Cinema
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public Guid? BlobId { get; set; }
        public Blob Blob { get; set; } = null!;

        public List<Theater> ListOfTheaters = new List<Theater>();
    }
}
