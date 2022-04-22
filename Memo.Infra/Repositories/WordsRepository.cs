using Memo.Domain.Models;
using Memo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Memo.Infra.Repositories;

public class WordsRepository : IWordsRepository
{
    private readonly DataContext context;

    public WordsRepository(DataContext context)
    {
        this.context = context;   
    }

    public async Task<Word> Add(Word word)
    {
        await context.AddAsync(word);
        await context.SaveChangesAsync();
        return word;
    }

    public async Task<IList<Word>> Get(Guid userId)
    {
        return await context.Words.Where(w => w.User.Id == userId).ToListAsync();
    }
}