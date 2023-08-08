# Swig example C++ -> Octave 
This project shows a simple C++ code to compute the factorial of n, and how it can be called from Octave using [SWIG](https://swig.org/Doc4.0/SWIGDocumentation.html)

In this project we will use myfactorial, instead of factorial to avoid confusions with Octave's factorial.

# Install Octave 
```sh
sudo apt-get update
sudo apt-get install octave liboctave-dev
```


# Code

## File myfactorial.h
```c++
#ifndef FACTORIAL_H
#define FACTORIAL_H

extern "C" {
unsigned long long myfactorial(int n);
}

#endif
```

## File factorial.cpp. Please note that in C# the package name as the method
```c++
#include "myfactorial.h"

unsigned long long myfactorial(int n) {
    unsigned long long result = 1;
    for(int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
```

## Create SWIG Interface file (factorial.i)
```
%module my_factorial

%{
#include "myfactorial.h"
%}

%include "myfactorial.h"
```

## CMake
```
mkdir build
cd build
cmake ..
make

```

### Execute the executable code
```octave
octave:1> myfactorial(5)
ans=120
```


## Manual Compilation
###    Generate Octave wrappers with SWIG:
```sh
swig -c++ -octave myfactorial.i
```

### Compile the C++ Code 

```sh
### Linux
mkoctfile myfactorial_wrap.cxx myfactorial.cpp -o myfactorial.oct
```
### Execute the executable code
```octave
octave:1> myfactorial(5)
ans=120
```
