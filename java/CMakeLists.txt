cmake_minimum_required(VERSION 3.10)
project(Factorial)

# Find SWIG
find_package(SWIG REQUIRED)
include(${SWIG_USE_FILE})

# Set C++ standard
set(CMAKE_CXX_STANDARD 11)

# Include Java headers
include_directories(
  /usr/lib/jvm/java-11-openjdk-amd64/include
  /usr/lib/jvm/java-11-openjdk-amd64/include/linux
  $(CMAKE_CURRENT_SOURCE_DIR)
)

# Define SWIG settings
set_property(SOURCE factorial.i PROPERTY CPLUSPLUS ON)
set(CMAKE_SWIG_FLAGS "")

# Define SWIG module
swig_add_library(factorial LANGUAGE java TYPE SHARED SOURCES factorial.i factorial.cpp)

# Rename output to libfactorial.so
set_target_properties(factorial PROPERTIES OUTPUT_NAME "factorial")

# Find Java compiler
find_program(JAVAC_EXECUTABLE NAMES javac)

# Custom target to compile Java code
add_custom_command(
  OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/Main.class
  COMMAND ${JAVAC_EXECUTABLE} -d ${CMAKE_CURRENT_BINARY_DIR} ${CMAKE_CURRENT_SOURCE_DIR}/Main.java
  WORKING_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}
  COMMENT "Compiling Java code"
  DEPENDS factorial
)
add_custom_target(CompileJava ALL DEPENDS ${CMAKE_CURRENT_BINARY_DIR}/Main.class)

