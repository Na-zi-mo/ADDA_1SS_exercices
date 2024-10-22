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
    public class PersonneSqliteDataService : IDataService<Personne>
    {
        private static string _chaineDeConnexion = "Data Source=sqlite.bd;Cache=Shared";

        public PersonneSqliteDataService()
        {
            if (!File.Exists("sqlite.bd"))
            {
                using SqliteConnection connexion = OuvrirConnexion();
                string contenuFichier = ExerciceInjection.Properties.AutresRessources.sqlite_script;
                using SqliteCommand commande = new SqliteCommand(contenuFichier, connexion);
                commande.ExecuteNonQuery();
            }
        }

        public IEnumerable<Personne> GetAll()
        {
            List<Personne> personnes = new List<Personne>();

            using SqliteConnection connexion = OuvrirConnexion();

            using SqliteCommand commande = new SqliteCommand("SELECT * FROM personne", connexion);

            using SqliteDataReader lecteur = commande.ExecuteReader();
            while (lecteur.Read())
            {
                personnes.Add(new Personne(
                    lecteur.GetInt32(lecteur.GetOrdinal("id")),
                    lecteur.GetString(lecteur.GetOrdinal("nom")),
                    lecteur.GetString(lecteur.GetOrdinal("prenom")),
                    lecteur.GetString(lecteur.GetOrdinal("telephone"))
                    ));
            }

            return personnes;
        }

        public Personne? Get(long id)
        {
            Personne personne = null;

            using SqliteConnection connexion = OuvrirConnexion();

            using SqliteCommand commande = new SqliteCommand("SELECT * FROM personne WHERE id = @id", connexion);

            commande.Parameters.AddWithValue("@id", id);
            commande.Prepare();

            using SqliteDataReader lecteur = commande.ExecuteReader();
            if (lecteur.Read())
            {
                personne = new Personne(
                    lecteur.GetInt32(lecteur.GetOrdinal("id")),
                    lecteur.GetString(lecteur.GetOrdinal("nom")),
                    lecteur.GetString(lecteur.GetOrdinal("prenom")),
                    lecteur.GetString(lecteur.GetOrdinal("telephone"))
                    );
            }

            return personne;
        }

        public bool Insert(Personne record)
        {
            using SqliteConnection connexion = OuvrirConnexion();

            using SqliteCommand commande = new SqliteCommand("INSERT INTO personne (nom,prenom,telephone) VALUES (@nom, @prenom, @telephone)", connexion);
            commande.Parameters.AddWithValue("@nom", record.Nom);
            commande.Parameters.AddWithValue("@prenom", record.Prenom);
            commande.Parameters.AddWithValue("@telephone", record.Telephone);
            commande.Prepare();

            int nbLignesAffectees = commande.ExecuteNonQuery();
            if (nbLignesAffectees != 1) return false;

            record.Id = LastInsertId(connexion);

            return true;
        }

        public bool Update(Personne record)
        {
            using SqliteConnection connexion = OuvrirConnexion();

            using SqliteCommand commande = new SqliteCommand("UPDATE personne SET nom = @nom, prenom = @prenom, telephone = @telephone WHERE id = @id", connexion);
            commande.Parameters.AddWithValue("@nom", record.Nom);
            commande.Parameters.AddWithValue("@prenom", record.Prenom);
            commande.Parameters.AddWithValue("@telephone", record.Telephone);
            commande.Parameters.AddWithValue("@id", record.Id);
            commande.Prepare();

            int nbLignesAffectees = commande.ExecuteNonQuery();
            if (nbLignesAffectees != 1) return false;

            return true;
        }

        public bool Delete(Personne record)
        {
            using SqliteConnection connexion = OuvrirConnexion();

            using SqliteCommand commande = new SqliteCommand("DELETE FROM personne WHERE id = @id", connexion);
            commande.Parameters.AddWithValue("@id", record.Id);
            commande.Prepare();

            int nbLignesAffectees = commande.ExecuteNonQuery();

            return nbLignesAffectees == 1;
        }

        private SqliteConnection OuvrirConnexion()
        {
            SqliteConnection connexion = new SqliteConnection(_chaineDeConnexion);
            connexion.Open();
            return connexion;
        }

        private long LastInsertId(SqliteConnection connexion)
        {
            using SqliteCommand commande = new SqliteCommand("SELECT last_insert_rowid()", connexion);
            return (long)(commande.ExecuteScalar() ?? 0);
        }
    }
}
