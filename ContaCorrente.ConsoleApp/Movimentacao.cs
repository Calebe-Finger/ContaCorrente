
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
}
