using Demo_DemoDbWebApi.Controllers;
using Demo_DemoDbWebApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Demo_DemoDbWebApi.Tests;

/// <remarks>
///     Bad insertion data scenarios:
///     - Name is NULL
///     - Name is EMPTY STRING
///     - Name contains lesser number of characters than what is required
///     - Name contains more characters than what is allowed
///     - NULL Category object
///     
///     LIMITATIONS OF WORKING WITH InMemory Database
///     - Relationships between Tables are not supported.
///     - EF Core DataAnnotation Validations are not supported.
///     - Identity Generation Policies are not fully supported.
/// </remarks>

public partial class CategoriesApiTests
{

    [Fact]
    public async Task InsertCategory_OkResult()
    {
        // ARRANGE
        var dbName = nameof(CategoriesApiTests.InsertCategory_OkResult);
        var logger = Mock.Of<ILogger<CategoriesController>>();
        var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        var apiController = new CategoriesController(dbContext, logger);
        Category categoryToAdd = new Category
        {
            CategoryId = 5,           // because inmemory db, identity insert is not supported. provide value.
            CategoryName = "New Category"             // IF = null, then: INVALID!  CategoryName is REQUIRED
        };

        // ACT
        var actionResultPost = await apiController.PostCategory(categoryToAdd);

        // ASSERT - check if the IActionResult is not null
        Assert.NotNull(actionResultPost);

        // ASSERT - if the result is a CreatedAtActionResult
        Assert.IsType<CreatedAtActionResult>(actionResultPost.Result);

        // Category? postResult = actionResultPost.Value;

        // Extract the inserted Category object
        Category insertedCategory = (actionResultPost.Result as CreatedAtActionResult)!.Value
                                  .Should().BeAssignableTo<Category>().Subject;

        // ASSERT - if the inserted Category object is NOT NULL
        Assert.NotNull(insertedCategory);

        Assert.Equal(categoryToAdd.CategoryId, insertedCategory.CategoryId);
        Assert.Equal(categoryToAdd.CategoryName, insertedCategory.CategoryName);

        _testOutputHelper.WriteLine("Category Inserted successfully!");
    }

}
