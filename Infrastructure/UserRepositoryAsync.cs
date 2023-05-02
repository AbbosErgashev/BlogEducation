using BlogEducation.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogEducation.Infrastructure;

public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
{
    private readonly DbSet<User> _users;

    public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _users = dbContext.Set<User>();
    }

    public async Task<Blog> CreateBlogAsync(Blog blog, int id)
    {
        var user = await _users.Include(user => user.Blogs).FirstOrDefaultAsync(user => user.Id == id);

        if(user is null)
            return null;

        user.Blogs.Add(blog);

        await SaveChangesAysnc();

        return blog;
    }

     public virtual async Task<User> GetByIdAsync(int id)
    {
        return await _users.FirstOrDefaultAsync(user => user.Id == id);
    }
}