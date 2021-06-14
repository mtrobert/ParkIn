using ParkInAPI.Data;
using ParkInAPI.Models;
using ParkInAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkInAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;

        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _db.NationalParks.FirstOrDefault(np => np.Id == nationalParkId);

        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalParks.OrderBy(np => np.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool result = _db.NationalParks.Any(np => np.Name.ToLower().Trim() == name.ToLower().Trim());
            return result;
        }

        public bool NationalParkExists(int id)
        {
            bool result = _db.NationalParks.Any(np => np.Id == id);
            return result;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
            return Save();

        }
    }
}
