using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinaBilder.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public List<Fil> Filer { get; set; } = new List<Fil>();
    }
}
