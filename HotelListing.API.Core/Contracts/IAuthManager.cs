using HotelListing.API.Core.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Core.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);

        Task<IEnumerable<IdentityError>> AdminRegister(ApiUserDto adminUserDto);

        Task<AuthResponseDto> Login(LoginDto userDto);

        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
