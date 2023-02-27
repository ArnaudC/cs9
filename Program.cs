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
PerformanceInterop.Main();
