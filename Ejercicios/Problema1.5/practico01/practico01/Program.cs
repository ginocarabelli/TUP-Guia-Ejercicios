using practico01.Domain;
using practico01.Services;
using System.Collections.Generic;

BillsManager bManager = new BillsManager();
PaymentFormsManager pfManager = new PaymentFormsManager();
InvoiceDetailsManager idManager = new InvoiceDetailsManager();
ArticleManager aManager = new ArticleManager();

// listar todas las facturas
Console.WriteLine("\nLista de todas las facturas: ");
List<Invoice> lst = bManager.GetAll();
foreach(var invoice in lst)
{
    Console.WriteLine($"[Id: {invoice.InvoiceId}, " +
        $"Date: {invoice.InvoiceDate}, " +
        $"Payment Form: {invoice.PForm.PaymentFormName}, " +
        $"Total: {(invoice.Detail.Quantity) * (invoice.Detail.Article.UnitPrice)}, " +
        $"Client: {invoice.Client}]"
    );
}

// listar una factura por id
int id = 1;
Console.WriteLine($"\nLa factura con id: {id} es:");
Invoice oInvoice = bManager.GetInvoiceById(id);
Console.WriteLine($"[Id: {oInvoice.InvoiceId}, " +
    $"Date: {oInvoice.InvoiceDate}, " +
    $"Payment Form: {oInvoice.PForm.PaymentFormName}, " +
    $"Total: {(oInvoice.Detail.Quantity) * (oInvoice.Detail.Article.UnitPrice)}, " +
    $"Client: {oInvoice.Client}]"
);

// crear una factura, para ello debemos
// crear un detalle factura para su posterior especificación
// detalle factura
InvoiceDetail oInvoiceDetail1 = new InvoiceDetail()
{
    InvoiceDetailsID = 2,
    Article = aManager.GetArticleById(2),
    Quantity = 2
};

Invoice oInvoice1 = new Invoice()
{
    InvoiceId = 1,
    InvoiceDate = Convert.ToDateTime("29/08/2024"),
    PForm = pfManager.GetPaymentFormById(1),
    Detail = oInvoiceDetail1,
    Client = "Juan Perez"
};
if (bManager.Save(oInvoice1))
{
    Console.WriteLine($"\nFactura creada correctamente!");
    Console.WriteLine(
        $"[Id: {oInvoice1.InvoiceId}, " +
        $"Date: {oInvoice1.InvoiceDate}, " +
        $"Payment Form: {oInvoice1.PForm.PaymentFormName}, " +
        $"Total: {(oInvoice1.Detail.Quantity) * (oInvoice1.Detail.Article.UnitPrice)}, " +
        $"Client: {oInvoice1.Client}]"
    );
}
else
{
    Console.WriteLine("Error al crear Factura");
}
