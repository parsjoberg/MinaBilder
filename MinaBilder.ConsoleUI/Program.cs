using MinaBilder.Data;
using MinaBilder.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MinaBilder.ConsoleUI
{
    class Program
    {
        private static MinaBilderContext _context = new MinaBilderContext();
        static void Main(string[] args)
        {            
            var jpgFiler = HämtaJpgFiler(@"C:\Users\46723\Pictures");
            var album = HämtaAlbum(jpgFiler);
            _context.Filer.AddRange(jpgFiler);            
            _context.SaveChanges();
        }

        private static List<Fil> HämtaJpgFiler(string sökväg)
        {
            var jpgFiler = new List<Fil>();
            var jpgFilnamnLista = Directory.GetFiles(sökväg, "*.jpg", SearchOption.AllDirectories);
            foreach(var jpgFilnamn in jpgFilnamnLista)
            {
                var fi = new FileInfo(jpgFilnamn);
                if(!_context.Filer.Any(f => f.Sökväg == jpgFilnamn))
                {
                    jpgFiler.Add(
                    new Fil
                    {
                        Namn = fi.Name,
                        Storlek = fi.Length,
                        Sökväg = fi.FullName
                    });
                }                
            }

            return jpgFiler;
        }

        private static List<Album> HämtaAlbum(List<Fil> filer)
        {
            var albumLista = new List<Album>();

            filer.ForEach(fil =>
            {
                var fi = new FileInfo(fil.Sökväg);
                var album = albumLista.FirstOrDefault(a => a.Namn == fi.Directory.Name) 
                    ?? new Album { Namn = fi.Directory.Name };
                album.Filer.Add(fil);
                fil.Album.Add(album);
                albumLista.Add(album);
            });

            return albumLista;
        }
    }
}
