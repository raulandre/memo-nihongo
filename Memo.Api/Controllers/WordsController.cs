using System.Security.Claims;
using Memo.Domain.Models;
using Memo.Infra.Repositories.Words;
using Memo.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers;

[Authorize]
[Route("[controller]")]
public class WordsController : ControllerBase
{
    private readonly IWordsRepository wordsRepository;

    public WordsController(IWordsRepository words)
    {
        this.wordsRepository = words;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = User.FindFirstValue("Id");
        var words = await wordsRepository.Get(User.GetId());

        if(words.Count > 0)
            return Ok(words);
        
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Word word)
    {
        word.UserId = User.GetId();
        var w = await wordsRepository.Add(word);
        return Ok(w);
    }
}