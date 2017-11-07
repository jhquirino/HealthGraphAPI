//-----------------------------------------------------------------------
// <copyright file="HealthGraphAuthStatus.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
namespace HealthGraphAPI
{

    /// <summary>
    /// Represents the authorization/authentication flow status.
    /// </summary>
    public enum HealthGraphAuthStatus
    {
        /// <summary>
        /// None status (nothing to handle).
        /// </summary>
        None = 0,
        /// <summary>
        /// An error has occurred (handled).
        /// </summary>
        Error = 1,
        /// <summary>
        /// The user authorized the application to access its Runkeeper data (handled).
        /// </summary>
        Auhtorized = 2
    }

}