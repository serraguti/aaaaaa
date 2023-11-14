using FevalAWSComicsRDS.Models;
using Microsoft.EntityFrameworkCore;

namespace FevalAWSComicsRDS.Data
{
    public class ComicsContext: DbContext
    {
        //ESTAMOS RECIBIENDO UNA CADENA DE CONEXION
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options) { }

        //TENDREMOS UN CONJUNTO DE COMICS PARA COMUNICARNOS CON LA BASE DE DATOS
        public DbSet<Comic> Comics { get; set; }
    }
}
