using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TP3Allocine2.Model { 

    public class Compte
    {
        public int CompteId { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string TelPortable { get; set; }

        public string Mel { get; set; }

        public string Pwd { get; set; }

        public string Rue { get; set; }

        public string CodePostal { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public DateTime DateCreation { get; set; }

        public Compte()
        {

        }

        public Compte(int compteId, string nom, string prenom, string telPortable, string mel, string pwd, string rue, string codePostal, string ville, string pays, float? latitude, float? longitude, DateTime dateCreation)
        {
            CompteId = compteId;
            Nom = nom;
            Prenom = prenom;
            TelPortable = telPortable;
            Mel = mel;
            Pwd = pwd;
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            Latitude = latitude;
            Longitude = longitude;
            DateCreation = dateCreation;
        }
    }
}