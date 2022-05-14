# Software Requirements

## Vision
In a time when more and more companies are moving towards a remote work environment, they need new ways to organize.

MAYAS-Car-Rent makes it easier for small businesses to switch to all remote office operations.

MAYAS-Car-Rent offers companies the ability to keep a car to be rented as well as maintain a new registry of employees.

## IN
- Allow an easy way to rent a car

- Allows Admin to create, update, and delete a car and employee and accept or ignore reservation.

- Allows Employee to accept or ignore reservation.

- Allows customers to create, update, and delete a reservation for the car

## OUT
- My website will never turn into an IOS or Android app.
- Won’t manage sales
- Will not track expenses

## Minimum Viable Product

- Able to view, update, create, and delete employee and car, as appropriate with the user’s permissions.

- Include unit tests for all application services.

## Stretch

- Able to view, update, create, and delete schedules. 


## Functional Requirements

- Admin can update, create, and delete all entities, view all employees, cars, and reservations

- Employees can only accept or ignore reservations and view all cars, and reservations.

- Customers can update, create, and delete reservations, and view all cars.


## Data Flow

There will be a controller for each entity implemented, which will take in a DTO object (when necessary) through an API route, and return data.

Each controller will use dependency injection to access a service object which will perform the actual database operations, and return DTO data back to the controller. The controller will not have access to actual entity data, but will only work with DTOs.

When a user signs in, they will create a token, and use that token to access the API data they have permission to access.

## Non-Functional Requirements

- **Security**

    We will employ ASP.NET Core Authorization and Identity to create Jwt tokens for users when they log in, and then those users will employ their token to gain access to the functionalities they have access to.

    Users can create an account with the login information stored in Identity or they can use an external login provider. Supported external login providers include Facebook, Google, Microsoft Account, and Twitter.

- **Testability** 

    We will employ xUnit to perform unit tests, and build the project using TDD.

    Every publicly accessible method in every service will be tested, with the unit tests written before the method(s).

- **Usability**

    API will be RESTful and return predictable data for a given internal state.

    API routes will be logical and consistent, with correct spelling and consistent pluralization.
