/*PROBLEM: Hotel Management System

Build an application that models a hotel and its rooms.Implement the following, exemplifying every point in main().Code must compile and run at every stage.No memory leaks.

P1 — Class definition.Define a class Camera(Room) with private fields including at least one dynamic field of type string* (the list of amenities / dotări in the room).Provide : default constructor, parameterized constructor, copy constructor, destructor, getters and setters with validation.
P2 — operator+=.Overload += so that camera += "Minibar"; adds a new amenity to the room's dynamic array.
P3 — operator==.Overload == so that two Camera objects can be compared(equal if same room number).
P4 — operator<< and operator>>.Overload << to print a Camera to the console, and >> to read one from the console. (This is your second + third operator practice.)
P5 — A processing function adaugaDotare.A named method that adds a string to the string* array(same skill as +=, but as a regular function — Boja asks for both).
P6 — A second function areDotare.Returns true if the room has a given amenity. (Second function for practice.)
P7 — "is-a" inheritance.Create CameraDeLux that is a Camera, adding a new field(e.g. int nrUtilNopti — free nights / a luxury extra) and a constructor for it.
P8 — "has-a" composition.Create a Hotel class that has an array of Camera objects(composition), with its own constructors and a method to display all rooms.
P9 — Read an object from a file.Read a Camera from a text file.
P10 — Polymorphism.Add a virtual method(e.g.descriere()), override it in CameraDeLux, and demonstrate with a vector<Camera*> — explain overloading vs overriding, early vs late binding*//*.*/


#include<iostream>
#include<string>
#include<string.h>
using namespace std;

class Camera {

private:
	int numar;
	double pret;
	string* dotari;
	int nrDotari;

public:
	//def const 
	Camera() {
		this->numar = 0;
		this->pret = 0.0;
		this->dotari = nullptr;
		this->nrDotari = 0;

	}//end public def cosnt 


	//const cu params deep copy la dotari 
	Camera(int numar, double pret, string* dotari, int nrDotari) {

		this->numar = numar;
		this->pret = pret;
		this->nrDotari = nrDotari;
		this->dotari = new string[nrDotari];
		for (int i = 0; i < nrDotari; i++)
			this->dotari[i] = dotari[i];

	}

	//copy const = how to duplicate camera 

	Camera(const Camera& other) {
		this->numar = other.numar;
		this->pret = other.pret;
		this->nrDotari = other.nrDotari;
		this->dotari = new string[other.nrDotari];
		for (int i=0; i < other.nrDotari; i++)
			this->dotari[i] = other.dotari[i];


	}

	//dest
	~Camera() {
		delete[] dotari;

	}

	// getters

	int getNumar() {
		return this->numar;

	}

	double getPret() {
		return this->pret;
	}

	int getNrDotari() {

		return this->nrDotari;
	}

	//set cu validare

	void setNumar(int numar) {
		if (numar <= 0)
			throw "numarul de cam n are cum sa fie negativ";
		this->numar = numar;
	}

	void setPret(double pret) {

		if (pret <= 0)
			throw " pretul camerei nu are cum sa fie negativ";
		this->pret = pret;
	}


	// nu e ok setter la nrdotari pt ca asta creste odata cu dotarile, se face prin operator 
	/*void setNrDotari(int nrDotari) {

		if (nrDotari == 0)
			throw " camera nu are cum sa nu aiba nicio dotare";
		this->nrDotari = nrDotari;
	}*/


 //P2 — operator+=.Overload += so that camera += "Minibar"; adds a new amenity to the room's dynamic array.
		
	Camera& operator +=(const string& dotareNoua) {
		string* newArray = new string[nrDotari + 1];//makes 6 slots

		for (int i = 0; i < nrDotari; i ++)// fill 5 of them (old copy)
			newArray[i] = dotari[i]; //create new array - put the text from the old slot i into new slot i 
		newArray[nrDotari] = dotareNoua; //fill 6 of them
		delete[] dotari;
		dotari = newArray;
		nrDotari++;
		return *this;
	}

//P3 — operator==.Overload == so that two Camera objects can be compared(equal if same room number).

	bool operator ==(const Camera& other ) const {
		return this->numar == other.numar;

	}

//Overload the cast operator to double for the Camera class.
// A Camera used as a double must return its price per night.
// Demonstrate both implicit and explicit conversion in main().
	 
	operator double() const {
		return this->pret;
	}

	// overload -= so that camera -= " Minibar ; removes an entity from the room s dynamic array by value 
	//if the entity isn t found , all stays unchanged 

