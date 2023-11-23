using FevalAWSComicsRDS.Models;
using FevalAWSComicsRDS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FevalAWSComicsRDS.Controllers
{
    public class ComicsController : Controller
    {
        //ESTE CONTROLADOR VA A RECIBIR LAS ACCIONES 
        //A REALIZAR SOBRE LA BASE DE DATOS EN LAS VISTAS.
        //DEBE TENER EL REPOSITORIO PARA PODER EJECUTAR LAS CONSULTAS
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
        }

        //VAMOS A MOSTRAR TODOS LOS COMICS
        public async Task<IActionResult> Index()
        {
            //TRAEMOS LOS COMICS DEL REPOSITORIO
            List<Comic> comics = await this.repo.GetComicsAsync();
            return View(comics);
        }

        //TENDREMOS OTRA VISTA PARA MOSTRAR LOS DETALLES DE UN COMIC
        //NECESITAMOS EL ID DEL COMIC, LO BUSCAMOS Y LO DEVOLVEMOS
        public async Task<IActionResult> Detalles(int id)
        {
            Comic comic = await this.repo.FindComicAsync(id);
            return View(comic);
        }

        //VAMOS A CREAR UNA VISTA CON UN FORMULARIO Y CAJAS DE 
        //TEXTO PARA PODER INSERTAR UN NUEVO COMIC
        public IActionResult Create()
        {
            return View();
        }

        //CUANDO HACEMOS CLICK SOBRE EL FORMULARIO, ENTRA EN 
        //ESTE METODO
        //RECIBIREMOS LOS DATOS DEL PROPIO COMIC
        [HttpPost]
        public async Task<IActionResult> Create(Comic comic)
        {
            await this.repo.CreateComicAsync(comic.Titulo,
                comic.Imagen, comic.Descripcion);
            //PONEMOS UN MENSAJE PARA SABER QUE HA REALIZADO TODO CORRECTO
            ViewData["MENSAJE"] = "Comic insertado correctamente";
            return View();
        }

        //TENDREMOS UN METODO PARA MODIFICAR COMIC
        //DICHO METODO DEBE RECIBIR EL ID DEL COMIC PARA 
        //PODER DIBUJARLO EN LAS CAJAS
        public async Task<IActionResult> Update(int id)
        {
            Comic comic = await this.repo.FindComicAsync(id);
            return View(comic);
        }

        //TENDREMOS UN METODO PARA CUANDO PULSE EL BOTON DEL FORMULARIO
        [HttpPost]
        public async Task<IActionResult> Update(Comic comic)
        {
            await this.repo.UpdateComicAsync(comic.IdComic,
                comic.Titulo, comic.Imagen, comic.Descripcion);
            //UNA VEZ MODIFICADO, LO ENVIAMOS A LA PAGINA PRINCIPAL
            return RedirectToAction("Index");
        }

        //METODO PARA ELIMINAR QUE RECIBIRA EL ID DE UN COMIC
        //Y DEVOLVEREMOS LA VISTA A LA PAGINA PRINCIPAL DONDE 
        //ESTAN TODOS LOS COMICS
        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteComic(id);
            return RedirectToAction("Index");
        }
    }
}
