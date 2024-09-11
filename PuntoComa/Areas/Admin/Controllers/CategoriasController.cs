﻿using Microsoft.AspNetCore.Mvc;
using PuntoComa.AccesoDatos.Data.Repository.IRepository;
using PuntoComa.Data;
using PuntoComa.Models;

namespace PuntoComa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        { 

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en BD
                _contenedorTrabajo.Categoria.Add(categoria);    
                _contenedorTrabajo.save();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //logica para actualizasr en BD
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.save();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }
        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll()});

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });
            }
            _contenedorTrabajo.Categoria.remove(objFromDb);
            _contenedorTrabajo.save();
            return Json(new { success = true, message = "Categoria borrada correctamente" });
        }

        #endregion
    }
}