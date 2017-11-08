//-----------------------------------------------------------------------
// <copyright file="HealthGraphAuth.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;

namespace HealthGraphAPI
{

    /// <summary>
    /// Data to perform authorization/authentication flows for connecting accounts from application to Health Graph.
    /// </summary>
    public sealed class HealthGraphAuth
    {

        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for a registered application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret for a registered application.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the page where the Health Graph API should redirect the user after accepting or denying the access request.
        /// </summary>
        public Uri RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets a parameter that represents an meaningful state for the application.
        /// </summary>
        /// <remarks>The authorization endpoint will return this value when responding to application authorization request.</remarks>
        public string State { get; set; }

        #endregion

    }

}