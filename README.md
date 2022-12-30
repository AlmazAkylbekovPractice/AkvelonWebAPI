
Welcome to the task and projects tracker Web API project for Akvelon Internship Program! This API allows you to store and manage information about tasks and projects in a database.

This project has been built using .Net or .Net Core and EntityFramework / EntityFramework Core. It also uses a PostgreSQL relational DBMS. Swagger has been implemented for automated API documentation.

The project follows a three-level architecture with a data access layer, a logic layer, and a representation layer. Any third-party frameworks and packages used are publicly available.

To get more information look at PDF Documentation file. The source files and project files are included in the repository.

The API allows you to perform the following actions:

-Create, view, edit, and delete information about projects
-Create, view, edit, and delete task information
-Add and remove tasks from a project (one project can contain several tasks)

Project information that is stored includes the name of the project, the start and completion dates, the current status of the project (enum: NotStarted (0), Active (1), Completed(2)), and the priority (int).
Task information that is stored includes the task name, task status (enum: ToDo (0) / InProgress (1) / Done (2)), description, and priority (int).

This API has been built with flexibility in mind and it is easy to add new fields to the Task entity.

It is recommended to deploy and provide public access to the application using Docker for optimal performance. The README.md file provides more information about the product, technologies, and templates used, as well as instructions for use.

We hope you find this API helpful in managing your tasks and projects.