using System;
using System.Net;

namespace programme_reseau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/papillon.jpg";

            var webClient = new WebClient();
            Console.WriteLine("Accès au réseau...");
            try
            {
                webClient.DownloadFile(url, "papillon.jpg");
                Console.WriteLine("Teléchargement terminé");

            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    var statusCode = ((HttpWebResponse)ex.Response).StatusCode;

                    if (statusCode == HttpStatusCode.NotFound)
                    {

                        Console.WriteLine("Erreur Reseau : Non trouvé.");
                    }
                    else
                    {
                        Console.WriteLine("Erreur Réseau : " + statusCode);
                    }
                }
                else
                {

                    Console.WriteLine($"Erreur reseau - ({ex.Message})");
                }

            }
        }
    }
}