using practico01.Domain;
using practico01.Repositories.Contracts;
using practico01.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Repositories.Implementations
{
    public class ArticleRepository : IArticleRepository
    {
        public Article GetArticleById(int id)
        {
            Article oArticle = new Article();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetArticleById", new SqlParameter("@ID", id));
            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int articleId = Convert.ToInt32(row["ARTICLE_ID"]);
                string name = Convert.ToString(row["ARTICLE_NAME"]);
                double unitPrice = Convert.ToDouble(row["UNIT_PRICE"]);

                oArticle.ArticleID = articleId;
                oArticle.ArticleName = name;
                oArticle.UnitPrice = unitPrice;
            }
            return oArticle;
        }
    }
}
