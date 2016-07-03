using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace XammaGames
{
	public class Conexion
	{
		public Conexion()
		{
		}

		public async Task<List<Usuarios>> login(string Username, string Password)
		{

			try
			{
				UsuariosList listUsuario = new UsuariosList();
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					//client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


					//HttpResponseMessage response = await client.GetAsync(String.Format("classes/Usuarios/Usuario={0}&Password={1}",Username,Password));
					HttpResponseMessage response = await client.GetAsync("classes/Usuarios");
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();

						listUsuario = JsonConvert.DeserializeObject<UsuariosList>(content);
						var we = listUsuario.results.Where(item => item.Usuario == Username && item.Password == Password).ToList();
						return we;
					}
				}

				return listUsuario.results;

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}

		}

		public async Task<ObservableCollection<ViewJuegosVM>> ObtenerJuegos()
		{
			try
			{
				JuegosListVM listJuegos = new JuegosListVM();
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage response = await client.GetAsync("classes/Juegos");
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();

						listJuegos = JsonConvert.DeserializeObject<JuegosListVM>(content);
						return listJuegos.results;
					}

				}
				return listJuegos.results;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}

		public async Task<int> ObtenerIdJuegos()
		{
			try
			{
				AddJuegosListVM listJuegos = new AddJuegosListVM();
				using (var client = new HttpClient())
				{

					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage response = await client.GetAsync("classes/Juegos");
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();

						listJuegos = JsonConvert.DeserializeObject<AddJuegosListVM>(content);
						var IdNuevo = listJuegos.results.Max(item => int.Parse(item.IdJuego));
						return IdNuevo + 1;
					}
				}
				return 0;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return 0;
			}
		}

		public async Task<bool> GuardarJuego(string IdJuego, string Nombre)
		{
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage wcfResponse = await client.PostAsync("https://parseapi.back4app.com/classes/Juegos", new StringContent("{\"IdJuego\":\"" + IdJuego + "\",\"Nombre\":\"" + Nombre + "\"}", Encoding.UTF8, "application/json"));
					var content = await wcfResponse.Content.ReadAsStringAsync();
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		public async Task<int> ObtenerIdUsuario()
		{
			try
			{
				RegistrarUsuarioListVM listUsuario = new RegistrarUsuarioListVM();
				using (var client = new HttpClient())
				{

					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage response = await client.GetAsync("classes/Usuarios");
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();

						listUsuario = JsonConvert.DeserializeObject<RegistrarUsuarioListVM>(content);
						var IdNuevo = listUsuario.results.Max(item => int.Parse(item.IdUsuario));
						return IdNuevo + 1;
					}
				}
				return 0;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return 0;
			}
		}

		public async Task<bool> VerificarUsuario(string NameUsuario)
		{
			try
			{
				RegistrarUsuarioListVM listUsuario = new RegistrarUsuarioListVM();
				using (var client = new HttpClient())
				{

					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage response = await client.GetAsync("classes/Usuarios");
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();

						listUsuario = JsonConvert.DeserializeObject<RegistrarUsuarioListVM>(content);
						var usuarios = listUsuario.results.Where(item => item.Usuario.Equals(NameUsuario)).ToList();
						if (usuarios.Count >= 1)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		public async Task<bool> GuardarUsurio(string IdUsuario, string Usuario,string Password)
		{
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://parseapi.back4app.com/");
					client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
					client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage wcfResponse = await client.PostAsync("https://parseapi.back4app.com/classes/Usuarios", new StringContent("{\"IdUsuario\":\"" + IdUsuario + "\",\"Usuario\":\"" + Usuario + "\",\"Password\":\""+Password+"\"}", Encoding.UTF8, "application/json"));
					var content = await wcfResponse.Content.ReadAsStringAsync();
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}
	}
}

