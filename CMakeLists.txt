cmake_minimum_required(VERSION 3.10)
project(MultiLanguageBindings)

# List of subdirectories
set(SUBDIRS csharp java lua octave python R)

# Add subdirectories for each language, setting specific output directories
foreach(SUBDIR ${SUBDIRS})
  set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/${SUBDIR})
  set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/${SUBDIR})
  add_subdirectory(${SUBDIR})
endforeach()

# Custom target to copy the golang directory to build directory
add_custom_target(CopyGolang ALL
  COMMAND ${CMAKE_COMMAND} -E copy_directory ${CMAKE_SOURCE_DIR}/golang ${CMAKE_BINARY_DIR}/golang
  COMMENT "Copying golang directory to build directory"
)

