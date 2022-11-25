using BlobStorage.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorage.Logica
{
    public interface IServiceLogAlbum 
    {
        void Insertar(LogAlbum logAlbum);

        List<LogAlbum> ObtenerLogAlbumOrdenadosPorFecha();

        LogAlbum ObtenerLogPorId(int id);

        void Eliminar(LogAlbum logAlbum);   

    }
    public class ServiceLogAlbum : IServiceLogAlbum
    {
        private AlbumProdContext _albumProdContext;

        public ServiceLogAlbum(AlbumProdContext albumProdContext)
        {
            _albumProdContext = albumProdContext;
        }

        public void Insertar(LogAlbum logAlbum)
        {
            _albumProdContext.LogAlbums.Add(logAlbum);
            _albumProdContext.SaveChanges();
        }

        public List<LogAlbum> ObtenerLogAlbumOrdenadosPorFecha()
        {
            return _albumProdContext.LogAlbums.OrderBy(f => f.FechaHora).ToList();
        }

        public LogAlbum ObtenerLogPorId(int id)
        {
            return _albumProdContext.LogAlbums.Find(id);
        }

        public void Eliminar(LogAlbum logAlbum)
        {
            _albumProdContext.LogAlbums.Remove(logAlbum);
            _albumProdContext.SaveChanges();
        }
    }
}
