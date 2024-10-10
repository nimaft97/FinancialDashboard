# Financial Dashboard

## Overview

The **Financial Dashboard** is a software project that allows users to interact with their financial data via a user-friendly interface. Users can enter new financial transactions, query existing records, and export the data as CSV files. This project consists of two separate applications: a C# application that manages the UI and database, and a Python application that acts as a natural language processing service for generating SQL queries using a pre-trained Large Language Model (LLM). The architecture of this project mimics a microservices approach, making it adaptable for future cloud deployment.

## Use Case

This application is designed for personal finance management, allowing users to:
1. Add financial transactions (value, description, category, date) to a relational database.
2. Query financial data using SQL or natural language queries, which are converted to SQL by an LLM integrated through a Python backend.
3. Export the financial data as a CSV for easy sharing or further analysis.

## Architecture

The project consists of two applications that work together:
- **C# Application (WPF & Backend)**: This application handles the user interface, communicates with the SQLite database, and provides the functionality to execute SQL queries.
- **Python Application (LLM Service)**: This application serves as a REST API, allowing the C# application to send natural language queries. The Python app uses a pre-trained LLM to convert these queries into SQL, which is then executed by the C# application.

The separation of concerns between the two applications is an early step toward a microservices architecture, enabling scalability and flexibility for future cloud-based deployments.

## LLM Integration

The Python application integrates a pre-trained model from Hugging Face for converting natural language into SQL queries. This feature allows users to write queries in plain language, which are then transformed into SQL statements and executed on the SQLite database. Although optional, this feature is a unique selling point of the project.

## Features

- Add financial transactions to a relational database (SQLite).
- Execute SQL queries directly or using natural language via the LLM service.
- Export database records as CSV files.
- Categories for transactions are selectable via a dropdown.
- A microservices-like architecture, separating the UI/database logic from the LLM service.

## Requirements

### C# Application
- .NET 5 or later
- SQLite
- Visual Studio 2019 or later

### Python Application
- Python 3.8 or later
- Flask (`pip install Flask`)
- Hugging Face Transformers (`pip install transformers`)
- PyTorch or TensorFlow (depending on the model backend)

## Building and Running

### C# Application (FinancialDashboard)
1. Clone the repository.
2. Open the solution file (`FinancialDashboard.sln`) in Visual Studio.
3. Ensure you have .NET 5 or later installed and properly configured.
4. Build the solution (`Ctrl+Shift+B` in Visual Studio).
5. Before launching the application, ensure the Python application (LLM service) is running.

### Python Application (LLM Service)
1. Navigate to the `LLMService` folder.
2. Install dependencies via pip:
    ```bash
    pip install Flask transformers torch
    ```
3. Run the Flask server:
    ```bash
    python app.py
    ```
   The service will start listening on `http://0.0.0.0:5000`.

### Running the Full Application
1. Start the **Python Application** (LLM service) first by running the Flask server (`python app.py`).
2. Launch the **C# Application** by starting it through Visual Studio.
3. Use the UI to add financial records, execute queries, and export data.

## Database

The application uses **SQLite**, a lightweight relational database, to store financial transactions. Each record includes the following fields:
- **Value**: The monetary value of the transaction.
- **Description**: A short description of the transaction.
- **Category**: One of several predefined categories, selectable via a dropdown.
- **Date**: The date of the transaction.

The C# application communicates with the database using SQL queries, and these queries can either be written manually by the user or generated through the Python-based LLM service.

## How It Works

- **Add Transaction**: The user fills in the details of a transaction (value, description, category, and date) and clicks the "Add to Database" button. The data is inserted into the SQLite database.
- **Query Database**: The user can write an SQL query directly or input a natural language query, which is sent to the LLM service. The LLM returns a structured SQL query, which is then executed on the database.
- **Export Data**: The user can export all transaction records in the database as a CSV file for further analysis.

## Future Enhancements

Here are some potential next steps for this project:
- **User Authentication**: Add secure user authentication to allow multiple users to manage their own data.
- **Advanced Visualizations**: Integrate charting libraries to display financial data in graphs and charts.
- **Cloud Deployment**: Host the microservices on a cloud platform, ensuring scalability and availability.
- **Mobile Integration**: Create a mobile version of the dashboard for on-the-go financial management.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you find any bugs or have suggestions for improvements.

## License

This project is licensed under the MIT License.
