﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2024 Bad Echo LLC. All rights reserved.
//
//      Bad Echo Technologies are licensed under the
//      GNU Affero General Public License v3.0.
//
//      See accompanying file LICENSE.md or a copy at:
//      https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Xna.Framework;

namespace BadEcho.Game;

/// <summary>
/// Defines a system for exerting control over a positional entity's movement.
/// </summary>
public interface IMovementSystem
{
    /// <summary>
    /// Updates the movement of the provided entity.
    /// </summary>
    /// <param name="entity">The positional entity whose movement is to be updated.</param>
    void UpdateMovement(IEntity entity);

    /// <summary>
    /// Applies a penetration vector to the provided entity.
    /// </summary>
    /// <param name="entity">
    /// The positional entity that has formed a penetration vector by overlapping with another entity.
    /// </param>
    /// <param name="penetration">The penetration vector to apply.</param>
    void ApplyPenetration(IEntity entity, Vector2 penetration);
}
