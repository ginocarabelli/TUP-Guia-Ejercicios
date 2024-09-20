using ProduccionBack.Contracts.Implementations;
using ProduccionBack.Contracts.Interfaces;
using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public class ArticleManager : IArticlesRepository
    {
        ArticlesRepository repo;
        public ArticleManager()
        {
            repo = new ArticlesRepository();
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<Article> GetAll()
        {
            return repo.GetAll();
        }

        public Article GetById(int id)
        {
            return repo.GetById(id);
        }

        public bool Save(Article oArticle)
        {
            return repo.Save(oArticle);
        }

        public bool Update(Article oArticle)
        {
            return repo.Update(oArticle);
        }
    }
}
