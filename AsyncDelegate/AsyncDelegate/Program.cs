using System;
using System.ComponentModel;
using System.Net;

namespace AsyncDelegate
{
    internal class Program
    {
        static bool downloading = false;
        static void Main(string[] args)
        {
            var webClient = new WebClient();

            Console.Write("Téléchargement...");

            string uri = "https://codeavecjonathan.com/res/bateau.jpg";

            //webClient.DownloadFile(uri, "bateauu.jpg");

            downloading = true;
            webClient.DownloadFileCompleted += Webclient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(uri), "bateau.jpg");

            while (downloading)
            {
                Thread.Sleep(500);
                if (downloading)
                {
                    Console.Write(".");
                }
            }

            Console.Write("Fin du programme");

        }

        private static void Webclient_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Téléchargement terminé");
            downloading = false;
        }
    }
}