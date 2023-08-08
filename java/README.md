# Swig example C++ -> Java 
This project shows a simple C++ code to compute the factorial of n, and how it can be called from Java using [SWIG](https://swig.org/Doc4.0/SWIGDocumentation.html)

# Install Java 
sudo apt update
sudo apt install openjdk-11-jdk


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
%module factorial

%{
#include "factorial.h"
%}

%include "factorial.h"

```

## Write the Java code to test the library (Main.java)
```java
public class Main {
    static {
        System.loadLibrary("factorial");
    }

    public static void main(String[] args) {
        System.out.println(factorial.factorial(5));
    }
}

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
java -Djava.library.path=. Main
```


## Manual Compilation
###    Generate Java wrappers with SWIG:
```sh
swig -c++ -java factorial.i
```

### Compile the C++ Code 

```sh
### Linux
g++ -fPIC -c factorial.cpp factorial_wrap.cxx -I/usr/lib/jvm/java-11-openjdk-amd64/include -I/usr/lib/jvm/java-11-openjdk-amd64/include/linux
g++ -shared factorial.o factorial_wrap.o -o libfactorial.so
### MacOS
g++ -fPIC -c factorial.cpp factorial_wrap.cxx -I${JAVA_HOME}/include -I${JAVA_HOME}/include/darwin
g++ -shared factorial.o factorial_wrap.o -o libfactorial.dylib

### Windows
g++ -c factorial.cpp factorial_wrap.cxx -I"C:\path\to\jdk\include" -I"C:\path\to\jdk\include\win32"
g++ -shared factorial.o factorial_wrap.o -o factorial.dll

```
### Compile the Java code
```
javac Main.java
```

### Execute the executable code
```
java -Djava.library.path=. Main
```

