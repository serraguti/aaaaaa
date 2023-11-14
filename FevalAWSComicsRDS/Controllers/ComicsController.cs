﻿using FevalAWSComicsRDS.Models;
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
    }
}