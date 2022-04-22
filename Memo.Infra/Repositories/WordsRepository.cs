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

    public async Task Delete(Word word)
    {
        context.Remove(word);
        await context.SaveChangesAsync();
    }

    public async Task<Word> Get(Guid id)
        => await context.Words.FirstOrDefaultAsync(w => w.Id == id);

    public async Task<List<Word>> GetByUserId(Guid userId)
        => await context.Words.Where(w => w.User.Id == userId).ToListAsync();

    public async Task<Word> Update(Word word)
    {
        context.Words.Update(word);
        await context.SaveChangesAsync();
        return word;
    }
}