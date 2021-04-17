using System;

namespace APP_bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}

        private string Nome{get; set;}

        //Metodo construtor => chamado no momento da criacao do objeto
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //Metodos => acoes a serem feitas com a conta
        public bool Sacar(double valorSaque)
        {
            //Validacao de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito*-1)) {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0}: R$ {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito) {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0}: R$ {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString() {
            string retorno = "";
            retorno += this.Nome + "\t\t|\t ";
            retorno += this.TipoConta + "\t\t|\t ";
            retorno += "R$ " + this.Saldo + "\t\t|\t ";
            retorno += "R$ " + this.Credito;
            return retorno;
        }


    }
}