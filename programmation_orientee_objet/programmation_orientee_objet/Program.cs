using System;
using System.Collections.Generic;

namespace programmation_orientee_objet
{

    class Enfant : Etudiant
    {
        string classeEcole;
        Dictionary<string, float> notes;

        public Enfant(string nom, int age, string classeEcole, Dictionary<string, float> notes) : base(nom, age, null)
        {
            this.classeEcole = classeEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine("Enfant en classe de " + classeEcole);
            if ((notes != null) && (notes.Count > 0))
            {
                Console.WriteLine("Notes moyennes ");
                foreach (var note in notes)
                {
                    Console.WriteLine("    " + note.Key + " : " + note.Value + "/10");
                }
            }
            AfficherProfesseurPrincipal();
        }

        public void Afficherotes()
        {

        }
    }

    class Etudiant : Personne
    {
        string infoEtudes = "Ecole de commerce.";
        public Personne professeurPrincipal;

        public Etudiant(string nom, int age, string infosEtudes) : base(nom, age, "Etudiant")
        {
            this.infoEtudes = infosEtudes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine("Etudiant en: " + infoEtudes);

            AfficherProfesseurPrincipal();

            Console.WriteLine();
        }

        protected void AfficherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine("Professeur principal: ");
                professeurPrincipal.Afficher();
            }
        }

    }

    class Personne
    {
        static int nombreDePersonnes = 0;


        protected string nom;
        protected int age;
        protected string emploi;

        protected int numeroDePersonne;

        public Personne(string nom, int age, string emploi = null)
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;

            nombreDePersonnes++;

            numeroDePersonne = nombreDePersonnes;
        }

        public virtual void Afficher()
        {
            AfficherNomEtAge();
            if (emploi == null)
            {
                Console.WriteLine("Aucun emploi spécifiée");
            }
            else
            {
                Console.WriteLine("Emploi: " + emploi);
            }
            Console.WriteLine();
        }

        public static void AfficherNombreDePersonnes()
        {
            Console.WriteLine("Nombre total de personnes: " + nombreDePersonnes);
        }

        protected void AfficherNomEtAge()
        {
            Console.WriteLine("Personne n°" + numeroDePersonne);
            Console.WriteLine("Nom: " + nom);
            Console.WriteLine("Age: " + age);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Personne personne1 = new Personne("Paul", 45, "Developpeur");
            Personne personne2 = new Personne("Marie", 36, "Professeur");
            Personne personne3 = new Personne("Thomas", 24);
            Personne personne4 = new Personne("Jeanne", 8, "CP");

            List<Personne> personnes = new List<Personne> { personne1, personne2, personne3, personne4 };

            foreach (Personne personne in personnes)
            {
                personne.Afficher();
            }

            Personne.AfficherNombreDePersonnes();*/

            Personne professeur = new Personne("Jean", 59, "Professeur");

            Etudiant etudiant = new Etudiant("Paul", 20, "Ecole de commerce") { professeurPrincipal = professeur };
            etudiant.Afficher();

            Dictionary<string, float> notesEnfant1 = new Dictionary<string, float> { { "Math", 8 }, { "Geo", 8.5f } };
            Enfant enfant1 = new Enfant("Sophie", 7, "CP", notesEnfant1)
            { professeurPrincipal = professeur };
            enfant1.Afficher();

        }
    }
}