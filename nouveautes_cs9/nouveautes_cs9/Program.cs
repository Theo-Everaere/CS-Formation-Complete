using System;

namespace nouveautes_cs9
{
    class Personne
    {
        public string nom { get; set; }
        public int age { get; set; }

        public Personne(string nom, int age)
        {
            this.nom = nom;
            this.age = age;
        }

        public void Afficher()
        {
            Console.WriteLine($"Le nom est {nom} et l'age est {age} ans.");

        }

        public override bool Equals(object? obj)
        {
            return obj is Personne personne &&
                   nom == personne.nom &&
                   age == personne.age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Personne personne1 = new Personne("Paul", 26);
            Personne personne2 = new Personne("Marie", 19);

            personne1.nom = "Jean";
            personne1.Afficher();

            personne1 = personne2;
            //personne2.nom = "Ralala";

            personne1.Afficher();
            personne2.Afficher();
        }
    }
}