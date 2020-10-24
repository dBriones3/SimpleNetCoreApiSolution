using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleNetCoreApi.Controllers;
using SimpleNetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            .UseInMemoryDatabase("TodoListDatabase")
            .Options;

            var todoContex = new TodoContext(_options);

            var todoItemsEndpoint = new TodoItemsController(todoContex);
            var item = new TodoItem
            {
                Name = "Clean my room",
                IsComplete = false
            };

            var response = await todoItemsEndpoint.PostTodoItem(item);

            var result = (OkObjectResult)response.Result;

            Assert.True(result.Value != null);
        }
    }
}
