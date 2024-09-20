using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProduccionBack.Entities;

namespace ProduccionBack.Contracts.Interfaces
{
    public interface IArticlesRepository
    {
        public List<Article> GetAll();
        public Article GetById(int id);
        public bool Save(Article oArticle);
        public bool Update(Article oArticle);
        public bool Delete(int id);
    }
}
