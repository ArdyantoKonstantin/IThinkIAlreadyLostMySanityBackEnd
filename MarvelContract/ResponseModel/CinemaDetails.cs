using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class CinemaDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public Guid? BlobId { get; set; }
        public string? FileUrl { get; set; }
    }
}
