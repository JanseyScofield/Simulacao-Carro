namespace CarrosInterfaces
{
    public interface ICarro
    {
        void Ligar();
        void Desligar();
        void Acelerar();
        void Frear();
        void Abastecer(float litros);
        void TrocarOleo(float quantidade);
        void TrocarAguaRadiador(float quantidade);
        void DefinirErros(Erros erros);
    }
}
