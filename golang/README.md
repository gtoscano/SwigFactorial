
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
%module libgofact

%{
#include "fact.h"
%}

%include "fact.h"
```



## Steps to install it manually 

1. Clone the project
```
git clone github.com/gtoscano/libgofact
```
2. Generate the SWIG wrapper files. Run the following command in your terminal:
```
swig -c++ -go -cgo -intgosize 64 fact.i
```
3. Copy the directory to $GOPATH/src
```
cp -r libgofact $GOPATH/src
cd $GOPATH/src/libgofact
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
	fmt.Println(libgofact.Factorial(5))
}

```
5. Execution
```go
run go main.go
120
```

## Steps to install it using go get 

1. Copy the files into a directory and change to that directory. In this case I'll use libgofact
2. Generate the SWIG wrapper files. Run the following command in your terminal:
```
swig -c++ -go -cgo -intgosize 64 fact.i
```
3. Push your directory to GitHub: github.com/gtoscano/libmyfact
4. Install the package 
```
	go get github.com/gtoscano/libgofact
    cd $GOPATH/src/github.com/gtoscano/libgofact
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
	fmt.Println(libgofact.Factorial(5))
}
5. Execution
```go
run go main.go
120
```

