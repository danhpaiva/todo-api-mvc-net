using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TodoApi.Controllers;
using TodoApi.Models;

namespace TodoApi.Tests.Controllers;

public class AuthControllerTests
{
    private IConfiguration GetMockConfiguration()
    {
        var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Key", "this_is_a_very_secret_key_for_jwt_testing_purposes_1234567890"},
                {"Jwt:Issuer", "TodoApiTestIssuer"},
                {"Jwt:Audience", "TodoApiTestAudience"},
            };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
    }

    [Fact]
    public void Login_WithValidCredentials_ReturnsOkWithToken()
    {
        // Arrange
        var configuration = GetMockConfiguration();
        var controller = new AuthController(configuration);
        var login = new Login { Username = "admin", Password = "senhaforte" };

        // Act
        var result = controller.Login(login);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var tokenProperty = okResult.Value.GetType().GetProperty("Token");
        Assert.NotNull(tokenProperty); // Garante que a propriedade 'Token' existe
        string token = tokenProperty.GetValue(okResult.Value) as string;
        Assert.False(string.IsNullOrEmpty(token));

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        Assert.NotNull(jwtToken);
        Assert.Contains(jwtToken.Claims, c => c.Type == JwtRegisteredClaimNames.Sub && c.Value == "admin");
        Assert.Contains(jwtToken.Claims, c => c.Type == ClaimTypes.Role && c.Value == "Admin");
        Assert.Contains(jwtToken.Claims, c => c.Type == "Permission" && c.Value == "Delete");
        Assert.Equal("TodoApiTestIssuer", jwtToken.Issuer);
        Assert.Equal("TodoApiTestAudience", jwtToken.Audiences.First());
    }

    [Fact]
    public void Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var configuration = GetMockConfiguration();
        var controller = new AuthController(configuration);
        var login = new Login { Username = "invalid", Password = "wrongpassword" };

        // Act
        var result = controller.Login(login);

        // Assert
        var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Credenciais inválidas.", unauthorizedResult.Value);
    }

    [Fact]
    public void Login_WithCorrectUsernameWrongPassword_ReturnsUnauthorized()
    {
        // Arrange
        var configuration = GetMockConfiguration();
        var controller = new AuthController(configuration);
        var login = new Login { Username = "admin", Password = "wrongpassword" };

        // Act
        var result = controller.Login(login);

        // Assert
        var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Credenciais inválidas.", unauthorizedResult.Value);
    }

    [Fact]
    public void Login_WithWrongUsernameCorrectPassword_ReturnsUnauthorized()
    {
        // Arrange
        var configuration = GetMockConfiguration();
        var controller = new AuthController(configuration);
        var login = new Login { Username = "wronguser", Password = "senhaforte" };

        // Act
        var result = controller.Login(login);

        // Assert
        var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Credenciais inválidas.", unauthorizedResult.Value);
    }
}
