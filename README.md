#include <iostream>
#include <cstring>

class Car {
private:
    char brand[30];
    char model[30];
    int year;
    int mileage;

public:
    Car() {
        strncpy(brand, "Unknown", sizeof(brand) - 1);
        brand[sizeof(brand) - 1] = '\0';
        strncpy(model, "Unknown", sizeof(model) - 1);
        model[sizeof(model) - 1] = '\0';
        year = 2000;
        mileage = 0;
    }

    Car(const char* carBrand, const char* carModel, int carYear, int carMileage) {
        strncpy(brand, carBrand, sizeof(brand) - 1);
        brand[sizeof(brand) - 1] = '\0';
        strncpy(model, carModel, sizeof(model) - 1);
        model[sizeof(model) - 1] = '\0';
        year = carYear;
        mileage = carMileage;
    }

    int getMileage() const {
        return mileage;
    }

    void setMileage(int newMileage) {
        if (newMileage >= mileage) {
            mileage = newMileage;
        }
    }

    void drive(int km) {
        if (km > 0) {
            mileage += km;
        }
    }

    int getAge(int currentYear) const {
        if (currentYear >= year) {
            return currentYear - year;
        }
        return 0;
    }
};

int main() {
    Car myCar("Toyota", "Corolla", 2015, 50000);

    int currentYear = 2025; // Текущий год
    std::cout << "Initial mileage: " << myCar.getMileage() << " km\n";
    
    std::cout << "Car age (2025): " << myCar.getAge(currentYear) << " years\n";

    myCar.drive(150);  // Используем метод drive
    std::cout << "\nAfter driving 150 km:\n";
    std::cout << "Updated mileage: " << myCar.getMileage() << " km\n";
    
    myCar.setMileage(40000);  
    std::cout << "\nAfter attempting to set mileage to 40000 km:\n";
    std::cout << "Current mileage: " << myCar.getMileage() << " km\n";

    return 0;
}
