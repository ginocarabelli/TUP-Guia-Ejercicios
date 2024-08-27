using practico02.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practico02.Domain;

namespace practico02.Services
{
    public class BankManager
    {
        BankRepositoryADO bankRepositoryADO;

        public BankManager()
        {
            bankRepositoryADO = new BankRepositoryADO();
        }

        public List<Account> GetAllAccounts()
        {
            return bankRepositoryADO.GetAll();
        }
        public Account GetAccountById(int id)
        {
            return bankRepositoryADO.GetAccountById(id);
        }
    }
}
