# MAYAS-Car-Rent

## Team 

1. Mutaz Altbakhi
2. Sultan Kanaan 
3. Ola Al-Shlool 
4. Haneen Al-Hamdan
5. AbdUlrahman Jaran 

# Introduction
In this project, We simulated the back-end of a Car Rental system using ASP.Net Core. Our aim was to comply with SOLID coding principles while performing this simulation.

---

## [Wireframe](Assest/Wirframe.jpeg)


---

## User Stories

**[Admin 1](Assest/Admin-Card1.jpeg)**

**[Admin 2](Assest/Admin-Card2.jpeg)**

**[Employee](Assest/Employee-Card.jpeg)**

**[User](Assest/User-Card.jpeg)**

---

## [Domain Modeling](Assest/Domain-Model.jpeg)

---

## [Database Schema Diagram](Assest/ERD.jpeg)

* **Company**
Companies is a class which holds the properties UserName, ProfilePicture, Email, Password, PhoneNumber,CommercialRegistrationNumber, Rate, RateCount and Address.

* **Car** 
Has Foreign Key CompanyId, It has the properties of Name, ImageUrl, Color, Year, Model, PlateNumber, PricePerDay and enum for CarType.
 
 * **CarType**
 List of three car types: Micro, Sport, Van, SUV, and Luxury. Connects to Car and nothing else.
 
 * **Reservation**
 Has two Foreign Key CompanyId and CustomerId. It has the properties of PickupDate, ReturnDate, NumberOfDays, and Price. 
 
 
 * **Customer** 
 The simple class have properties UserName, Email, Password, Gender, PhoneNumber, NationalNumber, and Address
 
 * **Employee** 
 Another simple class has properties Name, Email, Password, ProfilePicture, and PhoneNumber and has Foreign Key CompanyId.


---

## Cooperation Plan
Everyone in our team is collaborative and ready to self-learning.
We'll hold a daily meeting to discuss our progress and next steps.

---

## Conflict Plan
If a team member is late or unable to complete a task, we will divide it into portions and assign it to a different team member.
If a disagreement arises, we shall vote to resolve it.

---

## Communication Plan
We'll have a Zoom meeting at 5 p.m. for around 4 hours, and we have a Slack channel where we'll speak with each other beyond work hours and on weekends.

---

## Work Plan
Each needed work should be divided into subtasks and assigned to each team member based on his or her key strengths.

Our tool is Github it's useful for any stakeholder in the development of the project and not just the project managers. They are dynamic tools that can be completely altered to facilitate the needs of teams with different sizes and goals.

---

## Git Process
We have a table of tasks with deadline and status for each one.

| Tasks | Deadline | Status | 
|:-|:-|:-| 
| Planning | 9/5/2022 | Completeed |
| Diagram | 10/5/2022 | Completeed | 
| Entity FrameWork | 10/5/2022 | Completeed | 
| Services | 11/5/2022 | Completeed | 
| Controllers | 12/5/2022 | Completeed | 
| Identity | 15/5/2022 | Completeed | 
| Swagger | 15/5/2022 | Completeed | 


