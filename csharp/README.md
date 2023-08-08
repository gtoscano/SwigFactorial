# Swig example C++ -> C# 
This project shows a simple C++ code to compute the factorial of n, and how it can be called from C# using [SWIG](https://swig.org/Doc4.0/SWIGDocumentation.html)

# Install Mono
sudo apt install mono-devel

# Code

## File fact.h
```c++
#ifndef FACTORIAL_H
#define FACTORIAL_H

extern "C" {
unsigned long long calc_factorial(int n);
}

#endif
```

## File fact.cpp. Please note that in C# the package name as the method
```c++
#include "factorial.h"

unsigned long long calc_factorial(int n) {
    unsigned long long result = 1;
    for(int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}

```

## Create SWIG Interface file (factorial.i)
```
#ifndef FACTORIAL_H
#define FACTORIAL_H

extern "C" {
unsigned long long calc_factorial(int n);
}

#endif
```

##    Generate Java wrappers with SWIG: Next, generate the Java wrapper code with SWIG:
```sh
swig -c++ -csharp factorial.i
```

## Compile the C++ Code 

```csh
g++ -c -fpic factorial.cpp factorial_wrap.cxx -I/usr/lib/mono/4.5
g++ -shared factorial.o factorial_wrap.o -o factorial.so
```
## Make the new library available to the mcs
```sh
ldd /path/factorial.so
```

## Write the C# code (Main.cs)
```cs
// Main.cs
using System.Runtime.InteropServices;
using System;

public static class NativeMethods
{
    [DllImport("/home/gtoscano/projects/swig/csharp/factorial.so")]
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

```

## Compile the C# code
```
mcs Main.cs factorial.cs factorialPINVOKE.cs
mono Main.exe
```

