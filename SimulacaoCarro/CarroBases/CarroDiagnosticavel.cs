using UniversalScanner.Interfaces;

namespace SimulacaoCarro.CarroBase
{
    public class CarroDiagnosticavel : Carro, ICarroDiagnosticavel
    {
        public CarroDiagnosticavel(long id, string nome, string marca, int ano, float capacidadeTanque)
            : base(id, nome, marca,ano, capacidadeTanque)
        {
        }
    }
}
