using System;
using System.Collections.Generic;

namespace XammaGames
{
	public class Usuarios
	{
		public string objectId { get; set; }
		public string IdUsuario { get; set; }
		public string updatedAt { get; set; }
		public string createdAt { get; set; }
		public string Usuario { get; set; }
		public string Password { get; set; }
	}

	public class UsuariosList
	{
		public List<Usuarios> results { get; set; }
	}
}

