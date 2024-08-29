using practico01.Domain;
using practico01.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace practico01.Data
{
    public class ProjectADO : IBillsRepository
    {
        Invoice f;
        public ProjectADO()
        {
        }
        public InvoiceDetail GetInvoiceDetailsById(int id)
        {
            
        }
    }
}
