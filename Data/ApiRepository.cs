using Curso.Data.Interfaces;
using Curso.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data
{
    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _context;
        public ApiRepository(DataContext context)
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

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
           var products = await _context.Products.ToListAsync();
           return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
            return product;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id ==id);
            return user;
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users =  await _context.Users.ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}