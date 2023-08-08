# SwigFactorial
This project uses C++ and SWIG to compute factorials, providing examples to call it from C#, Go, Java, Lua, Octave, Python, and R. A bridge for multi-language development.

SWIG (Simplified Wrapper and Interface Generator) is a powerful tool that enhances this project's cross-language compatibility. By leveraging SWIG, we can seamlessly generate interfaces for various programming languages from a single C++ implementation. This approach not only saves development time but also ensures consistency across different language bindings. Whether you're working with C#, Go, Java, Lua, Octave, Python, R, or some of the supported programming languages, SWIG simplifies the process of integrating your  C++ code into your preferred language. Its efficiency and flexibility make it an ideal choice for developers looking to bridge multiple languages without writing redundant code.

In this repository, we provide a simple integration example using CMake files, demonstrating how to bridge the C++ factorial function with languages such as C#, Go, Java, Lua, Octave, Python, and R.

This approach not only saves development time but also ensures consistency across different language bindings. The example serves as a practical guide for those looking to explore the efficiency and flexibility of SWIG, making it an ideal choice for developers seeking to work across multiple languages.

# Compile
```
mkdir build
cd build
cmake ..
make
```

# Execution 
## Execution c#
```sh
cd csharp
mono Main.exe
```

## Execution go
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

## Execution java
```sh
cd java 
java -Djava.library.path=. Main

```

## Execution lua
```sh
cd lua
lua factorial_test.lua
```

## Execution octave


```sh
cd octave 
# To avoid confusions with octave's factorial, we call it, myfactorial
octave
octave:1> myfactorial(5)

```

## Execution python
```sh
cd python
python factorial_test.py
```

## Execution R
```sh
cd R 
Rscript factorial_test.R
```


