using CS9;

// Records
var record1 = new CustomRecord();
record1.ValueEquality();
record1.NonDestructiveMutation();
record1.EqualityInInheritanceHierarchies();
record1.WithExpressionsInDerivedRecords();
record1.PositionalParametersInDerivedRecordTypes();
record1.DeconstructorBehaviorInDerivedRecords();

// Init only setters
var weatherObservation = new WeatherObservation();
Console.WriteLine(weatherObservation);

// Pattern matching enhancements
var PatternMatchingEnhancements = new PatternMatchingEnhancements();

// Performance and interop
unsafe
{
    Console.WriteLine($"size of nint = {sizeof(nint)}");
    Console.WriteLine($"size of nuint = {sizeof(nuint)}");
    nint ni1 = 1;
    nuint nui2 = 2;
    Console.WriteLine($"ni1 = {ni1} {System.Runtime.InteropServices.Marshal.SizeOf(ni1)}");
    Console.WriteLine($"nui2 = {nui2} {System.Runtime.InteropServices.Marshal.SizeOf(nui2)}");
}
