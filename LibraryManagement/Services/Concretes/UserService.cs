using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Users;
using LibraryManagement.Services.Abstracts;
using ZstdSharp.Unsafe;

namespace LibraryManagement.Services.Concretes
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserAddRequestDto userAddRequestDto)
        {
            User user = ConvertToUser(userAddRequestDto);
            _userRepository.Add(user);
        }

        public List<UserResponseDto> GetAll()
        {
            List<User> users = _userRepository.GetAll();
            List<UserResponseDto> response = ConvertToUserResponseDtoList(users);
            return response;
        }

        public UserResponseDto? GetByEmail(string email)
        {
            User user = _userRepository.GetByEmail(email);
            UserResponseDto? response = ConvertToUserResponseDto(user);
            return response;

        }

        public UserResponseDto? GetById(string id)
        {
            Guid convertId = new Guid(id);
            User user = _userRepository.GetById(convertId);
            UserResponseDto response = ConvertToUserResponseDto(user);
            return response;
        }

        private User ConvertToUser(UserAddRequestDto dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
            };
        }
        private UserResponseDto ConvertToUserResponseDto(User user)
        {
            return new UserResponseDto
            {
                id = user.id.ToString(),
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
            };
        }
        private List<UserResponseDto> ConvertToUserResponseDtoList(List<User> users)
        {
            return users.Select(x => ConvertToUserResponseDto(x)).ToList();
        }
    }
}
