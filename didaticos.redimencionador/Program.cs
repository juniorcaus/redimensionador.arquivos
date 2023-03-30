using System;
using System.Threading;

namespace didaticos.redimencionador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando projeto de redimencionador ");

            Thread thread = new Thread(Redimensionar);
            thread.Start();

            

                
            Console.Read();
        }

        static void Redimensionar()
        {
            for(int i = 0; i < 100; i++)
            {
                while(true) {

                }

                Thread.Sleep(new TimeSpan(0, 0, 2));
            }
        }
    }
}
