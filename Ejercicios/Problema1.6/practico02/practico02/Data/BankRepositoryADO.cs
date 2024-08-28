using practico02.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace practico02.Data
{
    public class BankRepositoryADO : IBankRepository
    {
        // llamar los métodos del DataHelper
        public AccountType GetTypeAccount(int id)
        {
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAccountTypeById", new SqlParameter("@codigo", id));
            DataRow dr = t.Rows[0];
            AccountType oTipoCuenta = new AccountType()
            {
                IdTipoCuenta = (int)dr[0],
                TipoDeCuenta = dr[1].ToString()
            };
            return oTipoCuenta;
        }
        public Account GetAccountById(int id)
        {
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAccountById", new SqlParameter("@codigo", id));
            DataRow dr = t.Rows[0];
            Account oCuenta = new Account()
            {
                IdCuenta = (int)dr[0],
                Cbu = Convert.ToString(dr[1]),
                Saldo = Convert.ToDecimal(dr[2]),
                TipoDeCuenta = GetTypeAccount((int)dr[3]),
                UltimoMovimiento = Convert.ToDateTime(dr[4])
            };
            return oCuenta;
        }

        public List<Account> GetAll()
        {
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAllAccounts");
            List<Account> lst = new List<Account>();
            foreach(DataRow dr in t.Rows)
            {
                Account c = new Account()
                {
                    IdCuenta = (int)dr[0],
                    Cbu = Convert.ToString(dr[1]),
                    Saldo = (Decimal)dr[2],
                    TipoDeCuenta = GetTypeAccount((int)dr[3]),
                    UltimoMovimiento = (DateTime)dr[4]
                };
                lst.Add(c);
            }
            return lst;
        }
        public bool ValidateId(int id)
        {
            var helper = DataHelper.GetInstance();
            DataTable table = helper.ExecuteSPQuery("SP_GetAccountById", new SqlParameter("@codigo", id));
            if (table.Rows.Count != 0)
            {
                Console.WriteLine("Ya existe una cuenta con este código, por favor ingrese otro.");
                return false;
            }
            return true;
        }

        public bool Save(Account oAccount)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters =
            [
                new SqlParameter("@codigo", oAccount.IdCuenta),
                new SqlParameter("@cbu", oAccount.Cbu),
                new SqlParameter("@saldo", oAccount.Saldo),
                new SqlParameter("@id_tipo_cuenta", oAccount.TipoDeCuenta.IdTipoCuenta),
                new SqlParameter("@ultimo_movimiento", oAccount.UltimoMovimiento)
            ];
            if (ValidateId(oAccount.IdCuenta))
            {
                int result = helper.ExecuteCrudSPQuery("SP_CreateAccount", parameters);
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@codigo", id)
            };
            int result = helper.ExecuteCrudSPQuery("SP_DeleteAccount", parameters);
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(Account oAccount)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@codigo", oAccount.IdCuenta),
                new SqlParameter("@cbu", oAccount.Cbu),
                new SqlParameter("@saldo", oAccount.Saldo),
                new SqlParameter("@id_tipo_cuenta", oAccount.TipoDeCuenta.IdTipoCuenta),
                new SqlParameter("@ultimo_movimiento", oAccount.UltimoMovimiento)
            };
            int result = helper.ExecuteCrudSPQuery("SP_UpdateAccount", parameters);
            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
