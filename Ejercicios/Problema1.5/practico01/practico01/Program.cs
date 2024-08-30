using practico01.Domain;
using practico01.Services;

BillsManager bManager = new BillsManager();
PaymentFormsManager pfManager = new PaymentFormsManager();
InvoiceDetailsManager idManager = new InvoiceDetailsManager();
ArticleManager aManager = new ArticleManager();

// listar todas las facturas
Console.WriteLine("\nLista de todas las facturas: ");
List<Invoice> lst = bManager.GetAll();
foreach (var invoice in lst)
{
    Console.WriteLine($"[Id: {invoice.InvoiceId}, " +
        $"Date: {invoice.InvoiceDate}, " +
        $"Payment Form: {invoice.PForm.PaymentFormName}, " +
        $"Total: ${(invoice.Detail.Quantity) * (invoice.Detail.Article.UnitPrice)}, " +
        $"Client: {invoice.Client}]"
    );
}

// listar una factura por id
int id = 1;
Console.WriteLine($"\nLa factura con ID {id} es:");
Invoice oInvoice = bManager.GetInvoiceById(id);
Console.WriteLine($"[Id: {oInvoice.InvoiceId}, " +
    $"Date: {oInvoice.InvoiceDate}, " +
    $"Payment Form: {oInvoice.PForm.PaymentFormName}, " +
    $"Total: ${(oInvoice.Detail.Quantity) * (oInvoice.Detail.Article.UnitPrice)}, " +
    $"Client: {oInvoice.Client}]"
);

// CREACIÓN DE FACTURAS
// PARA ELLO DEBEMOS CREAR UN DETALLE FACTURA

// CREAR DETALLE FACTURA
Console.WriteLine($"\nCREANDO DETALLE FACTURA:");
InvoiceDetail oInvoiceDetail1 = new InvoiceDetail()
{
    InvoiceDetailsID = 2,
    Article = aManager.GetArticleById(2),
    Quantity = 2
};
if (idManager.Save(oInvoiceDetail1))
{
    Console.WriteLine("\nDetalle factura creado");
}
else
{
    Console.WriteLine("\nError al crear Detalle factura");
}

// CREAR FACTURA
Console.WriteLine($"\nCREANDO FACTURA:");
Invoice oInvoice1 = new Invoice()
{
    InvoiceId = 2,
    InvoiceDate = Convert.ToDateTime("29/08/2024"),
    PForm = pfManager.GetPaymentFormById(1),
    Detail = idManager.GetInvoiceDetailById(2),
    Client = "Juan Perez"
};
if (bManager.Save(oInvoice1))
{
    Console.WriteLine($"\nFactura creada correctamente!");
    Console.WriteLine(
        $"[Id: {oInvoice1.InvoiceId}, " +
        $"Date: {oInvoice1.InvoiceDate}, " +
        $"Payment Form: {oInvoice1.PForm.PaymentFormName}, " +
        $"Total: ${(oInvoice1.Detail.Quantity) * (oInvoice1.Detail.Article.UnitPrice)}, " +
        $"Client: {oInvoice1.Client}]"
    );
}
else
{
    Console.WriteLine("\nError al crear Factura");
}

// ACTUALIZAR FACTURA
// SI LO DESEAMOS, TAMBIEN PODEMOS ACTUALIZAR UN DETALLE FACTURA

// ACTUALIZAR DETALLE FACTURA (OPCIONAL)
Console.WriteLine($"\nACTUALIZANDO DETALLE FACTURA:");
InvoiceDetail oInvoiceDetail2 = new InvoiceDetail()
{
    InvoiceDetailsID = 2,
    Article = aManager.GetArticleById(1),
    Quantity = 5
};
if (idManager.Update(oInvoiceDetail2))
{
    Console.WriteLine($"\nDetalle Factura editado correctamente!");
    Console.WriteLine(
        $"[Id: {oInvoiceDetail2.InvoiceDetailsID}, " +
        $"Article: {oInvoiceDetail2.Article.ArticleName}, " +
        $"Quantity: {oInvoiceDetail2.Quantity}]"
    );
}
else
{
    Console.WriteLine("\nError al editar Detalle Factura");
}

// ACTUALIZAR FACTURA
Console.WriteLine($"\nACTUALIZANDO FACTURA:");
Invoice oInvoice2 = new Invoice()
{
    InvoiceId = 2,
    InvoiceDate = Convert.ToDateTime("30/08/2024"),
    PForm = pfManager.GetPaymentFormById(3),
    Detail = idManager.GetInvoiceDetailById(2),
    Client = "Lionel Messi"
};
if (bManager.Update(oInvoice2))
{
    Console.WriteLine($"\nFactura editada correctamente!");
    Console.WriteLine(
        $"[Id: {oInvoice2.InvoiceId}, " +
        $"Date: {oInvoice2.InvoiceDate}, " +
        $"Payment Form: {oInvoice2.PForm.PaymentFormName}, " +
        $"Total: ${(oInvoice2.Detail.Quantity) * (oInvoice2.Detail.Article.UnitPrice)}, " +
        $"Client: {oInvoice2.Client}]"
    );
}
else
{
    Console.WriteLine("\nError al editar Factura");
}

// ELIMINAR FACTURA
Console.WriteLine($"\nELIMINANDO FACTURA:");
if (bManager.Delete(oInvoice2.InvoiceId))
{
    Console.WriteLine($"\nFactura eliminada correctamente!");
}
else
{
    Console.WriteLine($"\nEsta Factura no existe");
}
// PD: PARA PROBAR EL ERROR RECUERDE COMENTAR LOS METODOS ACTUALIZAR Y CREAR
// YA QUE VA A ESTAR CREANDO Y ACTUALIZANDO oInvoice2 CONSTANTEMENTE,
// SE VA A ELIMINAR SI, PERO NUNCA NOS DIRÁ "Esta Factura no existe"