using System;
using System.IO;

namespace programme_fichiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = "out";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filename = "monFichier.txt";

            string pathAndFile = Path.Combine(path, filename);

            if (File.Exists(pathAndFile))
            {
                Console.WriteLine("Le fichier existe déjà, on va écraser son contenu.");
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas, on va le créer.");
            }

            Console.WriteLine("Mon fichier : " + pathAndFile);

            var noms = new List<string>()
            {
                "Jean",
                "Paul",
                "Martin"
            };

            File.WriteAllLines(pathAndFile, noms);

            try
            {
                var lignes = File.ReadAllLines(pathAndFile);

                foreach (var ligne in noms)
                {
                    Console.WriteLine(ligne);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Erreur : Ce fichier n'existe pas (" + ex.Message);
            }
        }
    }
}
