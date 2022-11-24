using bytebank;
using bytebank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank
{
    public class ContaCorrente
    {
        public Cliente titular;
        private string _conta;
        public double TaxaOperacao { get; private set; }
        public string Conta
        {
            get { return _conta; }
            set
            {
                if (value != null)
                    _conta = value;
            }
        }
        private int _numeroAgencia;
        public int NumeroAgencia
        {
            get { return _numeroAgencia; }
            private set
            {
                if (value > 0)
                    _numeroAgencia = value;
            }
        }
        public string NomeAgencia { get; set; }
        private double _saldo;

        public void Sacar(double valor)
        {
            if (_saldo < valor || valor < 0)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException($"Saldo insuficiente para saque no valor de R${valor}");
            }
            _saldo = _saldo - valor;                
            
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente destino)
        {
            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                throw new OperacaoFinanceiraException($"Operação não realizada", ex);
            }            
            destino._saldo = destino._saldo + valor;
        }
        public double Saldo
        {
            get { return _saldo; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    _saldo = value;
                }
            }
        }

        public ContaCorrente(int numeroagencia, string conta)
        {
            NumeroAgencia = numeroagencia;
            Conta = conta;
            if (numeroagencia <= 0 || conta == "0")
                throw new ArgumentException($"Os argumentos {nameof(numeroagencia)} e {nameof(conta)} devem ser maiores que 0.");

            TotalDeContasCriadas += 1;
            TaxaOperacao = 30 / TotalDeContasCriadas;            
        }

        public static int TotalDeContasCriadas { get; private set; }
        public static int ContadorSaquesNaoPermitidos { get; private set; }
        public static int ContadorTranferenciasNaoPermitidos { get; private set; }
    }
}
