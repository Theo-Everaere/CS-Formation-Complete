using Newtonsoft.Json;
using System;
using System.Text.Json.Nodes;
using System.Collections.Generic;

namespace le_format_json
{
    class Person
    {
        public string name;
        public int age;
        public bool majeure;

        public Person(string name, int age, bool majeure)
        {
            this.name = name;
            this.age = age;
            this.majeure = majeure;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom: {name} - age: {age} ans - Majeure : {majeure}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            //var tom = new Person("Tom", 21, true);
            //var marie = new Person("Marie", 17, false);
            //var sarah = new Person("Sarah", 32, true);
            //var personnes = new List<Person>() { tom, marie, sarah };

            //var json = JsonConvert.SerializeObject(personnes);
            //Console.WriteLine("Serialize " + json);

            //File.WriteAllText("personnes.txt", json);

            var json = File.ReadAllText("personnes.txt");
            var personnes = JsonConvert.DeserializeObject<List<Person>>(json);
            foreach (var personne in personnes)
            {
                personne.Afficher();

            }
        }
    }
}