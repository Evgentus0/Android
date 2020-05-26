using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task<bool> CreateAsync(Car item);
        Task<bool> CreateRangeAsync(IEnumerable<Car> items);
        Task<bool> UpdateAsync(Car item);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Car>> Find(Func<Car, bool> predicate);
    }
}
