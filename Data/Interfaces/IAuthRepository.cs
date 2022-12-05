using Curso.Models;

namespace Curso.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> ExistUser(string email);
    }
}