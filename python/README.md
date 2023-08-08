# Swig example C++ -> Python 
This project shows a simple C++ code to compute the factorial of n, and how it can be called from Python using [SWIG](https://swig.org/Doc4.0/SWIGDocumentation.html)

# Install Python 
sudo apt update
sudo apt install python3-dev swig cmake g++


# Code

## File factorial.h
```c++
#ifndef FACTORIAL_H
#define FACTORIAL_H

unsigned long long factorial(int n);

#endif

```

## File factorial.cpp. Please note that in C# the package name as the method
```c++
#include "factorial.h"

unsigned long long factorial(int n) {
    unsigned long long result = 1;
    for(int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}

```

## Create SWIG Interface file (factorial.i)
```
%module pyfactorial

%{
#include "factorial.h"
%}

%include "factorial.h"

```

## Write the Python code to test the library (factorial_test.python)
```python
import pyfactorial 

print(pyfactorial.factorial(5))

```

## CMake
```
mkdir build
cd build
cmake ..
make

```

### Execute the executable code
```
python factorial_test.py
```


## Manual Compilation
###    Generate Python wrappers with SWIG:
```sh
swig -c++ -python factorial.i
```

### Compile the C++ Code 

```sh
### Linux
g++ -shared -o _pyfactorial.so factorial.cpp factorial_wrap.cxx -fPIC `python3-config --includes`
```
### Execute the executable code
```
python factorial_test.py
```

