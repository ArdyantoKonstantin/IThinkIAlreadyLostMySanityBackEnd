using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class GetTheaterResponse
    {
        public List<TheaterDetails>? Theaters { get; set; }
        public string? NextCursor { get; set; }
        public string? PrevCursor { get; set; }
    }
}
