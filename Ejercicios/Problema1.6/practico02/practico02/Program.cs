using practico02.Domain;
using practico02.Services;

BankManager bankManager = new BankManager();

// Recuperar todas las Cuentas
var lst = bankManager.GetAllAccounts();
Console.WriteLine("\nLista de cuentas:");
foreach (var account in bankManager.GetAllAccounts())
{
    Console.WriteLine($"Id: {account.IdCuenta}, Cbu: {account.Cbu}, Tipo de Cuenta: {account.TipoDeCuenta.TipoDeCuenta}, " +
        $"Saldo: ${account.Saldo}, Ultimo Movimiento: {account.UltimoMovimiento}");
}
// Recuperar Cuentas por Id
var accountById = bankManager.GetAccountById(1);
Console.WriteLine($"\nBuscando la cuenta con el ID {accountById.IdCuenta}:");
Console.WriteLine($"Id: {accountById.IdCuenta}, Cbu: {accountById.Cbu}, Tipo de Cuenta: {accountById.TipoDeCuenta.TipoDeCuenta}, " +
$"Saldo: ${accountById.Saldo}, Ultimo Movimiento: {accountById.UltimoMovimiento}");

// Cuentas
Account account3 = new Account()
{
    IdCuenta = 3,
    Cbu = "34567",
    Saldo = 150000.00m,
    TipoDeCuenta = bankManager.GetAccountType(2),
    UltimoMovimiento = Convert.ToDateTime("28/08/2024")
};

Account account4 = new Account()
{
    IdCuenta = 4,
    Cbu = "45678",
    Saldo = 24590.90m,
    TipoDeCuenta = bankManager.GetAccountType(1),
    UltimoMovimiento = Convert.ToDateTime("10/06/2024")
};

Account genericAccount = new Account()
{
    IdCuenta = 1,
    Cbu = "56789",
    Saldo = 20000.00m,
    TipoDeCuenta = bankManager.GetAccountType(2),
    UltimoMovimiento = Convert.ToDateTime("28/08/2024")
};

// Crea una cuenta y valida que no exista otra con el mismo código
Console.WriteLine("\nCreando cuenta:");
if (bankManager.CreateAccount(account3))
{
    Console.WriteLine($"Cuenta creada correctamente! Los datos de la cuenta son: \nId: {account3.IdCuenta}, Cbu: {account3.Cbu}, Saldo: {account3.Saldo}, Tipo de Cuenta: {account3.TipoDeCuenta.TipoDeCuenta}");
}

// Valida que exista la cuenta y luego la elimina
Console.WriteLine($"\nEliminando cuenta NRO {account4.IdCuenta}:");
if (bankManager.DeleteAccount(account4.IdCuenta))
{
    Console.WriteLine($"Cuenta eliminada correctamente.");
}
else
{
    Console.WriteLine($"Esta cuenta ya no existe.");
}

// Actualiza una cuenta
Console.WriteLine($"\nActualizando cuenta NRO {genericAccount.IdCuenta}:");
if (bankManager.UpdateAccount(genericAccount))
{
    Console.WriteLine($"Cuenta actualizada correctamente.");
    Console.WriteLine($"Los nuevos datos de la cuenta son: Id: {genericAccount.IdCuenta}, Cbu: {genericAccount.Cbu}, Saldo: {genericAccount.Saldo}, Tipo de Cuenta: {genericAccount.TipoDeCuenta.TipoDeCuenta}");
}
else
{
    Console.WriteLine($"Error al actualizar la cuenta.");
}