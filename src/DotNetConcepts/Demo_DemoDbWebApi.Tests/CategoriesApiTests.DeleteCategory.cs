using Demo_DemoDbWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;


namespace Demo_DemoDbWebApi.Tests;


public partial class CategoriesApiTests
{

    [Fact]
    public void DeleteCategory_NotFoundResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.DeleteCategory_NotFoundResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var apiController = new CategoriesController(dbContext, logger);
        int findCategoryID = 900;

        // ACT
        IActionResult actionResultDelete = apiController.DeleteCategory(findCategoryID).Result;

        // ASSERT - check if the IActionResult is NotFound 
        Assert.IsType<NotFoundResult>(actionResultDelete);

        // ASSERT - check if the Status Code is (HTTP 404) "NotFound"
        int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound;
        var actualStatusCode = (actionResultDelete as NotFoundResult)!.StatusCode;
        Assert.Equal<int>(expectedStatusCode, actualStatusCode);
    }



    [Fact]
    public async Task DeleteCategory_BadRequestResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.DeleteCategory_BadRequestResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var apiController = new CategoriesController(dbContext, logger);
        int? findCategoryID = null;

        // ACT
        IActionResult actionResultDelete = await apiController.DeleteCategory(findCategoryID);

        // ASSERT - check if the IActionResult is BadRequest 
        Assert.IsType<BadRequestObjectResult>(actionResultDelete);

        // ASSERT - check if the Status Code is (HTTP 400) "BadRequest"
        int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        var actualStatusCode = (actionResultDelete as BadRequestObjectResult)?.StatusCode ?? 0;
        Assert.Equal<int>(expectedStatusCode, actualStatusCode);
    }


    [Fact]
    public async Task DeleteCategory_OkResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.DeleteCategory_BadRequestResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var apiController = new CategoriesController(dbContext, logger);
        int findCategoryID = 1;

        // ACT
        IActionResult actionResultDelete = await apiController.DeleteCategory(findCategoryID);

        // ASSERT - if IActionResult is Ok
        Assert.IsType<NoContentResult>(actionResultDelete);

        if (actionResultDelete is not null)
        {
            // ASSERT - if Status Code is HTTP 204 (No Content)
            int expectedStatusCode = (int)System.Net.HttpStatusCode.NoContent;
            var actualStatusCode = (actionResultDelete as NoContentResult)?.StatusCode ?? 0;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    
    }

}
