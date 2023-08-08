# SwigFactorial
This project uses C/C++ and SWIG to compute a simple factorial of a number, providing examples to call it from C#, Go, Java, Lua, Octave, Python, and R. A bridge for multi-language development.

As a developer who primarily works in C/C++, I recognize the importance of making code accessible across various programming languages. SWIG (Simplified Wrapper and Interface Generator) serves as a vital tool in this project, enhancing its cross-language compatibility. By leveraging SWIG, we can seamlessly generate interfaces for various programming languages from a single C/C++ implementation. This means that even though the core code is written in C/C++, there are no limitations for other users who want to utilize it in different languages. This approach not only saves development time but also ensures consistency across different language bindings. Whether you're working with C#, Go, Java, Lua, Octave, Python, R, or some of the supported programming languages, SWIG simplifies the process of integrating your C/C++ code into your preferred language. Its efficiency and flexibility make it an ideal choice for developers looking to bridge multiple languages without writing redundant code.

In this repository, we provide a simple integration example using CMake files, demonstrating how to bridge a factorial function written in C/C++ with languages such as C#, Go, Java, Lua, Octave, Python, and R. This approach not only saves development time but also ensures consistency across different language bindings. The example serves as a practical guide for those looking to explore the efficiency and flexibility of SWIG, making it a good choice for developers seeking to work across multiple languages.

## The code in C/C++ (iterative version)
```C
#include "factorial.h"

unsigned long long factorial(int n) {
    unsigned long long result = 1;
    for(int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
```
## Tree Structure
The project has independent directories for each of the tested programming languages. Below, you'll find the structure of the project

```
SwigFactorial
├── CMakeLists.txt
├── csharp
│   ├── CMakeLists.txt
│   ├── factorial.cpp
│   ├── factorial.h
│   ├── factorial.i
│   ├── Main.cs
│   └── README.md
├── golang
│   ├── libgofact
│   ├── main.go
│   └── README.md
├── java
│   ├── CMakeLists.txt
│   ├── commands.md
│   ├── factorial.cpp
│   ├── factorial.h
│   ├── factorial.i
│   ├── Main.java
│   └── README.md
├── LICENSE
├── lua
│   ├── CMakeLists.txt
│   ├── factorial.cpp
│   ├── factorial.h
│   ├── factorial.i
│   ├── factorial_test.lua
│   └── README.md
├── octave
│   ├── CMakeLists.txt
│   ├── commands.txt
│   ├── myfactorial.cpp
│   ├── myfactorial.h
│   ├── myfactorial.i
│   └── README.md
├── python
│   ├── CMakeLists.txt
│   ├── commands.txt
│   ├── factorial.cpp
│   ├── factorial.h
│   ├── factorial.i
│   ├── factorial_test.py
│   └── README.md
├── R
│   ├── CMakeLists.txt
│   ├── factorial.cpp
│   ├── factorial.h
│   ├── factorial.i
│   └── factorial_test.R
├── README.md
└── TREE.md
```
### Testing a specific programming language.
Each programming language directory has its own README.md file, where you can find specific notes for building the interface, and executing the code.

Below you'll find a link to the different README.md files.
- [c# README](csharp/README.md)
- [go README](golang/README.md)
- [java README](java/README.md)
- [lua README](lua/README.md)
- [octave README](octave/README.md)
- [python README](python/README.md)
- [r README](R/README.md)
- [General README (this file)](README.md)

For testing a specific programming language, just follow the following steps:
```sh
cd programming_language_directory
# READ README.md
mkdir build
cd build
cmake ..
make
```

### Python example

```sh
cd python 
mkdir build
cd build
cmake ..
make
python factorial_test.py
```


## Compile all the examples include in the project
```sh
git clone github.com/gtoscano/SwigFactorial
mkdir build
cd build
cmake ..
make
```

## Execution 
### Execution c#
```sh
cd csharp
mono Main.exe
```

### Execution go
For a better explanation, please read /golang/README.md
```sh
go get github.com/gtoscano/libgofact
cd $GOPATH/src/github.com/gtoscano/libgofact
swig -c++ -go -cgo -intgosize 64 fact.i
go install -x
cd WHERE_THIS_PROJECT_IS
cd golang
go run main.go 

```

### Execution java
```sh
cd java 
java -Djava.library.path=. Main

```

## Execution lua
```sh
cd lua
lua factorial_test.lua
```

### Execution octave


```sh
cd octave 
# To avoid confusions with octave's factorial, we call it, myfactorial
octave
octave:1> myfactorial(5)

```

### Execution python
```sh
cd python
python factorial_test.py
```

### Execution R
```sh
cd R 
Rscript factorial_test.R
```


