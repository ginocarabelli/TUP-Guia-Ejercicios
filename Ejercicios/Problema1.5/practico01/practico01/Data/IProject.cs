using practico01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Data
{
    public interface IProject
    {
        List<Article> GetAll();
        double CalcularPrecio();
        Article GetById(int id);
        bool Save(Article oArticle);
        bool Delete(int id);
        bool Update(int id);

    }
}
