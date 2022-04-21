using System.Security.Claims;
using Memo.Domain.Models;
using Memo.Infra.Repositories.Words;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers;

[Authorize]
[Route("[controller]")]
public class WordsController : ControllerBase
{
    Guid userId;
    private readonly IWordsRepository wordsRepository;

    public WordsController(IWordsRepository words)
    {
        this.wordsRepository = words;
        userId = Guid.Parse(User.FindFirst("Id")!.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var words = await wordsRepository.Get(userId);

        if(words.Count > 0)
            return Ok(words);
        
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Word word)
    {
        word.UserId = userId;
        var w = await wordsRepository.Add(word);
        return Ok(w);
    }
}