namespace DesignPatternsExamples
{
    public class Suv : Carro
    {
        public bool Tracao4x4{ get; private set; }
        public Suv(long id, string nome, string marca, int ano, float capacidadeTanque, bool tracao4x4) 
            : base(id, nome, marca, ano, capacidadeTanque)
        {
            Tracao4x4 = tracao4x4;
        }

        public void AtivarTracao4x4()
        {
            if (Tracao4x4)
            {
                Console.WriteLine($"A tração 4x4 do {Nome} foi ativada.");
            }
            else
            {
                Console.WriteLine($"{Nome} não possui tração 4x4.");
            }
        }
    }
}
