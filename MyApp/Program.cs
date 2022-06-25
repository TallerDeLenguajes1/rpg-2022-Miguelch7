// See https://aka.ms/new-console-template for more information
List<Personaje> listadoPersonajes = new List<Personaje>();

var random = new Random();

Console.Write("Ingresa la cantidad de personajes a pelear (Entre 1 y 13): ");
int cantidadPersonajes = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < cantidadPersonajes; i++) {
  listadoPersonajes.Insert(i, new Personaje());
};

foreach (Personaje personaje in listadoPersonajes) {
  Console.WriteLine();
  personaje.mostrarPersonaje();
  Console.WriteLine();
}