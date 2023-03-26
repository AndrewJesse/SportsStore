<h1>Sports Store</h1>
The SportsStore application follows a clean and modular design, adhering to industry best practices and SOLID principles. It's a well-structured, scalable, and maintainable e-commerce solution built on the .NET framework, showcasing efficient implementation of essential features and modern development techniques using Docker, controllers, action methods, views, Razor Pages, Blazor, routing, validation, authentication, and more.

<h4>Features</h4>
🛒 Full-featured e-commerce application
⚙️ Built using ASP.NET Core
🐳 Docker integration for consistent development and deployment
🧪 Includes unit and integration tests
💉 Implements dependency injection
📚 Uses the repository pattern for data access
🛣️ Implements controllers, action methods, views, Razor Pages, Blazor, routing, validation, and authentication

<h4>Getting Started</h4>
Prerequisites
Visual Studio or Visual Studio Code with C# and ASP.NET Core support
.NET 6.0 SDK
Docker

<h4>Installation</h4>
Clone the repository
git clone https://github.com/yourusername/SportsStore.git
Open the solution file SportsSln.sln in Visual Studio or open the project folder in Visual Studio Code
Build the solution and run the SportsStore project
dotnet build
dotnet run --project SportsStore

Open a web browser and navigate to https://localhost:5000 to access the application

<h4>Docker Deployment</h4>
Make sure Docker is installed and running on your machine
Navigate to the project folder in the terminal or command prompt

Build the Docker image:
docker-compose build
Run the Docker container:

docker-compose up
Open a web browser and navigate to http://localhost:5000 to access the application running inside the Docker container

<h4>Running Tests</h4>
To run the tests in Visual Studio, open the Test Explorer and click "Run All Tests". In Visual Studio Code or from the command line, use the following command:
dotnet test

</h4>Built With</h4>
ASP.NET Core - Web framework
Bootstrap - CSS framework for responsive design
Entity Framework Core - Object-relational mapper (ORM) for .NET
Docker - Containerization platform for consistent development and deployment
