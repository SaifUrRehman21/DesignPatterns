# Clean Architecture with Mediator Design in .NET 8

This project demonstrates the implementation of Clean Architecture with Mediator Design in .NET 8. The architecture aims to provide a scalable and maintainable solution by separating concerns into distinct layers, promoting testability, and ensuring a clear separation of responsibilities.

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Project Structure](#project-structure)
- [Technologies](#technologies)
- [License](#license)

## Overview

The Clean Architecture with Mediator Design is an architectural pattern that emphasizes the separation of concerns and the independence of external frameworks. The project is structured into layers, each with a specific responsibility:

1. **Presentation Layer:** Contains the user interface and is responsible for handling user input and displaying data.

2. **Application Layer:** Orchestrates the application's business logic and interacts with the infrastructure layer.

3. **Domain Layer:** Holds the core business logic and entities, ensuring that business rules are enforced.

4. **Infrastructure Layer:** Deals with external concerns such as database access, third-party APIs, and other infrastructure-related components.

The Mediator Design pattern is employed to facilitate communication between different parts of the application in a loosely coupled manner, promoting maintainability and flexibility.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/SaifUrRehman21/DesignPatterns.git
   ```

2. Navigate to the project directory:

   ```bash
   cd BehavioralPattern
   cd Mediator
   ```

3. Build the solution:

   ```bash
   dotnet build
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

## Project Structure

```
MediatorDesign/
│
├── src/
│   ├── MediatorDesign.API/
|	|	├──Controllers
|	|	├──Helpers
|	|	|	└──Middleware
|	|	├──Middleware
|	|	├──Model
|	|	|	├──Request
|	|	|	└──Response
│   ├── MediatorDesign.Application/
|	|	├──Commands
|	|	├──Contracts
|	|	|	├──Repository
|	|	|	└──Service
|	|	├──Handlers
|	|	└──Query
│   ├── MediatorDesign.Domain/
|	|	├──ErrorManagement
|	|	├──LogManagement
|	|	├──Migrations
|	|	├──Model
|	|	|	├──DTO
|	|	|	└──Entity
│   ├──	MediatorDesign.Infrastructure/
|	|	├──Repository
|	└──	└──Service
├── README.md
└── .gitignore
```

- **src:** Contains the source code organized into different layers.

## Technologies

- .NET 8
- MediatR
- Entity Framework Core

## License

This project is licensed under the [MIT License](LICENSE).