# Student Gradebook

A RESTful ASP.NET Core Web API project for managing Students and Teachers information, grading, and class enrollment. <br>
This project was mainly built to learn ASP.NET fundamentals, including RESTful API calls, Unit Tests, Middleware and API limitations.

# Technologies and Tools
- .NET 9.0 
- ASP.NET Core Web API
- Entity Framework Core 
- MS SQL Server 
- JWT Authentication
- Serilog for logging
- xUnit + Moq + Selenium for testing
- Scaler for API testing

# Architecture
- **API Layer** – Handles HTTP requests and responses (Controllers)
- **Business Layer** – Contains application logic (Services)
- **Infrastructure Layer** – Handles data access (EF Core, Repositories)

# Features
- User registration and authentication
- User Roles
- CRUD operations
- Student Grading
- Student Enrollment
- Internal logging via Serilog

# Authentication & Authorization
The project uses JWT for Authentication. Each API Call must have access token inside Authorization header. <br>
`Authorization: Bearer {token}` <br>
Registration and Login calls can be called without authorization header

# Configuration

Application configuration is manager via `appsettings.json`. Database connection string and JWT secret must be stored inside `"ConnectionStrings"` and `"AppSettings"` sections

# Database
MS SQL Server was used as a primary database. Entity Framework used for database migration and data access.

## Database Schema
<img width="862" height="639" alt="image" src="https://github.com/user-attachments/assets/c66ce394-a5a7-454c-99cf-5d63796f808d" />
