
namespace ContaCorrente.ConsoleApp
{
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

            Console.WriteLine();

            for (int i = 0; i < movimentacoes.Length; i++)
            {
                Movimentacao movimentacaoAtual = movimentacoes[i];

                if (movimentacaoAtual != null)
                {
                    Console.WriteLine(movimentacaoAtual.LerMovimentacao);
                }
            }
        }
    }
}
