✈️ Flight Booking App — 12-Milestone Roadmap
Project Goal

Build a production-style full-stack flight booking application using:

C#

ASP.NET Core

Entity Framework Core

PostgreSQL

React

TypeScript

Docker

GitHub Actions

Cloud deployment

External APIs

Payment sandbox

The goal isn't just to build an app. The goal is to become comfortable with software engineering and integration.

Milestone 1 — Project Foundation
Goal

Build the basic backend and database architecture.

Tasks

 Create the .NET solution

 Create Api project

 Create Application project

 Create Domain project

 Create Infrastructure project

 Set up PostgreSQL

 Install/configure Entity Framework Core

 Create Airport entity

 Create Aircraft entity

 Create Flight entity

 Configure entity relationships

 Create DbContext

 Create first EF Core migration

 Create PostgreSQL database

 Create basic API endpoints

 Add Swagger/OpenAPI

Initial Entities
Airport
Airport
--------
Id
Code
Name
City
Country

Aircraft
Aircraft
--------
Id
Model
Registration
SeatCapacity

Flight
Flight
------
Id
FlightNumber
DepartureAirportId
ArrivalAirportId
AircraftId
DepartureTime
ArrivalTime
Price

Checkpoint

You can:

 Create an airport

 Create an aircraft

 Create a flight

 Associate the flight with departure/arrival airports

 Associate the flight with an aircraft

 Store everything in PostgreSQL

 Retrieve the flight through your API

 Return related airport and aircraft information as JSON

Knowledge checkpoint

Be able to explain:

How does a request get from my API to PostgreSQL and back?

Milestone 2 — Flight Search
Goal

Build a realistic flight-search system.

Tasks

Create:

GET /api/flights/search


Support:

 Departure airport

 Arrival airport

 Departure date

 Number of passengers

 Filtering

 Sorting

 Pagination

 Input validation

 Appropriate HTTP status codes

Example:

Sydney → Tokyo
15 March 2027
2 passengers

Checkpoint

You can:

 Search for flights

 Return only matching flights

 Filter by date

 Sort results

 Paginate results

 Validate invalid search requests

Knowledge checkpoint

Be able to explain:

How your search query works

Why filtering happens in the database

How LINQ is translated by EF Core

How pagination works

Milestone 3 — Users & Authentication
Goal

Allow users to securely register and log in.

Tasks

Create:

User


Implement:

POST /api/auth/register
POST /api/auth/login


Learn:

 Password hashing

 JWT authentication

 Authentication vs authorization

 Claims

 Roles

 [Authorize]

Create roles:

Customer
Admin

Checkpoint

You can:

 Register an account

 Log in

 Receive a JWT

 Use the JWT to access protected endpoints

 Prevent unauthenticated users from accessing private endpoints

 Restrict admin endpoints to administrators

Knowledge checkpoint

Be able to explain:

What happens when a user logs in and subsequently calls my API?

Milestone 4 — Booking System
Goal

Build the core booking functionality.

Entities

Create:

Booking
Passenger


Relationship:

User
 ↓
Booking
 ↓
Flight


A booking can contain multiple passengers.

Tasks

Implement:

POST   /api/bookings
GET    /api/bookings
GET    /api/bookings/{id}
DELETE /api/bookings/{id}


Support:

 Multiple passengers

 Booking status

 Booking date

 Passenger details

 Price calculation

 Booking ownership

 Cancellation

Example:

John Smith
Jane Smith

Sydney → Tokyo

2 × $850
-----------
Total: $1,700

Checkpoint

A logged-in user can:

Login
 ↓
Search flight
 ↓
Select flight
 ↓
Enter passenger details
 ↓
Create booking
 ↓
View booking
 ↓
Cancel booking

Knowledge checkpoint

Be able to explain the relationships between:

User
Booking
Passenger
Flight

Milestone 5 — Seat Management
Goal

Introduce more complex business logic and concurrency.

