using BlogEducation.Domain;
using BlogEducation.Infrastructure;
using AutoMapper;

namespace BlogEducation.Application;

public class BlogService : IBlogService
{
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

    public async Task<IList<BlogDTO>> GetAllBlogsAsync()
    {
        return _mapper.Map<IList<BlogDTO>>(await _blogRepository.GetAllAsync());
    }

    public async Task<BlogDTO> GetBlogById(int id)
    {
        return _mapper.Map<BlogDTO>(await _blogRepository.GetByIdAsync(blog => blog.Id == id
            , new List<string> {" Owner "}));
    }
}