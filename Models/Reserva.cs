using System.Globalization;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        /// <summary>
        /// Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
        /// Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
        /// </summary>
        /// <param name="hospedes"></param>
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            var quantidadeHospedes = hospedes.Count();
            if (Suite.Capacidade >= quantidadeHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                Console.WriteLine($"Quantide de hóspedes {quantidadeHospedes}, é maior que a capacidade do suite: {Suite.Capacidade}!");
     
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        /// <summary>
        /// Retorna a quantidade de hóspedes (propriedade Hospedes)
        /// </summary>
        /// <returns></returns>
        public int ObterQuantidadeHospedes()
        {
            var quantidade = Hospedes.Count();
            return quantidade;
        }

        /// <summary>
        /// Retorna o valor da diária, DiasReservados X Suite.ValorDiaria
        /// Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
        /// </summary>
        /// <returns></returns>
        public decimal CalcularValorDiaria()
        {

            decimal valor = 0;
            if (DiasReservados >= 10)
            {
                decimal calculoDaDiaria = Suite.ValorDiaria * DiasReservados;
                decimal valorDesconto = calculoDaDiaria / 10;
                valor =  Math.Round(calculoDaDiaria - valorDesconto, 2);
            }
            else
                valor = Suite.ValorDiaria * DiasReservados;

            return valor;
        }
    }
}