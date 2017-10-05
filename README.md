# .NET WebApi 2.0 Template
This repository contains a Visual Studio Solution that comes in handy when creating web services.

## Installation

You can use the Download ZIP under the Clone or download button.

You can also clone it using the git CLI.

## Projects
1. [Database Project](#database-project)
2. [Entities Project](#entities-project)
3. [Data Access Project](#data-access-project)
4. [Services Project](#services-project)

## Database Project
This is a SQL Project, it contains the create statements for the database structure.

There only thing to consider when creating your tables is that the data access is prepared to handle transactions with an identifier. So your ID column would have to look something like this:

```SQL
CREATE TABLE [dbo].[TableName] 
(
    [Id] INT NOT NULL IDENTITY(1,1)
    --The rest of the columns

    CONSTRAINT [PK_TableName] PRIMARY KEY (Id)
)
```

## Entities Project
The entities project contains POCOs (Plain Old C# Objects) matching the database tables.

An example is the [DemoEntity](./Entities/DemoEntity.cs).

## Data Access Project
The data access project is where all the code to send and retrieve data from the DB is.

When creating a new entity you need to do the following steps in the Data Access:
* Create a folder with the entity name inside the `Queries` Folder.
* Create the required queries for the entity, remember you can use the [Demo Queries](../blob/master/DataAccess/Interfaces/IDemoRepository.cs).
* Build the [interface](../blob/master/DataAccess/Interfaces) that will define which methods your repository is going to implement. This is an escential part for [Dependency Injection](#dependency-injection).
* Create the Repository that is going to extend `BaseRepository` and implement the interface you created. Here is where you are going to have all your database code. You can take a look at the [DemoRepository](../blob/master/DataAccess/Repositories/DemoRepository.cs).


## Services Project
This is the project that centralizes all the other ones. Here is where your code runs.

The two important things that you need to know is that this project uses Dependency Injection, explained below. And that you need to create at least one Controller for each entity that you want. (That is for handling CRUD Operations only).

### Controllers
The controller is the class that is going to handle HTTP Requests. Each controller takes an URL (`/api/Demo` for example). 

Please use the Http Verbs accordingly:
* `HTTP GET` For reading operations
* `HTTP POST` For create transactions
* `HTTP PUT` For update transactions
* `HTTP DELETE` For delete transactions

### Dependency Injection
DI is a pattern that solves the problem of having to create multiple instances of the same object in high concurreny environments.

It doesn't matter if your API is going to be consumed by only one client, why would you ever need to create a new repository for each request when its serving the same methods, right?

The dependency injection framework we are using in this project is Unity. its configuration, and where you are going to define your repositories is the [UnityConfig](../blob/master/Services/App_Start/UnityConfig.cs).

Basically what you need to configure, is an instance of which class are you going to pass in as a parameter when the controllers request a certain interface.

```Csharp
container.RegisterType<IDemoRepository, DemoRepository>();
```

This way, we can now request a repository inside a controller constructor like this:

```Csharp
private IDemoRepository _repo { get; set; }

public DemoController(IDemoRepository repo)
{
    _repo = repo;
}
```

