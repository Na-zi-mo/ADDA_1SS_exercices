using ExerciceInjection.ViewModels.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceInjection.Models
{
    public class PersonneSurFichierDataService : IDataService<Personne>
    {
        private List<Personne> _personnes = new List<Personne>
    {
        new Personne(1, "Carnaval", "Bonhomme", "418-123-4567"),
        new Personne(2, "Gratton", "Bob", "450-659-8854"),
        new Personne(3, "Troudeau", "Justun", "514-465-4785"),
        new Personne(3, "Doué", "Jél", "819-567-0191")
    };

        public PersonneSurFichierDataService()
        {
            if (!File.Exists("personnes.json"))
            {
                
            }
        }

        private long _prochainId = 4;

        public IEnumerable<Personne> GetAll()
        {
            return _personnes;
        }

        public Personne? Get(long id)
        {
            return _personnes.Find(p => p.Id == id);
        }

        public bool Insert(Personne record)
        {
            record.Id = _prochainId;
            _prochainId++;
            _personnes.Add(record);
            return true;
        }

        public bool Update(Personne record)
        {
            Personne? ancien = this.Get(record.Id);
            if (ancien == null) return false;

            this.Delete(ancien);
            _personnes.Add(record);
            return true;
        }

        public bool Delete(Personne record)
        {
            foreach (Personne personne in _personnes)
            {
                if (personne.Id == record.Id)
                {
                    _personnes.Remove(personne);
                    return true;
                }
            }
            return false;
        }
    }

}
