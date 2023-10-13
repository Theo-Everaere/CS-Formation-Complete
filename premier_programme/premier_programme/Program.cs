using System;

namespace premier_programme // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static int DemanderAge(string nom)
            {
                int age_num = 0;
                while (age_num <= 0)
                {
                    Console.WriteLine("Quel age a " + nom + " ?");
                    string age_str = Console.ReadLine();
                    try
                    {
                        age_num = int.Parse(age_str);
                        if (age_num < 0)
                        {
                            Console.WriteLine("L'âge ne peut pas être négatif.");
                        }
                        if (age_num == 0)
                        {
                            Console.WriteLine("L'age ne doit pas être égal à 0.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Erreur, l'age n'est pas valide !");
                    }
                }
                return age_num;
            }

            static string DemanderNom(int numeroDeLaPersonne)
            {
                string name = "";

                while (name == "")
                {
                    Console.WriteLine("Quel est le nom de la personne numéro " + numeroDeLaPersonne + " ?");
                    name = Console.ReadLine();
                    name = name.Trim();
                    if (name == "")
                    {
                        Console.WriteLine("Votre nom doit contenir au moins 1 char.");
                    }
                }
                return name;
            }

            static void AfficherInfosPersonnes(string nom, int age, float taille = 0)
            {
                Console.WriteLine();
                Console.WriteLine("Vous vous appelez " + nom + ", vous avez " + age + " ans.");
                // Où bien
                Console.WriteLine($"Vous vous appelez {nom}, vous avez {age} ans.");
                Console.WriteLine("Bientôt vous aurez " + (age + 1) + " ans.");

                if (age == 18)
                {
                    Console.WriteLine("Vous êtes tout juste majeur");

                }
                else if (age == 17)
                {
                    Console.WriteLine("Vous serez bientôt majeur");

                }
                else if (age == 1 || age == 2)
                {
                    Console.WriteLine("Vous êtes un bébé");
                }
                else if (age >= 12 && age < 18)
                {
                    Console.WriteLine("Vous êtes un ado");
                }
                else if (age < 10)
                {
                    Console.WriteLine("Vous êtes un enfant");
                }
                else if (age >= 60)
                {
                    Console.WriteLine("Vous êtes un senoir");
                }
                else if (age >= 18)
                {
                    Console.WriteLine("Vous êtes majeur");
                }
                else
                {
                    Console.WriteLine("Vous êtes mineur");
                }

                if (taille != 0)
                {
                    Console.WriteLine("Vous faites " + taille + "m de hauteur.");
                }
            }

            // string nom1 = DemanderNom(1);
            string nom1 = "Jean";
            // string nom2 = DemanderNom(2);
            string nom2 = "Paul";

            int age_num1 = DemanderAge(nom1);
            int age_num2 = DemanderAge(nom2);

            AfficherInfosPersonnes(nom1, age_num1, 1.75f);
            AfficherInfosPersonnes(nom2, age_num2);

            /*
            const int NB_PERSONNES = 5;

            for (int i = 0; i < NB_PERSONNES; i++)
            {
                string nom = "Personne " + (i + 1);
                int age = DemanderAge(nom);
                AfficherInfosPersonnes(nom, age);
                Console.WriteLine();
                Console.WriteLine("---");
            }
            */

        }
    }
}
