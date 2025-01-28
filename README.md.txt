API Ednpoints

Endpoint to create a class:
	/api/ClassBooking/Class

	HttpMethod : HttpPost

	Request Body:
	{
  	"name": "Zumba",
  	"startDate": "2025-01-28",
  	"endDate": "2025-01-31",
  	"duration": "01:00:00",
  	"capacity": 10,
  	"startTime": "08:00:00"
	}


Endpoint to get all classes details:

	/api/ClassBooking/Details

	HttpMethod: HttpGet


Endpoint to Book a class

	/api/ClassBooking/Booking

	HttpMethod: HttpPost

	Body:
	{
  	"classId": "f7d7a88a-7160-4807-a132-0d782c17c3a7",
  	"memberName": "Pranitha",
  	"participationDate": "2025-01-28"
	}


Endpoint to search bookings:

	api/ClassBooking/Bookings?memberName=Pranitha&startDate=2025-01-28&endDate=2025-01-29	