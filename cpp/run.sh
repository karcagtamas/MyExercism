mkdir -p build && cd build
cmake -DEXERCISM_RUN_ALL_TESTS=ON -G "Unix Makefiles" ..
make