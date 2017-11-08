//-----------------------------------------------------------------------
// <copyright file="HealthGraphProfile.cs" company="Jorge Alberto Hernández Quirino">
// Copyright (c) Jorge Alberto Hernández Quirino 2017. All rights reserved.
// </copyright>
// <author>Jorge Alberto Hernández Quirino</author>
//-----------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace HealthGraphAPI
{

    /// <summary>
    /// Represents the user's profile (identity, geographical location, and fitness goals).
    /// </summary>
    public sealed class HealthGraphProfile
    {

        #region Properties

        /// <summary>
        /// Gets the user's full name (omitted if not yet specified).
        /// </summary>
        [JsonProperty]
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the user's geographical location (omitted if not yet specified).
        /// </summary>
        [JsonProperty]
        public string Location { get; internal set; }

        /// <summary>
        /// Gets or sets the type of the athlete.
        /// </summary>
        [JsonProperty]
        public HealthGraphAthleteType AthleteType { get; set; }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        [JsonProperty]
        public HealthGraphGender Gender { get; internal set; }

        /// <summary>
        /// Gets the user's birthday (omitted if not yet specified).
        /// </summary>
        [JsonProperty]
        public DateTime? Birthday { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the user subscribes to Runkeeper Elite.
        /// </summary>
        [JsonProperty]
        public bool Elite { get; internal set; }

        /// <summary>
        /// Gets the URL of the user's public, human-readable profile on the Runkeeper Web site.
        /// </summary>
        [JsonProperty]
        public string Profile { get; internal set; }

        /// <summary>
        /// Gets the URI of the small (50×50 pixels) version of the user's profile picture on the Runkeeper Web site (omitted if the user has no such picture).
        /// </summary>
        [JsonProperty]
        public string SmallPicture { get; internal set; }

        /// <summary>
        /// Gets the URI of the normal (100×100 pixels) version of the user's profile picture on the Runkeeper Web site (omitted if the user has no such picture).
        /// </summary>
        [JsonProperty]
        public string NormalPicture { get; internal set; }

        /// <summary>
        /// Gets the URI of the medium (200×600 pixels) version of the user's profile picture on the Runkeeper Web site (omitted if the user has no such picture) Note: The image may be shorter than 600 pixels in height if the user has provided a smaller picture..
        /// </summary>
        [JsonProperty]
        public string MediumPicture { get; internal set; }

        /// <summary>
        /// Gets the URI of the large (600×1800 pixels) version of the user's profile picture on the Runkeeper Web site (omitted if the user has no such picture) Note: The image may be shorter than 1800 pixels in height if the user has provided a smaller picture..
        /// </summary>
        [JsonProperty]
        public string LargePicture { get; internal set; }

        #endregion

    }

}
