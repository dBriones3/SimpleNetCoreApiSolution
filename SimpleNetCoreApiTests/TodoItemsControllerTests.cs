using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleNetCoreApi.Controllers;
using SimpleNetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleNetCoreApiTests
{
    public class TodoItemsControllerTests
    {

        [Fact]
        public async Task ShouldAddAnItem()
        {
            var _options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(new Guid().ToString())
            .Options;

            var todoContex = new TodoContext(_options);
            var todoItemsEndpoint = new TodoItemsController(todoContex);
            var item = new TodoItem
            {
                Name = "Clean my room",
                IsComplete = false
            };

            var response = await todoItemsEndpoint.PostTodoItem(item);

            
            Assert.Equal(item, ((ObjectResult)response.Result).Value);
        }

        [Fact]
        public async Task ShouldGetItems()
        {
            var _options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(new Guid().ToString())
            .Options;

            var todoContex = new TodoContext(_options);
            var todoItemsEndpoint = new TodoItemsController(todoContex);
            var item1 = new TodoItem
            {
                Name = "Clean my room",
                IsComplete = false
            };

            var item2 = new TodoItem
            {
                Name = "Make unit test",
                IsComplete = false
            };

            await todoItemsEndpoint.PostTodoItem(item1);
            await todoItemsEndpoint.PostTodoItem(item2);

            var getResponse = await todoItemsEndpoint.GetTodoItems();

            Assert.True(getResponse.Value.Count() == 2);
        }

        [Fact]
        public async Task ShouldGetAnItem()
        {
            var _options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(new Guid().ToString())
            .Options;

            var todoContex = new TodoContext(_options);
            var todoItemsEndpoint = new TodoItemsController(todoContex);
            var item1 = new TodoItem
            {
                Name = "Clean my room",
                IsComplete = false
            };

            var item2 = new TodoItem
            {
                Name = "Make unit test",
                IsComplete = false
            };

            await todoItemsEndpoint.PostTodoItem(item1);
            await todoItemsEndpoint.PostTodoItem(item2);

            var getResponse = await todoItemsEndpoint.GetTodoItem(1);

            Assert.True(getResponse.Value.Id == 1);
        }

        [Fact]
        public async Task ShouldDeleteAnItem()
        {
            var _options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(new Guid().ToString())
            .Options;

            var todoContex = new TodoContext(_options);
            var todoItemsEndpoint = new TodoItemsController(todoContex);
            var item1 = new TodoItem
            {
                Name = "Clean my room",
                IsComplete = false
            };

            var item2 = new TodoItem
            {
                Name = "Make unit test",
                IsComplete = false
            };

            await todoItemsEndpoint.PostTodoItem(item1);
            await todoItemsEndpoint.PostTodoItem(item2);

            var response = await todoItemsEndpoint.DeleteTodoItem(1);

            var getResponse = await todoItemsEndpoint.GetTodoItems();

            Assert.True(response.Value.Id == 1);
        }
    }
}
