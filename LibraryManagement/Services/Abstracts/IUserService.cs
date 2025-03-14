using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Users;

namespace LibraryManagement.Services.Abstracts
{
    public interface IUserService
    {
        void Add(UserAddRequestDto userAddRequestDto);
        List<UserResponseDto> GetAll();
        UserResponseDto? GetById(string id);
        UserResponseDto? GetByEmail(string email);
    }
}
