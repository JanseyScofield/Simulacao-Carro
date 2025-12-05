using CarrosInterfaces;

namespace UniversalScanner.Interfaces
{
    public interface ICarroDiagnosticavel : ICarro, IDiagnosticavel
    {
        string Nome { get; }
        string Marca { get; }
        int Ano { get; }
        bool Ligado { get;}
        float CapacidadeTanque { get; }
        float QtdCombustivelTanque { get; }
        float QtdAguaRadiador { get; }
        float NivelOleo { get; }
        float TemperaturaMotor { get; }
        bool DefeitoMotor { get; }
        bool DefeitoFreio { get; }
        bool DefeitoSuspensao { get; }
        bool DefeitoEletrico { get; }
        bool DefeitoFarois { get; }
    }
}
