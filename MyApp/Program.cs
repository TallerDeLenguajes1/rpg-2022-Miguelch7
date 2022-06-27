// See https://aka.ms/new-console-template for more information
List<Personaje> listadoPersonajes = new List<Personaje>();

var random = new Random();

Console.Write("Ingresa la cantidad de personajes a pelear (Entre 1 y 13): ");
int cantidadPersonajes = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < cantidadPersonajes; i++) {
  listadoPersonajes.Insert(i, new Personaje());
};

Console.WriteLine("Listado de personajes");
listarPersonajes(listadoPersonajes);

simularTorneo(listadoPersonajes);


// ========== FUNCIONES ==========
void listarPersonajes(List<Personaje> listadoPersonajes) {
  
  int indice = 0;
  
  foreach (Personaje personaje in listadoPersonajes) {
    Console.WriteLine($"{ indice }) \"{ personaje.caracteristicas.Apodo }\" { personaje.caracteristicas.Nombre }");
    indice++;
  };
}

void simularTorneo(List<Personaje> listadoPersonajes) {

  Personaje luchador;
  Personaje retador;
  Personaje campeon = listadoPersonajes.First();
  Combate combate;
  
  while (listadoPersonajes.Count() > 1) {
    luchador = listadoPersonajes.ElementAt(0);
    retador = listadoPersonajes.ElementAt(1);

    combate = new Combate(luchador, retador);

    Console.WriteLine($"\nLa siguiente pelea es entre { luchador.caracteristicas.Nombre } y { retador.caracteristicas.Nombre }");

    Console.WriteLine("FIGHT!");
    combate.simularPelea();

    Console.WriteLine($"El GANADOR del combate es: { combate.Ganador?.caracteristicas.Nombre }");
    campeon = combate.Ganador;
    listadoPersonajes.Remove(combate.Perdedor);
    combate.mejorarAtributos();
  };

  Console.WriteLine($"\nEl CAMPEÓN del torneo es: { campeon.caracteristicas.Nombre }");
}