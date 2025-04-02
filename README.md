# PWA-API

## Getting Started

To get started with the PWA-API project, follow the steps below:

### Prerequisites

Ensure you have the following programs installed:

- [Node.js](https://nodejs.org/) (version 14 or higher)
- [npm](https://www.npmjs.com/) (usually comes with Node.js)
- [Git](https://git-scm.com/)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
- [.NET SDKs](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [Visual Studio Code](https://code.visualstudio.com/) or any other preferred code editor

### Installation

1. **Clone the repository**

    ```sh
    git clone https://github.com/thedakotes/PWA-API.git
    cd PWA-API
    ```

2. **Install dependencies**

    ```sh
    npm install
    ```

3. **Set up the Database**

    - Open SQL Server Management Studio (SSMS)
    - Connect to your SQL Server instance
    - Create a new database for the application
    - Update the connection string in the application to point to your new database

4. **Set up .NET Environment**

    - Install the required .NET SDK version
    - Ensure that your environment variables are set correctly for the .NET SDK

### Running the Application

To start the application, use the following command:

```sh
npm start
```

This will start the server, and you can access the API at `http://localhost:3000`.

### Running Tests

To run tests, use the following command:

```sh
npm test
```

### Building for Production

To build the application for production, use the following command:

```sh
npm run build
```

This will create a `build` directory with the production files.

### Contributing

If you would like to contribute to this project, please follow these steps:

1. Fork the repository
2. Create a new branch (`git checkout -b feature-branch`)
3. Make your changes
4. Commit your changes (`git commit -m 'Add some feature'`)
5. Push to the branch (`git push origin feature-branch`)
6. Open a pull request

### License

This project is licensed under the MIT License.
