using System;

namespace jeu_de_maths
{
    internal class Program
    {
        enum e_Operator
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3,
        }

        static bool PoserQuestion(int min, int max)
        {
            Random rand = new Random();

            while (true)
            {

                int a = rand.Next(min, max + 1);
                int b = rand.Next(min, max + 1);
                e_Operator o = (e_Operator)rand.Next(1, 4);
                int resultatAttendu;

                switch (o)
                {
                    case e_Operator.ADDITION:
                        Console.WriteLine(a + " + " + b + " = ");
                        resultatAttendu = a + b;
                        break;

                    case e_Operator.MULTIPLICATION:
                        Console.WriteLine(a + " x " + b + " = ");
                        resultatAttendu = a * b;
                        break;

                    case e_Operator.SOUSTRACTION:
                        Console.WriteLine(a + " - " + b + " = ");
                        resultatAttendu = a - b;
                        break;

                    default:
                        Console.WriteLine();
                        return false;
                }

                string reponse = Console.ReadLine();
                try
                {
                    int reponseInt = int.Parse(reponse);
                    if (reponseInt == resultatAttendu)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine("Erreur : Vous devez rentrer un nombre.");
                }
            }
        }

        static void Main(string[] args)
        {

            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            const int NOMBRE_QUESTIONS = 4;

            int points = 0;


            for (int i = 0; i < NOMBRE_QUESTIONS; i++)
            {
                Console.WriteLine("Question n°" + (i + 1) + "/" + NOMBRE_QUESTIONS);
                bool bonneReponse = PoserQuestion(NOMBRE_MIN, NOMBRE_MAX);
                if (bonneReponse)
                {
                    Console.WriteLine("Bonne réponse");
                    points++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse");
                }
                Console.WriteLine();

            }

            Console.WriteLine("Nombre de points: " + points + "/" + NOMBRE_QUESTIONS);

            int moyenne = NOMBRE_QUESTIONS / 2;

            if (NOMBRE_QUESTIONS == points)
            {
                Console.WriteLine("Excellent");
            }
            else if (points == 0)
            {
                Console.WriteLine("Révisez vos maths");
            }
            else if (points > moyenne)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Peut mieux faire!");
            }

        }
    }
}