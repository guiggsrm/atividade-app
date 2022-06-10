using ProTask.Application.DTOs;

namespace ProTask.Application.Interfaces
{
    public interface ITokenService
    {
        TokenResponseDTO Generate(string userName, IEnumerable<string> userRoles);
    }
}