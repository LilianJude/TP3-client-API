using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3Allocine.Model
{
    public class Film
    {

        public int FilmId { get; set; }

        public string Titre { get; set; }

        public string Synopsis { get; set; }

        public DateTime DateParution { get; set; }

        public decimal Duree { get; set; }

        public string Genre { get; set; }

        public string UrlPhoto { get; set; }

        public Film()
        {

        }

        public Film(int filmId, string titre, string synopsis, DateTime dateParution, decimal duree, string genre, string urlPhoto)
        {
            FilmId = filmId;
            Titre = titre;
            Synopsis = synopsis;
            DateParution = dateParution;
            Duree = duree;
            Genre = genre;
            UrlPhoto = urlPhoto;
        }
    }
}
