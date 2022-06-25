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

}