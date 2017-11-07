//-----------------------------------------------------------------------
// <copyright file="HealthGraphClient.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static HealthGraphAPI.Constants;

namespace HealthGraphAPI
{

    /// <summary>
    /// Health Graph REST client.
    /// </summary>
    public sealed class HealthGraphClient : IHealthGraphClient, IDisposable
    {

        #region Inner members

        /// <summary>
        /// Helper to perform HTTP requests and receiving HTTP responses from a resource identified by a URI.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Helper for <see cref="IDisposable"/> implementation, to detect redundant calls.
        /// </summary>
        private bool disposed = false;

        #endregion

        #region Properties (IHealthGraphClient)

        /// <summary>
        /// Gets the data to perform authorization/authentication flows for connecting accounts from application to Health Graph.
        /// </summary>
        public HealthGraphAuth Auth { get; private set; }

        /// <summary>
        /// Gets the token that allows the user/application to access to Health Graph.
        /// </summary>
        public HealthGraphToken Token { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphClient"/> class.
        /// </summary>
        /// <param name="auth">The data to perform authorization/authentication flows.</param>
        public HealthGraphClient(HealthGraphAuth auth)
        {
            Auth = auth ?? throw new ArgumentNullException(nameof(auth));
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphClient"/> class.
        /// </summary>
        /// <param name="auth">The data to perform authorization/authentication flows.</param>
        /// <param name="token">The token that allows the user/application access.</param>
        public HealthGraphClient(HealthGraphAuth auth, HealthGraphToken token)
        {
            Auth = auth ?? throw new ArgumentNullException(nameof(auth));
            Token = token ?? throw new ArgumentNullException(nameof(token));
            httpClient = new HttpClient();
        }

        #endregion

        #region Authorization Methods (IHealthGraphClient)

        /// <summary>
        /// Builds and returns the authorization URL to start the flow for connecting account from application to Health Graph.
        /// </summary>
        /// <returns>The authorization URL to start the flow for connecting account from application to Health Graph.</returns>
        /// <exception cref="ArgumentException">The <see cref="Auth"/> is null or has invalid values.</exception>
        public Uri BuildAuthorizeUri()
        {
            EnsureAuth();
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add(QUERY_CLIENT_ID, Auth.ClientID);
            queryBuilder.Add(QUERY_REDIRECT_URI, Auth.RedirectUri.ToString());
            queryBuilder.Add(QUERY_RESPONSE_TYPE, RESPONSE_TYPE_CODE);
            if (!string.IsNullOrEmpty(Auth.State?.Trim()))
                queryBuilder.Add(QUERY_STATE, Auth.State?.Trim());
            return new UriBuilder(URL_AUTHORIZATION)
            {
                Query = queryBuilder.ToQueryString().Value
            }.Uri;
        }

        /// <summary>
        /// Handles the authorize/de-authorize flow to access to Health Graph.
        /// </summary>
        /// <param name="uri">The URL redirected from browser.</param>
        /// <returns>The result of authorize/de-authorize flow.</returns>
        /// <exception cref="ArgumentException">The <see cref="Auth"/> is null or has invalid values.</exception>
        public HealthGraphAuthResult HandleAuthorization(Uri uri)
        {
            return HandleAuthorizationAsync(uri).Result;
        }

        /// <summary>
        /// Handles the authorize/de-authorize flow to access to Health Graph.
        /// </summary>
        /// <param name="uri">The URL redirected from browser.</param>
        /// <returns>The result of authorize/de-authorize flow.</returns>
        /// <exception cref="ArgumentException">The <see cref="Auth"/> is null or has invalid values.</exception>
        public async Task<HealthGraphAuthResult> HandleAuthorizationAsync(Uri uri)
        {
            EnsureAuth();
            var result = new HealthGraphAuthResult
            {
                Status = HealthGraphAuthStatus.None
            };
            if (uri.AbsolutePath.Equals(Auth.RedirectUri.AbsolutePath, StringComparison.OrdinalIgnoreCase))
            {
                // Parse/Validate QueryString
                var queryValues = QueryHelpers.ParseQuery(uri.Query);
                var code = queryValues.ContainsKey(QUERY_CODE) ? queryValues[QUERY_CODE].ToString() : null;
                var state = queryValues.ContainsKey(QUERY_STATE) ? queryValues[QUERY_STATE].ToString() : null;
                if (!string.Equals(Auth.State, state, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentOutOfRangeException(nameof(Auth.State));
                // Build parameters to request token
                var tokenParams = new Dictionary<string, string>
                {
                    { QUERY_CLIENT_ID, Auth.ClientID },
                    { QUERY_CLIENT_SECRET, Auth.ClientSecret },
                    { QUERY_CODE, code },
                    { QUERY_GRANT_TYPE, GRANT_TYPE_AUTHORIZATION_CODE },
                    { QUERY_REDIRECT_URI, Auth.RedirectUri.ToString() }
                };
                var request = new HttpRequestMessage(HttpMethod.Post, URL_TOKEN)
                {
                    Content = new FormUrlEncodedContent(tokenParams)
                };
                // Perform request token
                var response = await httpClient.SendAsync(request);
                // Parse/validate token response
                result.StatusCode = response.StatusCode;
                result.ContentString = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                };
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Token = JsonConvert.DeserializeObject<HealthGraphToken>(result.ContentString, serializerSettings);
                    result.Status = HealthGraphAuthStatus.Auhtorized;
                    result.ErrorCode = null;
                }
                else
                {
                    Token = null;
                    result.Status = HealthGraphAuthStatus.Error;
                    var errorObject = JsonConvert.DeserializeObject<HealthGraphAuthErrorObject>(result.ContentString, serializerSettings);
                    result.ErrorCode = errorObject.Error;
                }
            }
            return result;
        }

        #endregion

        #region User Methods

        /// <summary>
        /// Reads the user resource.
        /// </summary>
        /// <returns>An instance of <see cref="HealthGraphUser"/> with user resource information.</returns>
        /// <exception cref="ArgumentException">The <see cref="Token"/> is null or has invalid values.</exception>
        public HealthGraphUser ReadUser()
        {
            try
            {
                return ReadUserAsync().Result;
            }
            catch (AggregateException aggregateException)
            {
                throw aggregateException.InnerExceptions.FirstOrDefault();
            }
            //catch
            //{
            //    throw;
            //}
        }

        /// <summary>
        /// Reads the user resource.
        /// </summary>
        /// <returns>An instance of <see cref="HealthGraphUser"/> with user resource information.</returns>
        /// <exception cref="ArgumentException">The <see cref="Token"/> is null or has invalid values.</exception>
        public async Task<HealthGraphUser> ReadUserAsync()
        {
            return await PerformRequestAsync<HealthGraphUser>(HttpMethod.Get, PATH_USER);
        }

        #endregion

        #region IDisposable implementation

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">To free managed resources.</param>
        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                }
                Auth = null;
                Token = null;
                disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        #region Auxiliar methods

        /// <summary>
        /// Ensures that <see cref="Auth"/> is valid and has valid values.
        /// </summary>
        /// <exception cref="ArgumentException">The <see cref="Auth"/> is null or has invalid values.</exception>
        private void EnsureAuth()
        {
            if (Auth == null ||
                string.IsNullOrEmpty(Auth.ClientID?.Trim()) ||
                string.IsNullOrEmpty(Auth.ClientSecret?.Trim()) ||
                Auth.RedirectUri == null)
                throw new ArgumentException("The authorization data is not valid.", nameof(Auth));
        }

        /// <summary>
        /// Ensures that <see cref="Token"/> is valid and has valid values.
        /// </summary>
        /// <exception cref="ArgumentException">The <see cref="Token"/> is null or has invalid values.</exception>
        private void EnsureToken()
        {
            if (Token == null ||
                string.IsNullOrEmpty(Token.TokenType?.Trim()) ||
                string.IsNullOrEmpty(Token.AccessToken?.Trim()))
                throw new ArgumentException("The token data is not valid.", nameof(Token));
        }

        private string PerformRequest(HttpMethod method, string path, string query = null)
        {
            return PerformRequestAsync(method, path, query).Result;
        }

        private T PerformRequest<T>(HttpMethod method, string path, string query = null)
        {
            return PerformRequestAsync<T>(method, path, query).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The <see cref="Token"/> is null or has invalid values.</exception>
        private async Task<string> PerformRequestAsync(HttpMethod method, string path, string query = null)
        {
            EnsureToken();
            if (string.IsNullOrEmpty(path?.Trim()))
                throw new ArgumentNullException(nameof(path));
            string result = null;
            var uriBuilder = new UriBuilder(URL_BASE_API);
            uriBuilder.Path = path;
            var request = new HttpRequestMessage(method, uriBuilder.Uri);
            request.Headers.Add(nameof(request.Headers.Authorization), $"{Token.TokenType} {Token.AccessToken}");
            try
            {
                var response = await httpClient.SendAsync(request);
                result = await response.Content.ReadAsStringAsync();
            }
            catch // (System.Exception)
            {
                // TODO: Create a HealthGraphException class, instanciate and throw
                throw;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The <see cref="Token"/> is null or has invalid values.</exception>
        private async Task<T> PerformRequestAsync<T>(HttpMethod method, string path, string query = null)
        {
            EnsureToken();
            if (string.IsNullOrEmpty(path?.Trim()))
                throw new ArgumentNullException(nameof(path));
            var result = default(T);
            var uriBuilder = new UriBuilder(URL_BASE_API);
            uriBuilder.Path = path;
            var request = new HttpRequestMessage(method, uriBuilder.Uri);
            request.Headers.Add(nameof(request.Headers.Authorization), $"{Token.TokenType} {Token.AccessToken}");
            try
            {
                var response = await httpClient.SendAsync(request);
                var contentString = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                };
                result = JsonConvert.DeserializeObject<T>(contentString, serializerSettings);
            }
            catch // (System.Exception)
            {
                // TODO: Create a HealthGraphException class, instanciate and throw
                throw;
            }
            return result;
        }

        #endregion

    }

}