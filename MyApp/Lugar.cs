using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Lugar {
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("name")]
  public string? Nombre { get; set; }

  [JsonPropertyName("type")]
  public string? Tipo { get; set; }

  [JsonPropertyName("dimension")]
  public string? Dimension { get; set; }

  public Lugar() {}

  public static Lugar obtenerLugarAleatorio() {
    Lugar? lugar = new Lugar();
    var random = new Random();

    int id = random.Next(20);

    var url = $"https://rickandmortyapi.com/api/location/{ id }";
    var request = (HttpWebRequest) WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType = "application/json";
    request.Accept = "application/json";

    try {
      using(WebResponse response = request.GetResponse()) {

        using(Stream strReader = response.GetResponseStream()) {

          if (strReader != null) {

            using(StreamReader objReader = new StreamReader(strReader)) {

              string responseBody = objReader.ReadToEnd();

              lugar = JsonSerializer.Deserialize<Lugar>(responseBody);
            };
          };
        };
      };
    } catch (WebException) {
      Console.WriteLine("Ocurrió un error");
    };

    return lugar!;
  }
}