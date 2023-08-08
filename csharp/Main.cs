// Main.cs
using System.Runtime.InteropServices;
using System;

public static class NativeMethods
{
    //[DllImport("/home/gtoscano/projects/swig/csharp/build/libcsharp_factorial.so")]
    [DllImport("csharp_factorial")]
    public static extern int calc_factorial(int n);
}
public class MainClass
{
    public static void Main()
    {
        int result = NativeMethods.calc_factorial(5);
        Console.WriteLine(result);
    }
}


