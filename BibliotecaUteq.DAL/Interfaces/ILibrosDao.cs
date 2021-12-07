using System.Collections.Generic;

namespace BibliotecaUteq.DAL
{
    public interface ILibrosDao
    {
        List<LibrosDto> GetLibros();
        LibrosDto GetLibro(int id);
        void AddLibro(LibrosDto libro);
        void UpdateLibro(LibrosDto libro);
        void DeleteLibro(int id);
    }
}
