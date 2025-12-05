namespace CarrosAntigos
{
    public class CarroAntigo
    {
        public long NumeroSerie { get; private set; }
        public string Nome { get; private set; }
        public string Marca { get; private set; }
        public int Ano { get; private set; }
        public float CapacidadeTanque { get; private set; }
        public float QtdCombustivelTanque { get; private set; }
        public float QtdAguaRadiador { get; private set; }
        public float NivelOleo { get; private set; }
        private float _temperaturaMotor;
        public float TemperaturaMotor
        {
            get => _temperaturaMotor;
            private set
            {
                if (_temperaturaMotor >= 100)
                {
                    QtdAguaRadiador *= 0.95f;
                }
                _temperaturaMotor = value;
            }
        }
        public bool Ligado { get; private set; }
        public List<CodigosStatus> StatusAtuais { get; private set; }

        public CarroAntigo(long numeroSerie, string nome, string marca, int ano, float capacidadeTanque)
        {
            NumeroSerie = numeroSerie;
            Nome = nome;
            Marca = marca;
            Ano = ano;
            CapacidadeTanque = capacidadeTanque;
            QtdCombustivelTanque = 0;
            QtdAguaRadiador = 5;
            NivelOleo = 4;
            TemperaturaMotor = 20;
            Ligado = false;
            StatusAtuais = new List<CodigosStatus>() { CodigosStatus.Ok };
        }

        public virtual void LigarCarro()
        {
            Console.WriteLine("Ligando o carro");
            TemperaturaMotor += 10;
            Ligado = true;
        }

        public virtual void DesligarCarro()
        {
            Console.WriteLine("Desligando o carro");
            TemperaturaMotor = 20;
            Ligado = false;
        }
        public virtual void AcionarAcelerador()
        {
            if (!Ligado)
            {
                Console.WriteLine("O carro está desligado");
                return;
            }
            Console.WriteLine("Acionando o acelerador");
            TemperaturaMotor += 20;
        }

        public virtual void FolgarAcelerador()
        {
            if (!Ligado)
            {
                Console.WriteLine("O carro está desligado");
                return;
            }
            Console.WriteLine("Folgando o acelerador");
            TemperaturaMotor -= 15;
            if (TemperaturaMotor < 20)
            {
                TemperaturaMotor = 20;
            }
        }
        public virtual void AcionarFreio()
        {
            if (!Ligado)
            {
                Console.WriteLine("O carro está desligado");
                return;
            }
            Console.WriteLine("Acionando o freio");
            TemperaturaMotor -= 10;
            if (TemperaturaMotor < 20)
            {
                TemperaturaMotor = 20;
            }
        }

        public virtual void Abastecer(float litros)
        {
            if (litros <= 0)
            {
                Console.WriteLine("A quantidade de litros deve ser maior que zero.");
                return;
            }
            if (QtdCombustivelTanque + litros > CapacidadeTanque)
            {
                Console.WriteLine($"Não é possível abastecer {litros} litros. O tanque de {Nome} só comporta mais {CapacidadeTanque - QtdCombustivelTanque} litros.");
                return;
            }
            QtdCombustivelTanque += litros;
            Console.WriteLine($"{litros} litros foram abastecidos no tanque de {Nome}. Quantidade atual no tanque: {QtdCombustivelTanque} litros.");
        }
        public void TrocarOleo(float quantidade)
        {
            if (quantidade <= 0)
            {
                Console.WriteLine("A quantidade de óleo deve ser maior que zero.");
                return;
            }
            Console.WriteLine($"Retirando todo o óleo velho que estava com {NivelOleo} L e adicionando {quantidade}");
            NivelOleo = quantidade;
        }

        public void TrocarAguaRadiador(float quantidade)
        {
            if (quantidade <= 0)
            {
                Console.WriteLine("A quantidade de água deve ser maior que zero.");
                return;
            }
            Console.WriteLine($"Retirando toda a água velha que estava com {QtdAguaRadiador} L e adicionando {quantidade}");
            QtdAguaRadiador = quantidade;
        }

        public override string ToString()
        {
            return $"{Marca} {Nome} {Ano} número {NumeroSerie} com capacidade de {CapacidadeTanque} L no tanque";
        }

        public virtual void DefinirStatus(List<CodigosStatus> status)
        {
            StatusAtuais = status;
        }
    }
}
