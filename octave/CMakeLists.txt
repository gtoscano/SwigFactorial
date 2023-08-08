cmake_minimum_required(VERSION 3.10)
project(MyFactorialOctave)

# Find Octave's mkoctfile
find_program(MKOCTFILE_EXECUTABLE mkoctfile)
if(NOT MKOCTFILE_EXECUTABLE)
  message(FATAL_ERROR "mkoctfile not found. Please ensure Octave development tools are installed.")
endif()

include_directories($(CMAKE_CURRENT_SOURCE_DIR))


# Set the SWIG interface and source files
set(SWIG_INTERFACE_FILE ${CMAKE_CURRENT_SOURCE_DIR}/myfactorial.i)
set(SOURCE_FILES ${CMAKE_CURRENT_SOURCE_DIR}/myfactorial.cpp)

# Custom command to run SWIG
add_custom_command(
  OUTPUT ${CMAKE_CURRENT_BINARY_DIR}/myfactorial_wrap.cxx
  COMMAND swig -c++ -octave -o ${CMAKE_CURRENT_BINARY_DIR}/myfactorial_wrap.cxx ${SWIG_INTERFACE_FILE}
  DEPENDS ${SWIG_INTERFACE_FILE}
  COMMENT "Running SWIG to generate Octave wrapper"
)

# Custom command to compile the Octave extension with mkoctfile
add_custom_command(
  OUTPUT myfactorial.oct
  COMMAND ${MKOCTFILE_EXECUTABLE} -I${CMAKE_CURRENT_SOURCE_DIR} ${CMAKE_CURRENT_BINARY_DIR}/myfactorial_wrap.cxx ${SOURCE_FILES} -o myfactorial.oct
  DEPENDS ${CMAKE_CURRENT_BINARY_DIR}/myfactorial_wrap.cxx ${SOURCE_FILES}
  COMMENT "Building Octave extension using mkoctfile"
)


# Custom target to build the Octave extension
add_custom_target(BuildOctaveExtension ALL
  DEPENDS myfactorial.oct
)

