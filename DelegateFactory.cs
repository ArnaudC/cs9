namespace CS9;

class DelegateFactory {
    private int x = 0;

    public static void Main() {
        var df = new DelegateFactory();
        df.run();
    }

    public void run() {
        var d1 = CreateDelegate();
        d1();
        var d2 = CreateDelegate();
        d2();
        var d3 = CreateDelegate();
        d3();
    }

    public delegate void MyDelegate();

    public MyDelegate CreateDelegate() {
        return () => Console.WriteLine(++this.x);
    }
}
