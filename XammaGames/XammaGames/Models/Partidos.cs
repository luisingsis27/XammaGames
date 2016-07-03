using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XammaGames.Models
{
    public class Partidos
    {
        public string IdPartido { get; set; }
        public string IdJuego { get; set; }
        public string IdUsuario1 { get; set; }
        public string IdUsuario2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

    }
}
