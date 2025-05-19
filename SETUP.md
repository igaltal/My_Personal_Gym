# My Personal Gym - Setup Guide

This is a .NET 6.0 web application for gym management. Follow these steps to set up and run the application.

## Prerequisites

- .NET 6.0 SDK or later
- SQLite (for database)

## Installing .NET SDK on Linux

Before running the application, you need to install the .NET SDK:

### Ubuntu/Debian:

```bash
# Install the package repository
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Install the SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0
```

### Using Snap:

```bash
sudo snap install dotnet-sdk --classic
```

## Setup Steps

1. Clone the repository to your local machine.

2. The SQLite database should be already set up in the `App_Data` directory.
   - If the database is not present, run this command:
   ```bash
   sqlite3 App_Data/Datatal.db < App_Data/sqlite_schema.sql
   ```

3. Ensure the connection string in `App_Code/Connect.cs` points to your database file.
   - The default configuration uses a relative path that should work across platforms.

## Running the Application

1. Open a terminal in the project directory.

2. Run the following command to restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open a web browser and navigate to:
   - https://localhost:7167 (for HTTPS)
   - http://localhost:5167 (for HTTP)

   Note: The actual ports might differ based on your system configuration. Check the console output for the exact URLs.

## Troubleshooting

- If you encounter database connection issues, check the path in `App_Code/Connect.cs` and ensure it points to the correct database file.
- Make sure you have sufficient permissions to read/write to the database file.
- If you get a "command not found" error for dotnet, ensure you've properly installed the .NET SDK using the instructions above. 