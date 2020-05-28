using System;

namespace Aula03
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteDeSoftware teste = new TesteDeSoftware();
            
            CalculoGenerico<TesteDeSoftware> calcDev = new CalculoGenerico<TesteDeSoftware>();
            calcDev.CalcularValorUnitario(teste);

            Console.WriteLine(teste.ValorFinal);

        }
    }
}
