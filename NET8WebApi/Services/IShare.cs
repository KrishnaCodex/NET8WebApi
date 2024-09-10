using Microsoft.Identity.Client;
using NET8WebApi.Models;

namespace NET8WebApi.Services
{
    public interface IShare
    {
        public List<Share> GetData();
        public Share GetDataWithId(int id);
        public List<Share> PostData(Share value);
        public List<Share> DeleteData(int id);
        public List<Share> GetDataWithFilter(string filter);
    }
}
