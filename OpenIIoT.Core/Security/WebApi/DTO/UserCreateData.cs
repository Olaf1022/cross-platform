﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄                              ▄████████                                                   ████████▄
      █   ███    ███                             ███    ███                                                  ███   ▀███
      █   ███    ███   ▄█████    ▄█████    █████ ███    █▀     █████    ▄█████   ▄█████      ██       ▄█████ ███    ███   ▄█████      ██      ▄█████
      █   ███    ███   ██  ▀    ██   █    ██  ██ ███          ██  ██   ██   █    ██   ██ ▀███████▄   ██   █  ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ███    ███   ██      ▄██▄▄     ▄██▄▄█▀ ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀  ▄██▄▄    ███    ███   ██   ██     ██  ▀   ██   ██
      █   ███    ███ ▀███████ ▀▀██▀▀    ▀███████ ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ▀▀██▀▀    ███    ███ ▀████████     ██    ▀████████
      █   ███    ███    ▄  ██   ██   █    ██  ██ ███    ███   ██  ██   ██   █    ██   ██     ██      ██   █  ███   ▄███   ██   ██     ██      ██   ██
      █   ████████▀   ▄████▀    ███████   ██  ██ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀     ███████ ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when creating a User object.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using Newtonsoft.Json;
using OpenIIoT.SDK.Security;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    /// <summary>
    ///     Data Transfer Object used when creating a <see cref="User"/> object.
    /// </summary>
    public class UserCreateData
    {
        #region Public Properties

        /// <summary>
        ///     Gets the <see cref="User"/><see cref="User.DisplayName"/>.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string DisplayName { get; }

        /// <summary>
        ///     Gets the <see cref="User"/><see cref="User.Email"/>.
        /// </summary>
        [JsonProperty(Order = 3)]
        public string Email { get; }

        /// <summary>
        ///     Gets the <see cref="User"/><see cref="User.Name"/>.
        /// </summary>
        [JsonProperty(Order = 1)]
        public string Name { get; }

        /// <summary>
        ///     Gets the <see cref="User"/> password.
        /// </summary>
        [JsonProperty(Order = 5)]
        public string Password { get; }

        /// <summary>
        ///     Gets the <see cref="User"/><see cref="User.Role"/>.
        /// </summary>
        [JsonProperty(Order = 4)]
        public Role Role { get; }

        #endregion Public Properties
    }
}