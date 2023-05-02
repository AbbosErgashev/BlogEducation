using BlogEducation.Domain;

namespace BlogEducation.Infrastructure;

public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
{
    Task<Blog> CreateBlogAsync(Blog blog, int id);

    Task<User> GetByIdAsync(int id);
}