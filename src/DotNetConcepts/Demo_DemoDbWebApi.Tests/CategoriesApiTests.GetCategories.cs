using Demo_DemoDbWebApi.Controllers;
using Demo_DemoDbWebApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;


namespace Demo_DemoDbWebApi.Tests;


public partial class CategoriesApiTests
{

    [Fact]
    public async Task GetCategories_OkResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.GetCategories_OkResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var apiController = new CategoriesController(dbContext, logger);

        // ACT
        // var actionResult = apiController.GetCategories()?.Result;
        var actionResult = await apiController.GetCategories();

        // ASSERT
        // --- Check if the ActionResult is of the type OkObjectResult
        Assert.IsType<OkObjectResult>(actionResult);

        if(actionResult is not null)
        {
            // --- Check if the HTTP Response Code is 200 "Ok"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            int actualStatusCode = (actionResult as OkObjectResult)!.StatusCode ?? 0;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    }


    // NOTE: This is an Async Test (demonstrating how to call the API asynchronously)
    [Fact]
    public async Task GetCategories_CheckCorrectResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.GetCategories_OkResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var apiController = new CategoriesController(dbContext, logger);


        // ACT: Call the API action method asynchronously
        IActionResult actionResult = await apiController.GetCategories();

        // ASSERT: Check if the ActionResult is of the type OkObjectResult
        //         The GetCategories_OkResult() method handles this.  Hence, not needed.

        // ACT: Extract the OkResult result 
        var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;

        // ASSERT: if the OkResult contains the object of the Correct Type
        Assert.IsAssignableFrom<List<Category>>(okResult.Value);


        // ACT: Extract the Categories from the result of the action
        var categoriesFromApi = okResult.Value.Should().BeAssignableTo<List<Category>>().Subject;

        // ASSERT: if the categories is NOT NULL
        Assert.NotNull(categoriesFromApi);

        // ASSERT: if the number of categories in the DbContext seed data
        //         is the same as the number of categories returned in the API Result
        Assert.Equal<int>(expected: DbContextMocker.TestData_Categories.Length,
                          actual: categoriesFromApi.Count);

        // ASSERT: Test the data received from the API against the Seed Data
        int ndx = 0;
        foreach (Category category in DbContextMocker.TestData_Categories)
        {
            // ASSERT: check if the Category ID is correct
            Assert.Equal<int>(expected: category.CategoryId,
                              actual: categoriesFromApi[ndx].CategoryId);

            // ASSERT: check if the Category Name is correct
            Assert.Equal(expected: category.CategoryName,
                         actual: categoriesFromApi[ndx].CategoryName);

            _testOutputHelper.WriteLine($"Compared Row # {ndx} successfully");
            _testOutputHelper.WriteLine($" (expected) ID: {category.CategoryId} Name: {category.CategoryName}");
            _testOutputHelper.WriteLine($" (received) ID: {categoriesFromApi[ndx].CategoryId} Name: {categoriesFromApi[ndx].CategoryName}");

            ndx++;          // now compare against the next element in the array
        }
    }

}
