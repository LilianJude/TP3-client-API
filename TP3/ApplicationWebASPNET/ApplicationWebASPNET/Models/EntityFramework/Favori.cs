using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApplicationWebASPNET.Models.EntityFramework
{
    [Table("T_J_FAVORI_FAV")]
    public class Favori
    {
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [ForeignKey("FilmId")]
        [InverseProperty("Favoris")]
        [JsonIgnore]
        public virtual Film FilmFavori { get; set; }

        [ForeignKey("CompteId")]
        [InverseProperty("Favoris")]
        [JsonIgnore]
        public virtual Compte CompteFavori { get; set; }
    }
}