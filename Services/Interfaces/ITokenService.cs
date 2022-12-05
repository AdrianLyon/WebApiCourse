using Curso.Models;

namespace Curso.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}