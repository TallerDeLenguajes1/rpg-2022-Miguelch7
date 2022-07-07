public class DatosPermitidos {

  private Random random = new Random();

  private string[] nombres = {
    "Luffy",
    "Zoro",
    "Sanji",
    "Ace",
    "Shanks",
    "Teach",
    "Kaido",
    "Newgate",
    "Mihawk",
    "Sakazuki",
    "Kuzan",
    "Law",
    "Doflamingo"
  };
  private string[] apodos = {
    "Sombrero de paja",
    "Cazador de piratas",
    "Piernas negras",
    "Puño de fuego",
    "Pelirrojo",
    "Barbanegra",
    "Rey de las bestias",
    "Barbablanca",
    "Ojos de halcón",
    "Akainu",
    "Aokiji",
    "Cirujano de la muerte",
    "Joker"
  };
  private string[] tipos = {
    "Pirata",
    "Yonkou",
    "Shichibukai",
    "Almirante"
  };

  public DatosPermitidos() {}

  public string obtenerNombre() {
    return nombres[ this.random.Next(0, nombres.Length) ];
  }

  public string obtenerApodo() {
    return apodos[ this.random.Next(0, apodos.Length) ];
  }

  public string obtenerTipo() {
    return tipos[ this.random.Next(0, tipos.Length) ];
  }

  public DateTime obtenerFechaNac() {

    int[] mesesCon30Dias = {4 , 6 , 9, 11} ; // Meses con 30 dias: abril , junio , septiembre y noviembre
    int diaMax = 32;
    int mes = this.random.Next(1, 12);

    if (mes == 2) {
      diaMax = 29;
    };

    if ( Array.IndexOf(mesesCon30Dias, mes) > -1 ) { 
      diaMax = 31;
    };

    int dia = this.random.Next(1, diaMax);
    int year = this.random.Next(1722, 2022);

    return new DateTime(year, mes, dia);
  }
}