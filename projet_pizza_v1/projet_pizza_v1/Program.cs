using System;
using System.Collections.Generic;
using System.Text;

namespace projet_pizza_v1
{
    class Program
    {
        class PizzaPersonalisee : Pizza
        {
            static int nbPizzaPersonalisee = 0;

            public PizzaPersonalisee() : base("Personalisée", 5, false, null)
            {
                nbPizzaPersonalisee++;
                ingredients = new List<string>();

                while (true)
                {
                    Console.Write($"Rentrez un ingredient pour la pizza personalisée n°{nbPizzaPersonalisee} (ENTER pour terminer) : ");
                    string ingredient = Console.ReadLine();
                    Console.Clear();

                    if (string.IsNullOrEmpty(ingredient))
                    {
                        break;
                    }
                    if (ingredients.Contains(ingredient))
                    {
                        Console.WriteLine("Cet ingrédient est déja dans la liste.");
                        Console.WriteLine("Ingrédients: ");
                        Console.WriteLine(string.Join(", ", ingredients));
                    }
                    else
                    {
                        ingredients.Add(ingredient);

                        Console.WriteLine("Ingrédients: ");
                        Console.WriteLine(string.Join(", ", ingredients));
                    }
                    Console.WriteLine();

                    prix = 5 + ingredients.Count * 1.5f;

                }
            }
        }

        class Pizza
        {
            protected string nom;
            public float prix { get; protected set; }
            public bool vegetarienne { get; private set; }
            public List<string> ingredients { get; protected set; }

            public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.vegetarienne = vegetarienne;
                this.ingredients = ingredients;
            }

            public void Afficher()
            {
                string badgeVegetarienne = vegetarienne ? " (V)" : "";
                string NomAfficher = FormatPremiereLettreEnMajuscule(nom);

                /* List<string> ingredientsAfficher = new List<string>();
                 foreach (var ingredient in ingredients)
                 {
                     ingredientsAfficher.Add(FormatPremiereLettreEnMajuscule(ingredient));
                 }*/
                List<string> ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreEnMajuscule(i)).ToList();

                Console.WriteLine("Pizza " + NomAfficher + badgeVegetarienne + " - " + prix + "€");
                Console.WriteLine(string.Join(" - ", ingredientsAfficher));
                Console.WriteLine();
            }

            public bool ContientIngredient(string ingredient)
            {
                return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count > 0;
            }

        }

        private static string FormatPremiereLettreEnMajuscule(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string minuscules = s.ToLower();
            string majuscules = s.ToUpper();

            string resultat = majuscules[0] + minuscules[1..];
            return resultat;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<string> ingredientsQuatresFromages = new() { "mozarella", "oignon", "poivron", "tomates", "gruyère", "chèvre", "gouda" };
            List<string> ingredientsSalamis = new() { "mozarella", "oignon", "poivron", "tomate", "basilic", "salami", "olive" };
            List<string> ingredientsVegetarienne = new() { "mozarella", "oignon", "poivron", "sauce tomate", "basilic" };
            List<string> ingredientsPoulet = new() { "mozarella", "oignon", "poivron", "tomate", "poulet" };
            List<string> ingredientsCalzone = new() { "mozarella", "oignon", "oeuf", "tomate", "jambon" };

            Pizza quatresFromages = new("4 fromages", 11.5f, true, ingredientsQuatresFromages);
            Pizza salamis = new("Salamis", 13.5f, false, ingredientsSalamis);
            Pizza vegetarienne = new("vegetarienne", 8.5f, true, ingredientsVegetarienne);
            Pizza poulet = new("canibale", 10f, false, ingredientsPoulet);
            Pizza calzone = new("calzone", 11.5f, false, ingredientsCalzone);

            List<Pizza> pizzas = new() { quatresFromages, salamis, vegetarienne, poulet, calzone, new PizzaPersonalisee(), new PizzaPersonalisee()
            };

            // TRIER PAR PRIX CROISSANT ET DECROISSANT
            // pizzas = pizzas.OrderBy(p => p.prix).ToList();
            // pizzas = pizzas.OrderByDescending(p => p.prix).ToList();


            foreach (Pizza pizza in pizzas)
            {
                pizza.Afficher();
            }

            /*
           Pizza pizzaPrixMin = pizzas[0];
           Pizza pizzaPrixMax = pizzas[0];

           foreach (var pizza in pizzas)
           {
               if (pizza.prix < pizzaPrixMin.prix)
               {
                   pizzaPrixMin = pizza;
               }

               if (pizza.prix > pizzaPrixMax.prix)
               {
                   pizzaPrixMax = pizza;
               }
           }

           Console.WriteLine();
           Console.WriteLine("La pizza la moins chere est : ");
           pizzaPrixMin.Afficher();
           Console.WriteLine();
           Console.WriteLine("La pizza la plus chere est : ");
           pizzaPrixMax.Afficher();

           Console.WriteLine("Les pizzas vegetariennes: ");
           foreach (var pizza in pizzas.Where(p => p.vegetarienne).ToList())
           {
               pizza.Afficher();
           }

           Console.WriteLine("Les pizzas qui contiennent de la tomate sont: ");
           foreach (var pizza in pizzas.Where(p => p.ContientIngredient("tomate")).ToList())
           {
               pizza.Afficher();
           }
           */



        }
    }
}