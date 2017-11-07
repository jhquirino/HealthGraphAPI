//-----------------------------------------------------------------------
// <copyright file="IHealthGraphClient.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("HealthGraphAPI.Core")]

namespace HealthGraphAPI
{

    /// <summary>
    /// Health Graph REST client.
    /// </summary>
    public interface IHealthGraphClient
    {

        #region Properties

        /// <summary>
        /// Gets the data to perform authorization/authentication flows for connecting accounts from application to Health Graph.
        /// </summary>
        HealthGraphAuth Auth { get; }

        /// <summary>
        /// Gets the token that allows the user/application to access to Health Graph.
        /// </summary>
        HealthGraphToken Token { get; }

        #endregion

        #region Authorization Methods

        /// <summary>
        /// Builds the authorization URL to start the flow for connecting account from application to Health Graph.
        /// </summary>
        /// <returns>The authorization URL to start the flow for connecting account from application to Health Graph.</returns>
        Uri BuildAuthorizeUri();

        /// <summary>
        /// Handles the authorize/de-authorize flow to access to Health Graph.
        /// </summary>
        /// <param name="uri">The URL redirected from browser.</param>
        /// <returns>The result of authorize/de-authorize flow.</returns>
        HealthGraphAuthResult HandleAuthorization(Uri uri);

        /// <summary>
        /// Handles the authorize/de-authorize flow to access to Health Graph.
        /// </summary>
        /// <param name="uri">The URL redirected from browser.</param>
        /// <returns>The result of authorize/de-authorize flow.</returns>
        Task<HealthGraphAuthResult> HandleAuthorizationAsync(Uri uri);

        #endregion

        #region User Methods

        /// <summary>
        /// Reads the user resource.
        /// </summary>
        /// <returns>An instance of <see cref="HealthGraphUser"/> with user resource information.</returns>
        HealthGraphUser ReadUser();

        /// <summary>
        /// Reads the user resource.
        /// </summary>
        /// <returns>An instance of <see cref="HealthGraphUser"/> with user resource information.</returns>
        Task<HealthGraphUser> ReadUserAsync();

        #endregion

    }

}