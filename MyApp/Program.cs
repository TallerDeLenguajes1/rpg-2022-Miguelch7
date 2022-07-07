internal class Program {
  private static void Main(string[] args) {

    string ganadoresCSV = Directory.GetCurrentDirectory() + "\\ganadores.csv";
    string jugadoresJSON = Directory.GetCurrentDirectory() + "\\jugadores.json";

    Torneo torneo = new Torneo(ganadoresCSV, jugadoresJSON);
    torneo.cargarJugadores();

    if (torneo.CantidadDeParticipantes == 0) {
      Console.Write("Ingresa la cantidad de personajes a pelear: ");
      int cantidad = Convert.ToInt32(Console.ReadLine());

      torneo.cargarJugadoresAleatoriamente(cantidad);
      torneo.guardarJugadores();
    };

    torneo.listarCampeones();

    torneo.listarPersonajes();

    torneo.simularTorneo();

    torneo.mostrarCampeon();

    torneo.guardarCampeon();
  }
}