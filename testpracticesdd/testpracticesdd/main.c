#include<string.h>
#include<stdio.h>
#include<stdlib.h>

//define the booking struct
typedef struct Booking {
	unsigned int booking_id;
	char* hotel;
	unsigned char rooms;
	char* guest_name;
	float price;
	char* status;
}Booking;

typedef struct TreeNode {
	Booking info;
	struct TreeNode* left;
	struct TreeNode* right;

}TreeNode;

Booking create_booking(unsigned int id, const char* hotel, unsigned char rooms,
	const char* guest, float price, const char* status) {

	Booking b;
	b.booking_id=id;
	b.rooms = rooms;
	b.price = price;

	b.hotel = (char*)malloc(strlen(hotel) + 1);
	strcpy_s(b.hotel, strlen(hotel) + 1, hotel);
	b.guest_name = (char*)malloc(strlen(guest) + 1);
	strcpy_s(b.guest_name, strlen(guest) + 1, guest);

	b.status = (char*)malloc(strlen(status) + 1);
	strcpy_s(b.status, strlen(status) + 1, status);

	return b;
}


int main() {
	//create a booking instance
	Booking booking1;
	//booking1.booking_id = 12345;
	//booking1.hotel = "Grand Hotel";
	//booking1.rooms = 2;
	//booking1.guest_name = "John Doe";
	//booking1.price = 299.99;
	//booking1.status = "Confirmed";
	////print the booking details
	//printf("Booking ID: %u\n", booking1.booking_id);
	//printf("Hotel: %s\n", booking1.hotel);
	//printf("Rooms: %u\n", booking1.rooms);
	//printf("Guest Name: %s\n", booking1.guest_name);
	//printf("Price: %.2f\n", booking1.price);
	//printf("Status: %s\n", booking1.status);
	return 0;	
}