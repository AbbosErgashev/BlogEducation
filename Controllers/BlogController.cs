using Microsoft.AspNetCore.Mvc;
using BlogEducation.Application;

namespace BlogEducation.Controllers;

[ApiController]
[Route("api/blogs")]

public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;
    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        return Ok(await _blogService.GetAllBlogsAsync());
    }

    [HttpGet]
    [Route("id:int")]
    public async Task<IActionResult> GetBlog(int id)
    {
        return Ok(await _blogService.GetBlogById(id));
    }
}