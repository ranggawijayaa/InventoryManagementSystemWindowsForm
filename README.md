# Inventory Management System

## Description
The Inventory Management System is a robust application designed to manage products, categories, and stock levels. This system is built using C#, .NET 8, and SQLite, applying SOLID principles and best practices such as dependency injection and the repository pattern. The user interface is created with WinForms.

## Features
- Add, update, delete products
- Categorize products
- View stock levels
- Alerts when stock is low

## Technologies Used
- C#
- .NET 8
- SQLite
- Entity Framework Core
- WinForms

## Project Structure
InventoryManagement
│ InventoryManagement.sln
│
└───InventoryManagement.Domain
│ │ IProductRepository.cs
│ │ Product.cs
│
└───InventoryManagement.Infrastructure
│ │ ApplicationDbContext.cs
│ │ ProductRepository.cs
│
└───InventoryManagement.WinForms
│ MainForm.cs
│ AddProductForm.cs
│ UpdateProductForm.cs
│ Program.cs


## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 (or later)
- SQLite

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/inventory-management-system.git
    ```
2. Navigate to the project directory:
    ```bash
    cd inventory-management-system
    ```
3. Open the solution file in Visual Studio:
    ```bash
    InventoryManagement.sln
    ```

### Build and Run
1. Build the solution in Visual Studio to restore the NuGet packages.
2. Run the application.

## Usage

### Adding a Product
1. Click the "Add" button.
2. Fill in the product details.
3. Click "Add" to save the product.

### Updating a Product
1. Select a product from the list.
2. Click the "Update" button.
3. Modify the product details.
4. Click "Update" to save the changes.

### Deleting a Product
1. Select a product from the list.
2. Click the "Delete" button.
3. Confirm the deletion.

## Architecture and Design
The project follows the SOLID principles and uses a clean architecture with the following layers:
- **Domain Layer**: Contains business entities and repository interfaces.
- **Infrastructure Layer**: Contains the database context and repository implementations.
- **Presentation Layer**: Contains the UI and application logic.