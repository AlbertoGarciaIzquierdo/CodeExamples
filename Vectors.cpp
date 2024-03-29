// Introduccion.cpp: define el punto de entrada de la aplicación de consola.
//

#include "stdafx.h"
#include <iostream>
#include <math.h>

const double PI = 3.14159265359;

class Vector {
public:
	float x, y, z;
	Vector(float _x, float _y, float _z) {
		x = _x;
		y = _y;
		z = _z;
	}
};

double CosDeg(float angle) {
	if (angle == 90 || angle == -90 || angle == 270 || angle == -270)
		return 0;
	else
		return cos(angle * PI/180);
}

double SinDeg(float angle) {
	if (angle == 0 || angle == 180 || angle == -180)
		return 0;
	else
		return sin(angle * PI/180);
}

// ROTAR SOBRE EL EJE Z
Vector ZRotation(Vector p, float angle) {
	return Vector(CosDeg(angle) * p.x + (-SinDeg(angle) * p.y), SinDeg(angle) * p.x + CosDeg(angle) * p.y, p.z);
}

double Lenght(Vector a) {
	return sqrt(pow(a.x, 2.0) + pow(a.y, 2.0));
}

float Dot(Vector a, Vector b) {
	return float(a.x * b.x + a.y * b.y + a.z * b.z);
}

double AngleBetween(Vector a, Vector b) {
	return acos(
		(Dot(a, b)) / // NUMERATOR
		(Lenght(a) * Lenght(b))	// DENOMINATOR
	) * 180 / PI;
}

double AngleOfVector(Vector a) {
	return atan(a.x / a.y) * 180 / PI;
}

int main()
{
	Vector _vectorPrueba(0, 2, 0);
	Vector _vectorPrueba1(1, 0, 0);
	Vector _resultado(0,0,0);

	std::cout << "DOT PRODUCT: " << Dot(_vectorPrueba, _vectorPrueba1) << std::endl;
	std::cout << "LENGHT: " << Lenght(_vectorPrueba) << std::endl;
	std::cout << "ANGLE: " << AngleOfVector(_vectorPrueba) << std::endl;
	std::cout << "ANGLE BETWEEN: " << AngleBetween(_vectorPrueba, _vectorPrueba1) << std::endl;

	std::cout << "COSENO: " << CosDeg(60) << std::endl;

	_resultado = ZRotation(_vectorPrueba, 30);

	std::cout << "x: " << _resultado.x << " y: " << _resultado.y << " z: " << _resultado.z;
	
	std::cin.get();
	return 0;
}

