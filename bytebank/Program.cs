using bytebank;
using bytebank.Titular;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Boas vindas ao seu banco, Bytebank");
        
        try
        {
            ContaCorrente conta = new ContaCorrente(12, "122");
            ContaCorrente conta2 = new ContaCorrente(122, "1223");
            conta.Depositar(50);
            Console.WriteLine(conta.Saldo);
            //conta.Sacar(500);
            conta.Transferir(500, conta2);
            Console.WriteLine(conta.Saldo);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Divisão por 0 - "+ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        catch(SaldoInsuficienteException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        catch(OperacaoFinanceiraException ex)
        {
            // Nesse caso posso mostrar a mensagem ex.Message para o usuário e manter a
            // ex.InnerException.Message somente no log
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("INNER EXCEPTION");
            Console.WriteLine(ex.InnerException.Message);
            Console.WriteLine(ex.InnerException.StackTrace);
        }

        Console.WriteLine(ContaCorrente.ContadorSaquesNaoPermitidos);
        Console.ReadKey();
    }
} 