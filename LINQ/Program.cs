namespace LINQ
{
    internal class Program
    {
        static void Exemples()
        {
            List<int> entiers = new List<int>() { 204, 199, -1, 45, 46, 99, 24, 40, 204, -101, 27, 12 };
            Console.WriteLine($"Liste de départ: {String.Join(", ", entiers)}");

            List<int> sousEnsemble = entiers.Where(entier => entier < 0).ToList();
            Console.WriteLine($"Sous-ensemble des entiers négatifs : {String.Join(", ", sousEnsemble)}");

            int premierEntier45 = entiers.FirstOrDefault(entier => entier == 45);
            Console.WriteLine($"Premier entier 45 : {premierEntier45}");

            int entierNonExistent = entiers.FirstOrDefault(entier => entier == 999);
            Console.WriteLine($"Entier 999 non existent avec FirstOrDefault : {entierNonExistent}");

            // Il existe aussi First() qui lève une exception si l'élément n'est pas trouvé.
            try
            {
                entierNonExistent = entiers.First(entier => entier == 999);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Entier 999 non existent avec First (exception) : {ex.Message}");
            }

            // On peut trier une liste avec OrderBy().
            // Ici, on trie la liste par ordre croissant.
            List<int> listeTrie = entiers.OrderBy(entier => entier).ToList();
            Console.WriteLine($"Liste triée par ordre croissant : {String.Join(", ", listeTrie)}");

            // On peut aussi trier par ordre décroissant avec OrderByDescending().
            listeTrie = entiers.OrderByDescending(entier => entier).ToList();
            Console.WriteLine($"Liste triée par ordre décroissant : {String.Join(", ", listeTrie)}");

            // On peut rapidement faire la moyenne avec Linq.
            double moyenne = entiers.Average();
            Console.WriteLine($"La moyenne des entiers est de {moyenne}");

            // On peut aussi faire la somme.
            int somme = entiers.Sum();
            Console.WriteLine($"La somme des entiers est de {somme}");

            // On peut aussi faire des opérations sur les éléments de la liste avec Select.
            // Ici, on divise chaque élément par 2.
            List<int> diviserPar2 = entiers.Select(entier => entier / 2).ToList();
            Console.WriteLine($"Division par 2 : {String.Join(", ", diviserPar2)}");

            // On peut obtenir qu'un certain nombre d'élément avec Take
            List<int> limite = entiers.Take(2).ToList();
            Console.WriteLine($"Limite de 2 (Take) : {String.Join(", ", limite)}");


            // On peut combiner plusieurs opérations avec Linq.
            // Par exemple, on peut faire la moyenne des entiers positifs
            double moyennePositifs = entiers.Where(entier => entier > 0).Average();
            Console.WriteLine($"La moyenne des entiers positifs est de {moyennePositifs}");
        }

        static void Main(string[] args)
        {
            //Exemples();

            Exercice();
        }

        static void Exercice() {

            // Liste de personnes
             List<Personne> personnes = new List<Personne>()
            {
                new Personne("Jean", "Dupont", 20, "Shawinigan"),
                new Personne("Jean", "Arrache", 99, "St-Lin"),
                new Personne("Sophie", "Beaudoin", 20, "Montréal"),
                new Personne("Mohammed", "Salah", 24, "Montréal"),
                new Personne("Marc", "Gagné", 45, "Shawinigan"),
                new Personne("Calos", "Santana", 77, "Québec")
            };

            // Faites la sélection des Montréalais
            // TODO
            List<Personne> montrealais = personnes.Where(personne => personne.Ville == "Montréal").ToList();

            //Output : Les Montréalais : Sophie Beaudoin - 20 - Montréal ### Mohammed Salah - 24 - Montréal
            Console.WriteLine($"Les Montréalais : {String.Join(" ### ", montrealais)}");

            // Faites la sélection de Marc
            // TODO

            Personne marc = personnes.FirstOrDefault(personne => personne.Prenom == "Marc");

            //Output : Marc Gagné - 45 - Shawinigan
            Console.WriteLine(marc);

            // Trier la liste du plus jeune au plus vieux
            // TODO 

            List<Personne> personnesTriees = personnes.OrderBy(personne => personne.Age).ToList();

            //Output : Les personnes triées par ordre croissant : Jean Dupont - 20 - Shawinigan ### Sophie Beaudoin - 20 - Montréal ### Mohammed Salah - 24 - Montréal ### Marc Gagné - 45 - Shawinigan ### Carlos Santana - 77 - Québec ### Jean Arrache - 99 - St-Lin
            Console.WriteLine($"Les personnes triées par ordre croissant : {String.Join(" ### ", personnesTriees)}");

            // Faites la moyenne d'âge des personne plus âgées que 23 ans
            // TODO

            double moyenneAge = personnes.Where(personne => personne.Age > 23).Average(personne => personne.Age);

            //Output : La moyenne d'âge des personnes plus âgées que 23 ans est de 61.25
            Console.WriteLine($"La moyenne d'âge des personnes plus âgées que 23 ans est de {moyenneAge}");

            // Modifier l'âge des personnes ayant moins de 25 ans à 18 ans, mais vous ne devez pas modifier la liste originale
            // TODO

            //List<Personne> personnesModifiees = personnes.Where(personne => personne.Age < 25).ToList();
            //personnesModifiees.ForEach(personne => personne.Age = 18);

            List<Personne> personnesModifiees = personnes.Where(personne => personne.Age < 25).Select(personne => 
            new Personne(
                personne.Prenom,
                personne.Nom,
                18,
                personne.Ville
            )
            ).ToList();


            //Output : Les personnes modifiées : Jean Dupont - 18 - Shawinigan ### Sophie Beaudoin - 18 - Montréal ### Mohammed Salah - 18 - Montréal
            Console.WriteLine($"Les personnes modifiées : {String.Join(" ### ", personnesModifiees)}");
            Console.WriteLine($"La liste originale : {String.Join(" ### ", personnes)}");

            // Modifier l'âge des personnes ayant moins de 25 ans à 18 ans et vous DEVEZ modifier les personnes de la liste d'origine
            // TODO

            List<Personne> personnesModifieesOrigine = personnes.Where(personne => personne.Age < 25).Select((personne) => { personne.Age = 18; return personne; }).ToList();

            //Output: Les personnes modifiées: Jean Dupont -18 - Shawinigan ### Sophie Beaudoin - 18 - Montréal ### Mohammed Salah - 18 - Montréal
            Console.WriteLine($"Les personnes modifiées : {String.Join(" ### ", personnesModifieesOrigine)}");
            Console.WriteLine($"La liste originale : {String.Join(" ### ", personnes)}");
        }
    }
}
