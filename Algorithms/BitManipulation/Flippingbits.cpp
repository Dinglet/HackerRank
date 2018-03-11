/*
Flipping bits
https://www.hackerrank.com/challenges/flipping-bits/problem
*/
#include <bits/stdc++.h>

using namespace std;

typedef u_int32_t number_t;

inline number_t flippingBits(number_t N) {
    return ~N;
}

int main() {
    int T;
    cin >> T;
    
    number_t N, result;
    for(int i = 0; i < T; ++i){
        cin >> N;
        cout << flippingBits(N) << endl;
    }
    return 0;
}
