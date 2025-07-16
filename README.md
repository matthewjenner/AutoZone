# AutoZone

AutoZone is a comprehensive vehicle management system built with .NET 9 and React. The application provides a modern web interface for managing vehicle inventory, user registration, and vehicle transactions.

## Architecture

The solution follows a clean architecture pattern with the following components:

- **AutoZone.Api** - ASP.NET Core Web API with controllers and DTOs
- **AutoZone.Service** - Business logic layer with services
- **AutoZone.Data** - Data access layer with Entity Framework Core
- **AutoZone.Domain** - Domain models and DTOs
- **AutoZone.FrontEnd** - React frontend application
- **AutoZone.Api.Tests** - API controller tests
- **AutoZone.Service.Tests** - Service layer tests

## Quick Start

### Prerequisites

Before running the application, ensure you have the following installed:

- **Docker Desktop** - [Download here](https://www.docker.com/products/docker-desktop/)
- **Git** - [Download here](https://git-scm.com/downloads)

### Running with Docker Compose

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd AutoZone
   ```

2. **Run the application using the provided script**

   ```bash
   # On Windows (Git Bash)
   ./Scripts/run-docker.sh

   # On Linux/macOS
   chmod +x Scripts/run-docker.sh
   ./Scripts/run-docker.sh
   ```

   Alternatively, you can run Docker Compose directly:

   ```bash
   docker compose up --build -d
   ```

3. **Access the application**
   - **Frontend**: http://localhost:3000
   - **API**: http://localhost:7000
   - **SQL Server**: localhost:1433

### Manual Setup (Development)

If you prefer to run the application without Docker:

#### Backend Setup

1. **Install .NET 9 SDK**

   - Download from [Microsoft .NET](https://dotnet.microsoft.com/download)

2. **Install SQL Server**

   - Download SQL Server Express or use SQL Server LocalDB
   - Update connection string in `AutoZone.Api/appsettings.json`

3. **Run the application**

   ```bash
   # Restore packages
   dotnet restore

   # Run migrations
   cd AutoZone.Data
   dotnet ef database update

   # Run the API
   cd ../AutoZone.Api
   dotnet run
   ```

#### Frontend Setup

1. **Install Node.js**

   - Download from [Node.js](https://nodejs.org/)

2. **Install pnpm**

   ```bash
   npm install -g pnpm
   ```

3. **Run the frontend**
   ```bash
   cd AutoZone.FrontEnd
   pnpm install
   pnpm run dev
   ```

## Docker Services

The application consists of three main services:

### API Service

- **Port**: 7000 (host) → 8080 (container)
- **Technology**: ASP.NET Core 9
- **Features**: RESTful API endpoints for vehicles and users

### Frontend Service

- **Port**: 3000 (host) → 80 (container)
- **Technology**: React with Vite
- **Features**: Modern web interface for vehicle management

### SQL Server

- **Port**: 1433 (host) → 1433 (container)
- **Technology**: Microsoft SQL Server
- **Features**: Database for storing vehicle and user data

## Project Structure

```
AutoZone/
├── AutoZone.Api/              # Web API controllers and DTOs
├── AutoZone.Service/          # Business logic services
├── AutoZone.Data/             # Data access and Entity Framework
├── AutoZone.Domain/           # Domain models and DTOs
├── AutoZone.FrontEnd/         # React frontend application
├── AutoZone.Api.Tests/        # API controller tests
├── AutoZone.Service.Tests/    # Service layer tests
├── Scripts/                   # Utility scripts
├── docker-compose.yml         # Docker Compose configuration
└── README.md                  # This file
```

## Configuration

### Environment Variables

The application uses the following environment variables:

- `ASPNETCORE_ENVIRONMENT`: Development/Production
- `ConnectionStrings__DefaultConnection`: Database connection string
- `VITE_API_URL`: Frontend API URL configuration

### Database Connection

The default connection string is configured for Docker:

```
Server=sql_server;Database=AutoZoneDb;User Id=sa;Password=Your_password123;TrustServerCertificate=true;
```

For local development, update the connection string in `AutoZone.Api/appsettings.json`.

## Testing

### Running Tests

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test AutoZone.Api.Tests
dotnet test AutoZone.Service.Tests
```

### Test Structure

Tests are organized with Arrange/Act/Assert regions for better readability:

- **Arrange**: Setup test data and mocks
- **Act**: Execute the method under test
- **Assert**: Verify the expected results

## API Documentation

### Vehicle Endpoints

- `GET /api/vehicles` - Get all vehicles (with optional filtering)
- `GET /api/vehicles/{id}` - Get vehicle by ID
- `POST /api/vehicles` - Create new vehicle
- `PUT /api/vehicles/{id}` - Update existing vehicle
- `DELETE /api/vehicles/{id}` - Delete vehicle

### User Endpoints

- `POST /api/users/register` - Register new user
- `GET /api/users` - Get all users (Admin only)

### Health Check

- `GET /api/health` - Health check endpoint

## Development

### Adding New Features

1. **Domain Models**: Add entities in `AutoZone.Domain/Models/`
2. **DTOs**: Add DTOs in `AutoZone.Domain/Dtos/`
3. **Repository**: Create repository interface and implementation
4. **Service**: Add business logic in `AutoZone.Service/Services/`
5. **Controller**: Create API endpoints in `AutoZone.Api/Controllers/`
6. **Tests**: Add comprehensive tests with Arrange/Act/Assert regions

### Code Style

- Use XML documentation for all public interfaces and classes
- Use `inheritdoc` for interface implementations
- Organize tests with regions for better readability
- Follow C# coding conventions

## Troubleshooting

### Common Issues

1. **Docker containers not starting**

   - Ensure Docker Desktop is running
   - Check if ports 3000, 7000, and 1433 are available
   - Run `docker compose down` and try again

2. **Database connection issues**

   - Verify SQL Server container is running: `docker compose ps`
   - Check connection string in `appsettings.json`
   - Ensure database migrations are applied

3. **Frontend not loading**
   - Check if the API is running on port 7000
   - Verify `VITE_API_URL` environment variable
   - Check browser console for errors

### Useful Commands

```bash
# View container logs
docker compose logs -f

# Stop all services
docker compose down

# Restart services
docker compose restart

# View container status
docker compose ps

# Access SQL Server
docker exec -it autozone-sql_server-1 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Your_password123
```
