//-----------------------------------------------------------------------
// <copyright file="HealthGraphToken.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------

namespace HealthGraphAPI
{

    /// <summary>
    /// Token to access Health Graph API.
    /// </summary>
    public sealed class HealthGraphToken
    {

        #region Properties

        /// <summary>
        /// Access token to authenticate to Health Graph API.
        /// </summary>
        /// <remarks>This string uniquely identifies the association of the application to the user's Health Graph/Runkeeper account.</remarks>
        public string AccessToken { get; set; }

        /// <summary>
        /// Authorization type: "Bearer" in this case.
        /// </summary>
        public string TokenType { get; set; }

        #endregion

    }

}