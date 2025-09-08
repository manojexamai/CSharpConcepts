/************************************
    Add the following Nuget Packages:
        System.Net.Http.Json
******************/

using System.Net.Http.Headers;
using System.Net.Http.Json;


var client = new HttpClient();

client.BaseAddress = new Uri( "https://localhost:7204/" );

// Login and get the JWT token
var loginResponse 
    = await client.PostAsJsonAsync( "api/auth/login", new { Username = "admin", Password = "password" } );

if ( loginResponse.IsSuccessStatusCode && loginResponse.StatusCode == System.Net.HttpStatusCode.OK )
{
    var loginResult
        = await loginResponse.Content.ReadFromJsonAsync<LoginResultDto>();

    Console.WriteLine( $"Token: {loginResult?.Token}" );
    Console.WriteLine();

    // Add the Authorization Bearer Token to the Headers Collection for the request
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", loginResult?.Token );

    // Call the protected API
    var privateResponse = await client.GetStringAsync( "api/demo/private" );
    Console.WriteLine( $"Response: {privateResponse}" );
    Console.WriteLine();
}
else
{
    Console.WriteLine("Invalid credentials!");
    Console.WriteLine();
}
Console.Write( "Press any key to exit..." );
Console.ReadKey();


record LoginResultDto ( string Token );


//class LoginResultDto1
//{
//    public string? Token { get; private set; }

//    public LoginResultDto1(string? token)
//    {
//        Token = token;
//    }
//}


//// Primary Constructor Version
//class LoginResultDto2 ( string? token  )
//{
//}
