using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelEntity.Entity
{
    public class Theater
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CinemaId { get; set; } = string.Empty;

        public Cinema Cinema { get; set; } = null!;

        public string TheaterTypeId { get; set; } = string.Empty;

        public TheaterType TheaterType { get; set; } = null!;


    }
}
