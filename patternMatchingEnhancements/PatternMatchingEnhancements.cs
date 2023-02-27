
namespace CS9;

public class PatternMatchingEnhancements {
    public char c1 { get; set; }
    public char c2 { get; set; }
    public List<String> l1 { get; set; }
    public List<String> l2 { get; set; }

    public PatternMatchingEnhancements() { }

    public PatternMatchingEnhancements(char c1, char c2, List<String> l1, List<String> l2) {
        this.c1 = c1;
        this.c2 = c2;
        this.l1 = l1;
        this.l2 = l2;
    }

    public void run() {
        this.c1 = '1';
        this.c2 = 'f';
        this.l1 = new List<String> { "abc", "def" };
        this.l2 = null;
        Console.WriteLine($"c.IsLetter(): {c1} {c1.IsLetter()}");
        Console.WriteLine($"c.IsLetter(): {c2} {c2.IsLetter()}");
        Console.WriteLine($"l1.IsNotNull(): {l1} {l1.IsNotNull()}");
        Console.WriteLine($"l2.IsNotNull(): {l2} {l2.IsNotNull()}");
    }
}
