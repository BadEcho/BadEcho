﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		Creative Commons Attribution-NonCommercial 4.0 International License.
//
//		See accompanying file LICENSE.md or a copy at:
//		http://creativecommons.org/licenses/by-nc/4.0/
// </copyright>
//-----------------------------------------------------------------------

using System;
using BadEcho.Fenestra.ViewModels;
using BadEcho.Odin;
using BadEcho.Omnified.Vision.Apocalypse.Properties;

namespace BadEcho.Omnified.Vision.Apocalypse.ViewModels
{
    /// <summary>
    /// Provides a view model that facilitates the display of an event generated by the Apocalypse system in an Omnified game.
    /// </summary>
    /// <typeparam name="TApocalypseEvent">The type of Apocalypse event bound to the view model for display on a view.</typeparam>
    internal class ApocalypseEventViewModel<TApocalypseEvent> : ViewModel<ApocalypseEvent, TApocalypseEvent>, IApocalypseEventViewModel
        where TApocalypseEvent : ApocalypseEvent
    {
        private string _effectMessage = string.Empty;
        private double _effectMessageMaxWidth = double.NaN;
        private DateTime _timestamp;

        /// <inheritdoc/>
        public string EffectMessage
        {
            get => _effectMessage;
            set => NotifyIfChanged(ref _effectMessage, value);
        }

        /// <inheritdoc/>
        public double EffectMessageMaxWidth
        {
            get => _effectMessageMaxWidth;
            set => NotifyIfChanged(ref _effectMessageMaxWidth, value);
        }

        /// <inheritdoc/>
        public DateTime Timestamp
        {
            get => _timestamp;
            set => NotifyIfChanged(ref _timestamp, value);
        }

        /// <inheritdoc/>
        protected override void OnBinding(TApocalypseEvent model)
        {
            Require.NotNull(model, nameof(model));

            string? effectMessage = model.ToString();

            if (string.IsNullOrEmpty(effectMessage))
                throw new ArgumentException(Strings.ApocalypseEventMissingMessage, nameof(model));

            EffectMessage = effectMessage;
            Timestamp = model.Timestamp;
        }

        /// <inheritdoc/>
        protected override void OnUnbound(TApocalypseEvent model)
        {
            EffectMessage = string.Empty;
            Timestamp = default;
        }
    }
}
