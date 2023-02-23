using System.Text;

namespace CS9;

class Record
{
    public record Person1(string FirstName, string LastName, string[] PhoneNumbers);

    // Use a nice format with ToString()
    public record Person2(string FirstName, string LastName)
    {
        public string[] PhoneNumbers { get; init; }

        protected virtual bool PrintMembers(StringBuilder stringBuilder)
        {
            foreach (var (value, i) in PhoneNumbers.Select((value, i) => (value, i)))
            {
                Console.WriteLine($"PhoneNumber[{i}] = {value}");
                stringBuilder.Append($"PhoneNumber[{i}] = {value}, ");
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Person2"); // type name
            stringBuilder.Append(" { ");
            if (PrintMembers(stringBuilder))
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }

    public abstract record Person(string FirstName, string LastName);
    public record Teacher(string FirstName, string LastName, int Grade)
        : Person(FirstName, LastName);
    public record Student(string FirstName, string LastName, int Grade)
        : Person(FirstName, LastName);

    public record Point(int X, int Y)
    {
        public int Zbase { get; set; }
    }
    public record NamedPoint(string Name, int X, int Y) : Point(X, Y)
    {
        public int Zderived { get; set; }
    }

    // Value equality for records
    public void ValueEquality()
    {
        var phoneNumbers = new string[2] { "555-1234", "555-5678" };
        Person1 person1 = new("Nancy", "Davolio", phoneNumbers);
        Person1 person2 = new("Nancy", "Davolio", phoneNumbers);
        Console.WriteLine(person1 == person2); // output: True

        person1.PhoneNumbers[0] = "555-1234";
        Console.WriteLine(person1 == person2); // output: True

        Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
    }

    // Mutate immutable properties of a record instance using a 'with' expression
    public void NonDestructiveMutation()
    {
        Person2 person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] { "555-1234" } };
        Console.WriteLine(person1);
        // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

        // Person2 person2 = person1 with { FirstName = "John" };
        Person2 person2 = person1 with { FirstName="John" };
        Console.WriteLine(person2);
        // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with { PhoneNumbers = new string[1] { "123-4567" }  };
        Console.WriteLine(person2);
        // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with { };
        Console.WriteLine(person1 == person2); // output: True
    }

    public void PositionalParametersInDerivedRecordTypes()
    {
        Person teacher = new Teacher("Nancy", "Davolio", 3);
        Console.WriteLine(teacher);
    }

    public void EqualityInInheritanceHierarchies() {
        Person teacher = new Teacher("Nancy", "Davolio", 3);
        Person student = new Student("Nancy", "Davolio", 3);
        Console.WriteLine(teacher == student); // output: False

        Student student2 = new Student("Nancy", "Davolio", 3);
        Console.WriteLine(student == student2); // output: True
    }

    // with expressions in derived records
    public void WithExpressionsInDerivedRecords()
    {
        Point p1 = new NamedPoint("A", 1, 2) { Zbase = 3, Zderived = 4 };
        Point p2 = p1 with { X = 6, Y = 7, Zbase = 7 }; // Can't set Name or Zderived
        Console.WriteLine(p2 is NamedPoint); // output: True
        Console.WriteLine(p2);

        Point p3 = (NamedPoint) p1 with { Name="B", Zderived = 5 };
        Console.WriteLine(p3);
    }

    public void DeconstructorBehaviorInDerivedRecords()
    {
        Person teacher = new Teacher("Nancy", "Davolio", 3);
        var (firstName, lastName) = teacher; // Doesn't deconstruct Grade
        Console.WriteLine($"{firstName} {lastName}"); // output: Nancy Davolio

        var (fName, lName, grade) = (Teacher)teacher;
        Console.WriteLine($"{fName} {lName} {grade}"); // output: Nancy Davolio 3
    }
}
