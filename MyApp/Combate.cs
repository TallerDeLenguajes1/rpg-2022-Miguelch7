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
}