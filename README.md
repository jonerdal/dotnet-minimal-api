_.NET | ASP.NET Core | API | Minimal APIs | Entity Framework | SQLite_

## Introduction
Trying out .NET minimal API, comparing it to ASP.NET MVC controller based API. This is for exploratory and learning purposes. 

The API will be a simple CRUD API. 

## Learnings
Minimal APIs works as a complement to MVC Controller based APIs and is well suited for lightweight applications with fewer dependencies, such as micro services. Minimal APIs does not support model validation out of the box. Also does not support filters or custom model binding (IModelBinder). This feels limiting for a production running API, even if it is a micro service API.

## Learn more
[Minimal APIs Overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-7.0)