﻿using Microsoft.AspNetCore.Mvc;

namespace Demo_DemoDbWebApi.Tests;


public class UnitTest1
{

    [Fact]
    public void Test1()
    {
        // ARRANGE
        int a = 10;
        int b = 20;
        int actualResult;
        int expectedResult = 30;

        // ACT
        actualResult = a + b;

        // ASSERT
        Assert.Equal<int>(expected: expectedResult, actual: actualResult);

        Assert.IsType<int>(actualResult);
    }


    [Fact]
    public void CheckIfInfo_IndexWorks()
    {
        // ARRANGE
        var controller = new Demo_DemoDbWebApi.Controllers.InfoController();
        var expectedResult = "Alter Domus India Pvt. Ltd.";

        // ACT
        var actionResult = controller.Index();

        // ASSERT
        Assert.NotNull(actionResult);

        Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(actionResult);

        var result = actionResult as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal((int)System.Net.HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(expectedResult, result.Value);
    }

}
