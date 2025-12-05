namespace UniversalScanner.Interfaces
{
    public interface IScanner
    {
        void ConectarDispositivo(IDiagnosticavel dispositivo);
        void Scanear();
    }
}
