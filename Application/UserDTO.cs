using BlogEducation.Infrastructure;

namespace BlogEducation.Application;

public class UserDTO : UserForCreationDTO
{
    public int Id { get; set; }

    public IList<BlogDTO> Blogs { get; set; }
}