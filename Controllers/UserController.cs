using BlogEducation.Application;
using BlogEducation.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlogEducation.WebApi.Controllers;

[ApiController]
[Route("api/users")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) => _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("id:int")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(await _userService.GetUserByIdAsync(id));
    }

    [HttpPost()]
    public async Task<IActionResult> PostUser([FromBody] UserForCreationDTO userDTO)
    {
        return Created("", await _userService.CreateUserAsync(userDTO));
    }

    [HttpPost("id:int/blog")]
    public async Task<IActionResult> PostBlog([FromBody] BlogForCreationDTO blogDTO, int id)
    {
        return Created("", await _userService.CreateBlogAsync(blogDTO, id));
    }
}