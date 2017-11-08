//-----------------------------------------------------------------------
// <copyright file="HealthGraphException.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace HealthGraphAPI
{

    /// <summary>
    /// Represents errors that occur during Health Graph API requests.
    /// </summary>
    [Serializable]
    public class HealthGraphException : Exception
    {

        #region Properties

        /// <summary>
        /// Gets or sets the resource reference property.
        /// </summary>
        public Uri RequestUri { get; }

        #endregion

        #region Constructors (base)

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphException"/> class.
        /// </summary>
        public HealthGraphException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public HealthGraphException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public HealthGraphException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected HealthGraphException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            RequestUri = new Uri(info.GetString(nameof(RequestUri)));
        }

        #endregion

        #region Constructors (custom)

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="requestUri">The request URI.</param>
        public HealthGraphException(string message, Uri requestUri) : base(message)
        {
            RequestUri = requestUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthGraphException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="requestUri">The request URI.</param>
        public HealthGraphException(string message, Exception innerException, Uri requestUri) : base(message, innerException)
        {
            RequestUri = requestUri;
        }

        #endregion

        #region Overriding (ISerializable)

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"></see> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">info</exception>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            info.AddValue(nameof(RequestUri), RequestUri.ToString());
            base.GetObjectData(info, context);
        }

        #endregion

    }

}
