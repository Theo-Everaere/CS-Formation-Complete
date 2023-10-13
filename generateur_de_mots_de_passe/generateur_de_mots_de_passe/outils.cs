using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS
{
    static class outils
    {

        public static int DemanderNombrePositifNonNul(string question)
        {
            return DemanderNombreEntre(question, 1, int.MaxValue, "Erreur: Le nombre doit être positif et non null.");
        }

        public static int DemanderNombreEntre(string question, int min, int max, string messageErreurPersonalise = null)
        {
            int nombre = DemanderNombre(question);
            if ((nombre >= min) && (nombre <= max))
            {
                // Valid
                return nombre;
            }
            if (messageErreurPersonalise == null)
            {
                Console.WriteLine($"Erreur: Le nombre doit être compris entre {min} et {max}.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(messageErreurPersonalise);
                Console.WriteLine();
            }

            return DemanderNombreEntre(question, min, max, messageErreurPersonalise);
        }

        public static int DemanderNombre(string question)
        {
            Console.WriteLine(question);

            while (true)
            {
                string reponse = Console.ReadLine();
                try
                {
                    int reponseInt = int.Parse(reponse);
                    return reponseInt;

                }
                catch
                {
                    Console.WriteLine("Erreur: Merci de rentrer un nombre.");
                    Console.WriteLine();
                }
            }
        }
    }
}
