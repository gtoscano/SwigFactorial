
##    Generate Java wrappers with SWIG: Next, generate the Java wrapper code with SWIG:
swig -c++ -java factorial.i


## Compile the C++ code and the SWIG wrapper into a shared library:

### Linux
g++ -fPIC -c factorial.cpp factorial_wrap.cxx -I/usr/lib/jvm/java-11-openjdk-amd64/include -I/usr/lib/jvm/java-11-openjdk-amd64/include/linux
g++ -shared factorial.o factorial_wrap.o -o libfactorial.so

### MacOS
g++ -fPIC -c factorial.cpp factorial_wrap.cxx -I${JAVA_HOME}/include -I${JAVA_HOME}/include/darwin
g++ -shared factorial.o factorial_wrap.o -o libfactorial.dylib

### Windows
g++ -c factorial.cpp factorial_wrap.cxx -I"C:\path\to\jdk\include" -I"C:\path\to\jdk\include\win32"
g++ -shared factorial.o factorial_wrap.o -o factorial.dll


javac Main.java
java -Djava.library.path=. Main
