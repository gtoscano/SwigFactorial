cmake_minimum_required(VERSION 3.0)
project(factorial)

find_package(SWIG REQUIRED)
include(${SWIG_USE_FILE})

# Find Python libraries
find_package(PythonLibs REQUIRED)
include_directories(${PYTHON_INCLUDE_PATH} ${CMAKE_CURRENT_SOURCE_DIR})

set(CMAKE_CXX_FLAGS "-fPIC")

set_source_files_properties(factorial.i PROPERTIES CPLUSPLUS ON)

# Set the SWIG module name
set(SWIG_MODULE_factorial_EXTRA_DEPS factorial.h)

# Add the factorial.cpp file to the project and generate Python bindings
swig_add_library(factorial LANGUAGE python SOURCES factorial.i factorial.cpp)
swig_link_libraries(factorial ${PYTHON_LIBRARIES})

# Copy the test file to the build directory
configure_file(factorial_test.py ${CMAKE_CURRENT_BINARY_DIR}/factorial_test.py COPYONLY)

