using CarrosAntigos;
using CarrosInterfaces;
using UniversalScanner.Interfaces;

namespace SimulacaoCarro.Resposta
{
    public class CarroAntigoAdapter : ICarroDiagnosticavel
    {
        private readonly CarroAntigo _carroAntigo;

        public long Id => _carroAntigo.NumeroSerie;
        public string Nome => _carroAntigo.Nome;

        public string Marca => _carroAntigo.Marca;

        public int Ano => _carroAntigo.Ano;

        public bool Ligado => _carroAntigo.Ligado;

        public float CapacidadeTanque => _carroAntigo.CapacidadeTanque;

        public float QtdCombustivelTanque => _carroAntigo.QtdCombustivelTanque;

        public float QtdAguaRadiador => _carroAntigo.QtdAguaRadiador;

        public float NivelOleo => _carroAntigo.NivelOleo;

        public float TemperaturaMotor => _carroAntigo.TemperaturaMotor;

        public bool DefeitoMotor => _carroAntigo.StatusAtuais.Contains(CodigosStatus.MotorFalhando);

        public bool DefeitoFreio => _carroAntigo.StatusAtuais.Contains(CodigosStatus.FreioBaixo);

        public bool DefeitoSuspensao => _carroAntigo.StatusAtuais.Contains(CodigosStatus.SuspensaoDanificada);

        public bool DefeitoEletrico => _carroAntigo.StatusAtuais.Contains(CodigosStatus.ProblemaEletrico);

        public bool DefeitoFarois => _carroAntigo.StatusAtuais.Contains(CodigosStatus.FaroisQueimados);

        public CarroAntigoAdapter(CarroAntigo carroAntigo)
        {
            _carroAntigo = carroAntigo;
        }
        public void Ligar()
        {
            _carroAntigo.LigarCarro();
        }
        public void Desligar()
        {
            _carroAntigo.DesligarCarro();
        }
        public void Abastecer(float litros)
        {
            _carroAntigo.Abastecer(litros);
        }

        public override string ToString()
        {
            return _carroAntigo.ToString();
        }

        public void TrocarOleo(float quantidade)
        {
            _carroAntigo.TrocarOleo(quantidade);
        }

        public void TrocarAguaRadiador(float quantidade)
        {
            _carroAntigo.TrocarAguaRadiador(quantidade);
        }

        public void Acelerar()
        {
            _carroAntigo.LigarCarro();
            _carroAntigo.AcionarAcelerador();
        }

        public void Frear()
        {
            _carroAntigo.FolgarAcelerador();
            _carroAntigo.AcionarFreio();
        }
        public void DefinirErros(Erros erros)
        {
            var codigos = new List<CodigosStatus>();
            bool statusOk = true;
            if (erros.MotorQuebrado)
            {
                codigos.Add(CodigosStatus.MotorFalhando);
                statusOk = false;
            }
            if (erros.FreioQuebrado)
            {
                codigos.Add(CodigosStatus.FreioBaixo);
                statusOk = false;
            }
            if (erros.SuspensaoQuebrada)
            {
                codigos.Add(CodigosStatus.SuspensaoDanificada);
                statusOk = false;
            }
            if (erros.ComponentesEletricosQuebrados)
            {
                codigos.Add(CodigosStatus.ProblemaEletrico);
                statusOk = false;
            }
            if (erros.FaroisQuebrados)
            {
                codigos.Add(CodigosStatus.FaroisQueimados);
                statusOk = false;
            }
            if (statusOk)
            {
                codigos.Add(CodigosStatus.Ok);
            }
            _carroAntigo.DefinirStatus(codigos);
        }
    }
}
