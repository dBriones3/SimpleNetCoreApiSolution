# SimpleNetCoreApiSolution
A simple API using .Net Core 3.1 (C#)
Unit Test using XUnit

Set SimpleNetCoreApi as Startup project

The project has 2 endpoints:
* https://localhost:{port}/api/Greeting : Just a Get which return "Hello, world!"
* https://localhost:{port}/api/TodoItems/ : Use to add, get, delete task you want to remember as a todo list. It use a memory database so each time you stop the execution all data will be deleted. 

**Post:** Send a JSON with attributes name and IsComplete, e.g 
```JSON 
{
"name":"go to the gym",
"isComplete":false
}
```
**Get:** you will get all the items (tasks) or you can send an specific id to get just that item.

**Delete:** send the id of the item you want to delete

**Put:** send the id of the item by url and in the body the JSON with the data to update (including de id), e.g.
```JSON 
{
"id":1,
"name":"go to the gym",
"isComplete":true
}
```
