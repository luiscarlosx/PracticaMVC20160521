using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Infraestructura;
using TiendaMusica.Logica;
using TiendaMusica.Logica.ViewModels;
using Web.UI.Utilidades;


namespace TiendaMusica.Web.Controllers
{
    public class AlbumController : Controller
    {

        private readonly TiendaConsultas tienda;
        public AlbumController()
        {
            tienda = ConstructorServicios.TiendaConsultas();
        }
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar(string nombre, string album)
        {
            IEnumerable<AlbumsPorArtistaViewModel> albums =
                                                       tienda.Album(nombre, album);

            AlbumsPorArtistaViewModel uNalbum = albums.FirstOrDefault();

            return View(uNalbum);
        }

        [HttpPost]
        public ActionResult Editar(string album,string artista, string Idartista, string Idalbum , HttpPostedFileBase archivo)
        {

            AlbumsPorArtistaViewModel dato;
            dato = new AlbumsPorArtistaViewModel();
            dato.Album = album;
            dato.Artista = artista;
            dato.IdAlbum = Convert.ToInt16(Idartista);
            dato.IdArtista = Convert.ToInt16(Idalbum);

            tienda.Grabar(dato);

            string nombreArchivo = album + ".jpg";  //Path.GetExtension(archivo.FileName);

            if (EsImagen(archivo.ContentType))
            {
                 GrabarImagen(archivo, nombreArchivo);
            }

            return RedirectToAction("Index", "Home");
        }

        private bool EsImagen(string contentType)
        {
            return (contentType.Contains("image"));
        }

        private void GrabarImagen(HttpPostedFileBase archivo, string nombreArchivo)
        {
            MemoryStream ms = new MemoryStream();
            archivo.InputStream.CopyTo(ms);
            Imagen imagen = new Imagen(ms, archivo.FileName, archivo.ContentType, Server.MapPath("~/Imagenes/Album"));
            imagen.Grabar(nombreArchivo, Server.MapPath("~/Imagenes/thumbnails"));
        }



    }

}