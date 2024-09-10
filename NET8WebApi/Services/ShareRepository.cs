
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NET8WebApi.Data;
using NET8WebApi.Models;

namespace NET8WebApi.Services
{
    public class ShareRepository : IShare
    {
        private readonly ApplicationDbContext _db;

        public ShareRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Share> GetData()
        {
            return _db.Shares.ToList();
        }

        public Share GetDataWithId(int id)
        {
            var share = _db.Shares.Find(id);
            if (share == null)
            {
                return null;
            }
            return share;

        }
        public List<Share> PostData(Share value)
        {
            var newStock = _db.Shares.Add(value);
            _db.SaveChanges();
            return _db.Shares.ToList();
        }

        public List<Share> DeleteData(int id)
        {
            var searchid = _db.Shares.Find(id);
            if (searchid == null)
            {
                return null;
            }
            _db.Shares.Remove(searchid);
            _db.SaveChanges();
            return _db.Shares.ToList();
        }

        public List<Share> GetDataWithFilter(string filter)
        {
            return _db.GetSharesFromStoredProcedureWithParams(filter).ToList(); 
        }

    }
}
