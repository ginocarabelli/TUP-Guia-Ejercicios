using practico02.Domain;
using practico02.Services;

BankManager bankManager = new BankManager();

var lst = bankManager.GetAllAccounts();
Console.WriteLine("\nLista de cuentas:");
foreach (var account in bankManager.GetAllAccounts())
{
    Console.WriteLine($"\nId: {account.IdCuenta}, Cbu: {account.Cbu}, Tipo de Cuenta: {account.TipoDeCuenta.TipoDeCuenta}, " +
        $"Saldo: ${account.Saldo}, Ultimo Movimiento: {account.UltimoMovimiento}");
}

Console.WriteLine("\nIngrese un número de cuenta:");
var idAccount = Console.ReadLine();
var accountById = bankManager.GetAccountById(Convert.ToInt32(idAccount));
Console.WriteLine($"\nId: {accountById.IdCuenta}, Cbu: {accountById.Cbu}, Tipo de Cuenta: {accountById.TipoDeCuenta.TipoDeCuenta}, " +
$"Saldo: ${accountById.Saldo}, Ultimo Movimiento: {accountById.UltimoMovimiento}");

