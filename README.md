# 📚 Sparkle Library

> ⚠️ **This project is currently under active development.**  
> So far, only the core functionality for book management is implemented.  
> The architecture is well-structured with layered separation and uses design patterns for maintainability.

## 🚀 Overview

**Sparkle Library** is a digital library system focused on modularity, clarity, and scalability.  
It features a censorship system to control content access and follows best practices for clean architecture.

## ✅ Current Features

- Basic **book service** implementation  
- Clean **layered architecture**  
- Implementation of the **Repository pattern**  
- Configured project structure with modular layers  
- Basic domain and service logic implemented

## 🧱 Architecture

The solution is divided into clearly defined layers:

- `API` — ASP.NET Core Razor Pages (presentation layer)  
- `BLL` — Business Logic Layer  
- `DAL` — Data Access Layer (Entity Framework Core)  
- `DTO` — Data Transfer Objects  
- `Common` — Shared constants and helpers 

This architecture ensures loose coupling and separation of concerns.

## 🛠️ Tech Stack

- **Language**: C#  
- **Framework**: ASP.NET Core Razor Pages
- **ORM**: Entity Framework Core  
- **Mapping**: Mapster  
- **Database**: Microsoft SQL Server

## 📦 Getting Started

- Configure your database connection string in `appsettings.json/appsettings.Development.json`
- Run the project!

## 📌 Roadmap

- 🔐 Add authentication and user roles  
- 📚 Book reading and download interface  
- 📝 User submissions and moderation tools  
- 🌐 Web frontend UI (planned)  

## 👨‍💻 Author

**Aitegin**  
[GitHub](https://github.com/Aitegin77)

---
_If you like this project, feel free to ⭐ the repository!_
