//-----------------------------------------------------------------------
// <copyright file="HealthGraphAPITests.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using HealthGraphAPI;
using Xunit;
using Xunit.Abstractions;

namespace HealthGraphAPI.Tests
{

    public class HealthGraphApiTests : IClassFixture<HealthGraphApiFixture>
    {

        private readonly ITestOutputHelper output;

        private readonly HealthGraphApiFixture fixture;

        public HealthGraphApiTests(ITestOutputHelper output, HealthGraphApiFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public void When_build_authorize_uri_Then_the_authorize_uri_is_returned()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth))
            {
                // Act
                var authorizeUri = client.BuildAuthorizeUri();
                output?.WriteLine("Authorization URL: {0}", authorizeUri);
                // Assert
                Assert.NotNull(authorizeUri);
            }
        }

        [Fact]
        public void When_handle_authorization_Then_authorization_result_instance_is_returned()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth))
            {
                // Act
                var result = client.HandleAuthorization(fixture.RedirectedUri);
                output?.WriteLine("Authorization handled. Status: {0}, ErrorCode: {1}. HTTP Status: {2}, Content: {3}.", result?.Status, result?.ErrorCode, result?.StatusCode, result?.ContentString);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task When_handle_authorization_async_Then_authorization_result_instance_is_returned()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth))
            {
                // Act
                var result = await client.HandleAuthorizationAsync(fixture.RedirectedUri);
                output?.WriteLine("Authorization handled. Status: {0}, ErrorCode: {1}. HTTP Status: {2}, Content: {3}.", result?.Status, result?.ErrorCode, result?.StatusCode, result?.ContentString);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void When_read_user_with_token_Then_the_user_instance_is_returned()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth, fixture.Token))
            {
                // Act
                var user = client.ReadUser();
                // Assert
                Assert.NotNull(user);
            }
        }

        [Fact]
        public async Task When_read_user_async_with_token_Then_the_user_instance_is_returned()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth, fixture.Token))
            {
                // Act
                var user = await client.ReadUserAsync();
                // Assert
                Assert.NotNull(user);
            }
        }

        [Fact]
        public async Task When_read_profile_async_with_token_Then_the_user_instance_is_returned()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth, fixture.Token))
            {
                // Act
                var profile = await client.ReadProfileAsync();
                // Assert
                Assert.NotNull(profile);
            }
        }

        [Fact]
        public void When_read_user_without_token_Then_argument_exception_is_thrown()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth))
            {
                // Act & Assert
                Assert.Throws<InvalidOperationException>(() => client.ReadUser());
            }
        }

        [Fact]
        public async Task When_read_user_async_without_token_Then_argument_exception_is_thrown()
        {
            // Arrange
            using (var client = new HealthGraphClient(fixture.Auth))
            {
                // Act & Assert
                await Assert.ThrowsAsync<InvalidOperationException>(async () => await client.ReadUserAsync());
            }
        }

    }

}