using System.Security.Claims;
using Memo.Domain.Models;
using Memo.Infra.Repositories;
using Memo.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Memo.Domain.Managers.Words;
using Memo.Api.ViewModels.Words;
using AutoMapper;

namespace Memo.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class WordsController : ControllerBase
{
    private readonly IWordsManager wordsManager;
    private readonly IMapper mapper;

    public WordsController(IWordsManager wordsManager, IMapper mapper)
    {
        this.wordsManager = wordsManager; 
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var words = await wordsManager.GetByUser(User.GetId());

        if(words.Count > 0)
            return Ok(words);
        
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateWordViewModel wordViewModel)
    {
        var word = await wordsManager.Create(new Word(wordViewModel.Text, User.GetId()));
        return Ok(word);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateWordViewModel wordViewModel)
    {
        var word = mapper.Map<Word>(wordViewModel);
        word.Id = id;
        word.UserId = User.GetId();

        return Ok(
            await wordsManager.Update(word)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await wordsManager.Delete(id);

        if(ok) return Ok("Word deleted successfully!");

        return NotFound("Word not found");
    }
}