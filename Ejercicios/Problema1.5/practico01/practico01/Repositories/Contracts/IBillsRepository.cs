﻿using practico01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Repositories.Contracts
{
    public interface IBillsRepository
    {
        List<Invoice> GetAll();
        Invoice GetInvoiceById(int id);
        bool Save(Invoice oInvoice);
        bool Delete(int id);
        bool Update(Invoice oInvoice);

    }
}
