# Swig example C++ -> Lua 
This project shows a simple C++ code to compute the factorial of n, and how it can be called from Lua using [SWIG](https://swig.org/Doc4.0/SWIGDocumentation.html)

# Install Lua 
sudo apt update
sudo apt-get install lua5.3 liblua5.3-dev


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
%module luafactorial

%{
#include "factorial.h"
%}

%include "factorial.h"

```

## Write the Lua code to test the library (factorial_test.lua)
```lua
require("luafactorial")
print(luafactorial.factorial(5))
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
lua factorial_test.lua
```


## Manual Compilation
###    Generate Lua wrappers with SWIG:
```sh
swig -c++ -lua factorial.i
```

### Compile the C++ Code 

```sh
### Linux
g++ -fPIC -shared factorial.cpp factorial_wrap.cxx -o luafactorial.so -I/usr/include/lua5.3 -L/usr/lib -llua5.3
```
### Execute the executable code
```
lua factorial_test.lua

