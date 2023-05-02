using BlogEducation.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogEducation.Infrastructure;

public class BlogRepository : GenericRepositoryAsync<Blog>, IBlogRepository
{
    private readonly DbSet<Blog> _blogs;

    public BlogRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _blogs = dbContext.Set<Blog>();
    }
}