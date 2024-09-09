

using RepositoryExample.Domain;

namespace RepositoryExample.Data
{
    public interface IBudgetRepository
    {
        bool Save(Budget oBudget);
        List<Budget> GetAll();
        Budget? GetById(int id);

    }
}
