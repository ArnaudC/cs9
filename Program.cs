namespace CS9;

class Program
{
    public static void Main()
    {
        var record1 = new Record();
        record1.ValueEquality();
        record1.NonDestructiveMutation();
        record1.EqualityInInheritanceHierarchies();
        record1.WithExpressionsInDerivedRecords();
        record1.PositionalParametersInDerivedRecordTypes();
        record1.DeconstructorBehaviorInDerivedRecords();

        var weatherObservation = new WeatherObservation();
        Console.WriteLine(weatherObservation);
    }
}
