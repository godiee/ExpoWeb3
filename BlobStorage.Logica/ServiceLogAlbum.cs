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
        void insertar(LogAlbum logAlbum);

        List<LogAlbum> obtenerLogAlbumOrdenadosPorFecha();

    }
    public class ServiceLogAlbum : IServiceLogAlbum
    {
        private AlbumProdContext _albumProdContext;

        public ServiceLogAlbum(AlbumProdContext albumProdContext)
        {
            _albumProdContext = albumProdContext;
        }

        public void insertar(LogAlbum logAlbum)
        {
            _albumProdContext.LogAlbums.Add(logAlbum);
            _albumProdContext.SaveChanges();
        }

        public List<LogAlbum> obtenerLogAlbumOrdenadosPorFecha()
        {
            return _albumProdContext.LogAlbums.OrderBy(f => f.FechaHora).ToList();
        }
    }
}
