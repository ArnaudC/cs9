namespace CS9;

public class FitAndFinishFreatures {
    private List<WeatherObservation> _observations = new();

    public FitAndFinishFreatures() {
    }

    public void Run() {
        WeatherStation weatherStation = new() { Summary = "Hot", TemperatureC = 42 };
        Console.WriteLine(weatherStation);
    }
}