Tasks

Create a seat-management system.

Support:

 Seat numbers

 Economy/business class

 Available/unavailable seats

 Seat selection

 Aircraft seat configuration

 Passenger seat assignment

Example:

A B C   D E F
1 1 1   1 1 1
2 2 2   2 2 2
3 3 3   3 3 3

Important problems to solve

Prevent:

 Two users selecting the same seat

 Booking more seats than are available

 Invalid seat selections

Learn:

 Database constraints

 Transactions

 Concurrency

 Race conditions

 Optimistic concurrency

Checkpoint

Two users cannot successfully book the same seat.

Knowledge checkpoint

Be able to explain:

What happens if two users try to book the same seat at exactly the same time?

Milestone 6 — React Frontend
Goal

Build the actual user interface.

Learn

 React

 TypeScript

 Components

 Props

 State

 Hooks

 Forms

 Routing

 API calls

Pages

Create:

/login
/register
/flights
/flights/:id
/booking
/my-bookings

Checkpoint

A user can use the application without Swagger:

Login
 ↓
Search flights
 ↓
View results
 ↓
Select flight
 ↓
Select seats
 ↓
Enter passenger details
 ↓
Create booking
 ↓
View confirmation

Milestone 7 — Frontend ↔ Backend Integration
Goal

Become comfortable integrating different parts of the application.

Architecture:

React
 ↓
HTTP
 ↓
ASP.NET Core
 ↓
Application
 ↓
EF Core
 ↓
PostgreSQL

Tasks

Learn:

 HTTP clients

 JSON

 DTOs

 CORS

 API error handling

 Loading states

 Authentication tokens

 Environment variables

 Frontend error handling

Handle:

200 OK
400 Bad Request
401 Unauthorized
403 Forbidden
404 Not Found
500 Internal Server Error

Checkpoint

You can deliberately break the API and your frontend responds appropriately.

Example:

API returns 401
 ↓
React detects it
 ↓
User is redirected to login

Knowledge checkpoint

Be able to explain the entire request lifecycle:

User clicks button
 ↓
React event
 ↓
HTTP request
 ↓
ASP.NET Controller
 ↓
Application/service
 ↓
Database
 ↓
Response
 ↓
React
 ↓
UI update

Milestone 8 — External API Integration
Goal

Learn how to integrate your application with an external service.

Find a suitable flight/airport data API.

Architecture:

Your Application
 ↓
ASP.NET Core
 ↓
External API
 ↓
Flight data

Tasks

Learn:

 HttpClient

 Dependency injection

 API keys

 Configuration

 JSON serialization

 JSON deserialization

 DTO mapping

 Timeouts

 Retries

 External API errors

 Logging

Do not expose the external API directly to your React frontend.

Checkpoint

Your ASP.NET application can:

 Call the external API

 Authenticate with it

 Process the response

 Map the external response into your own models

 Handle API failures

 Return appropriate data to React

Knowledge checkpoint

Be able to explain:

What happens if the external flight API goes down?

Milestone 9 — Payment Integration
Goal

Build a realistic payment workflow using a sandbox/test environment.

Architecture:

Booking
 ↓
Payment
 ↓
Payment Provider
 ↓
Payment Result
 ↓
Booking Confirmation

Tasks

Implement:

 Payment initiation

 Payment status

 Successful payment

 Failed payment

 Cancelled payment

 Booking confirmation

 Payment webhook

Learn:

 Webhooks

 Idempotency

 Transactions

 Distributed-system considerations

Checkpoint

Successful payment:

Booking
 ↓
Payment
 ↓
Success
 ↓
Booking Confirmed


Failed payment:

Booking
 ↓
Payment
 ↓
Failed
 ↓
Booking Not Confirmed

Knowledge checkpoint

Be able to explain:

Why shouldn't my application simply trust the browser when it says a payment succeeded?

Milestone 10 — Testing
Goal

Learn how to properly test software.

