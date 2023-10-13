using System;
using System.Globalization;

namespace generateur_de_mots_de_passe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int NB_MOTS_DE_PASSE = 10;

            int longueurMotDePasse = FormationCS.outils.DemanderNombrePositifNonNul("Definir une longueur de mot de passe: ");
            int typeMotDePasse = FormationCS.outils.DemanderNombreEntre("Voulez-vous un mot de passe avec:\n" +
                "1 - Uniquement des caractères en minuscule\n" +
                "2 - Des caractères muniscules et majuscules\n" +
                "3 - Des caractères minuscules/majuscules et des chiffres\n" +
                "4 - Des caractères minuscules/majuscules, des chiffres et des caractères spéciaux", 1, 4);

            string minuscules = "abcdefghijklmnopqrstuvwxyz";
            string majuscules = minuscules.ToUpper();
            string chiffres = "0123456789";
            string caracteresSpeciaux = "&-+!?";
            string alphabet;

            if (typeMotDePasse == 1)
                alphabet = minuscules;
            else if (typeMotDePasse == 2)
                alphabet = minuscules + majuscules;
            else if (typeMotDePasse == 3)
                alphabet = minuscules + majuscules + chiffres;
            else
                alphabet = minuscules + majuscules + chiffres + caracteresSpeciaux;

            int longueurAlphabet = alphabet.Length;

            Random random = new Random();

            string motDePasse;

            for (int j = 0; j < NB_MOTS_DE_PASSE; j++)
            {
                motDePasse = "";
                for (int i = 0; i < longueurMotDePasse; i++)
                {
                    int index = random.Next(0, longueurAlphabet);
                    motDePasse += alphabet[index];
                }
                Console.WriteLine("Mot de passe : " + motDePasse);
            }
        }
    }
}