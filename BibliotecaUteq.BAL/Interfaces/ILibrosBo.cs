using BibliotecaUteq.DAL;
using System.Collections.Generic;

namespace BibliotecaUteq.BAL
{
    public interface ILibrosBo
    {
        List<LibrosDto> GetLibros();
        LibrosDto GetLibro(int id);
        void AddLibro(LibrosDto libro);
        void UpdateLibro(LibrosDto libro);
        void DeleteLibro(int id);
    }
}
