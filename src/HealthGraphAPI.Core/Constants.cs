//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------

namespace HealthGraphAPI
{

    /// <summary>
    /// Internal-use constatns
    /// </summary>
    static class Constants
    {

        /// <summary>
        /// This is the URL to which the application should redirect the user in order to authorize access to his/her Runkeeper account.
        /// </summary>
        internal const string URL_AUTHORIZATION = "https://runkeeper.com/apps/authorize";

        /// <summary>
        /// This is the URL at which the application can convert an authorization code to an access token.
        /// </summary>
        internal const string URL_TOKEN = "https://runkeeper.com/apps/token";

        /// <summary>
        /// This is the URL at which the application can disconnect itself from the user's account.
        /// </summary>
        internal const string URL_DEAUTHORIZATION = "https://runkeeper.com/apps/de-authorize";

        /// <summary>
        /// This is the base URL to access all Health Graph API resources.
        /// </summary>
        internal const string URL_BASE_API = "https://api.runkeeper.com";

        /// <summary>
        /// This is the path for the user resource.
        /// </summary>
        internal const string PATH_USER = "/user";

        /// <summary>
        /// This is the path for the user profile resource.
        /// </summary>
        internal const string PATH_PROFILE = "/profile";

        /// <summary>
        /// URL QueryString key to pass the registered application unique identifier.
        /// </summary>
        internal const string QUERY_CLIENT_ID = "client_id";

        /// <summary>
        /// URL QueryString key to pass the registered application secret.
        /// </summary>
        internal const string QUERY_CLIENT_SECRET = "client_secret";

        /// <summary>
        /// URL QueryString key to pass the page where should redirect the user after accepting or denying the access request.
        /// </summary>
        internal const string QUERY_REDIRECT_URI = "redirect_uri";

        /// <summary>
        /// URL QueryString key to pass the expected response type.
        /// </summary>
        internal const string QUERY_RESPONSE_TYPE = "response_type";

        /// <summary>
        /// URL QueryString key to pass the meaningful state for the application.
        /// </summary>
        internal const string QUERY_STATE = "state";

        /// <summary>
        /// URL QueryString key which will contain a one-time authorization code needed to obtain an access token.
        /// </summary>
        internal const string QUERY_CODE = "code";

        /// <summary>
        /// URL QueryString key which will contain the type of access granted.
        /// </summary>
        internal const string QUERY_GRANT_TYPE = "grant_type";

        /// <summary>
        /// The QueryString value to obtain the one-time authorization code needed to obtain an access token.
        /// </summary>
        internal const string RESPONSE_TYPE_CODE = "code";

        /// <summary>
        /// The QueryString value to obtain an access token.
        /// </summary>
        internal const string GRANT_TYPE_AUTHORIZATION_CODE = "authorization_code";

    }

}
