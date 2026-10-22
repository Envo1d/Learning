#pragma once

#ifdef INTEGER
void Rand_Int(int*, int);
void Print_Int(int*, int);
void Min_Int(int*, int);
void Max_Int(int*, int);
void Sort_Int(int*, int, int);
void Edit_Int(int*, int);
#define Type int
#define Rand Rand_Int
#define Print Print_Int
#define Min Min_Int
#define Max Max_Int
#define Sort Sort_Int
#define Edit Edit_Int
#endif

#ifdef DOUBLE
void Rand_Double(double*, int);
void Print_Double(double*, int);
void Min_Double(double*, int);
void Max_Double(double*, int);
void Sort_Double(double*, int, int);
void Edit_Double(double*, int);
#define Type double
#define Rand Rand_Double
#define Print Print_Double
#define Min Min_Double
#define Max Max_Double
#define Sort Sort_Double
#define Edit Edit_Double
#endif

#ifdef CHAR
void Rand_Char(char*, int);
void Print_Char(char*, int);
void Min_Char(char*, int);
void Max_Char(char*, int);
void Sort_Char(char*, int, int);
void Edit_Char(char*, int);
#define Type char
#define Rand Rand_Char
#define Print Print_Char
#define Min Min_Char
#define Max Max_Char
#define Sort Sort_Char
#define Edit Edit_Char
#endif
