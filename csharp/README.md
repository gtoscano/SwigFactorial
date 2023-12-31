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
%module csharp_factorial

%{
#include "factorial.h"
%}

%include "factorial.h"

```

## Write the C# code to test the library (Main.cs)
```csharp
// Main.cs
using System.Runtime.InteropServices;
using System;

public static class NativeMethods
{
    //[DllImport("/home/gtoscano/projects/swig/csharp/build/libcsharp_factorial.so")]
    [DllImport("csharp_factorial")] //the file is called libcsharp_factorial.so
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

## CMake
```
mkdir build
cd build
cmake ..
make
mono Main.exe
```



## Manual Compilation
###    Generate C# wrappers with SWIG:
```sh
swig -c++ -csharp factorial.i
```

### Compile the C++ Code 

```sh
g++ -c -fpic factorial.cpp factorial_wrap.cxx -I/usr/lib/mono/4.5
g++ -shared factorial.o factorial_wrap.o -o libcsharp_factorial.so
```

### Compile the C# code
```
mcs Main.cs csharp_factorial.cs csharp_factorialPINVOKE.cs
```

### Execute the executable code
```
# if you don not want to add an entry to the LD_LIBRARY_PATH, you can put the full path on Dllimport in Main.cs file.
mono Main.exe
```


## In case of trouble finding the dll library
```sh
# 
ldd /path/csharp_factorial.so
# OR
export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/PATH_WHERE_IS_YOUR_BUID/build
# OR Complie the full path of the library in DllImport
```


