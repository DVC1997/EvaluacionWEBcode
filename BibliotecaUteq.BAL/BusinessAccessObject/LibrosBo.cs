using BibliotecaUteq.DAL;
using System;
using System.Collections.Generic;

namespace BibliotecaUteq.BAL
{
    public class LibrosBo : ILibrosBo
    {
        ILibrosDao _librosDao;

        public LibrosBo(ILibrosDao librosDao)
        {
            _librosDao = librosDao;
        }

        public List<LibrosDto> GetLibros()
        {
            List<LibrosDto> libros = new List<LibrosDto>();
            try
            {
                libros = _librosDao.GetLibros();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
            return libros;
        }

        public LibrosDto GetLibro(int id)
        {
            LibrosDto libro = new LibrosDto();
            try
            {
                libro = _librosDao.GetLibro(id);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
            return libro;
        }

        public void AddLibro(LibrosDto libro)
        {
            try
            {
                _librosDao.AddLibro(libro);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        public void UpdateLibro(LibrosDto libro)
        {
            try
            {
                _librosDao.UpdateLibro(libro);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        public void DeleteLibro(int id)
        {
            try
            {
                _librosDao.DeleteLibro(id);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }
    }
}
