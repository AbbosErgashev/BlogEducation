using BlogEducation.Domain;
using BlogEducation.Infrastructure;

namespace BlogEducation.Application;

public interface IBlogService
{
    Task<IList<BlogDTO>> GetAllBlogsAsync();
    Task<BlogDTO> GetBlogById(int id);
}