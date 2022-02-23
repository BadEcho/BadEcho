﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2022 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		Creative Commons Attribution-NonCommercial 4.0 International License.
//
//		See accompanying file LICENSE.md or a copy at:
//		http://creativecommons.org/licenses/by-nc/4.0/
// </copyright>
//-----------------------------------------------------------------------

using System.Composition;
using BadEcho.Presentation;

namespace BadEcho.Omnified.Vision.Statistics.Themes;

/// <summary>
/// Provides access to resources belonging to the Statistics plugin for Vision.
/// </summary>
[Export(typeof(IResourceProvider))]
internal sealed class ResourceProvider : IResourceProvider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceProvider"/> class.
    /// </summary>
    public ResourceProvider() 
        => ResourceUri = PackUri.FromRelativePath<ResourceProvider>("Root.xaml");

    /// <inheritdoc/>
    public Uri ResourceUri 
    { get; }
}