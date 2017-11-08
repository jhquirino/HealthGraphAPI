//-----------------------------------------------------------------------
// <copyright file="HealthGraphAPIFixture.Values.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------

namespace HealthGraphAPI.Tests
{

    /// <summary>
    /// Shared values (keys, urls) to be used by objects required to test HealthGraphAPI.
    /// </summary>
    /// <remarks>
    /// Paste your specific values before run the tests.
    /// </remarks>
    public sealed partial class HealthGraphApiFixture
    {

        /// <summary>
        /// The client_id for your registered application.
        /// </summary>
        private readonly string clientID = "<<your application client_id>>";

        /// <summary>
        /// The client_secret for your registered application.
        /// </summary>
        private readonly string clientSecret = "<<your application client_secret>>";

        /// <summary>
        /// The redirect_uri for your registered application.
        /// </summary>
        private readonly string redirectUri = "<<your application reedirect_uri>>";

        /// <summary>
        /// The URL redirected from WebBrowser (after authenticate and allow the access from your application to your Runkeeper account).
        /// </summary>
        private readonly string redirectedUri = "<<paste here the URL redirected from WebBrowser>>";

        /// <summary>
        /// The token type generated after the authorization/authentication flow.
        /// </summary>
        private readonly string tokenType = "Bearer";

        /// <summary>
        /// The access token generated after the authorization/authentication flow.
        /// </summary>
        private readonly string accessToken = "<<your generated access token>>";

    }

}