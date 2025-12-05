namespace DesignPatternsExamples
{
    public class CarroEletrico : Carro
    {
        public float CapacidadeBateria{ get; private set; }
        public float CargaAtualBateria{ get; private set; }
        public CarroEletrico(long id, string nome, string marca, int ano, float capacidadeBateria)
            : base(id, nome, marca, ano, 0)
        {
            CapacidadeBateria = capacidadeBateria;
            CargaAtualBateria = 0;
        }
        public void CarregarBateria(float kWh)
        {
            if (kWh <= 0)
            {
                Console.WriteLine("A quantidade de kWh deve ser maior que zero.");
                return;
            }
            if (CargaAtualBateria + kWh > CapacidadeBateria)
            {
                Console.WriteLine($"Não é possível carregar {kWh} kWh. A bateria de {Nome} só comporta mais {CapacidadeBateria - CargaAtualBateria} kWh.");
                return;
            }
            CargaAtualBateria += kWh;
            Console.WriteLine($"{kWh} kWh foram carregados na bateria de {Nome}. Carga atual da bateria: {CargaAtualBateria} kWh.");
        }

        public override void Abastecer(float litros)
        {
            Console.WriteLine("Carros elétricos não abastecem");
        }

        public override string ToString()
        {
            return $"{Marca} {Nome} {Ano} número {Id} com capacidade de {CapacidadeBateria} kWh na bateria";
        }
    }
}
