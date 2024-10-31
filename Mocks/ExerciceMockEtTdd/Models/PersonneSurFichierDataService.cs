using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExerciceMockEtTdd.Models
{
    public class PersonneSurFichierDataService : IDataService<Personne>
    {
        private static readonly string FICHIER_SAUVEGARDE = "personnes.txt";

        private long _prochainId = 1;

        public PersonneSurFichierDataService()
        {
            if (!File.Exists(FICHIER_SAUVEGARDE))
            {
                using var stream = File.Create(FICHIER_SAUVEGARDE);
            }

            var personnes = this.GetAll();
            if (personnes.Count() > 0)
            {
                _prochainId = personnes.Last().Id + 1;
            }
        }

        public Personne? Get(long id)
        {
            foreach (var p in GetAll())
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;
        }

        public IEnumerable<Personne> GetAll()
        {
            List<Personne> personnes = new();

            string[] lignes = File.ReadAllLines(FICHIER_SAUVEGARDE);
            foreach (string l in lignes)
            {
                string[] split = l.Split(';');
                personnes.Add(new Personne((long)Convert.ToDouble(split[0]), split[1], split[2], split[3]));
            }

            return personnes;
        }

        public bool Insert(Personne record)
        {
            record.Id = _prochainId;
            _prochainId += 1;

            var personnes = (List<Personne>)GetAll();
            personnes.Add(record);

            this.EcrireListeSurFichier(personnes);

            return true;
        }

        public bool Update(Personne record)
        {
            var personnes = (List<Personne>)GetAll();
            for (int i = 0; i < personnes.Count; i++)
            {
                if (personnes[i].Id == record.Id)
                {
                    personnes.RemoveAt(i);
                    personnes.Insert(i, record);
                    this.EcrireListeSurFichier(personnes);
                    return true;
                }
            }

            return false;
        }

        public bool Delete(Personne record)
        {
            var personnes = (List<Personne>)GetAll();
            for (int i = 0; i < personnes.Count; i++)
            {
                if (personnes[i].Id == record.Id)
                {
                    personnes.RemoveAt(i);
                    this.EcrireListeSurFichier(personnes);
                    return true;
                }
            }

            return false;
        }

        private void EcrireListeSurFichier(List<Personne> personnes)
        {
            using var stream = new StreamWriter(File.Open(FICHIER_SAUVEGARDE, FileMode.Create));
            foreach (Personne p in personnes)
            {
                stream.Write($"{p.Id};{p.Nom};{p.Prenom};{p.Telephone}\n");
            }
        }
    }
}
