using CarrosInterfaces;
using CarrosAntigos;
using UniversalScanner;
using SimulacaoCarro.Resposta;
using UniversalScanner.Interfaces;
using SimulacaoCarro.CarroBase;

namespace DesignPatternsExamples
{
    public class Program
    {
        public void Run1(ICarro carro)
        {
            Console.WriteLine("Tipo de execução 1");
            Console.WriteLine(carro.ToString());
            carro.Acelerar();
            carro.Frear();
            carro.Desligar();
            carro.Abastecer(20);
            Console.WriteLine("--------------------------------");
        }
        public void Run2(ICarroDiagnosticavel carro)
        {
            Console.WriteLine("Tipo de execução 2");
            ScannerCarro scanner = new ScannerCarro();
            Console.WriteLine(carro.ToString());
            scanner.ConectarDispositivo(carro);
            scanner.Scanear();
            carro.Acelerar();
            carro.Frear();
            carro.Desligar();
            carro.Abastecer(20);
            scanner.Scanear();
            Console.WriteLine("--------------------------------");
        }
        public void Run3(IDiagnosticavel dispositivo, IScanner scanner)
        {
            scanner.ConectarDispositivo(dispositivo);
            scanner.Scanear();
        }
        static void Main(string[] args)
        {
            var program = new Program();

            CarroAntigo carroAntigo = new CarroAntigo(1, "Ford", "Model T", 1925, 10);
            CarroAntigoAdapter carroAntigoAdaptado = new CarroAntigoAdapter(carroAntigo);
            program.Run1(carroAntigoAdaptado);
            program.Run2(carroAntigoAdaptado);
        }
    }
}
