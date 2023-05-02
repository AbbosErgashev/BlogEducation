using AutoMapper;
using BlogEducation.Domain;
using BlogEducation.Infrastructure;

namespace BlogEducation.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BlogDTO> CreateBlogAsync(BlogForCreationDTO blogDTO, int userId)
        {
            return _mapper.Map<BlogDTO>(await _userRepository.CreateBlogAsync(_mapper.Map<Blog>(blogDTO), userId));
        }

        public async Task<UserDTO> CreateUserAsync(UserForCreationDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IReadOnlyList<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetByIdAsync(user => user.Id == id, new List<string> {" Blogs "}));
        }
    }
}
