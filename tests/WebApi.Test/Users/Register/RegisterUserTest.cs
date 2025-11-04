using CommomTestsUtilities.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace WebApi.Test.Users.Register;
public class RegisterUserTest: IClassFixture<CustomizedServer> 
{
    private const string METHOD = "api/User";
    private readonly HttpClient _httpClient;

    public RegisterUserTest(WebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Builder();
        var result = await _httpClient.PostAsJsonAsync(METHOD, request);

        Assert.True(result.StatusCode.Equals(StatusCodes.Status201Created));
    }
}
