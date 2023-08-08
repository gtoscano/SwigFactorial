
##    Generate Java wrappers with SWIG: Next, generate the Java wrapper code with SWIG:
swig -c++ -csharp factorial.i


### Linux

g++ -c -fpic factorial.cpp factorial_wrap.cxx -I/usr/lib/mono/4.5
g++ -shared factorial.o factorial_wrap.o -o factorial.so
ldd /home/gtoscano/projects/swig/csharp/factorial.so
mcs Main.cs factorial.cs factorialPINVOKE.cs
mono Main.exe
