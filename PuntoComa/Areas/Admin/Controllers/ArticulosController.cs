using Microsoft.AspNetCore.Mvc;
using PuntoComa.AccesoDatos.Data.Repository.IRepository;
using PuntoComa.Models.ViewModels;

namespace PuntoComa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public ArticuloVM GetArtiVM()
        {
            return new ArticuloVM()
            {
                Articulo = new PuntoComa.Models.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };
        }

        [HttpGet]
        public IActionResult Create(ArticuloVM artiVM)
        {
            return View();
        }
        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties:"Categoria") });

        }
        #endregion
    }
}
