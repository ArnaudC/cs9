namespace CS9;

class PerformanceInterop {
    public static void Main() {
        unsafe
        {
            Console.WriteLine($"size of nint = {sizeof(nint)}");
            Console.WriteLine($"size of nuint = {sizeof(nuint)}");
            nint ni1 = 1;
            nuint nui2 = 2;
            Console.WriteLine($"ni1 = {ni1} {System.Runtime.InteropServices.Marshal.SizeOf(ni1)}");
            Console.WriteLine($"nui2 = {nui2} {System.Runtime.InteropServices.Marshal.SizeOf(nui2)}");
        }
        DelegateFactory.Main();
    }
}
