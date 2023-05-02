using BlogEducation.Infrastructure;

namespace BlogEducation.Application
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserDTO>> GetAllUsersAsync();
        
        Task<UserDTO> GetUserByIdAsync(int id);

        Task<UserDTO> CreateUserAsync(UserForCreationDTO userDTO);
        
        Task<BlogDTO> CreateBlogAsync(BlogForCreationDTO blogDTO, int userId);
    }
}
