# My Personal Gym - Fitness Management Application

## Overview

My Personal Gym is a comprehensive web application designed to manage and enhance the experience of gym goers and trainers. It provides a complete management system for user accounts, trainer schedules, exercise routines, and progress tracking.

## Features

- **User Management**: Register, authenticate, and manage user profiles
- **Exercise Database**: Comprehensive collection of exercises with descriptions and difficulty levels
- **Trainer Profiles**: Information about gym trainers and their specializations
- **Training Programs**: Predefined workout programs for different fitness goals
- **Progress Tracking**: Monitor weight, height, and workout performance over time
- **Messaging System**: Communication between trainers and clients

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Database**: SQLite 
- **Frontend**: HTML, CSS, JavaScript
- **ORM**: ADO.NET with custom data adapters

## Project Structure

### Core Components

- **App_Code**: Contains service classes and business logic
  - `UserService.cs`: User authentication and profile management
  - `TrainersService.cs`: Trainer profile management
  - `ExercisesService.cs`: Exercise database operations
  - `ProgramService.cs`: Training program management
  - `WeightService.cs`: Weight tracking functionality
  - `Connect.cs`: Database connection management

- **App_Data**: Database files and initialization scripts
  - `sqlite_schema.sql`: SQLite database schema
  - Various CSV files for data initialization

- **wwwroot**: Static files and frontend interface
  - HTML pages for each section of the application
  - CSS styling for the interface

## Setup Instructions

Please refer to the [SETUP.md](SETUP.md) file for detailed installation and configuration instructions.

## Database Schema

The application uses a relational database with the following main tables:

- **Users**: Stores user profile information
- **Trainers**: Contains trainer details and specialties
- **Exercises**: Catalog of all available exercises
- **Programs**: Workout program definitions
- **WorkOnTa**: Categories of exercises by body part
- **WeightHeight**: Tracks user body measurements over time
- **Messages**: Communication between users and trainers

## Development

### Prerequisites

- .NET SDK 8.0 or later
- SQLite

### Building and Running

```bash
# Clone the repository
git clone https://github.com/yourusername/My_Personal_Gym.git

# Navigate to the project directory
cd My_Personal_Gym

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Thanks to all contributors who have helped shape this project
- Special thanks to the SQLite team for their excellent database engine



