using System.Text.Json;
using System.Text.Json.Serialization;

public class Personaje {
  public Dato datos;
  public Caracteristica caracteristicas;

  public Personaje() {
    this.datos = Personaje.generarDatosPersonaje();
    this.caracteristicas = Personaje.generarCaracteristicaPersonaje();
  }

  public Personaje(Dato datos, Caracteristica caracteristicas) {
    this.datos = datos;
    this.caracteristicas = caracteristicas;
  }

  public Dato Datos { get => datos; set => datos = value; }
  public Caracteristica Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

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

  static Dato generarDatosPersonaje() {

    var random = new Random();
    Dato nuevoDato = new Dato();

    nuevoDato.Velocidad = random.Next(1, 11);
    nuevoDato.Destreza = random.Next(1, 6);
    nuevoDato.Fuerza = random.Next(1, 11);
    nuevoDato.Nivel = random.Next(1, 11);
    nuevoDato.Armadura = random.Next(1, 11);

    return nuevoDato;
  }

  static Caracteristica generarCaracteristicaPersonaje() {

    Caracteristica nuevaCaracteristica = new Caracteristica();

    DatosPermitidos datosPermitidos = new DatosPermitidos();

    nuevaCaracteristica.Tipo = datosPermitidos.obtenerTipo();
    nuevaCaracteristica.Nombre = datosPermitidos.obtenerNombre();
    nuevaCaracteristica.Apodo = datosPermitidos.obtenerApodo();
    nuevaCaracteristica.FechaNac = datosPermitidos.obtenerFechaNac();
    nuevaCaracteristica.Edad = nuevaCaracteristica.obtenerEdad(nuevaCaracteristica.FechaNac);
    nuevaCaracteristica.Salud = 100;

    return nuevaCaracteristica;
  }

}