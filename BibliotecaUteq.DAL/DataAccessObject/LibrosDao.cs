using BibliotecaUteq.Shared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace BibliotecaUteq.DAL
{
    public class LibrosDao : ILibrosDao
    {
        public List<LibrosDto> GetLibros()
        {
            List<LibrosDto> libros = new List<LibrosDto>();

            try
            {
                //creacion de cliente de la api
                var client = new RestClient(Constants.apiUrl);
                //construir request
                var request = new RestRequest(Constants.getLibros, Method.GET);               
                //consumir api
                var response = client.Execute(request);
                if (response.Content != null && response.Content != string.Empty)
                {
                    libros = JsonConvert.DeserializeObject<List<LibrosDto>>(response.Content);
                }
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
                //creacion de cliente de la api
                var client = new RestClient(Constants.apiUrl);
                //construir request
                var request = new RestRequest(Constants.getLibro + "?id=" + id, Method.GET);
                //request.AddParameter("id", id);
                //consumir api
                var response = client.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    new Exception("Ocurrió un error al obtener los datos del libro de la base de datos. Se obtuvo un StatusCode: " + response.StatusCode.ToString());
                }
                libro = JsonConvert.DeserializeObject<LibrosDto>(response.Content);
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
                //creacion de cliente de la api
                var client = new RestClient(Constants.apiUrl);
                //construir request
                var request = new RestRequest(Constants.addLibro, Method.POST);
                string jBody = JsonConvert.SerializeObject(libro);                
                request.AddJsonBody(jBody);
                //consumir api
                var response = client.Execute(request);
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    new Exception("Ocurrió un error al guardar el libro en la base de datos. Se obtuvo un StatusCode: " + response.StatusCode.ToString());
                }
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
                //creacion de cliente de la api
                var client = new RestClient(Constants.apiUrl);
                //construir request
                var request = new RestRequest(Constants.updateLibro, Method.POST);
                string jBody = JsonConvert.SerializeObject(libro);
                request.AddJsonBody(jBody);
                //consumir api
                var response = client.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    new Exception("Ocurrió un error al actualizar el libro en la base de datos. Se obtuvo un StatusCode: " + response.StatusCode.ToString());
                }
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
                //creacion de cliente de la api
                var client = new RestClient(Constants.apiUrl);
                //construir request
                var request = new RestRequest(Constants.deleteLibro + "?id=" + id, Method.DELETE);
                //request.AddParameter("id", id);
                //consumir api
                var response = client.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    new Exception("Ocurrió un error al eliminar el libro de la base de datos. Se obtuvo un StatusCode: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }
    }
}
