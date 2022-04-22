using Memo.Domain.Models;

namespace Memo.Domain.Repositories;

public interface IWordsRepository
{
    Task<IList<Word>> Get(Guid userId);
    Task<Word> Add(Word word);
}