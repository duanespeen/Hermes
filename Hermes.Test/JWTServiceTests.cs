using Hermes.Application.Abstractions;
using Hermes.Application.Services;
using Hermes.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Hermes.Test
{
    public class JWTServiceTests
    {
        private readonly IJWTService _JWTService;
        private readonly User _user;

        public JWTServiceTests()
        {
            var inMemoryConfig = new Dictionary<string, string>{
                {"JWT:Key", "testkey" },
                { "JWT:Issuer", "test"},
                { "JWT:Audience", "test"},
                { "JWT:Subject", "test"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryConfig)
                .Build();

            _JWTService = new JWTService(configuration);
            _user = new User()
            {
                Id = 0,
                Username = "test",
                Password = "test",
                NormalizedUsername = "test"
            };
        }

        [Fact]
        public void CreateJWT_WithValidUserData_ReturnsJWT()
        {
            // Act
            var result = _JWTService.CreateJWT(_user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test", result.Subject);
            Assert.Equal("test", result.Issuer);
            Assert.Equal("test", result.Payload["username"]);
            Assert.Equal("0", result.Payload["id"]);
        }

        [Fact]
        public void CreateJWT_WithNullUserData_ReturnsNull()
        {
            // Act
            var result = _JWTService.CreateJWT(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadJWT_WithValidJWT_ReturnsSubject()
        {
            var jwt = _JWTService.CreateJWT(_user);

            // Act
            var result = _JWTService.ReadJWT(jwt);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test", result);
        }

        [Fact]
        public void ReadJWT_WithInvalidJWT_ReturnsNull()
        {
            // Act
            var result = _JWTService.ReadJWT(null);
            
            // Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void CreateJWT_ValidUser_ReturnsValidToken()
        { 

            //Act
            var result = _JWTService.CreateJWT(_user);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.ValidTo > DateTime.UtcNow);
        }


    }
}