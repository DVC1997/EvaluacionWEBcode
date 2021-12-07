using BibliotecaUteq.BAL;
using BibliotecaUteq.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUteq.Controllers
{
    public class LibrosController : Controller
    {
        public ILibrosBo _librosBo;

        public LibrosController(ILibrosBo librosBo)
        {
            _librosBo = librosBo;
        }

        // GET: Libros
        public ActionResult Libros()
        {
            List<LibrosDto> libros = new List<LibrosDto>();
            libros = _librosBo.GetLibros();
            return View(libros);
        }

        [HttpGet]
        public ActionResult CreateLibro()
        {
            LibrosDto libro = new LibrosDto();
            return View(libro);
        }

        [HttpPost]
        public ActionResult AddLibro(LibrosDto libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    libro.Activo = true;
                    _librosBo.AddLibro(libro);
                    ViewBag.alerta = "¡El libro fue guardado satisfactoriamente!";
                    return RedirectToAction("Libros");
                }
            }
            catch (Exception ex)
            {
                ViewBag.alerta = "Ocurrió un error al guardar el libro." + ex.Message;
            }
            return View(libro);
        }

        [HttpGet]
        public ActionResult EditLibro(int id)
        {
            LibrosDto libro = _librosBo.GetLibro(id);
            return View(libro);
        }

        [HttpPost]
        public ActionResult UpdateLibro(LibrosDto libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _librosBo.UpdateLibro(libro);
                    ViewBag.alerta = "¡El libro ha sido actualizado satisfactoriamente!";
                    return RedirectToAction("Libros");
                }
            }
            catch (Exception ex)
            {
                ViewBag.alerta = "Ocurrió un error al actualizar el libro: " + ex.Message;
            }
            return View(libro);
        }

        [HttpGet]
        public ActionResult DeleteLibro(int id)
        {
            try
            {
                _librosBo.DeleteLibro(id);
                ViewBag.alerta = "¡El libro ha sido borrado satisfactoriamente!";
            }
            catch(Exception ex)
            {
                ViewBag.alerta = "Ocurrió un error al borrar el libro: " + ex.Message;
            }
            return RedirectToAction("Libros");
        }
    }
}