	Camera& operator-=(const string& stergeDotare) {
		
		bool gasit = false;
	
		for (int i = 0; i < nrDotari; i++) {
			if (dotari[i] == stergeDotare) {
				gasit = true;
				break;                      
			}
		}

		
		if (gasit == false)
			return *this;

		// STEP 3: build a smaller array, copy everything EXCEPT the match
		string* newArray = new string[nrDotari - 1];
		int j = 0;                           // separate counter for the new array
		for (int i = 0; i < nrDotari; i++) {
			if (dotari[i] != stergeDotare) { // copy only the ones we KEEP
				newArray[j] = dotari[i];
				j++;                         // advance new-array counter only when we copy
			}
		}

		// STEP 4: swap old array for new, update count
		delete[] dotari;
		dotari = newArray;
		nrDotari--;
		return *this;
	}

	// operator[]
	//Overload[] so that camera[2] returns the amenity at index 2 from the dynamic array.
	// Demonstrate reading an element in main().
 //(Index family.Returns a string & .One of Boja's listed operators.)


	string& operator[](int indice) {
		if (indice < 0 || indice >= nrDotari)
			throw "Index invalid!";
		return dotari[indice];

	}


	//functii
	//P5 — A processing function adaugaDotare.A named method that adds a string to the string*
	// array(same skill as +=, but as a regular function — Boja asks for both).

	 void adaugareDotare (const string& dotareNoua) {
		string* newArray = new string[nrDotari + 1];//makes 6 slots

		for (int i = 0; i < nrDotari; i++)// fill 5 of them (old copy)
			newArray[i] = dotari[i]; //create new array - put the text from the old slot i into new slot i 
		newArray[nrDotari] = dotareNoua; //fill 6 of them
		delete[] dotari;
		dotari = newArray;
		nrDotari++;
		
	}

	 //P6 — A second function areDotare.Returns true if the room has a given amenity. (Second function for practice.)

	 bool areDotare(const string& indice2) {


		 bool gasit = false;

		 for (int i = 0; i < nrDotari; i++) {
			 if (dotari[i] == indice2) {
				 gasit = true;
				 break;
			 }
		 }


		 if (gasit == false)
			 return gasit; //not *this ca ala e obiectu gen family 




	 }








};//class end 


int main() {
	string d [5] = { "ac" , "balcon" , "king-size" , "room-service" , "curatenie"};
	Camera c(14, 275, d, 5);


	Camera copie = c; // copy const 

	cout << "Camera: " << c.getNumar() << "; Pret : " << c.getPret() << " ; Dotari: " << c.getNrDotari() << endl;

	//cout operator 1


	c += "minibar";
	cout<<  "operator += overload : " << c.getNrDotari() <<" dotari " << endl;

	//operator 2 

	Camera a(221, 500, d, 4);
	Camera b(320, 400, d, 1);

	if (a == b) cout << "a si b sunt aceeasi camera ca au acelasi nr" << endl;
	else
		cout << "Camera gresita , nu e aceeasi" << endl;

	//operator 3

	double pretImplicit = c;
	double pretExplicit = (double)c;
	cout << "pret prin cast: " << (double)c << endl;
	

	

	//operator stergere

	cout << "Inainte: " << c.getNrDotari() << " dotari" << endl;

	c -= "king-size"; 
	cout << "Dupa stergere: " << c.getNrDotari() << " dotari" << endl; 

	c -= "nu exista doatrea random in array";
	cout << "Stergerea nu se poate face => " << c.getNrDotari() << endl;


	//[]
	cout << "Dotarea 0: " << c[0] << endl;   // reads first amenity
	cout << "Dotarea 2: " << c[2] << endl;   // reads third
	c[1] = "jacuzzi";                         // writes — works because string&
	cout << "Dupa modificare: " << c[1] << endl;


	//fucntie de adaugare 

	c.adaugareDotare("Piscina");
	cout << "Dupa dotare adaugata prin functie: " << c.getNrDotari() << endl;


	//bool daca exista dotarea - gresit 

	/*c.areDotare("Curatenie");
	cout << "Variabilele dupa verificare sunt: " << c.getNrDotari() << endl;

	c.areDotare("Nu exista");
	cout << "Camera nu are dotarea resp: " << c.getNrDotari() << endl;*/

	//test corect are dotare


	if (c.areDotare("ac"))
		cout << "Camera ARE dotarea ac" << endl;
	else
		cout << "Camera NU are dotarea ac" << endl;

	if (c.areDotare("nu exista"))
		cout << "Camera ARE dotarea cautata" << endl;
	else
		cout << "Camera NU are dotarea cautata" << endl;




	return 0;
}//end main