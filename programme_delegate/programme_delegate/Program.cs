using System;

namespace programme_delegate
{
    internal class Program
    {
        public delegate string ValidationChaine(string s);
        static string DemanderChaineUtilisateur(string message, ValidationChaine fonctionValidation = null)
        {
            Console.WriteLine(message + " ");
            string reponse = Console.ReadLine();
            if (fonctionValidation != null)
            {
                string erreur = fonctionValidation(reponse);
                if (erreur != null)
                {
                    Console.WriteLine("Erreur " + erreur);
                    return DemanderChaineUtilisateur(message, fonctionValidation);
                }
            }
            return reponse;
        }

        static string CheckValidationNom(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le nom ne doit pas être vide.";
            }

            if (s.Any(char.IsDigit))
            {
                return "Le nom ne doit pas contenir de chiffres";
            }

            return null;
        }

        static string CheckValidationTelephone(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le numéro de téléphone ne doit pas être vide.";
            }

            if (s.Length != 10)
            {
                return "Le numéro de téléphone doit contenir 10 chiffres";
            }

            if (!s.All(char.IsDigit))
            {
                return "Le numéro doit contenir uniquement des chiffres.";
            }

            return null;
        }

        static void Main(string[] args)
        {
            string nom = DemanderChaineUtilisateur("Quel est votre nom ?", CheckValidationNom);
            string tel = DemanderChaineUtilisateur("Quel est votre numéro de téléphone ?", CheckValidationTelephone);
            Console.WriteLine();
            Console.WriteLine($"Bonjour {nom}, votre numéro de téléphone est {tel}");
        }
    }
}