![StefaniniChallenge](https://even3.blob.core.windows.net/pagina-evento/stefaniniargentina-1554928407-kenobypng.287f79e797ee4b00b972.png)

# ASP.NET Core Challenge
Testing application required by Stefanini

## Features

* Docker running .NET Core SDK 2.2, ASP.NET Core 2.2
* Application structured in DDD
   * Presentation Layer
   * Application Layer
   * Domain Layer
   * Infrastructure - Data Layer
   * Infrastructure - IoC Layer
* EntityFramework Core as ORM

## Installation

### Docker

To use this project you first need Docker installed.
Downloads:

* MacOS: https://www.docker.com/docker-mac
* Windows: https://www.docker.com/docker-windows
* Other: https://www.docker.com/get-docker

Once Docker is installed you should be able to run the following from command line (terminal / cmd / powershell):  `docker -v`.

### Docker-Compose

Do you have "docker-compose" installed? If you don't have, just check `https://docs.docker.com/compose/install/` to install.

### Git

First of all, clone the repository:
```
git clone https://github.com/fabriciodsr/stefanini-challenge.git YOURFOLDERNAME
cd YOURFOLDERNAME
```

## Project Folder Structure

* [src - Folder containing the project itself](./src/)
   * [Presentation Layer](./src/StefaniniChallenge.Presentation/)
   * [Application Layer](./src/StefaniniChallenge.Application/)
   * [Domain Layer](./src/StefaniniChallenge.Domain/)
   * [Infrastructure - Data Layer](./src/StefaniniChallenge.Data/)
   * [Infrastructure - IoC Layer](./src/StefaniniChallenge.IoC/)
* [.gitignore - File which contains some files/folder that shouldn't be in Git](./.gitignore)
* [Dockerfile - File which contains the Docker image configuration](./Dockerfile)
* [docker-compose.yml - File which contains the Docker container configuration](./docker-compose.yml)
* [stefanini-challenge.sln - Visual Studio solution](./stefanini-challenge.sln)
* [README.md -- The current text that you're reading now! :)](./README.md)


### Setting up the application

You can simply run the project using the VSCode or the VStudio if you want, but I'm going to proceed with the Docker way.

Now, let's go to Docker! Just open a terminal/cmd in the project folder and type the following command: 
```
docker-compose up -d
```

This command will generate the following container:
```
stefanini-challenge
```

And the following image:
```
stefanini-challenge:latest
```

### Generating the database

The project actually is using an AWS Database, but if you want to generate yours, just change the connection in the following file: 
* [appsettings.json](./src/StefaniniChallenge.Presentation/appsettings.json)

and then run the following command to apply your changes in the application inside the Docker container:
```
docker-compose build
```

Now you need to run the migration to generate the whole structure with the following command:
```
dotnet ef database update
```
If you're using Visual Studio (and if you're prefer), just type the following command in the Package Manager Console:
```
Update-Database
```
### When you run the application, it's going to Seed the database with all you need to start using the system.

## URLs

The application is running under the following URL 
```
http://localhost:10000/
```


## Credentials

### Application

* Administrator account:
```
Username: admin@sellseverything.com
Password: admin123
```

* Seller1 account:
```
Username: seller1@sellseverything.com
Password: seller1123
```

* Seller2 account:
```
Username: seller2@sellseverything.com
Password: seller2123
```