public class Personaje {
  public Dato datos;
  public Caracteristica caracteristicas;

  public Personaje() {
    this.datos = new Dato();
    this.caracteristicas = new Caracteristica();
  }

  public void mostrarDatos() {
    Console.WriteLine($"Velocidad: { this.datos.Velocidad }");
    Console.WriteLine($"Destreza: { this.datos.Destreza }");
    Console.WriteLine($"Fuerza: { this.datos.Fuerza }");
    Console.WriteLine($"Nivel: { this.datos.Nivel }");
    Console.WriteLine($"Armadura: { this.datos.Armadura }");
  }
  public void mostrarCaracteristicas() {
    Console.WriteLine($"Tipo: { this.caracteristicas.Tipo }");
    Console.WriteLine($"Nombre: { this.caracteristicas.Nombre }");
    Console.WriteLine($"Apodo: { this.caracteristicas.Apodo }");
    Console.WriteLine($"Fecha de Nacimiento: { this.caracteristicas.FechaNac }");
    Console.WriteLine($"Edad: { this.caracteristicas.Edad }");
    Console.WriteLine($"Salud: { this.caracteristicas.Salud }");
  }

  public void mostrarPersonaje() {
    Console.WriteLine("----- Datos -----");
    this.mostrarDatos();
    Console.WriteLine("----- Caracteristicas -----");
    this.mostrarCaracteristicas();
  }

  public void atacar(Personaje personaje) {

    var random = new Random();

    int PoderDeDisparo = this.datos.Destreza * this.datos.Fuerza * this.datos.Nivel;
    double EfectividadDeDisparo = random.Next(1, 101);
    double ValorDeAtaque = (PoderDeDisparo * EfectividadDeDisparo)/100;

    int PoderDeDefensa = personaje.datos.Armadura * personaje.datos.Velocidad;

    int MaximoDanioProvocable = 5000;

    double DanioProvocado = ( Math.Abs( (((ValorDeAtaque * EfectividadDeDisparo) - PoderDeDefensa) / MaximoDanioProvocable) * 100 ) );

    personaje.caracteristicas.Salud = Convert.ToInt32(personaje.caracteristicas.Salud - DanioProvocado);
  }

}