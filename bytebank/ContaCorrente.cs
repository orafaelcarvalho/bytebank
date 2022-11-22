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
            set
            {
                if (value > 0)
                    _numeroAgencia = value;
            }
        }
        public string NomeAgencia { get; set; }
        private double _saldo;

        public bool Sacar(double valor)
        {
            if (_saldo < valor || valor < 0)
            {
                return false;
            }
            else
            {
                _saldo = _saldo - valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente destino)
        {
            if (_saldo < valor || valor < 0)
            {
                return false;
            }
            else
            {
                _saldo = _saldo - valor;
                destino._saldo = destino._saldo + valor;
                return true;
            }
        }

        //public void SetSaldo(double valor)
        //{
        //    if(valor < 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        saldo += valor;
        //    }
        //}

        //public double GetSaldo()
        //{
        //    return saldo;
        //}

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
            TotalDeContasCriadas += 1;
        }

        public static int TotalDeContasCriadas{ get; set; }
    }
}
