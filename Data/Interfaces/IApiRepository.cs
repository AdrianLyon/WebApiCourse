using Curso.Models;

namespace Curso.Data.Interfaces
{
    public interface IApiRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsersAsync();
         Task<User> GetUserByIdAsync(int id);
         Task<User> GetUserByNameAsync(string name);
         Task<IEnumerable<Product>> GetProductAsync();
         Task<Product> GetProductByIdAsync(int id);
         Task<Product> GetProductByNameAsync(string name);
    }
}