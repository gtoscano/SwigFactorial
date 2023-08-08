cmake_minimum_required(VERSION 3.10)
project(CSharpFactorial)

# Find SWIG
find_package(SWIG REQUIRED)
include(${SWIG_USE_FILE})

# Set C++ standard
set(CMAKE_CXX_STANDARD 11)

# Include Mono headers
include_directories($(CMAKE_CURRENT_SOURCE_DIR) /usr/lib/mono/4.5)

# Define SWIG settings
set_property(SOURCE factorial.i PROPERTY CPLUSPLUS ON)
set(CMAKE_SWIG_FLAGS "")

# Add C++ source files
set_source_files_properties(factorial.i PROPERTIES CPLUSPLUS ON)
set_source_files_properties(factorial.i PROPERTIES SWIG_FLAGS "-namespace;Factorial")

# Define SWIG module and link with shared library
swig_add_library(factorial TYPE SHARED LANGUAGE csharp SOURCES factorial.i factorial.cpp)
set_target_properties(factorial PROPERTIES OUTPUT_NAME "libcsharp_factorial")

# Custom target to compile C# code
add_custom_target(Main ALL
                  COMMAND mcs -out:Main.exe ${CMAKE_CURRENT_SOURCE_DIR}/Main.cs ${CMAKE_CURRENT_BINARY_DIR}/factorial.cs ${CMAKE_CURRENT_BINARY_DIR}/factorialPINVOKE.cs
                  DEPENDS ${CMAKE_CURRENT_BINARY_DIR}/factorial.cs ${CMAKE_CURRENT_BINARY_DIR}/factorialPINVOKE.cs
                  WORKING_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}
)

# Depend on SWIG target
add_dependencies(Main factorial)

