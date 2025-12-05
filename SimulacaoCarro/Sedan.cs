namespace DesignPatternsExamples
{
    public class Sedan : Carro
    {
        private int _tamPortaMalas{ get; set; }
        public Sedan(long id, string nome, string marca, int ano, float capacidadeTanque, int tamPortaMalas)
            : base(id, nome, marca, ano, capacidadeTanque)
        {
            _tamPortaMalas = tamPortaMalas;
        }

        public void AbrirPortaMalas()
        {
            Console.WriteLine($"O porta malas de {Nome} com o tamanho de {_tamPortaMalas} foi aberto.");
        }
    }
}
