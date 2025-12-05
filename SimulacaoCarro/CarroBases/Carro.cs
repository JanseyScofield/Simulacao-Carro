using CarrosInterfaces;

public class Carro : ICarro
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Marca { get; private set; }
    public int Ano { get; private set; }
    public bool Ligado { get; private set; }
    public float CapacidadeTanque { get; private set; }
    public float QtdCombustivelTanque { get; private set; }
    public float QtdAguaRadiador { get; private set; }
    public float NivelOleo { get; private set; }
    private float _temperaturaMotor;
    public float TemperaturaMotor
    {
        get => _temperaturaMotor;
        set
        {
            _temperaturaMotor = value;
            if (_temperaturaMotor >= 100)
            {
                QtdAguaRadiador *= 0.95f;
            }
        }
    }
    public bool DefeitoMotor { get; set; }
    public bool DefeitoFreio { get; set; }
    public bool DefeitoSuspensao { get; set; }
    public bool DefeitoEletrico { get; set; }
    public bool DefeitoFarois { get; set; }
    
    public Carro(long id, string nome, string marca, int ano, float capacidadeTanque)
    {
        Id = id;
        Nome = nome;
        Marca = marca;
        Ano = ano;
        Ligado = false;
        CapacidadeTanque = capacidadeTanque;
        QtdCombustivelTanque = 0;
        QtdAguaRadiador = 5;
        NivelOleo = 5;
        _temperaturaMotor = 30;
        DefeitoMotor = false;
        DefeitoFreio = false;
        DefeitoSuspensao = false;
        DefeitoEletrico = false;
        DefeitoFarois = false;
    }
    
    public void Ligar()
    {
        Ligado = true;
        Console.WriteLine($"{Nome} está ligado.");
        _temperaturaMotor = 80;
    }

    public void Desligar()
    {
        Ligado = false;
        Console.WriteLine($"{Nome} está desligado.");
        _temperaturaMotor = 30;
    }

    public void Acelerar()
    {
        Console.WriteLine($"{Nome} está acelerando...");
        _temperaturaMotor += 10;
    }

    public void Frear()
    {
        Console.WriteLine($"{Nome} está freando...");
        _temperaturaMotor -= 5;
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

    public void DefinirErros(Erros erros)
    {
        DefeitoMotor = erros.MotorQuebrado;
        DefeitoFreio = erros.FreioQuebrado;
        DefeitoSuspensao = erros.SuspensaoQuebrada;
        DefeitoEletrico = erros.ComponentesEletricosQuebrados;
        DefeitoFarois = erros.FaroisQuebrados;
    }

    public override string ToString()
    {
        return $"{Marca} {Nome} {Ano} número {Id} com capacidade de {CapacidadeTanque} L no tanque";
    }
}