using ExerciceInjection.ViewModels.Interfaces;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExerciceInjection.Models
{
    public class PersonneSurFichierDataService : IDataService<Personne>
    {
        private List<Personne> _seed = new List<Personne>
        {
            new Personne(1, "Carnaval", "Bonhomme", "418-123-4567"),
            new Personne(2, "Gratton", "Bob", "450-659-8854"),
            new Personne(3, "Troudeau", "Justun", "514-465-4785"),
            new Personne(4, "Doué", "Jél", "819-567-0191")
        };

        private string _path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "personnes.json");


        private List<Personne> _personnes;
        public PersonneSurFichierDataService()
        {
            if (!File.Exists(_path))
            {
                string jsonString = JsonConvert.SerializeObject(_seed, Formatting.Indented);

                File.WriteAllText(_path, jsonString);
            }
            else
            {
                string json = File.ReadAllText(_path);

                _personnes = JsonConvert.DeserializeObject<List<Personne>>(json) ?? new List<Personne>();

                if (_personnes.Count == 0)
                {
                    string jsonString = JsonConvert.SerializeObject(_seed, Formatting.Indented);

                    File.WriteAllText(_path, jsonString);
                }

            }
            _prochainId = _personnes.Count + 1;
        }

        private long _prochainId;

        public IEnumerable<Personne> GetAll()
        {
            return _personnes;
        }

        public Personne? Get(long id)
        {
            return _personnes.Find(p => p.Id == id);
        }


        private long NextId() {
            long nextId = _prochainId;
            while (_personnes.Find(p => p.Id == nextId) != null )
            {
                nextId++;
            }
            _prochainId = nextId + 1;
            return nextId;
        }

        private void SaveChanges(List<Personne> newPersonnes)
        {
            string jsonString = JsonConvert.SerializeObject(newPersonnes, Formatting.Indented);

            File.WriteAllText(_path, jsonString);
        }

        public bool Insert(Personne record)
        {
            record.Id = NextId();
            _personnes.Add(record);

            SaveChanges(_personnes);
            return true;
        }

        public bool Update(Personne record)
        {
            Personne? ancien = this.Get(record.Id);
            if (ancien == null) return false;

            this.Delete(ancien);
            _personnes.Add(record);
            SaveChanges(_personnes);
            return true;
        }

        public bool Delete(Personne record)
        {
            foreach (Personne personne in _personnes)
            {
                if (personne.Id == record.Id)
                {
                    _personnes.Remove(personne);
                    SaveChanges(_personnes);
                    return true;
                }
            }
            return false;
        }
    }

}
