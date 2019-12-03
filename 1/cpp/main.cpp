#include <numeric>
#include <fstream>
#include <vector>
#include <cmath>
#include <string>
#include <iostream>


float calcFuel(float mass){
    return std::floor(mass / 2) -1;
}

float totalFuel(float fuel){
    auto f = calcFuel(fuel);
    return f > 0 ? f + totalFuel(f) : 0;
}

std::vector<float> fuelForSet(std::vector<int> *modules){
    std::vector<float> fuels;

    for (auto& m : *modules){
        fuels.push_back(calcFuel(m));
    }
}


int main(){
    std::ifstream fs("..\\modules.txt");
    std::string line; 
    std::vector<int> modules;
    

    while(std::getline(fs, line)){
        modules.push_back(std::stoi(line));
    }

    auto modulesWithFuel = fuelForSet(&modules);

    auto result = std::accumulate(begin(modulesWithFuel), end(modulesWithFuel), 0);

    std::cout << result << "\n";
}