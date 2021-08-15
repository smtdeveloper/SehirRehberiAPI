using Microsoft.EntityFrameworkCore;
using SehirRehberiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberiAPI.DataAccess
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
           var city = _context.Cities.Include(c => c.Photos).ToList();
            return city;
        }

        public City GetCityById(int cityId)
        {
            var cities = _context.Cities.Include(c => c.Photos)
                  .FirstOrDefault(c => c.Id == cityId);
            return cities;
        }

        public Photo GetPhoto(int id)
        {
          var photo =  _context.Photos.FirstOrDefault(p => p.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosByCity(int CityId)
        {
           var photos =  _context.Photos.Where(p => p.CityId == CityId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
