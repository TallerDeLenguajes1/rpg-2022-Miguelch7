public class Caracteristica {
  private string tipo = "";
  private string nombre = "";
  private string apodo = "";
  private DateTime fechaNac;
  private int edad;
  private int salud;

  public Caracteristica() {}

  public Caracteristica(string tipo, string nombre, string apodo, DateTime fechaNac, int edad, int salud) {
    this.tipo = tipo;
    this.nombre = nombre;
    this.apodo = apodo;
    this.fechaNac = fechaNac;
    this.edad = edad;
    this.salud = salud;
  }

  public string Tipo { get => tipo; set => tipo = value; }
  public string Nombre { get => nombre; set => nombre = value; }
  public string Apodo { get => apodo; set => apodo = value; }
  public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
  public int Edad { get => edad; set => edad = value; }
  public int Salud { get => salud; set => salud = value; }

  public int obtenerEdad(DateTime fecha) {
    int edad = DateTime.Now.Year - fecha.Year;

    if (DateTime.Now.Month <= FechaNac.Month && DateTime.Now.Day <= FechaNac.Day) {
        edad--;
    };

    return edad;
  }
};