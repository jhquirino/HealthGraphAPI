//-----------------------------------------------------------------------
// <copyright file="HealthGraphUser.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using Newtonsoft.Json;

namespace HealthGraphAPI
{

    /// <summary>
    /// Represents a user resource which identifies the available resources for a specific user and the URIs for accessing them.
    /// </summary>
    public sealed class HealthGraphUser
    {

        #region Properties

        /// <summary>
        /// Gets the unique ID for the user.
        /// </summary>
        [JsonProperty(nameof(UserId))]
        public int UserId { get; internal set; }

        /// <summary>
        /// Gets the URI of the user profile resource.
        /// </summary>
        [JsonProperty]
        public string Profile { get; internal set; }

        /// <summary>
        /// Gets the URI of the sharing and display settings resource.
        /// </summary>
        [JsonProperty]
        public string Settings { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the fitness activity feed.
        /// </summary>
        [JsonProperty]
        public string FitnessActivities { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the strength training activity feed.
        /// </summary>
        [JsonProperty]
        public string StrengthTrainingActivities { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the background activity feed.
        /// </summary>
        [JsonProperty]
        public string BackgroundActivities { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the sleep feed.
        /// </summary>
        [JsonProperty]
        public string Sleep { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the nutrition feed.
        /// </summary>
        [JsonProperty]
        public string Nutrition { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the weight measurement feed.
        /// </summary>
        [JsonProperty]
        public string Weight { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the general measurements feed.
        /// </summary>
        [JsonProperty]
        public string GeneralMeasurements { get; internal set; }

        /// <summary>
        /// Gets the URI of the first page of the diabetes measurements feed.
        /// </summary>
        [JsonProperty]
        public string Diabetes { get; internal set; }

        /// <summary>
        /// Gets the URI of the personal records resource.
        /// </summary>
        [JsonProperty]
        public string Records { get; internal set; }

        /// <summary>
        /// Gets the URI of the friends (formerly known as the "street team") resource.
        /// </summary>
        [JsonProperty]
        public string Team { get; internal set; }

        /// <summary>
        /// Gets the URI of the change log resource.
        /// </summary>
        [JsonProperty]
        public string ChangeLog { get; internal set; }

        #endregion

    }


}