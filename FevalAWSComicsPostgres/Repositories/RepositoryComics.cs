using FevalAWSComicsRDS.Data;
using FevalAWSComicsRDS.Models;
using Microsoft.EntityFrameworkCore;

namespace FevalAWSComicsRDS.Repositories
{
    public class RepositoryComics
    {
        //LA CLASE REPOSITORY UTILIZA UN CONTEXT, POR LO QUE 
        //DEBEMOS RECIBIR DICHO CONTEXT DENTRO DEL CONSTRUCTOR
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        //METODO PARA RECUPERAR DATOS (TODOS LOS COMICS)
        public async Task<List<Comic>> GetComicsAsync()
        {
            //DEVOLVEMOS TODOS LOS COMICS DEL CONTEXTO
            return await this.context.Comics.ToListAsync();
        }

        //METODO PARA BUSCAR UN COMIC POR SU ID
        public async Task<Comic> FindComicAsync(int id)
        {
            return await
                this.context.Comics.FirstOrDefaultAsync(x => x.IdComic == id);
        }

        //TAMBIEN VAMOS A INSERTAR.  PARA NO PENSAR, VAMOS A REALIZAR 
        //UN METODO QUE NOS DEVOLVERA EL MAXIMO ID DE LOS COMICS
        private async Task<int> GetMaxIdComic() 
        {
            return await
                this.context.Comics.MaxAsync(z => z.IdComic) + 1;
        }

        //METODO PARA INSERTAR UN NUEVO COMIC
        public async Task CreateComicAsync
            (string nombre, string imagen, string descripcion)
        {
            Comic comic = new Comic();
            comic.IdComic = await this.GetMaxIdComic();
            comic.Titulo = nombre;
            comic.Imagen = imagen;
            comic.Descripcion = descripcion;
            //ALMACENAMOS EL COMIC JUNTO AL RESTO DENTRO DEL CONTEXT
            this.context.Comics.Add(comic);
            //GUARDAMOS LOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }

        //METODO PARA MODIFICAR UN COMIC EXISTENTE
        public async Task UpdateComicAsync
            (int idcomic, string nombre, string imagen, string descripcion)
        {
            //BUSCAMOS EL COMIC EN LA BASE DE DATOS
            Comic comic = await
                this.FindComicAsync(idcomic);
            //MODIFICAMOS LAS PROPIEDADES QUE DESEEMOS
            comic.Titulo = nombre;
            comic.Imagen = imagen;
            comic.Descripcion = descripcion;
            //GUARDAMOS LOS DATOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }

        //METODO PARA ELIMINAR UN COMIC MEDIANTE SU ID
        public async Task DeleteComic(int id)
        {
            //BUSCAMOS EL COMIC A ELIMINAR
            Comic comic = await this.FindComicAsync(id);
            //ELIMINAMOS EL COMIC DEL CONJUNTO DEL CONTEXT
            this.context.Comics.Remove(comic);
            //GUARDAMOS LOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }
    }
}
