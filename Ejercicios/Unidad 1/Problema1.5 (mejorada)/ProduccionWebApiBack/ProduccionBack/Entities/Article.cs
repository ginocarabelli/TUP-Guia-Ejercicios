using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Domain
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string ArticleName { get; set; }
        public double UnitPrice { get; set; }

        public override string ToString()
        {
            return $"[{ArticleID}, {ArticleName}, {UnitPrice}]";
        }
    }
}
