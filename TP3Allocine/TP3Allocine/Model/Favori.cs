using System.ComponentModel.DataAnnotations.Schema;
using TP3Allocine.Model;

namespace ApplicationWebASPNET.Models.EntityFramework
{
    public class Favori
    {

        public int CompteId { get; set; }

        public int FilmId { get; set; }

        public virtual Film FilmFavori { get; set; }

        public virtual Compte CompteFavori { get; set; }
    }
}