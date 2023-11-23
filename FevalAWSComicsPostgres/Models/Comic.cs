using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FevalAWSComicsRDS.Models
{
    [Table("COMICS")]
    public class Comic
    {
        [Key]
        [Column("IDCOMIC")]
        public int IdComic { get; set; }
        [Column("NOMBRE")]
        public string Titulo { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

    }
}
