# Insurance Quote API

This is a .NET Core REST API that provides mock insurance quotes, with an Angular frontend served from `wwwroot`.

## Features

- Submit a quote request with:
  - `term` (policy duration)
  - `sum insured` (coverage amount)
- Retrieve a quote by ID, showing:
  - Request parameters
  - Four premiums from imaginary insurance companies
- Angular frontend:
  - Submit quote requests via UI
  - Display results
- API endpoints available at `/api/...`
- Swagger UI available at `/swagger` (development only)

## Project Structure

QuotingApi/
│-- Controllers/ # API endpoints
│-- Services/ # Quote logic
│-- wwwroot/ # Angular frontend (dist folder)
│-- Program.cs # .NET Core startup
│-- QuotingApi.sln # Solution file
│-- README.md # This file

## How to Run

1. Clone the repository:

```bash
git clone https://github.com/binaamin1991-bit/InsuranceQuoteApi.git

Open the solution QuotingApi.sln in Visual Studio.

Build and run the project.

Access:

Angular UI: https://localhost:5001/

API endpoints: https://localhost:5001/api/...

Swagger UI (dev only): https://localhost:5001/swagger

Notes

Angular app is already compiled and placed in wwwroot, no additional steps needed.

Premiums are randomly generated but remain the same while the API is running.

For development, you can enable live Angular builds if desired.

