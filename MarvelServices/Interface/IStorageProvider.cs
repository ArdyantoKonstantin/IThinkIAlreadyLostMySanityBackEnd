using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.Interface
{
    public interface IStorageProvider
    {
        public Task<string> GetPresignedUrl(string fileName);
        public Task<string> GetPutPresignedUrl(string fileName);
        public Task DeleteFileAsync(string fileName, string fileExtension);
    }
}
