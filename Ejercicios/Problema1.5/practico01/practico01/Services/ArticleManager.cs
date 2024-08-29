using practico01.Domain;
using practico01.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Services
{
    public class ArticleManager
    {
        ArticleRepository aRepo;
        public ArticleManager()
        {
            aRepo = new ArticleRepository();
        }
        public Article GetArticleById(int id)
        {
            return aRepo.GetArticleById(id);
        }
    }
}
