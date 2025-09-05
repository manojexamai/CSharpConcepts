using Demo_DemoDbWebApi.Controllers;
using Demo_DemoDbWebApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Demo_DemoDbWebApi.Tests;

public partial class CategoriesApiTests
{

    [Fact]
    public async Task GetCategoryById_NotFoundResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.GetCategoryById_NotFoundResult);
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var apiController = new CategoriesController(dbContext, logger);
        int findCategoryID = 900;

        // ACT
        IActionResult actionResultGet = await apiController.GetCategory(findCategoryID);

        // ASSERT - check if the IActionResult is NotFound 
        Assert.IsType<NotFoundResult>(actionResultGet);

        if (actionResultGet is not null)
        {
            // ASSERT - check if the Status Code is (HTTP 404) "NotFound"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound;
            int actualStatusCode = (actionResultGet as NotFoundResult)!.StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    }


    [Fact]
    public async Task GetCategoryById_BadRequestResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.GetCategoryById_BadRequestResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var controller = new CategoriesController(dbContext, logger);
        int? findCategoryID = null;

        // ACT
        IActionResult actionResultGet = await controller.GetCategory(findCategoryID);

        // ASSERT - check if the IActionResult is BadRequest
        Assert.IsType<BadRequestObjectResult>(actionResultGet);

        if (actionResultGet is not null)
        {
            // ASSERT - check if the Status Code is (HTTP 400) "BadRequest"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            int actualStatusCode = (actionResultGet as BadRequestObjectResult)!.StatusCode ?? 0;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    }


    [Fact]
    public async Task GetCategoryById_OkResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.GetCategoryById_OkResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var controller = new CategoriesController(dbContext, logger);
        int findCategoryID = 2;

        // ACT
        IActionResult actionResultGet = await controller.GetCategory(findCategoryID);

        // ASSERT - if IActionResult is Ok
        Assert.IsType<OkObjectResult>(actionResultGet);

        // ASSERT - if Status Code is HTTP 200 (Ok)
        if (actionResultGet is not null)
        {
            // --- Check if the HTTP Response Code is 200 "Ok"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            int actualStatusCode = (actionResultGet as OkObjectResult)!.StatusCode ?? 0;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    }


    [Fact]
    public async Task GetCategoryById_CorrectResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.GetCategoryById_OkResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var controller = new CategoriesController(dbContext, logger);
        int findCategoryID = 2;
        Category? expectedCategory 
            = DbContextMocker.TestData_Categories
                             .SingleOrDefault(c => c.CategoryId == findCategoryID);

        // ACT
        IActionResult actionResultGet = await controller.GetCategory(findCategoryID);

        // ASSERT - if IActionResult is Ok
        Assert.IsType<OkObjectResult>(actionResultGet);

        // ASSERT - if IActionResult (i.e., OkObjectResult) contains an object of the type Category.
        OkObjectResult okResult = actionResultGet.Should().BeOfType<OkObjectResult>().Subject;
        Assert.IsType<Category>(okResult.Value);

        // Extract the category object from the result.
        Category actualCategory = okResult.Value.Should().BeAssignableTo<Category>().Subject;
        _testOutputHelper.WriteLine($"Found: CategoryID == {actualCategory.CategoryId}");

        // ASSERT - if category is NOT NULL.
        Assert.NotNull(actualCategory);

        if (expectedCategory is not null && actualCategory is not null)
        {
            // ASSERT - if the CategoryId is containing the expected data.
            Assert.Equal<int>(expected: expectedCategory.CategoryId,
                              actual: actualCategory.CategoryId);

            // ASSERT - if the CateogoryName is correct 
            Assert.Equal(expected: expectedCategory.CategoryName,
                         actual: actualCategory.CategoryName);
        }
    }

}
