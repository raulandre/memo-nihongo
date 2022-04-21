using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers;

[Authorize]
[Route("[controller]")]
public class WordsController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("こんにちは世界！！！");
    }
}