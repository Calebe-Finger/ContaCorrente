
namespace ContaCorrente.ConsoleApp
{
    public class Movimentacao
    {
        public decimal valor;
        public string tipo;

        public string LerMovimentacao()
        {
            return $"{tipo} - {valor.ToString("C2")}";
        }
    }

    public class ContaCorrente
    {
        //atributos
        public decimal saldo;
        public int numero;
        public decimal limite;
        public Movimentacao[] movimentacoes;
        int contadorMovimentacoes = 0;

        //métodos
        public void Sacar(decimal quantia)
        {
            if (quantia < saldo + limite)
            {
                saldo -= quantia;

                Movimentacao novaMovimentacao = new Movimentacao();
                novaMovimentacao.valor = quantia;
                novaMovimentacao.tipo = "Débito";

                movimentacoes[contadorMovimentacoes] = novaMovimentacao;
                contadorMovimentacoes++;
            }
        }

        public void Depositar(decimal quantia)
        {
            saldo += quantia;

            Movimentacao novaMovimentacao = new Movimentacao();
            novaMovimentacao.valor = quantia;
            novaMovimentacao.tipo = "Crédito";

            movimentacoes[contadorMovimentacoes] = novaMovimentacao;
            contadorMovimentacoes++;
        }

        internal void TransferirPara(ContaCorrente destinatario, decimal quantia)
        {
            destinatario.Depositar(quantia);

            this.Sacar(quantia);
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("O extrato da conta #" + this.numero);

            Console.WriteLine("Saldo " + this.saldo);

            for (int i = 0; i < movimentacoes.Length; i++)
            {
                Movimentacao movimentacaoAtual = movimentacoes [i];

                if (movimentacaoAtual != null)
                {
                    Console.WriteLine(movimentacaoAtual.LerMovimentacao);
                }
            }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente();
            conta1.saldo = 1000;
            conta1.numero = 12;
            conta1.limite = 0;
            conta1.movimentacoes = new Movimentacao[100];

            conta1.Sacar(200);
            conta1.Depositar(300);
            conta1.Depositar(500);
            conta1.Sacar(200);

            ContaCorrente conta2 = new ContaCorrente();
            conta2.saldo = 300;
            conta2.numero = 14;
            conta2.limite = 0;
            conta2.movimentacoes = new Movimentacao[100];

            conta1.TransferirPara(conta2, 400);

            conta1.ExibirExtrato();

            Console.WriteLine();

            conta2.ExibirExtrato();
        }
    }
}
