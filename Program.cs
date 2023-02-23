namespace CS9;

class Program
{
    public static void Main()
    {
        Record record1 = new Record();
        record1.ValueEquality();
        record1.NonDestructiveMutation();
        record1.EqualityInInheritanceHierarchies();
        record1.WithExpressionsInDerivedRecords();
    }
}
