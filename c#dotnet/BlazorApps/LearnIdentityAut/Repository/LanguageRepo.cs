using LearnIdentityAut.Data;
using LearnIdentityAut.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnIdentityAut.Repository
{
    public class LanguageRepo : ILanguageRepo
    {
        protected readonly ApplicationDbContext dbContext;
        public LanguageRepo(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<bool> Add(LanguageModel model)
        {
            var dbLanguage = new Language()
            {
                Name = model.Name,
                Description = model.Description
                //CreatedOn = DateTime.Now
            };

            await dbContext.Language.AddAsync(dbLanguage);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<LanguageModel>> GetAll()
        {
            //var ListOfBooks = BookDataSource();
            /*var GetCompleteList = await dbContext.Language.ToListAsync();
            var ListOfModel = new List<LanguageModel>();

            if (GetCompleteList?.Any() == true)
            {
                foreach (var item in GetCompleteList)
                {
                    ListOfModel.Add(new LanguageModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }*/

            //other way to write it
            return await dbContext.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).OrderBy(x => x.Name).ToListAsync();

            //return ListOfModel;
        }
    }
}
