using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practico02.Domain;

namespace practico02.Data
{
    public interface IBankRepository
    {
        // metodos abstractos
        List<Account> GetAll();
        Account GetAccountById(int id);
        bool Save(Account oCuenta);
        bool Delete(int id);
        bool Update(int id);
    }
}
