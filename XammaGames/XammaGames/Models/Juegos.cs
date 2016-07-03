using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XammaGames.Models
{
    public class Juegos
    {
        public string IdJuego { get; set; }
        public string Nombre { get; set; }

    }

	public class JuegosList
	{
		public List<Juegos> results { get; set; }
	}
}
