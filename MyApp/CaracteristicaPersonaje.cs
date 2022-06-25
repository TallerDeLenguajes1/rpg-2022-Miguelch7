public class Caracteristica {
  private string tipo = "";
  private string nombre = "";
  private string apodo = "";
  private DateOnly fechaNac;
  private int edad;
  private int salud;

  public Caracteristica() {

    DatosPermitidos datosPermitidos = new DatosPermitidos();

    this.tipo = datosPermitidos.obtenerTipo();
    this.nombre = datosPermitidos.obtenerNombre();
    this.apodo = datosPermitidos.obtenerApodo();
    this.fechaNac = datosPermitidos.obtenerFechaNac();
    this.edad = this.obtenerEdad(this.fechaNac);
    this.salud = 100;
  }

  public string Tipo { get => tipo; }
  public string Nombre { get => nombre; }
  public string Apodo { get => apodo; }
  public DateOnly FechaNac { get => fechaNac; }
  public int Edad { get => edad; }
  public int Salud { get => salud; set => salud = value; }

  private int obtenerEdad(DateOnly fecha) {
    int edad = DateTime.Now.Year - fecha.Year;

    if (DateTime.Now.Month <= FechaNac.Month && DateTime.Now.Day <= FechaNac.Day) {
        edad--;
    };

    return edad;
  }
};