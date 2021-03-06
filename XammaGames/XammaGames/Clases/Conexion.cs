﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XammaGames
{
	public class Conexion
	{
        private Conexion()
		{
		}

		private static Conexion instance;

		public static Conexion Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Conexion();
				}
				return instance;
			}
		}
        private List<Usuarios> ListaJugadores = new List<Usuarios>();

        public List<Usuarios> listaJugadores{
            get
            {
                return ListaJugadores; 
            }
            set 
            {
                ListaJugadores = value;
            }
        }


		public  Task<List<Usuarios>> login(string Username, string Password)
		{
           
			return Task.Run(async() => { 
				try
				{
					UsuariosList listUsuario = new UsuariosList();
					HttpClientHandler handler = new HttpClientHandler();
					
					using (var client = new HttpClient(handler))
					{
						client.BaseAddress = new Uri("https://parseapi.back4app.com/");
						//client.DefaultRequestHeaders.Accept.Clear();
						client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
						client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync("classes/Usuarios?"+"where={\"Usuario\":\"" + Username + "\",\"Password\":\"" + Password + "\"}");
						string resultContents = await response.Content.ReadAsStringAsync();
						Debug.WriteLine(resultContents);
						if (response.IsSuccessStatusCode)
						{
							listUsuario = JsonConvert.DeserializeObject<UsuariosList>(resultContents);
							//var we = listUsuario.results.Where(item => item.Usuario == Username && item.Password == Password).ToList();
                            return listUsuario.results;
						}
					}

					return listUsuario.results;

				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return null;
				}
			});
		}

	

		public Task<ObservableCollection<ViewJuegosVM>> ObtenerJuegos()
		{
			return Task.Run(async () =>{
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
			});
		}

		public  Task<int> ObtenerIdJuegos()
		{
			return Task.Run(async () =>
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
			});
		}

		public  Task<bool> GuardarJuego(string IdJuego, string Nombre)
		{
			return Task.Run(async () =>
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
			});
		}

		public  Task<int> ObtenerIdUsuario()
		{
			return Task.Run(async () =>
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
			});
		}

		public  Task<bool> VerificarUsuario(string NameUsuario)
		{
			return Task.Run(async () =>
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
			});

		}

		public  Task<bool> GuardarUsurio(string IdUsuario, string Usuario,string Password)
		{
			return Task.Run(async () =>
			{
				try
				{
					using (var client = new HttpClient())
					{
						client.BaseAddress = new Uri("https://parseapi.back4app.com/");
						client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
						client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

						HttpResponseMessage wcfResponse = await client.PostAsync("https://parseapi.back4app.com/classes/Usuarios", new StringContent("{\"IdUsuario\":\"" + IdUsuario + "\",\"Usuario\":\"" + Usuario + "\",\"Password\":\"" + Password + "\"}", Encoding.UTF8, "application/json"));
						var content = await wcfResponse.Content.ReadAsStringAsync();
						return true;
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return false;
				}
			});
		}

        public  Task<ObservableCollection<ViewPartidosVM>> ObtenerPartidos(string idJuego)
		{
			return Task.Run(async () =>
			{
				try
				{
					PartidosListVM listPartidos = new PartidosListVM();

					using (var client = new HttpClient())
					{
						client.BaseAddress = new Uri("https://parseapi.back4app.com/");
						client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
						client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync("classes/Partidos?"+"where={ \"IdJuego\":\"" + idJuego + "\"}");
						string resultContents = await response.Content.ReadAsStringAsync();
						Debug.WriteLine(resultContents);
                        Device.BeginInvokeOnMainThread(()=>{
                            
                        });
						if (response.IsSuccessStatusCode)
						{
							

							listPartidos = JsonConvert.DeserializeObject<PartidosListVM>(resultContents);
							foreach (var item in listPartidos.results)
							{
                                var usuario1 = (listaJugadores.Count() == 0 ? await ObtenerJugadores() : ListaJugadores).Where(x => x.IdUsuario == item.IdUsuario1)?.Single()?.Usuario; // listaJugadores?.Where(x => x.IdUsuario == item.IdUsuario1)?.Single()?.Usuario;
								item.Usuario1 = usuario1.ToString();
								var usuario2 = (listaJugadores.Count() == 0 ? await ObtenerJugadores() : ListaJugadores).Where(x => x.IdUsuario == item.IdUsuario2)?.Single()?.Usuario;
								item.Usuario2 = usuario2.ToString();
								item.Color1 = int.Parse(item.Score1) >= int.Parse(item.Score2) ? Color.Green : Color.Red;
								item.Color2 = int.Parse(item.Score2) >= int.Parse(item.Score1) ? Color.Green : Color.Red;
							}
                            listaJugadores = new List<Usuarios>();
							return listPartidos.results;
						}

					}
					return listPartidos.results;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return null;
				}
			});
		}


		public async Task<string> ObtenerNombreJuego(string IdJuego)
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
							var juegoNombre = listJuegos.results.Where(item => item.IdJuego == IdJuego).First();
							return juegoNombre.Nombre;
						}
					}
					return "";
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return "";
				}

		}

        public Task<List<Usuarios>> ObtenerJugadores()
		{
			return Task.Run(async () =>
			{
				try
				{
					UsuariosList listJugador = new UsuariosList();
					using (var client = new HttpClient())
					{

						client.BaseAddress = new Uri("https://parseapi.back4app.com/");
						client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "KmSpRBINwKQ8AN1fDl77tyrnKlBxDtKfifMztXZx");
						client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "yttT5ALodijbui6GfeK82PRXtZFqGtuxvFJOjRnT");
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						
                        HttpResponseMessage response = await client.GetAsync("classes/Usuarios");
						string resultContents = await response.Content.ReadAsStringAsync();
						Debug.WriteLine(resultContents);
                        Device.BeginInvokeOnMainThread(()=>{


                        });
                        if (response.IsSuccessStatusCode)
						{

							var content = await response.Content.ReadAsStringAsync();

                            listJugador = JsonConvert.DeserializeObject<UsuariosList>(content);
                            ListaJugadores = listJugador.results;
                            return listJugador.results;
						}
					}
					return null;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return null;
				}
			});
		}
	}
}

