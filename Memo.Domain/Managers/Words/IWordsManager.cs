
using Memo.Domain.Models;

namespace Memo.Domain.Managers.Words;

public interface IWordsManager
{
    Task<List<Word>> GetByUser(Guid userId);
    Task<Word> Create(Word word);
    Task<Word> Update(Word word);
    Task<bool> Delete(Guid id);
}