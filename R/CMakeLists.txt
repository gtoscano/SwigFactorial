cmake_minimum_required(VERSION 3.0)
project(RFactorial)

find_package(SWIG REQUIRED)
include(${SWIG_USE_FILE})

find_program(R_EXECUTABLE R)

set(CMAKE_CXX_FLAGS "-fPIC")
set(CMAKE_SWIG_FLAGS "-c++" "-r")

set(R_INCLUDE_DIR /usr/share/R/include)
include_directories(${R_INCLUDE_DIR} ${CMAKE_CURRENT_SOURCE_DIR})

set_source_files_properties(factorial.i PROPERTIES CPLUSPLUS ON)

# Set the SWIG module name
set(SWIG_MODULE_factorial_EXTRA_DEPS factorial.h)
# Add the factorial.cpp file to the project
#swig_add_library(factorial MODULE factorial.cpp factorial.i)
swig_add_library(rfactorial LANGUAGE r SOURCES factorial.i factorial.cpp)
swig_link_libraries(rfactorial ${R_LIBRARIES})


# Add custom target to generate SWIG wrapper before building the library
add_custom_target(generate_swig_wrap ALL DEPENDS factorial.i)
add_custom_command(OUTPUT factorial.i COMMAND swig -c++ -r -o ${CMAKE_CURRENT_BINARY_DIR}/factorial_wrap.cpp ${CMAKE_CURRENT_SOURCE_DIR}/factorial.i)

# Add dependency to the library on the generated wrapper
add_dependencies(rfactorial generate_swig_wrap)

# Copy the test file to the build directory
configure_file(factorial_test.R ${CMAKE_CURRENT_BINARY_DIR}/factorial_test.R COPYONLY)

