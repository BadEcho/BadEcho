﻿//-----------------------------------------------------------------------
// <copyright>
//		Created by Matt Weber <matt@badecho.com>
//		Copyright @ 2023 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using BadEcho.Extensions;
using Microsoft.Xna.Framework;

namespace BadEcho.Game.Tiles;

/// <summary>
/// Provides an area in a tile map filled with tile data.
/// </summary>
public sealed class TileLayer : Layer
{
    private readonly Tile?[] _tiles;
    private readonly Size _size;

    /// <summary>
    /// Initializes a new instance of the <see cref="TileLayer"/> class.
    /// </summary>
    /// <param name="name">The name of the layer.</param>
    /// <param name="isVisible">Value indicating if the layer data should actually be rendered.</param>
    /// <param name="opacity">The opacity of the layer and all of its contents.</param>
    /// <param name="offset">The offset, in terms of the layer's position, from the tile map's origin.</param>
    /// <param name="size">
    /// The tile layer's size, measured in tiles (i.e., a 4x4 size indicates four tiles wide by four tiles high, with a total area of 16 tiles).
    /// </param>
    public TileLayer(string name,
                     bool isVisible,
                     float opacity,
                     Vector2 offset,
                     Size size)
        : base(name, isVisible, opacity, offset)
    {
        _size = size;
        _tiles = new Tile[size.Width * size.Height];
    }

    /// <summary>
    /// Gets the tiles belonging to this tile layer.
    /// </summary>
    public IReadOnlyCollection<Tile?> Tiles
        => _tiles;

    /// <summary>
    /// Gets a range of tiles found within this tile layer.
    /// </summary>
    /// <param name="firstId">The global identifier of the tile at which the range starts.</param>
    /// <param name="maxCount">The maximum number of elements in the range.</param>
    /// <returns>A range of up to <c>maxCount</c> tiles starting at the tile identified by <c>firstId</c>.</returns>
    public IEnumerable<Tile> GetRange(int firstId, int maxCount)
    {
        int lastId = maxCount + firstId - 1;

        return _tiles.WhereNotNull()
                     .Where(t => t.Id >= firstId && t.Id <= lastId);
    }

    /// <summary>
    /// Gets the tile, if any, found at the specified position in the layer.
    /// </summary>
    /// <param name="position">The drawing location of the tile to return.</param>
    /// <returns>The tile being drawn at <c>position</c>, if one exists; otherwise, null.</returns>
    public Tile? GetTile(Vector2 position)
    {
        int columnIndex = (int) position.X / _size.Width;
        int rowIndex = (int) position.Y / _size.Height;
        int index = CalculateTileIndex(columnIndex, rowIndex);

        return _tiles[index];
    }

    /// <summary>
    /// Loads the identified tile into the tile layer at the specified location.
    /// </summary>
    /// <param name="idWithFlags">The global identifier and flip flags of the tile to load into the layer.</param>
    /// <param name="columnIndex">The index of the column within the tile layer to load the tile into.</param>
    /// <param name="rowIndex">The index of the row within the tile layer to load the tile into.</param>
    public void LoadTile(uint idWithFlags, int columnIndex, int rowIndex)
    {
        int index = CalculateTileIndex(columnIndex, rowIndex);
        
        _tiles[index] = new Tile(idWithFlags, columnIndex, rowIndex);
    }

    private int CalculateTileIndex(int columnIndex, int rowIndex)
        => columnIndex + rowIndex * _size.Width;
}   
  