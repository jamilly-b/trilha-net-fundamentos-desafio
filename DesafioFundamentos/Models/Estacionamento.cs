using Microsoft.Win32.SafeHandles;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Propriedades do Estacionamento
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();

        // Construtor
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para adicionar um veículo ao dicionário
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            DateTime horarioEntrada = DateTime.Now;
            try{
                string placa = Console.ReadLine();
                veiculos.Add(placa.ToUpper(), horarioEntrada);
                Console.WriteLine("Veículo adicionado com sucesso.\n");
            }
            catch{
                Console.WriteLine("Erro. Esse veículo já está estacionado.\n");
            }
        }

        // Método para remover um veículo ao dicionário
        public void RemoverVeiculo()
        {
            // Pede para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            // Verifica se o veículo existe
            if (veiculos.ContainsKey(placa))
            {
                // Recebe a hora que foi solicitado para remover o veículo e calcula o tempo que passou estacionado.
                DateTime horarioSaida;
                DateTime horarioEntrada = veiculos[placa];
                horarioSaida = DateTime.Now;
                TimeSpan tempoEstacionado = horarioSaida - horarioEntrada;
                
                // Calcula o valor final de acordo com o tempo que o veículo ficou estacionado
                decimal valorTotal; 
                valorTotal = precoInicial + (precoPorHora * (decimal)tempoEstacionado.TotalHours);

                // Remove a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"\nPlaca: {placa}\nHorário de chegada: {horarioEntrada.ToString("HH:mm:ss dd/MM/yyyy")}\n" + 
                $"Horario de saída: {horarioSaida.ToString("HH:mm:ss dd/MM/yyyy")}\nValor Total total: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                DateTime horarioAgora = DateTime.Now;
                Console.WriteLine($"Os veículos estacionados às {horarioAgora.ToString("HH:mm:ss")} em {horarioAgora.ToString("dd/MM/yyyy")} são:");
                
                // Imprime a placa de cada veículo estacionado e o horário de entrada
                foreach(var (veiculo, horarioEntrada) in veiculos){
                    Console.WriteLine($"{veiculo} - {horarioEntrada.ToString("HH:mm:ss")}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
