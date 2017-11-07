//-----------------------------------------------------------------------
// <copyright file="HealthGraphAuthResult.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System.Net;

namespace HealthGraphAPI
{

    /// <summary>
    /// Result object for authorization/authentication flows.
    /// </summary>
    public sealed class HealthGraphAuthResult
    {

        #region Properties

        /// <summary>
        /// Gets or sets the HTTP response status code.
        /// </summary>
        public HttpStatusCode? StatusCode { get; internal set; }

        /// <summary>
        /// Gets or sets the HTTP response content representation as string.
        /// </summary>
        public string ContentString { get; internal set; }

        /// <summary>
        /// Gets or sets flow status.
        /// </summary>
        /// <returns></returns>
        public HealthGraphAuthStatus Status { get; internal set; }

        /// <summary>
        /// Gets or sets the error code (if <see cref="Status"/> = <see cref="HealthGraphAuthStatus.Error"/>).
        /// </summary>
        /// <returns></returns>
        public string ErrorCode { get; internal set; }

        #endregion

    }

}