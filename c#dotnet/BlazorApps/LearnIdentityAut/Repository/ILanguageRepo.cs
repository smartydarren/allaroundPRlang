using LearnIdentityAut.Models;

namespace LearnIdentityAut.Repository
{
    public interface ILanguageRepo
    {
        Task<bool> Add(LanguageModel model);
        Task<List<LanguageModel>> GetAll();
    }
}