namespace DesignPatternsExamples
{
    public class Hatch : Carro
    {
        public bool TemTetoSolar{ get; private set; }
        public Hatch(long id, string nome, string marca, int ano, float capacidadeTanque, bool temTetoSolar) 
            : base(id, nome, marca, ano, capacidadeTanque)
        {
            TemTetoSolar = temTetoSolar;
        }
        public void AbrirTetoSolar()
        {
            if (TemTetoSolar)
            {
                Console.WriteLine($"O teto solar do {Nome} foi aberto.");
            }
            else
            {
                Console.WriteLine($"{Nome} não possui teto solar.");
            }
        }
    }
}
