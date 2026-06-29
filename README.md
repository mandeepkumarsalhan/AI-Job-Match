# AI Job Match

A .NET backend service that matches job listings with candidate profiles.

## Overview

The **AI Job Match** project provides APIs for creating and retrieving job postings, integrating with external services (e.g., Nav API), and handling job‑matching logic. It is built with ASP.NET Core and follows clean architecture principles.
## Features

- **Job Posting API**: Create, read, update, and delete job listings.
- **Candidate Matching**: Match jobs to candidate profiles using AI‑driven scoring.
- **External Integrations**: Seamlessly integrates with Nav API for enriched job data.
- **Clean Architecture**: Layers (Controllers, Services, Models, DTOs) promote maintainability and testability.
- **Extensible**: Easily add new data sources or matching algorithms.


## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) or later
- Visual Studio 2022 (or any IDE supporting .NET 8)
- Access to the required external APIs (e.g., Nav API) – configure credentials in `appsettings.json`.

## Getting Started

1. **Clone the repository**
   ```
   git clone <repository-url>
   cd "AI Job Match"
   ```
2. **Restore packages**
   ```
   dotnet restore
   ```
3. **Configure environment**
   - Update `appsettings.Development.json` with your API keys and connection strings.
4. **Run the application**
   ```
   dotnet run --project backend
   ```
   The API will be available at `https://localhost:5001`.

## Project Structure

```
AI Job Match/
├─ backend/
│  ├─ Controllers/          # API controllers
│  ├─ DTOs/                 # Data transfer objects
│  ├─ Integrations/         # External service clients
│  ├─ Models/               # Domain models
│  ├─ Services/             # Core business logic
│  └─ Program.cs            # Application entry point
└─ README.md                # Project documentation (this file)
```

## Building & Testing

- **Build**: `dotnet build backend`
- **Run tests** (if any): `dotnet test`

## Contributing

Feel free to open issues or submit pull requests. Please follow the existing coding style and add unit tests for new features.

## License

This project is licensed under the MIT License.

## Live Fetching Nav Demo Api in AIJobMatch App
<img width="1910" height="1034" alt="image" src="https://github.com/user-attachments/assets/77907d88-4062-483e-bdf6-14f20d306b01" />

