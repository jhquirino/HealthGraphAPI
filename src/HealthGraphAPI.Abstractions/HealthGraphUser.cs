//-----------------------------------------------------------------------
// <copyright file="HealthGraphUser.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------

namespace HealthGraphAPI
{

    /// <summary>
    /// Represents a user resource which identifies the available resources for a specific user and the URIs for accessing them.
    /// </summary>
    public sealed class HealthGraphUser
    {

        #region Properties

        /// <summary>
        /// Gets or sets the unique ID for the user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(nameof(UserID))]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the URI of the user profile resource.
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Gets or sets the URI of the sharing and display settings resource.
        /// </summary>
        public string Settings { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the fitness activity feed.
        /// </summary>
        public string FitnessActivities { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the strength training activity feed.
        /// </summary>
        public string StrengthTrainingActivities { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the background activity feed.
        /// </summary>
        public string BackgroundActivities { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the sleep feed.
        /// </summary>
        public string Sleep { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the nutrition feed.
        /// </summary>
        public string Nutrition { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the weight measurement feed.
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the general measurements feed.
        /// </summary>
        public string GeneralMeasurements { get; set; }

        /// <summary>
        /// Gets or sets the URI of the first page of the diabetes measurements feed.
        /// </summary>
        public string Diabetes { get; set; }

        /// <summary>
        /// Gets or sets the URI of the personal records resource.
        /// </summary>
        public string Records { get; set; }

        /// <summary>
        /// Gets or sets the URI of the friends (formerly known as the "street team") resource.
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// Gets or sets the URI of the change log resource.
        /// </summary>
        public string ChangeLog { get; set; }

        #endregion

    }


}