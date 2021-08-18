using System.Collections.Generic;

namespace MinaBilder.Domain
{
    public class Fil
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public long Storlek { get; set; }
        public string Sökväg { get; set; }
        public List<Album> Album { get; set; } = new List<Album>();
    }
}
