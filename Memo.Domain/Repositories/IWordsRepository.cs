using Memo.Domain.Models;

namespace Memo.Domain.Repositories;

public interface IWordsRepository
{
    Task<List<Word>> GetByUserId(Guid userId);
    Task<Word> Get(Guid id);
    Task<Word> Add(Word word);
    Task<Word> Update(Word word);
    Task Delete(Word word);
}