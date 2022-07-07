using System.Text.Json;

public class Torneo {
  private List<Personaje> participantes;
  private int cantidadDeParticipantes;
  private Lugar lugarTorneo;
  private DateTime fecha;
  private Personaje campeon;
  private string ganadoresCSV;
  private string jugadoresJSON;

  public Torneo(string ganadoresCSV, string jugadoresJSON) {
    this.participantes = new List<Personaje>();
    this.cantidadDeParticipantes = 0;
    this.lugarTorneo = Lugar.obtenerLugarAleatorio();
    this.fecha = DateTime.Now;
    this.campeon = new Personaje();
    this.ganadoresCSV = ganadoresCSV;
    this.jugadoresJSON = jugadoresJSON;
  }

  public List<Personaje> Participantes { get => participantes; set => participantes = value; }
  public int CantidadDeParticipantes { get => cantidadDeParticipantes; set => cantidadDeParticipantes = value; }
  public Lugar LugarTorneo { get => lugarTorneo; set => lugarTorneo = value; }
  public DateTime Fecha { get => fecha; set => fecha = value; }
  public Personaje Campeon { get => campeon; set => campeon = value; }

  public void simularTorneo() {

    while (this.participantes.Count() > 1) {
      
      Combate combate = new Combate(this.participantes.ElementAt(0), this.participantes.ElementAt(1));

      combate.simularPelea();

      this.campeon = combate.Ganador!;
      this.participantes.Remove(combate.Perdedor!);
      combate.mejorarAtributos();
    };
  }

  public void SimularCombate(Personaje luchador, Personaje retador) {
    
    Combate combate = new Combate(luchador, retador);
    
    combate.simularPelea();

    this.participantes.Remove(combate.Perdedor!);
    combate.mejorarAtributos();
  }

  public void cargarJugadores() {

    StreamReader sr = new StreamReader(this.jugadoresJSON);

    string listadoDePersonajesJSON = sr.ReadToEnd()!;

    sr.Close();

    if (!string.IsNullOrEmpty(listadoDePersonajesJSON)) {
      this.participantes = JsonSerializer.Deserialize<List<Personaje>>(listadoDePersonajesJSON)!;
      this.cantidadDeParticipantes = this.participantes.Count();
    };
  }

  public void cargarJugadoresAleatoriamente(int cantidad) {
    
    for (int i = 0; i < cantidad; i++) {
      this.participantes.Insert(i, new Personaje());
    };

    this.cantidadDeParticipantes = cantidad;
  }

  public void listarPersonajes() {
  
    int indice = 1;
    
    foreach (Personaje personaje in this.participantes) {
      Console.WriteLine($"{ indice }) \"{ personaje.caracteristicas.Apodo }\" { personaje.caracteristicas.Nombre }");
      indice++;
    };
  }

  public void guardarJugadores() {

    if (!File.Exists(this.jugadoresJSON)) {
      File.Create(this.jugadoresJSON);
    };

    string listadoDePersonajesJSON = JsonSerializer.Serialize(this.participantes);

    StreamWriter sw = new StreamWriter(this.jugadoresJSON);

    sw.WriteLine(listadoDePersonajesJSON);

    sw.Close();
  }

  public void mostrarCampeon() {
    Console.WriteLine("\n========== Resumen del torneo ==========");
    Console.WriteLine("Cantidad de participantes: " + this.cantidadDeParticipantes);
    Console.WriteLine("Lugar del torneo: " + this.lugarTorneo.Nombre);
    Console.WriteLine("Fecha del torneo: " + this.fecha.ToShortDateString());

    Console.WriteLine("\nEl Campeon del torneo es:");
    this.campeon.mostrarPersonaje();
  }

  public void guardarCampeon() {

    StreamWriter sw = new StreamWriter(this.ganadoresCSV, append: true);

    sw.WriteLine($"{ this.campeon.caracteristicas.Nombre } { this.campeon.caracteristicas.Apodo };{ this.cantidadDeParticipantes };{ this.lugarTorneo.Nombre };{ this.fecha.ToShortDateString() }");

    sw.Close();
  }

  public void listarCampeones() {
    StreamReader sr = new StreamReader(this.ganadoresCSV);

    string linea = sr.ReadLine()!;

    Console.WriteLine("---------- Campeones anteriores ----------");

    while (linea != null) {

      string[] array = linea.Split(";");

      Console.WriteLine($"Campeon: { array[0] } | Cantidad de participantes: { array[1] } | Lugar del torneo: { array[2] } | Fecha del torneo: { array[3] }");

      linea = sr.ReadLine()!;
    };

    Console.WriteLine();

    sr.Close();
  }
}