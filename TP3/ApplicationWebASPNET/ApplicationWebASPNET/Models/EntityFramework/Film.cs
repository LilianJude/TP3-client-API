using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationWebASPNET.Models.EntityFramework
{
    [Table("T_E_FILM_FLM")]
    public partial class Film
    {
        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Required]
        [Column("FLM_TITRE")]
        [StringLength(100)]
        public string Titre { get; set; }

        [Column("FLM_SYNOPSIS")]
        [StringLength(500)]
        public string Synopsis { get; set; }

        [Required]
        [Column("FLM_DATEPARUTION")]
        [StringLength(500)]
        public DateTime DateParution { get; set; }

        [Required]
        [Column("FLM_DUREE")]
        [StringLength(500)]
        public decimal Duree { get; set; }

        [Required]
        [Column("FLM_GENRE")]
        [StringLength(30)]
        public string Genre { get; set; }

        [Column("FLM_URLPHOTO")]
        [StringLength(200)]
        public string UrlPhoto { get; set; }

        [InverseProperty("FilmFavori")]
        public virtual ICollection<Favori> Favoris { get; set; }
    }
}
