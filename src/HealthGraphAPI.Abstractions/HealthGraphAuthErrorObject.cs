//-----------------------------------------------------------------------
// <copyright file="HealthGraphAuthErrorObject.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
namespace HealthGraphAPI
{

    /// <summary>
    /// Simple error object for authorization/authentication flows.
    /// </summary>
    internal sealed class HealthGraphAuthErrorObject
    {

        #region Properties

        /// <summary>
        /// Gets or sets the error occurred.
        /// </summary>
        public string Error { get; set; }

        #endregion

    }

}