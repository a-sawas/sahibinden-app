# Sahibinden App

A full-stack classified listings desktop application built with C# WinForms and PostgreSQL.

## Features

- Card-based listings with multi-image support
- Real-time chat messaging with per-conversation threading
- Online/offline status via heartbeat system
- Admin control panel with audit logging
- BCrypt password hashing
- Guest mode with overlay prompts

## Tech Stack

| Layer | Technology |
|-------|-----------|
| UI | C# WinForms (.NET) |
| Database | PostgreSQL |
| ORM / Driver | Npgsql |
| Auth | BCrypt.Net |
| Architecture | Single MainShell with swappable UserControls |



## Getting Started

### Prerequisites
* .NET 8.0
* Visual Studio 2022
* PostgreSQL (with DBeaver installed)

### Setup

#### 1. Clone the Repository

```bash
git clone https://github.com/a-sawas/sahibinden-app.git
```

#### 2. Import the Database via DBeaver

1. Open **DBeaver** and connect to your local PostgreSQL server.
2. Create a new database named `sahibinden_db`.
3. Right-click the newly created database and select **Tools → Restore**.
4. Under the **Input File** section, select the `.backup` file provided in this repository.
5. Click **Start** to restore the database.
6. After the process completes, right-click the database and select **Refresh** to verify that all tables have been imported successfully.

#### 3. Configure Database Credentials

1. Open `SAHIBINDENapplication.sln` in Visual Studio.
2. In **Solution Explorer**, locate and open `DBHelper.cs`.
3. Find the PostgreSQL connection string and replace `YOUR_LOCAL_PASSWORD` with your local PostgreSQL password:

```csharp
Host=localhost;Port=5432;Username=YOUR_USERNAME;Password=YOUR_LOCAL_PASSWORD;Database=sahibinden_db
```

4. Save the file.

> **Note:** Ensure that the database name in the connection string matches the restored database (`sahibinden_db`).

#### 4. Run the Application

1. Build the solution.
2. Run the application from Visual Studio.

---


# Test Accounts

Use the following pre-configured accounts to test the application:

| Username     | Password   | Role          |
| ------------ | ---------- | ------------- |
| admin        | 12345678a  | Admin         |
| admin second | 12345678a2 | Admin         |
| moo          | 12345678m  | Standard User |
| testuser     | 12345678t  | Standard User |

---

# Important Note Regarding Listing Images

> No listing photos are included in this database backup, and the `listing_images` table has been intentionally left empty.

The application currently stores image locations using **absolute local file paths**. Since these paths are specific to the original development environment, they would be invalid on other machines and result in broken image references.

To avoid errors and ensure a smooth testing experience, listing images have been excluded from the database dump.




## License

MIT