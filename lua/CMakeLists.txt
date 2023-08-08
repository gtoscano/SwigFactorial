cmake_minimum_required(VERSION 3.10)
project(LuaFactorial)

# Find SWIG
find_package(SWIG REQUIRED)
include(${SWIG_USE_FILE})

# Set C++ standard
set(CMAKE_CXX_STANDARD 11)

# Find Lua
find_package(Lua 5.3 REQUIRED)
include_directories(${LUA_INCLUDE_DIR} $(CMAKE_CURRENT_SOURCE_DIR))

# Define SWIG settings
set_property(SOURCE factorial.i PROPERTY CPLUSPLUS ON)
set(CMAKE_SWIG_FLAGS "")

# Define SWIG module
swig_add_library(luafactorial LANGUAGE lua TYPE MODULE SOURCES factorial.i factorial.cpp)

# Link with Lua library
target_link_libraries(luafactorial ${LUA_LIBRARIES})

# Set output name to factorial.so
#set_target_properties(luafactorial PROPERTIES OUTPUT_NAME "factorial")

# Copy the test file to the build directory
configure_file(factorial_test.lua ${CMAKE_CURRENT_BINARY_DIR}/factorial_test.lua COPYONLY)
