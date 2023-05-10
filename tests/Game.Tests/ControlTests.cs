﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2023 Bad Echo LLC. All rights reserved.
//
//      Bad Echo Technologies are licensed under the
//      GNU Affero General Public License v3.0.
//
//      See accompanying file LICENSE.md or a copy at:
//      https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using BadEcho.Game.UI;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Xunit;

namespace BadEcho.Game.Tests;

public class ControlTests : IClassFixture<ContentManagerFixture>
{
    private readonly Rectangle _screenBounds = new(0, 0, 1920, 1080);

    private readonly Label _label;

    public ControlTests(ContentManagerFixture contentFixture)
    {
        var font = contentFixture.Content.Load<SpriteFont>("Fonts\\Lato");

        _label = new Label
                 {
                     Background = new Brush(Color.Gray),
                     Border = new Brush(Color.Aqua),
                     Font = font,
                     Text = "Hello there",
                     VerticalAlignment = VerticalAlignment.Top,
                     HorizontalAlignment = HorizontalAlignment.Left
                 };
    }

    [Fact]
    public void MeasureArrange_Default_ValidLayoutBounds()
    {
        _label.Measure(_screenBounds.Size);
        _label.Arrange(_screenBounds);

        var bounds = new Rectangle(0, 0, 158, 38);

        Assert.Equal(bounds, _label.LayoutBounds);
        Assert.Equal(bounds, _label.BorderBounds);
        Assert.Equal(bounds, _label.BackgroundBounds);
        Assert.Equal(bounds, _label.ContentBounds);
    }

    [Fact]
    public void MeasureArrange_MarginApplied_ValidLayoutBounds()
    {
        _label.Margin = new Thickness(10);
        _label.Measure(_screenBounds.Size);
        _label.Arrange(_screenBounds);

        var layoutBounds = new Rectangle(0, 0, 178, 58);
        var contentBounds = new Rectangle(10, 10, 158, 38);
        
        Assert.Equal(layoutBounds, _label.LayoutBounds);
        Assert.Equal(contentBounds, _label.BorderBounds);
        Assert.Equal(contentBounds, _label.BackgroundBounds);
        Assert.Equal(contentBounds, _label.ContentBounds);
    }

    [Fact]
    public void MeasureArrange_BorderApplied_ValidLayoutBounds()
    {
        _label.BorderThickness = new Thickness(2);
        _label.Measure(_screenBounds.Size);
        _label.Arrange(_screenBounds);

        var layoutBounds = new Rectangle(0, 0, 162, 42);
        var contentBounds = new Rectangle(2, 2, 158, 38);

        Assert.Equal(layoutBounds, _label.LayoutBounds);
        Assert.Equal(layoutBounds, _label.BorderBounds);
        Assert.Equal(contentBounds, _label.BackgroundBounds);
        Assert.Equal(contentBounds, _label.ContentBounds);
    }

    [Fact]
    public void MeasureArrange_PaddingApplied_ValidLayoutBounds()
    {
        _label.Padding = new Thickness(5);
        _label.Measure(_screenBounds.Size);
        _label.Arrange(_screenBounds);

        var layoutBounds = new Rectangle(0, 0, 168, 48);
        var contentBounds = new Rectangle(5, 5, 158, 38);

        Assert.Equal(layoutBounds, _label.LayoutBounds);
        Assert.Equal(layoutBounds, _label.BorderBounds);
        Assert.Equal(layoutBounds, _label.BackgroundBounds);
        Assert.Equal(contentBounds, _label.ContentBounds);
    }

    [Fact]
    public void MeasureArrange_MarginBorderPaddingApplied_ValidLayoutBounds()
    {
        _label.Padding = new Thickness(5);
        _label.BorderThickness = new Thickness(2);
        _label.Margin = new Thickness(10);
        _label.Measure(_screenBounds.Size);
        _label.Arrange(_screenBounds);

        var layoutBounds = new Rectangle(0, 0, 192, 72);
        var borderBounds = new Rectangle(10, 10, 172, 52);
        var backgroundBounds = new Rectangle(12, 12, 168, 48);
        var contentBounds = new Rectangle(17, 17, 158, 38);

        Assert.Equal(layoutBounds, _label.LayoutBounds);
        Assert.Equal(borderBounds, _label.BorderBounds);
        Assert.Equal(backgroundBounds, _label.BackgroundBounds);
        Assert.Equal(contentBounds, _label.ContentBounds);
    }

    [Fact]
    public void MeasureArrange_ExplicitWidth_ValidLayoutBounds()
    {
        _label.Width = 300;
        _label.Measure(_screenBounds.Size);
        _label.Arrange(_screenBounds);

        var bounds = new Rectangle(0, 0, 300, 38);

        Assert.Equal(bounds, _label.LayoutBounds);
        Assert.Equal(bounds, _label.BorderBounds);
        Assert.Equal(bounds, _label.BackgroundBounds);
        Assert.Equal(bounds, _label.ContentBounds);
    }
}
