using UniversalScanner.Interfaces;

namespace UniversalScanner
{
    public class ScannerCarro : IScanner
    {
        private ICarroDiagnosticavel? _carroDiagnosticavel = null;

        public void ConectarDispositivo(IDiagnosticavel dispositivo)
        {
            if (dispositivo is not ICarroDiagnosticavel carroDiagnosticavel)
            {
                Console.WriteLine("Dispositivo conectado não é um carro");
                return;
            }
            _carroDiagnosticavel = carroDiagnosticavel;
        }

        public void Scanear()
        {
            if (_carroDiagnosticavel is null)
            {
                Console.WriteLine("Nenhum carro está conectado");
                return;
            }

            Console.WriteLine($"----- Relatório de Diagnóstico do {_carroDiagnosticavel.Nome} {_carroDiagnosticavel.Id} -----");
            Console.WriteLine($"Quantidade de Combustível no Tanque: {_carroDiagnosticavel.QtdCombustivelTanque} litros");
            if (_carroDiagnosticavel.QtdCombustivelTanque < 2)
            {
                Console.WriteLine("Alerta! Tente abastecer o carro o mais rápido possível");
            }
            Console.WriteLine($"Temperatura do Motor: {_carroDiagnosticavel.TemperaturaMotor} °C");
            if (_carroDiagnosticavel.TemperaturaMotor > 180)
            {
                Console.WriteLine("Alerta! Motor super aquecendo!");
            }
            Console.WriteLine($"Quantidade de Água no Radiador: {_carroDiagnosticavel.QtdAguaRadiador} litros");
            if (_carroDiagnosticavel.QtdAguaRadiador < 1)
            {
                Console.WriteLine("Alerta! O nível de água do radiador está baixo! Troque imediatamente");
            }
            Console.WriteLine($"Nível de Óleo: {_carroDiagnosticavel.NivelOleo} litros");
            if (_carroDiagnosticavel.NivelOleo < 0.5)
            {
                Console.WriteLine("Alerta! O nível de óleo está baixo! Troque imediatamente");
            }
            if (_carroDiagnosticavel.DefeitoMotor)
            {
                Console.WriteLine("Consertando defeitos no motor");
            }
            Console.WriteLine("Motor em perfeito estado");
            if (_carroDiagnosticavel.DefeitoFreio)
            {
                Console.WriteLine("Consertando defeitos no freio");
            }
            Console.WriteLine("Freios em perfeito estado");
            if (_carroDiagnosticavel.DefeitoSuspensao)
            {
                Console.WriteLine("Consertando defeitos na suspensão");
            }
            Console.WriteLine("Suspensão em perfeito estado");
            if (_carroDiagnosticavel.DefeitoEletrico)
            {
                Console.WriteLine("Consertando defeitos elétricos");
            }
            Console.WriteLine("Faróis em perfeito estado");
            Console.WriteLine("----------------------------------------------");
        }
    }
}
