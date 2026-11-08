# RetroHero API

A learning REST API project for a retro game store, built with ASP.NET Core and Entity Framework Core. It stores games together with their genre and platform, and supports full CRUD operations.

## WHAT I USE
- C# 
- .NET 10 
- ASP.NET Core (minimal API)
- Entity Framework Core 
- SQLite

## Features
- CRUD endpoints for games, plus read-only endpoints for genres and platforms
- DTOs to control what data enters and leaves the API
- Input validation with Data Annotations
- Database migrations and seed data with Entity Framework Core
- Asynchronous endpoints (async/await)

## Run it
Requires the .NET 10 SDK.

    git clone https://github.com/PanagiotisGia-prog/<repo-name>.git
    cd <repo-name>
    dotnet run

The database is created and seeded automatically on first run.

## Project structure
- `Model/` – entities mapped to database tables
- `DTOs/` – request and response objects
- `EndPoints/` – route handlers
- `Data/` – DbContext, seed data and migrations setup

## Credits
I built this as learning project with ASP.NET Core from the video of "ASP.NET Core Full Course For Beginners" by Julio Casal. The overall structure follows the video. The platform feature (model, relationship with games, endpoint and seed data) is my own extension, and the theme is my own.