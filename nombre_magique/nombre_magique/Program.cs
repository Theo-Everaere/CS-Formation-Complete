using System;

namespace nombre_magique // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static int DemanderNombre(int nombreMin, int nombreMax)
        {
            int nombreUtilisateur = nombreMin - 1;

            while (nombreUtilisateur < nombreMin || nombreUtilisateur > nombreMax)
            {
                Console.Write("Rentrez un nombre entre " + nombreMin + " et " + nombreMax + " : ");
                string reponse = Console.ReadLine();

                try
                {
                    nombreUtilisateur = int.Parse(reponse);

                    if (nombreUtilisateur < nombreMin || nombreUtilisateur > nombreMax)
                    {
                        Console.WriteLine("ERREUR | Le nombre n'est pas compris  entre " + nombreMin + " et " + nombreMax);
                    }

                }
                catch
                {
                    Console.WriteLine("Le nombre n'est pas valide.");
                }
            }

            return nombreUtilisateur;
        }

        static void Main(string[] args)
        {

            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;

            Random rand = new Random();
            int NOMBRE_MAGIQUE = rand.Next(NOMBRE_MIN, NOMBRE_MAX + 1);

            int nombre = NOMBRE_MAGIQUE + 1;

            // int nbVies = 4;

            //while (nbVies > 0)
            for (int nbVies = 4; nbVies > 0; nbVies--)
                {
                    Console.WriteLine();
                    Console.WriteLine("Vies restantes : " + nbVies);

                    nombre = DemanderNombre(NOMBRE_MIN, NOMBRE_MAX);

                    if (NOMBRE_MAGIQUE > nombre)
                    {
                        Console.WriteLine("Le nombre magique est plus grand.");
                    }
                    else if (NOMBRE_MAGIQUE < nombre)
                    {
                        Console.WriteLine("Le nombre magique est plus petit.");
                    }
                    else
                    {
                        Console.WriteLine("Bravo, vous avez trouvé le nombre magique !");
                        break;
                    }
                    //nbVies--;
                }

                if (nombre != NOMBRE_MAGIQUE)
                {
                    Console.WriteLine("Vous avez perdu ! Le nombre magique était " + NOMBRE_MAGIQUE);
                }

            }
        }
    }