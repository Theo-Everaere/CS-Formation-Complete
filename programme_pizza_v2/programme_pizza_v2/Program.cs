﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;

namespace programme_pizza_v2
{
    // PizzaPersonnalisee
    // - Classe : hériter de Pizza
    // constructeur ()
    //  nom = "Personnalisée"
    //  prix = 5
    //  vegetarienne = false
    // ingredients = demander à l'utilisateur
    //   Rentrez un ingrédient pour la pizza personnalisée (ENTER pour terminer) : 

    class PizzaPersonnalisee : Pizza
    {
        static int nbPizzasPersonnalisee = 0;

        public PizzaPersonnalisee() : base("Personnalisée", 5, false, null)
        {

            // index
            // nom = ...
            nbPizzasPersonnalisee++;
            nom = "Personnalisée " + nbPizzasPersonnalisee;


            ingredients = new List<string>();

            while (true)
            {
                Console.Write("Rentrez un ingrédient pour la pizza personnalisée " + nbPizzasPersonnalisee + " (ENTER pour terminer) : ");
                var ingredient = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    break;
                }
                if (ingredients.Contains(ingredient))
                {
                    Console.WriteLine("ERREUR : Cet ingrédient est déjà présent dans la pizza.");
                }
                else
                {
                    ingredients.Add(ingredient);
                    Console.WriteLine(string.Join(", ", ingredients));
                }

                Console.WriteLine();
            }


            prix = 5 + ingredients.Count * 1.5f;


        }
    }

    class Pizza
    {
        public string nom { get; protected set; }
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
            //4 fromages (V) - 11.5€
            /*string badgeVegetarienne = " (V)";
            if (!vegetarienne)
            {
                badgeVegetarienne = "";
            }*/

            string badgeVegetarienne = vegetarienne ? " (V)" : "";

            string nomAfficher = FormatPremiereLettreMajuscules(nom);

            /*var ingredientsAfficher = new List<string>();
            foreach(var ingredient in ingredients)
            {
                ingredientsAfficher.Add(FormatPremiereLettreMajuscules(ingredient));
            }*/

            var ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();

            Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
            Console.WriteLine(string.Join(", ", ingredientsAfficher));
            Console.WriteLine();

        }

        private static string FormatPremiereLettreMajuscules(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string minuscules = s.ToLower();
            string majuscules = s.ToUpper();

            string resultat = majuscules[0] + minuscules[1..];

            return resultat;
        }

        public bool ContientIngredient(string ingredient)
        {
            return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count > 0;
        }
    }

    class Program
    {

        static List<Pizza> GetPizzasFromCode()
        {
            var pizzas = new List<Pizza>() {
                new Pizza("4 fromages", 11.5f, true, new List<string> { "cantal", "mozzarella", "fromage de chèvre", "gruyère" }),
                new Pizza("indienne", 10.5f, false, new List<string> { "curry", "mozzarella", "poulet", "poivron", "oignon", "coriandre" }),
                new Pizza("MEXICAINE", 13f, false, new List<string> {"boeuf", "mozzarella", "maïs", "tomates", "oignon", "coriandre"}),
                new Pizza("margherita", 8f, true, new List<string> { "sauce tomate", "mozzarella", "basilic" }),
                new Pizza("Calzone", 12f, false, new List<string> { "tomate", "jambon", "persil", "oignons"}),
                new Pizza("complète", 9.5f, false, new List<string> { "jambon", "oeuf", "fromage" }),
                //new PizzaPersonnalisee(),
                //new PizzaPersonnalisee()
            };
            return pizzas;
        }

        static List<Pizza> GetPizzasFromFile(string filename)
        {
            string json = null;

            try
            {
                json = File.ReadAllText(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Le fichier " + filename + " n'a pas été trouvé.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de lecture du fichier " + filename + ": " + ex.Message);
                return null;
            }

            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
                return null;
            }

            return pizzas;
        }

        static void GenerateJsonFile(string filename, List<Pizza> pizzas)
        {
            string json = JsonConvert.SerializeObject(pizzas);
            //Console.WriteLine(json);
            File.WriteAllText(filename, json);
        }

        static List<Pizza> GetPizzasFromUrl(string url)
        {
            var client = new WebClient();
            string json = null;

            try
            {
                json = client.DownloadString(url);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur réseau : {ex.Message}");
                return null;
            }


            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
                return null;
            }

            return pizzas;

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // string filename = "pizzas.json";

            //var pizzas = GetPizzasFromCode();
            //GenerateJsonFile(filename, pizzas);

            // var pizzas = GetPizzasFromFile(filename);

            string url = "https://codeavecjonathan.com/res/pizzas2.json";
            var pizzas = GetPizzasFromUrl(url);

            if (pizzas != null)
            {
                foreach (var pizza in pizzas)
                {
                    pizza.Afficher();
                }
            }
        }
    }
}
