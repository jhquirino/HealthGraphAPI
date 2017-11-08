//-----------------------------------------------------------------------
// <copyright file="HealthGraphAPIFixture.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;

namespace HealthGraphAPI.Tests
{

    /// <summary>
    /// Shared context for HealthGraphAPI tests.
    /// </summary>
    public sealed partial class HealthGraphApiFixture : IDisposable
    {

        #region Properties

        /// <summary>
        /// Gets the data for authorization/authentication flows.
        /// </summary>
        public HealthGraphAuth Auth { get; private set; }

        /// <summary>
        /// Gets the data for access to Runkeeper resources.
        /// </summary>
        public HealthGraphToken Token { get; private set; }

        /// <summary>
        /// Gets the URL redirected from WebBrowser (after authenticate and allow the access from your application to your Runkeeper account).
        /// </summary>
        public Uri RedirectedUri => new Uri(redirectedUri);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphApiFixture"/> class.
        /// </summary>
        public HealthGraphApiFixture()
        {
            Auth = new HealthGraphAuth
            {
                ClientId = clientID,
                ClientSecret = clientSecret,
                RedirectUri = new Uri(redirectUri)
            };
            Token = new HealthGraphToken
            {
                TokenType = tokenType,
                AccessToken = accessToken
            };
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Auth = null;
            Token = null;
        }

        #endregion

    }

}