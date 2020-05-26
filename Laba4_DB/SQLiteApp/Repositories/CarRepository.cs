using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataBaseContext dataBaseContext;
        public CarRepository(string dbPath)
        {
            dataBaseContext = new DataBaseContext(dbPath);
        }
        public async Task<bool> CreateAsync(Car item)
        {
            try
            {
                var tracking = await dataBaseContext.Cars.AddAsync(item);
                await dataBaseContext.SaveChangesAsync();

                bool isAdded = tracking.State == EntityState.Added;
                return isAdded;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public async Task<bool> CreateRangeAsync(IEnumerable<Car> items)
        {
            try
            {
                await dataBaseContext.Cars.AddRangeAsync(items);
                await dataBaseContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var car = await dataBaseContext.Cars.FindAsync(id);

                var tracking = dataBaseContext.Remove(car);
                await dataBaseContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Detached;
                return isDeleted;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        public async Task<IEnumerable<Car>> Find(Func<Car, bool> predicate)
        {
            try
            {
                var products = dataBaseContext.Cars.Where(predicate);
                return products.ToList();
            }
            catch(Exception e)
            {
                throw new Exception("Error in Data Base", e);
            }
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            try
            {
                var cars = await dataBaseContext.Cars.ToListAsync();
                return cars;
            }
            catch(Exception e)
            {
                throw new Exception("Errors in DataBase", e);
            }
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            try
            {
                var car = await dataBaseContext.Cars.FindAsync(id);
                return car;
            }
            catch(Exception e)
            {
                throw new Exception("Error in Data Base", e);
            }
        }

        public async Task<bool> UpdateAsync(Car item)
        {
            try
            {
                var tracking = dataBaseContext.Cars.Update(item);
                await dataBaseContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