Unit Tests

Test business logic such as:

CalculatePrice()
CanBookFlight()
CancelBooking()
IsSeatAvailable()

Integration Tests

Test:

API
 ↓
Database

End-to-End Tests

Test important user journeys:

Login
 ↓
Search
 ↓
Book
 ↓
Confirm

Tasks

 Create unit tests

 Create integration tests

 Create end-to-end tests

 Test error cases

 Test important business rules

Checkpoint

You have automated tests covering the important business rules.

Knowledge checkpoint

Be able to explain:

What's the difference between a unit test and an integration test?

Milestone 11 — Docker + CI/CD
Goal

Make the application easier to run and deploy.

Docker

Containerize:

React
ASP.NET API
PostgreSQL


Use Docker Compose for local development.

CI/CD

Create a GitHub Actions pipeline:

Push code
 ↓
Build
 ↓
Run tests
 ↓
If successful
 ↓
Deploy

Tasks

 Create Dockerfile for API

 Create Dockerfile for frontend

 Create Docker Compose configuration

 Containerize PostgreSQL

 Run entire application locally with Docker

 Create GitHub Actions workflow

 Run tests automatically

 Build automatically

 Deploy automatically

Checkpoint

Someone can clone your repository and run:

docker compose up


and get the application running.

Your GitHub Actions pipeline automatically:

 Builds the application

 Runs tests

 Reports failures

Milestone 12 — Production + Portfolio
Goal

Turn the project into something you can confidently show employers.

Tasks

Deploy the application and add:

 Production database

 HTTPS

 Environment variables

 Secure secrets

 Logging

 Error monitoring

 Database migrations

 API documentation

 Architecture diagram

 Professional README

README should explain
What the application does

Why you built it

Architecture

Technologies

Database design

How to run it

How to test it

How it is deployed

Interesting engineering decisions

Challenges you encountered

How you solved them

Final Checkpoint

Someone you've never met can:

 Find your GitHub repository

 Understand what the application does

 Run the application

 Use the deployed application

 Understand your architecture

 See your automated tests

 Understand your major engineering decisions

You can explain every major part of the application in an interview.

Final Architecture

By the end, your application should roughly look like:

                    ┌─────────────────┐
                    │ React + TS      │
                    │ Frontend        │
                    └────────┬────────┘
                             │
                         HTTP/JSON
                             │
                             ▼
                    ┌─────────────────┐
                    │ ASP.NET Core    │
                    │ API             │
                    └────────┬────────┘
                             │
              ┌──────────────┼──────────────┐
              │              │              │
              ▼              ▼              ▼
          Auth          Booking         Flight
         Service        Service         Service
              │              │              │
              └──────────────┼──────────────┘
                             │
                             ▼
                      ┌─────────────┐
                      │ EF Core     │
                      └──────┬──────┘
                             │
                             ▼
                       PostgreSQL

             ┌─────────────────────────┐
             │ External Flight API     │
             └─────────────────────────┘

             ┌─────────────────────────┐
             │ Payment Provider        │
             └─────────────────────────┘

             ┌─────────────────────────┐
             │ Docker + CI/CD + Cloud  │
             └─────────────────────────┘

Milestone Progress Tracker
[ ] 1. Project Foundation
[ ] 2. Flight Search
[ ] 3. Users & Authentication
[ ] 4. Booking System
[ ] 5. Seat Management
[ ] 6. React Frontend
[ ] 7. Frontend ↔ Backend Integration
[ ] 8. External API Integration
[ ] 9. Payment Integration
[ ] 10. Testing
[ ] 11. Docker + CI/CD
[ ] 12. Production + Portfolio

Important Rule

Do not move to the next milestone just because you've written the code.

Move on when you can:

Build it yourself.

Debug it when it breaks.

Explain why it works.

Explain the important design decisions.

The goal isn't just to finish the flight booking app.

The goal is to finish the app and become the person who knows how to build it again.