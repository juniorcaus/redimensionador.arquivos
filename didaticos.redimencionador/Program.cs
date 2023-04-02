using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace didaticos.redimensionador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando projeto de redimensionador ");

            Thread thread = new Thread(Redimensionar);
            thread.Start();

            

                
            Console.Read();
        }

        static void Redimensionar()
        {
            #region "Diretorios" 
            string diretorio_entrada = "Arquivos_Entrada";
            string diretorio_redimensionados = "Arquivos_Redimensionados";
            string diretorio_finalizados = "Arquivos_Finalizados";


            if (!Directory.Exists(diretorio_entrada))
            {
                Directory.CreateDirectory(diretorio_entrada);
            }

            if (!Directory.Exists(diretorio_redimensionados))
            {
                Directory.CreateDirectory(diretorio_redimensionados);
            }

            if (!Directory.Exists(diretorio_finalizados))
            {
                Directory.CreateDirectory(diretorio_finalizados);
            }

            #endregion
            FileStream fileStream;
            FileInfo fileInfo;

            while (true) 
                {

                //Meu programa vai olhar para pasta de entrada
                // se tiver arquivo, ele irá dimencionar
                var arquivosEntradas = Directory.EnumerateFiles(diretorio_entrada);


                //ler o tamanho q ira redimensionar 
                int novaAltura = 200;           

                foreach (var arquivo in arquivosEntradas)
                {

                    fileStream = new FileStream(arquivo, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    fileInfo  = new FileInfo(arquivo);

                    string caminho = Environment.CurrentDirectory + @"\" + diretorio_redimensionados + @"\" + DateTime.Now.Millisecond.ToString() + "_" + fileInfo.Name;

                    //redimensiona + //copia arquivos redimensionados para a pasta de redimensionados       
                    Redimensionador(Image.FromStream(fileStream), novaAltura, caminho);

                    //fecha o arquivo
                    fileStream.Close();


                    //move o arquivo de entrada para pasta de finalizados
                    string caminhoFinalido = Environment.CurrentDirectory + @"\" + diretorio_finalizados + @"\" + fileInfo.Name;
                    fileInfo.MoveTo(caminhoFinalido);   
                }

                Thread.Sleep(new TimeSpan(0, 0, 2));

                }   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imagem">imagem a ser redimencionada </param>
        /// <param name="altura">altura que desejamos redimensionar</param>
        /// <param name="caminho">caminho q iremos gravar o arquivo redimensionar </param>
        /// <returns></returns>

        static void Redimensionador(Image imagem, int altura, string caminho)
        {
            double ratio = (double)altura / imagem.Height;  
            int novaLargura = (int)(imagem.Width * ratio);
            int novaAltura = (int)(imagem.Height * ratio);

            Bitmap novaImage = new Bitmap(novaLargura, novaAltura);

            using (Graphics g = Graphics.FromImage(novaImage))
            {
                g.DrawImage(imagem, 0, 0, novaLargura, novaAltura);
            }

            novaImage.Save(caminho);
            imagem.Dispose();
        }
    }  
}
