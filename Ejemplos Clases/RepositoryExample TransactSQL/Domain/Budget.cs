using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Domain
{
    public class Budget
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Client { get; set; }

        public int Expiration { get; set; }

        //...más atributos

        private List<DetailBudget> details;

        public List<DetailBudget> GetDetails() {
            return details;
        }

        public Budget()
        {
            details = new List<DetailBudget>();
        }

        public void AddDetail(DetailBudget detail)
        {
            if (detail != null)
                details.Add(detail);
        }

        public void Remove(int index)
        {
            details.RemoveAt(index);
        }

        public float Total()
        {
            float total = 0;
            foreach (var detail in details)
                total += detail.SubTotal();

            return total;
        }

    }
}
