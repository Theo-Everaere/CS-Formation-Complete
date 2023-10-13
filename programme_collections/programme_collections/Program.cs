using System;
using System.Collections;
using System.Linq;

namespace programme_collections // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        // Array []
        static int SommeTableau(int[] t)
        {
            int somme = 0;

            for (int i = 0; i < t.Length; i++)
            {
                somme += t[i];
            }
            return somme;
        }

        static void AfficherTableau(int[] tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.WriteLine(" [" + i + "] " + tableau[i]);
            }
        }

        static void AfficherValeurMaximale(int[] tableau)
        {
            int valeurMax = tableau[0];

            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] > valeurMax)
                    valeurMax = tableau[i];
            }

            Console.WriteLine("La valeur maximale est : " + valeurMax);
        }

        static void AfficherValeurMinimale(int[] tableau)
        {
            int valeurMin = tableau[0];

            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] < valeurMin)
                    valeurMin = tableau[i];
            }

            Console.WriteLine("La valeur minimale est : " + valeurMin);
        }

        static void Tableaux()
        {

            const int TAILLE_TABLEAU = 20;

            Random random = new Random();

            int[] t = new int[TAILLE_TABLEAU];

            for (int i = 0; i < TAILLE_TABLEAU; i++)
            {
                t[i] = random.Next(101);
            }

            AfficherTableau(t);
            Console.WriteLine("La somme du tableau est : " + SommeTableau(t));
            AfficherValeurMaximale(t);
            AfficherValeurMinimale(t);
        }

        // List
        static void AfficherListe(List<string> liste, bool ordreDescendant = false)
        {
            if (!ordreDescendant)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    Console.WriteLine(liste[i]);
                }

            }
            else
            {
                for (int i = liste.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(liste[i]);
                }
            }


            string nomLePlusLong = "";
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste[i].Length > nomLePlusLong.Length)
                {
                    nomLePlusLong = liste[i];
                }
            }

            Console.WriteLine("Le nom le plus long est : " + nomLePlusLong);
        }

        static void Listes()
        {
            /*
            List<string> noms = new List<string>() { "Jean", "Paul" };
            while (true)
            {
                Console.Write("Entrez un nom (ENTER pour finir) : ");
                string nom = Console.ReadLine();

                if (nom == "")
                {
                    break;
                }

                if (noms.Contains(nom))
                {
                    Console.WriteLine("Erreur, ce nom est déjà dans la liste.");
                }
                else
                {
                    noms.Add(nom);
                }

            }*/

            // List<string> lesPremiersNoms = noms.GetRange(0, 2);
            // AfficherListe(lesPremiersNoms);

            /* for (int i = noms.Count - 1; i > 0; i--)
             {
                 string nom = noms[i];
                 if (nom[nom.Length - 1] == 'e')
                 {
                     noms.RemoveAt(i);
                 }
             }

             AfficherListe(noms, true); */

            List<string> liste1 = new List<string>() { "Jean", "Paul", "Pierre" };
            List<string> liste2 = new List<string>() { "Jean", "Léa", "Tristan", "Paul" };

            AfficherElementsCommuns(liste1, liste2); // Dans notre cas, JEAN et Paul.

        }

        static void AfficherElementsCommuns(List<string> liste1, List<string> liste2)
        {
            List<string> elementsCommuns = new List<string>();

            for (int i = 0; i < liste1.Count; i++)
            {
                string nom1 = liste1[i];

                if (liste2.Contains(nom1))
                {
                    elementsCommuns.Add(nom1);
                    Console.WriteLine("Les noms communs entre les listes sont : " + nom1);
                }
            }

        }

        // ArrayList : Peuvent contenir plusieurs types (int, string, ...) -> Mais ! à utiliser parcimonie (mixer les types n'est pas une bonne pratique).
        static void ArrayList()
        {
            ArrayList a = new ArrayList();
            a.Add("Tom");
            a.Add(45);
            a.Add(true);

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine("Mon ArrayList : " + a[i]);
            }

        }

        // Dictionnaire:  clef -> valeur
        static void Disctionnaire()
        {
            // string: nom -> string : numero de telephone "+33"
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Jean", "+085456865");
            dictionary.Add("Marie", "+087665548");
            dictionary["Marc"] = "+085789654";

            string personneAChercher = "Marc";

            if (dictionary.ContainsKey(personneAChercher))
            {
                Console.WriteLine(dictionary[personneAChercher]);
            }
            else
            {
                Console.WriteLine("Cette personna n'a pas été trouvée");
            }

        }

        // Boucle ForEach
        static void BoucleForEach()
        {
            // string[] noms = new string[] { "Tom", "Martin", "Pierre" };

            // Fonctionne aussi avec les listes
            /*
            List<string> noms = new List<string> { "Tom", "Martin", "Pierre" };

            foreach (string nom in noms)
            {
                Console.WriteLine(nom + "Test");
            }*/

            // Aussi avec le Dictionnaire
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Jean", "+085456865");
            dictionary.Add("Marie", "+087665548");
            dictionary["Marc"] = "+085789654";

            foreach (var e in dictionary)
            {
                Console.WriteLine(e.Key + " -> " + e.Value);
            }


        }

        // TrisEtLinq
        static void TrisEtLinq()
        {
            // Ordre alphabetique pour les Listes
            //var noms = new List<string>() { "Jean", "Tom", "Marie", "Sophie" };
            //noms.Sort();

            // Ordre alphabetique pour les Arrays
            // var noms = new string[] { "Jean", "Tom", "Marie", "Sophie", "martha" };
            // Array.Sort(noms);
            // var nomsTries = noms.OrderBy(nom => nom[nom.Length -1]); // Trie les noms par ordre alphabetique en se basant sur la derniere lettre.
            // var nomsTries = noms.OrderBy(nom => nom);

            // foreach (var nom in nomsTries)
            // {
            //    Console.WriteLine(nom);
            // }

            // LINQ
            var noms = new List<string>() { "Jean", "Tom", "Marie", "Sophie" };
            noms = noms.Where(nom => nom.Length > 5).ToList();
            foreach (var nom in noms)
            {
                Console.WriteLine(nom);
            }

        }


        static void Main(string[] args)
        {
            // Tableaux();
            // Listes();
            // ArrayList();
            // Disctionnaire();
            //BoucleForEach();
            TrisEtLinq();
        }
    }
}