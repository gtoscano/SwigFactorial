#include "myfactorial.h"

unsigned long long myfactorial(int n) {
    unsigned long long result = 1;
    for(int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}

