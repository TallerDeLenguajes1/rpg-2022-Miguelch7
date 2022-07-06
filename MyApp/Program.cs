// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text.Json;

List<Personaje> listadoPersonajes = new List<Personaje>();

string ganadoresCSV = Directory.GetCurrentDirectory() + "\\ganadores.csv";
string jugadoresJSON = Directory.GetCurrentDirectory() + "\\jugadores.json";

if ( !File.Exists(ganadoresCSV) ) {
  File.Create(ganadoresCSV);
};

if (File.Exists(ganadoresCSV)) {
  listarGanadores(ganadoresCSV);
};

listadoPersonajes = cargarPersonajes(jugadoresJSON);

if (listadoPersonajes.Count == 0) {
  var random = new Random();

  Console.Write("Ingresa la cantidad de personajes a pelear (Entre 1 y 13): ");
  int cantidadPersonajes = Convert.ToInt32(Console.ReadLine());

  for (int i = 0; i < cantidadPersonajes; i++) {
    listadoPersonajes.Insert(i, new Personaje());
  };

  guardarPersonajes(listadoPersonajes, jugadoresJSON);
};

Console.WriteLine("Listado de personajes");
listarPersonajes(listadoPersonajes);

simularTorneo(listadoPersonajes, ganadoresCSV);

// ========== FUNCIONES ==========
void listarPersonajes(List<Personaje> listadoPersonajes) {
  
  int indice = 0;
  
  foreach (Personaje personaje in listadoPersonajes) {
    Console.WriteLine($"{ indice }) \"{ personaje.caracteristicas.Apodo }\" { personaje.caracteristicas.Nombre }");
    indice++;
  };
}

void simularTorneo(List<Personaje> listadoPersonajes, string ganadoresCSV) {

  Personaje luchador;
  Personaje retador;
  Personaje campeon = listadoPersonajes.First();
  int cantidadParticipantes = listadoPersonajes.Count();
  Combate combate;
  Lugar lugar = Lugar.obtenerLugarAleatorio();
  
  while (listadoPersonajes.Count() > 1) {
    luchador = listadoPersonajes.ElementAt(0);
    retador = listadoPersonajes.ElementAt(1);

    combate = new Combate(luchador, retador);

    Console.WriteLine($"\nLa siguiente pelea es entre { luchador.caracteristicas.Nombre } y { retador.caracteristicas.Nombre }");

    Console.WriteLine("FIGHT!");
    combate.simularPelea();

    Console.WriteLine($"El GANADOR del combate es: { combate.Ganador?.caracteristicas.Nombre }");
    campeon = combate?.Ganador!;
    listadoPersonajes.Remove(combate?.Perdedor!);
    combate?.mejorarAtributos();
  };

  Console.WriteLine($"\nEl CAMPEÓN del torneo es: { campeon.caracteristicas.Nombre! }");

  guardarCampeon(campeon, cantidadParticipantes, lugar, ganadoresCSV);
}

void guardarCampeon(Personaje ganador, int cantidadParticipantes, Lugar lugar, string archivoCSV) {

  StreamWriter sw = new StreamWriter(archivoCSV, append: true);

  sw.WriteLine($"{ ganador.caracteristicas.Nombre } { ganador.caracteristicas.Apodo };{ cantidadParticipantes };{ lugar.Nombre };{ DateTime.Now.ToShortDateString() }");

  sw.Close();
}

void listarGanadores(string archivoCSV) {
  StreamReader sr = new StreamReader(archivoCSV);

  string linea = sr.ReadLine()!;

  Console.WriteLine("---------- Listado de ganadores ----------");

  while (linea != null) {
    Console.WriteLine(linea);

    linea = sr.ReadLine()!;
  };

  Console.WriteLine();

  sr.Close();
};

List<Personaje> cargarPersonajes(string personajesJSON) {
  List<Personaje> listadoDePeliculas = new List<Personaje>();
  
  StreamReader sr = new StreamReader(personajesJSON);

  string listadoDePersonajesJSON = sr.ReadToEnd()!;

  sr.Close();

  if (!string.IsNullOrEmpty(listadoDePersonajesJSON)) {
    listadoDePeliculas = JsonSerializer.Deserialize<List<Personaje>>(listadoDePersonajesJSON)!;
  };

  return listadoDePeliculas;
};

void guardarPersonajes(List<Personaje> listadoDePersonajes, string personajesJSON) {

  if (!File.Exists(personajesJSON)) {
    File.Create(personajesJSON);
  };

  string listadoDePersonajesJSON = JsonSerializer.Serialize(listadoDePersonajes);

  StreamWriter sw = new StreamWriter(personajesJSON);

  sw.WriteLine(listadoDePersonajesJSON);

  sw.Close();
};