# BookMVC

BookMVC is a web-based library management system built with ASP.NET Core MVC. This application allows users to **add, update, delete, and rent books**, as well as manage **users and categories**. It provides a simple yet powerful interface for managing a book rental system efficiently.

## Features

✅ **Book Management**  
- Add new books with title, author, stock, and category.
- Update book details.
- Delete books.

✅ **User Management**  
- Add new members.
- Update member details.
- Delete members.

✅ **Book Rental System**  
- Rent books to users.
- Track rented books.
- Return books and update stock.

✅ **Category Management**  
- Add and update book categories.
- Assign books to categories.

## Installation & Setup

### Prerequisites
Before running this project, make sure you have:
- **.NET SDK** (6.0 or later)
- **SQL Server**
- **Entity Framework Core**

### Clone the Repository
```sh
git clone https://github.com/Sandoval-dev/BookMVC.git
cd BookMVC
```

### Configure Database
1. Open `appsettings.json` and update the **connection string**:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BookDB;Trusted_Connection=True;"
}
```
2. Apply Migrations & Seed Data:
```sh
dotnet ef database update
```

### Run the Project
```sh
dotnet run
```
The application will be available at `http://localhost:5000`.

## API Endpoints
| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | `/Books` | Get all books |
| POST | `/Books/Create` | Add a new book |
| POST | `/Books/Update` | Update book details |
| POST | `/Books/Delete/{id}` | Delete a book |
| GET | `/Categories/GetMainCategory` | Get main categories |
| GET | `/Categories/GetSubCategory?mainCategoryId={id}` | Get subcategories |

## Technologies Used
- **ASP.NET Core MVC** - Web framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database
- **jQuery & AJAX** - Frontend dynamic interactions
- **Bootstrap** - UI styling

## Contributing
Pull requests are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch: `git checkout -b feature-branch`.
3. Commit your changes: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature-branch`.
5. Open a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---


