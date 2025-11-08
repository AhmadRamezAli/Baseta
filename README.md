# 🚀 Baseta REST API Documentation

This document describes all the REST endpoints for the **Baseta Web API**.  
It is designed for frontend developers and API consumers who want to integrate with the backend.

---

## 🌐 Base URL
https:///api/


---

## 🧱 Response Structure

All endpoints return JSON in the following structure:

```json
{
  "isSuccess": true,
  "message": "THE_DATA_RETURNED_SUCCESSFULLY",
  "data": {}
}
```
Error example:
```json
{
  "isSuccess": false,
  "errorCode": "ERROR_CODE",
  "errorMessage": "Error description"
}
```
🧍 User API
POST /api/user/register

Register a new user.

Request Body
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "1234567890",
  "password": "mypassword",
  "contactInfoDtos": [
    { "type": "email", "value": "john@example.com" },
    { "type": "linkedin", "value": "https://linkedin.com/in/john" }
  ]
}
``````

Response
```json
{
  "isSuccess": true,
  "message": "THE_USER_REGISTERED_CORRECTLY",
  "data": "JWT_TOKEN_STRING"
}
```
```json
POST /api/user/login
```

Authenticate a user and return a JWT token.

Request Body
```json
{
  "phoneNumber": "1234567890",
  "password": "mypassword"
}

```
Response
```json
{
  "isSuccess": true,
  "message": "THE_USER_LOGIN_CORRECTLY",
  "data": "JWT_TOKEN_STRING"
}
```
🏷️ Category API
GET /api/category/get-all

Returns all categories.

Response
```json
{
  "isSuccess": true,
  "message": "THE_DATA_RETURNED_SUCCESSFULLY",
  "data": [
    { "id": 1, "name": "IT" },
    { "id": 2, "name": "Engineering" }
  ]
}
```
🏛️ Governarate API
GET /api/governarate/get-all

Returns all governarates.

Response
```json
{
  "isSuccess": true,
  "message": "THE_DATA_RETURNED_SUCCESSFULLY",
  "data": [
    { "id": 1, "name": "Cairo" },
    { "id": 2, "name": "Giza" }
  ]
}
```
⚙️ Type API
GET /api/type/get-all

Returns all job types.

Response
```json
{
  "isSuccess": true,
  "message": "THE_DATA_RETURNED_SUCCESSFULLY",
  "data": [
    { "id": 1, "name": "Full-Time" },
    { "id": 2, "name": "Part-Time" }
  ]
}
```
💼 Job API
```json
POST /api/job/get-all
```
Returns a paginated list of jobs.

Query Parameters
```json
Name	Type	Required	Description
pageNumber	int	✅	Page number
pageSize	int	✅	Number of items per page
```
Response
```json
{
  "isSuccess": true,
  "message": "DATA_RETURNED_SUCCESSFULLY",
  "data": {
    "items": [
      {
        "id": 1,
        "name": "Frontend Developer",
        "description": "React + TypeScript",
        "salary": 8000,
        "userName": "John Doe",
        "locationName": "Cairo",
        "categories": [{ "id": 2, "name": "IT" }],
        "types": [{ "id": 1, "name": "Full-Time" }]
      }
    ],
    "totalCount": 1,
    "pageNumber": 1,
    "pageSize": 10
  }
}
```
```json
POST /api/job/create 🔒 (Requires JWT)
```
Create a new job posting.

Headers
```json
Authorization: Bearer <token>
```

Request Body
```json
{
  "name": "Backend Developer",
  "description": "C# and SQL Server experience",
  "location": "New Cairo",
  "features": "Flexible hours",
  "jobTypeIds": [1, 2],
  "salary": 10000,
  "requirements": "5 years experience",
  "experenceRequirement": 5,
  "governarateId": 1,
  "categoryIds": [3, 5]
}

```
Response
```json
{
  "isSuccess": true,
  "message": "JOB_CREATED_SUCCESSFULLY",
  "data": {
    "id": 12,
    "name": "Backend Developer",
    "salary": 10000,
    "locationName": "New Cairo",
    "userName": "John Doe",
    "categories": [{ "id": 3, "name": "Software" }],
    "types": [{ "id": 1, "name": "Full-Time" }]
  }
}
```
```json
POST /api/job/get
```
Filter jobs by category, type, and governarate.

Query Parameters
```json
Name	Type	Required
pageNumber	int	✅
pageSize	int	✅
```
Request Body
```json
{
  "categoryIds": [1, 2],
  "typeIds": [1],
  "governarateIds": [1]
}

```
Response has the same 

```json
structure as /api/job/get-all.
```
🛠️ Service API
```json
POST /api/service/create 🔒 (Requires JWT)
```
Create a new service.

Headers

```json
Authorization: Bearer <token>
```

Request Body
```json
{
  "name": "Plumbing Service",
  "description": "Experienced plumber available 24/7",
  "categoryIds": [2, 3]
}
```

Response
```json
{
  "isSuccess": true,
  "message": "THE_SERVICE_CREATED_SUCCESSFULLY",
  "data": {
    "title": "Plumbing Service",
    "description": "Experienced plumber available 24/7",
    "user": { "id": 3, "fullName": "John Doe" },
    "serviceCategories": [
      { "id": 2, "name": "Maintenance" },
      { "id": 3, "name": "Home Services" }
    ]
  }
}
```
```json
DELETE /api/service/delete
```
Delete a service by ID.

Query Parameters
```
Name	Type	Required
serviceId	int	✅
```
Response
```json
{
  "isSuccess": true,
  "message": "THE_SERVICE_IS_SELETED_SUCCESSFULLY",
  "data": true
}
```
```json
GET /api/service/get-all
```
Return paginated list of services.

Query Parameters

Name	Type	Required
pageNumber	int	✅
pageSize	int	✅

Response
```json
{
  "isSuccess": true,
  "message": "THE_DATA_RETURNED_SUCCESSFULLY",
  "data": {
    "items": [
      {
        "title": "Electrician Service",
        "description": "All types of electrical work",
        "user": { "id": 2, "fullName": "Ali Hassan" },
        "serviceCategories": [{ "id": 1, "name": "Electrical" }]
      }
    ],
    "totalCount": 1,
    "pageNumber": 1,
    "pageSize": 10
  }
}
```
🔐 Authentication

Endpoints that require authentication use Bearer tokens (JWT).

Example

Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6Ikp...

🧩 Common DTOs

DTO	Fields
```json
CategoryDto	{ id, name }
TypeDto	{ id, name }
GovernarateDto	{ id, name }
UserDto	{ id, fullName }
JobDto	{ id, name, salary, locationName, categories[], types[], userName }
ServiceDto	{ title, description, serviceCategories[], user }
```
🧠 Notes
```json
All POST /create and DELETE endpoints require a valid JWT token.
```
Pagination uses pageNumber and pageSize for consistent results.

All timestamps are in UTC.
