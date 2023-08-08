
# libgofact

This project shows a simple C++ code to compute the factorial of n, and how it can be called from Go Go (golang) using [SWIG](https://swig.org/Doc4.0/SWIGDocumentation.html)

## Factorial example

For this example, we'll use fact.h, fact.cpp, and fact.i.

### File fact.h

```c++
#ifndef FACTORIAL_H
#define FACTORIAL_H

unsigned long long factorial(int n);

#endif

```
### File fact.cpp
```c++
#include "fact.h"

unsigned long long factorial(int n) {
    unsigned long long result = 1;
    for(int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}
```
## File fact.i
```
%module libfact

%{
#include "fact.h"
%}

%include "fact.h"
```

## Steps to create the directory 

## Steps to install it manually 
1. Create a directory. In this case I'll use libgofact. You can use any other
2. Create files fact.cpp, fact.h,  and fact.i, in the directory using your preferred editor

```
```
3. Copy the directory to $GOPATH/src
```sh
cp -r libgofact $GOPATH/src
cd $GOPATH/src/libgofact
#Generate the SWIG wrapper files. Run the following command in the created directory:
swig -c++ -go -cgo -intgosize 64 fact.i
go install -x
```
4. Now you can use libgofact like any other package. Here it is an example (main.go):
``` go
package main

import (
	"fmt"

	"libgofact"
)

func main() {
	fmt.Println(libfact.Factorial(5))
}

```
5. Execution
```go
run go main.go
120
```

## Steps to install it using go get 

1. Copy the files into a directory and change to that directory. In this case I'll use libgofact
2. Push your directory to a GitHub project. In this case I'll use github.com/gtoscano/libmyfact
3. Install the package 
```sh
go get github.com/gtoscano/libgofact
cd $GOPATH/src/github.com/gtoscano/libgofact
#Generate the SWIG wrapper files. Run the following command in the created directory:
swig -c++ -go -cgo -intgosize 64 fact.i
go install -x
```

4. Now you can use libmyfact like any other package. Here it is an example, called 'main.go':
``` go
package main

import (
	"fmt"

	"github.com/gtoscano/libgofact"
)

func main() {
	fmt.Println(libfact.Factorial(5))
}
```
5. Execution
```go
run go main.go
120
```

