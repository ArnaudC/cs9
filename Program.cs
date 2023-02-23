using System.Text;

namespace CS9;

class Program
{
    public record Person1(string FirstName, string LastName, string[] PhoneNumbers);

    public record Person2(string FirstName, string LastName)
    {
        public string[]? PhoneNumbers { get; init; }

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

    // Value equality for records
    public static void ValueEquality()
    {
        var phoneNumbers = new string[2];
        Person1 person1 = new("Nancy", "Davolio", phoneNumbers);
        Person1 person2 = new("Nancy", "Davolio", phoneNumbers);
        Console.WriteLine(person1 == person2); // output: True

        person1.PhoneNumbers[0] = "555-1234";
        Console.WriteLine(person1 == person2); // output: True

        Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
    }

    // Mutate immutable properties of a record instance using a 'with' expression
    public static void NonDestructiveMutation() {
        Person2 person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
        Console.WriteLine(person1);
        // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

        // Person2 person2 = person1 with { FirstName = "John" };
        Person2 person2 = person1 with { FirstName="John" };
        Console.WriteLine(person2);
        // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with { PhoneNumbers = new string[1] };
        Console.WriteLine(person2);
        // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with { };
        Console.WriteLine(person1 == person2); // output: True
    }

    public static void PositionalParametersInDerivedRecordTypes() {
        Person teacher = new Teacher("Nancy", "Davolio", 3);
        Console.WriteLine(teacher);
    }

    public static void EqualityInInheritanceHierarchies() {
        Person teacher = new Teacher("Nancy", "Davolio", 3);
        Person student = new Student("Nancy", "Davolio", 3);
        Console.WriteLine(teacher == student); // output: False

        Student student2 = new Student("Nancy", "Davolio", 3);
        Console.WriteLine(student == student2); // output: True
    }

    public static void Main()
    {
        ValueEquality();
        NonDestructiveMutation();
        EqualityInInheritanceHierarchies();
    }
}
