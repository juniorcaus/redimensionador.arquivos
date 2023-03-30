using System;
using System.IO;
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
            #region "Diretorios" 
            string diretorio_entrada = "Arquivos_Entrada";
            string diretorio_redimencionados = "Arquivos_Redimencionados";
            string diretorio_finalizados = "Arquivos_Finalizados";


            if (!Directory.Exists(diretorio_entrada)) ;
            {
                Directory.CreateDirectory(diretorio_entrada);
            }

            if (!Directory.Exists(diretorio_redimencionados)) ;
            {
                Directory.CreateDirectory(diretorio_redimencionados);
            }

            if (!Directory.Exists(diretorio_finalizados)) ;
            {
                Directory.CreateDirectory(diretorio_finalizados);
            }

            #endregion 

            while (true) 
                {

                //Meu programa vai olhar para pasta de entrada
                // se tiver arquivo, ele irá dimencionar

                Thread.Sleep(new TimeSpan(0, 0, 2));

                }

            
        }
    }
}
