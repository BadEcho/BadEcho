﻿//-----------------------------------------------------------------------
// <copyright>
//		Created by Matt Weber <matt@badecho.com>
//		Copyright @ 2024 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under the
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using System.Text.Json.Serialization;
using System.Windows;

namespace BadEcho.Presentation.Tests.Serialization;

public sealed class FakeThicknessObject
{
    [JsonConverter(typeof(JsonThicknessConverter))]
    public Thickness SomeThickness
    { get; set; }
}