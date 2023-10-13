using System;
using System.Collections.Generic;

namespace generateur_phrases_aleatoires
{
    internal class Program
    {
        static Random random = new Random();

        static string ObtenirElementAleatoire(string[] t)
        {
            int indexAleatoire = random.Next(t.Length);

            return t[indexAleatoire];
        }


        static void Main(string[] args)
        {
            string[] sujets = { "Le chien", "Le chat", "L'oiseau", "La voiture", "Le vélo", "La fleur", "Le livre", "La table" };

            string[] verbes = { "mange", "court", "saute", "regarde", "écoute", "lit", "joue", "s'accroche à" };

            string[] complements = { "le gâteau", "le soleil", "le parc", "la musique", "le livre", "le film", "le ballon", "le jardin" };

            const int NB_PHRASES = 100;
            int doublonsEvites = 0;

            List<string> phrasesUniques = new List<string>();

            while(phrasesUniques.Count < NB_PHRASES)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complement = ObtenirElementAleatoire(complements);
                string phrase = sujet + " " + verbe + " " + complement;
                phrase = phrase.Replace("à le", "au");

                if (!phrasesUniques.Contains(phrase))
                {
                    phrasesUniques.Add(phrase);
                }
                else
                {
                    doublonsEvites++;
                }
            }

            foreach (var phrase in phrasesUniques)
            {
                Console.WriteLine(phrase);
            }

            Console.WriteLine();
            Console.WriteLine("Nombre de phrases: " + phrasesUniques.Count);
            Console.WriteLine("Nombre de doublons évités: " + doublonsEvites);

        }
    }
}