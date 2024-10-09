
# Todo List Management Web API

## Overview
The Todo List Management API is a task management system built using .NET Core 8. This API allows users to manage tasks by creating, updating, and deleting them. Users can also track task completion, prioritize tasks, assign them to team members, and set due dates. The system provides endpoints to filter tasks by status and priority for efficient management.

## Features
- **Task Creation**: Add tasks with titles, descriptions, due dates, priorities, and assignments.
- **Task Management**: Update or delete existing tasks.
- **Task Filtering**: Filter tasks by their completion status and priority.
- **Task Status**: Mark tasks as completed or pending.
- **Due Dates & Prioritization**: Assign due dates and priorities to tasks.
- **User Assignment**: Assign tasks to responsible individuals.
- **Swagger Documentation**: Interactive API documentation via Swagger.
- **Timestamps**: Track task creation and modification times automatically.

## Technologies
- **Backend**: .NET Core 8
- **Database**: Entity Framework Core with SQL Server (localdb)
- **API Documentation**: Swagger (OpenAPI)

## Prerequisites
Before running the project, make sure you have the following installed:
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- (Optional) [Postman](https://www.postman.com/downloads/) for testing the API

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/YunusAlamm/To-Do-List.git
cd To-Do-List
```

### 2. Configure the Database
The project uses SQL Server LocalDB by default. No changes are necessary if you’re using LocalDB. The connection string is as follows:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ToDoListDb;Trusted_Connection=True;"
}
```

If you need to use a different database, update the connection string in `appsettings.json` to point to your database server.

### 3. Run the Application
Run the project using the .NET CLI:

```bash
dotnet run
```

This will start the application at the following URLs based on your launch settings:
- **HTTP**: `http://localhost:5007`
- **HTTPS**: `https://localhost:7001`

You can also access the app via the IIS Express URL:
- **IIS Express**: `http://localhost:55621` (HTTP)
- **IIS Express (SSL)**: `https://localhost:44316` (HTTPS)

### 4. Access Swagger
Swagger is enabled for API documentation and can be accessed at:
```
https://localhost:7001/swagger
```
or
```
http://localhost:5007/swagger
```

## API Endpoints

### Task Management Endpoints

| HTTP Method | Endpoint                    | Description                            |
|-------------|-----------------------------|----------------------------------------|
| `POST`      | `/api/tasks`                | Create a new task                      |
| `GET`       | `/api/tasks`                | Get tasks (filter by completion status or priority) |
| `GET`       | `/api/tasks/{id}`           | Get task by ID                         |
| `PUT`       | `/api/tasks/{id}`           | Update an existing task by ID          |
| `DELETE`    | `/api/tasks/{id}`           | Delete a task by ID                    |

### Example API Requests

- **Create a new task**:
  ```bash
  POST /api/tasks
  {
    "title": "New Task",
    "description": "Task details",
    "isComplete": false,
    "status": "In Progress",
    "priority": "High",
    "dueDate": "2024-12-31",
    "assignedTo": "John Doe"
  }
  ```

- **Get tasks**:
  - Completed tasks:
    ```bash
    GET /api/tasks?flag=true
    ```
  - Incomplete tasks with priority "High":
    ```bash
    GET /api/tasks?flag=false&priority=high
    ```

- **Update a task**:
  ```bash
  PUT /api/tasks/{id}
  {
    "title": "Updated Task Title",
    "description": "Updated description",
    "isComplete": true,
    "status": "Completed",
    "priority": "Low",
    "dueDate": "2024-11-30",
    "assignedTo": "Jane Doe"
  }
  ```

- **Delete a task**:
  ```bash
  DELETE /api/tasks/{id}
  ```

## Running Tests
The project includes unit tests to validate the functionality of the API. To run tests:
```bash
dotnet test
```

## Contributing
We welcome contributions! Here's how you can get started:
1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to your branch (`git push origin feature-name`).
5. Create a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
For questions or support, reach out via:
- Email: alamdari.yoonos@gmail.com
- GitHub: [YunusAlamm
](https://github.com/YunusAlamm
)

---

### Changes Based on Your Configuration:
1. **Connection String**: Reflects the use of SQL Server LocalDB as seen in `appsettings.json`.
2. **Launch URLs**: Updated to show the URLs for both HTTP (`http://localhost:5007`) and HTTPS (`https://localhost:7001`), and IIS Express.
3. **Swagger URL**: Updated based on the `launchsettings.json` file.
4. **Optional Configuration**: Added that you can modify the connection string if using a database other than LocalDB.

