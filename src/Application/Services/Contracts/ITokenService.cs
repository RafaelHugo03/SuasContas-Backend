using Application.DTOs;

namespace Application.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO dto);
        Guid GetIdFromToken(string token);
        string PermittedForAllRoles();
    }
}