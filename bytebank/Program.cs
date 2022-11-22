using bytebank;
using bytebank.Titular;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Boas vindas ao seu banco, Bytebank");

        ContaCorrente conta1 = new ContaCorrente(1, "1234-X");
        conta1.NomeAgencia = "Matriz";        

        ContaCorrente conta2 = new ContaCorrente(1, "4321-Y");
        //conta2.titular = "Roberto";
        conta2.NomeAgencia = "Matriz";


        conta1.Saldo=200;
        conta2.Saldo=100;
        Console.WriteLine($"Saldo 1: {conta1.Saldo}");
        Console.WriteLine($"Saldo 2: {conta2.Saldo}");

        conta1.Tranferir(50, conta2);

        Console.WriteLine($"Saldo 1: {conta1.Saldo}");
        Console.WriteLine($"Saldo 2: {conta2.Saldo}");

        Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
        Console.ReadKey();
    }
} 