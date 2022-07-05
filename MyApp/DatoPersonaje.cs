public class Dato {
  private int velocidad;// 1 a 10
  private int destreza; // 1 a 5
  private int fuerza;// 1 a 10
  private int nivel; // 1 a 10
  private int armadura; // 1 a 10

  public Dato() {}

  public Dato(int velocidad, int destreza, int fuerza, int nivel, int armadura) {
    this.velocidad = velocidad;
    this.destreza = destreza;
    this.fuerza = fuerza;
    this.nivel = nivel;
    this.armadura = armadura;
  }
  
  public int Velocidad { get => velocidad; set => velocidad = value; }
  public int Destreza { get => destreza; set => destreza = value; }
  public int Fuerza { get => fuerza; set => fuerza = value; }
  public int Nivel { get => nivel; set => nivel = value; }
  public int Armadura { get => armadura; set => armadura = value; }
}