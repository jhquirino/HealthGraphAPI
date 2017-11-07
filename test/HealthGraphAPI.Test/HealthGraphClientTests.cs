using System;
using System.Threading.Tasks;
using HealthGraphAPI;
using Xunit;
using Xunit.Abstractions;

namespace HealthGraphAPI.Test
{

    public class HealthGraphClientTests
    {

        // TODO: Generate a TestFixture
        private readonly string clientID = "<<your application client_id>>";

        private readonly string clientSecret = "<<your application client_secret>>";

        private readonly string redirectUri = "<<your application reedirect_uri>>";

        private readonly string uriRedirected = "<<paste here the URL redirected from WebBrowser>>";

        private readonly string tokenType = "Bearer";

        private readonly string accessToken = "<<your generated access token>>";

        private readonly ITestOutputHelper output;

        public HealthGraphClientTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void When_build_authorize_uri_Then_the_authorize_uri_is_returned()
        {
            // Arrange
            var auth = new HealthGraphAuth
            {
                ClientID = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            var client = new HealthGraphClient(auth);
            // Act
            var authorizeUri = client.BuildAuthorizeUri();
            // Assert
            output?.WriteLine("Authorization URL: {0}", authorizeUri);
            Assert.NotNull(authorizeUri);
        }

        [Fact]
        public void When_handle_authorization_Then_authorization_result_instance_is_returned()
        {
            // Arrange
            var auth = new HealthGraphAuth
            {
                ClientID = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            var handledUri = new Uri(uriRedirected);
            using (var client = new HealthGraphClient(auth))
            {
                // Act
                var result = client.HandleAuthorization(handledUri);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void When_read_user_with_token_Then_the_user_instance_is_returned()
        {
            // Arrange
            var auth = new HealthGraphAuth
            {
                ClientID = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            var token = new HealthGraphToken
            {
                TokenType = tokenType,
                AccessToken = accessToken
            };
            using (var client = new HealthGraphClient(auth, token))
            {
                // Act
                var user = client.ReadUser();
                // Assert
                Assert.NotNull(user);
            }
        }

        [Fact]
        public void When_read_user_without_token_Then_argument_exception_is_thrown()
        {
            // Arrange
            var auth = new HealthGraphAuth
            {
                ClientID = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            using (var client = new HealthGraphClient(auth))
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(() => client.ReadUser());
            }
        }

        [Fact]
        public async Task When_read_user_async_with_token_Then_the_user_instance_is_returned()
        {
            // Arrange
            var auth = new HealthGraphAuth
            {
                ClientID = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            var token = new HealthGraphToken
            {
                TokenType = tokenType,
                AccessToken = accessToken
            };
            using (var client = new HealthGraphClient(auth, token))
            {
                // Act
                var user = await client.ReadUserAsync();
                // Assert
                Assert.NotNull(user);
            }
        }

        [Fact]
        public async Task When_read_user_async_without_token_Then_argument_exception_is_thrown()
        {
            // Arrange
            var auth = new HealthGraphAuth
            {
                ClientID = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            using (var client = new HealthGraphClient(auth))
            {
                // Act & Assert
                await Assert.ThrowsAsync<ArgumentException>(async() => await client.ReadUserAsync());
            }
        }

    }

}
