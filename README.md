# SwigFactorial
This project uses C++ and SWIG to compute factorials, providing examples to call it from C#, Go, Java, Lua, Octave, Python, and R. A bridge for multi-language development.


# Compile
```
mkdir build
cd build
cmake ..
make
```

# Execution c#
```sh
cd csharp
mono Main.exe
```

# Execution go
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

# Execution java
```sh
cd java 
java -Djava.library.path=. Main

```

# Execution lua
```sh
cd lua
lua factorial_test.lua
```

# Execution octave


```sh
cd octave 
# To avoid confusions with octave's factorial, we call it, myfactorial
octave
octave:1> myfactorial(5)

```

# Execution python
```sh
cd python
python factorial_test.py
```

# Execution R
```sh
cd R 
Rscript factorial_test.R
```


