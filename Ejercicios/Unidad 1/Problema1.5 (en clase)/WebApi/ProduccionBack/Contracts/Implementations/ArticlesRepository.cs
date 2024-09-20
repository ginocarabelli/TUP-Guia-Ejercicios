using ProduccionBack.Contracts.Interfaces;
using ProduccionBack.Data;
using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Contracts.Implementations
{
    public class ArticlesRepository : IArticlesRepository
    {
        public bool Delete(int id)
        {
            bool x = false;
            try
            {
                var helper = DataHelper.GetInstance();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", id),
                };
                x = helper.ExecuteCRUDSPQuery("SP_DeleteArticle", parameters);
            }
            catch (SqlException)
            {
                x = false;
            }
            return x;
        }

        public List<Article> GetAll()
        {
            var helper = DataHelper.GetInstance();
            List<Article> list = new List<Article>();
            DataTable table = helper.ExecuteSPQuery("SP_GetAllArticles");
            foreach(DataRow row in table.Rows)
            {
                Article oArticle = new Article()
                {
                    Codigo = Convert.ToInt32(row["article_id"]),
                    Descripcion = row["article_name"].ToString(),
                    Pre_Unitario = Convert.ToDecimal(row["unit_price"])
                };
                list.Add(oArticle);
            }
            return list;
        }

        public Article GetById(int id)
        {
            var helper = DataHelper.GetInstance();
            Article a = new Article();
            SqlParameter[] param = new SqlParameter[]{ new SqlParameter("@ID", id) };
            DataTable table = helper.ExecuteSPQuery("SP_GetArticleById", param);
            if(table.Rows.Count != 0)
            {
                var row = table.Rows[0];
                a.Codigo = Convert.ToInt32(row["article_id"]);
                a.Descripcion = row["article_name"].ToString();
                a.Pre_Unitario = Convert.ToDecimal(row["unit_price"]);
            }
            return a;
        }

        public bool Save(Article oArticle)
        {
            bool x = false;
            try
            {
                var helper = DataHelper.GetInstance();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", oArticle.Codigo),
                    new SqlParameter("@NAME", oArticle.Descripcion),
                    new SqlParameter("@UNIT_PRICE", oArticle.Pre_Unitario)
                };
                x = helper.ExecuteCRUDSPQuery("SP_SaveArticle", parameters);
            }
            catch (SqlException)
            {
                x = false;
            }
            return x;
        }

        public bool Update(Article oArticle)
        {
            bool x = false;
            try
            {
                var helper = DataHelper.GetInstance();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", oArticle.Codigo),
                    new SqlParameter("@NAME", oArticle.Descripcion),
                    new SqlParameter("@UNIT_PRICE", oArticle.Pre_Unitario)
                };
                x = helper.ExecuteCRUDSPQuery("SP_UpdateArticle", parameters);
            }
            catch (SqlException)
            {
                x = false;
            }
            return x;
        }
    }
}
