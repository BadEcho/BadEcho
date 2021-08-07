﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BadEcho.Fenestra.Configuration
{
    /// <summary>
    /// Provides configuration settings for a Fenestra application.
    /// </summary>
    public sealed class FenestraConfiguration
    {
        /// <summary>
        /// Get or sets the index of the monitor that the main window of the Fenestra application should be initially
        /// launched on.
        /// </summary>
        /// <remarks>
        /// A monitor's index corresponds to where the monitor is in the arrangement defined in the user's display settings, with
        /// the lowest index being the leftmost monitor and the highest being the rightmost.
        /// </remarks>
        public int LaunchDisplay
        { get; set; }
    }
}
