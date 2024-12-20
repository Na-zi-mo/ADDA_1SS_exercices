﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JardinageWpf.Models
{
    public class Plante
    {
        private string _nomCommun;
        private string _nomScientifique;
        private double _hauteur;
        private Famille _famille;

        [Key]
        public int Id { get; set; }

        [Required]
        public string NomCommun
        {
            get { return _nomCommun; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Nom commun de la plante non valide.");
                _nomCommun = value;
            }
        }

        [Required]
        public string NomScientifique
        {
            get { return _nomScientifique; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Nom scientifique de la plante non valide.");
                _nomScientifique = value;
            }
        }

        [Required]
        public double Hauteur
        {
            get { return _hauteur; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La hauteur de la plante doit être supérieure à 0.");
                _hauteur = value;
            }
        }

        [Required]
        public int FamilleId { get; set; }

        [ForeignKey("FamilleId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Famille Famille
        {
            get { return _famille; }
            set
            {
                if (value == null)
                    throw new ArgumentException("La famille est obligatoire.");
                _famille = value;
            }
        }

        public ICollection<Region> Regions { get; set; } = new List<Region>();

        public override string ToString()
        {
            return NomCommun;
        }
    }
}