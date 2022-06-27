public class Combate {

  private Personaje personaje1;
  private Personaje personaje2;
  private Personaje? ganador;
  private Personaje? perdedor;
  
  public Combate(Personaje personaje1, Personaje personaje2) {
    this.personaje1 = personaje1;
    this.personaje2 = personaje2;
  }

  public Personaje? Ganador { get => ganador; }
  public Personaje? Perdedor { get => perdedor; }

  public void simularPelea() {

    for (int i = 0; i < 3; i++) {
      this.personaje1.atacar(this.personaje2);
      this.personaje2.atacar(this.personaje1);
    };

    if (this.personaje1.caracteristicas.Salud > this.personaje2.caracteristicas.Salud) {
      this.ganador = this.personaje1;
      this.perdedor = this.personaje2;
    };

    if (this.personaje2.caracteristicas.Salud > this.personaje1.caracteristicas.Salud) {
      this.ganador = this.personaje2;
      this.perdedor = this.personaje1;
    };
  }

  public void mejorarAtributos() {
    var random = new Random();

    int fuerza = random.Next(0, 3);
    int destreza = random.Next(0, 3);
    int armadura = random.Next(0, 3);
    int velocidad = random.Next(0, 3);

    this.ganador.datos.Fuerza += fuerza;
    this.ganador.datos.Destreza += destreza;
    this.ganador.datos.Armadura += armadura;
    this.ganador.datos.Velocidad += velocidad;
    this.ganador.datos.Nivel++;

    Console.WriteLine($"+1 en Nivel");
    Console.WriteLine($"+{ fuerza } en Fuerza");
    Console.WriteLine($"+{ destreza } en Destreza");
    Console.WriteLine($"+{ armadura } en Armadura");
    Console.WriteLine($"+{ velocidad } en Velocidad");
  }
}