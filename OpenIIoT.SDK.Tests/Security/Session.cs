﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the Session class.
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

using System;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Xunit;

namespace OpenIIoT.SDK.Tests.Security
{
    /// <summary>
    ///     Unit tests for the <see cref="SDK.Security.Session"/> class.
    /// </summary>
    public class Session
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            DateTimeOffset expiry = DateTime.UtcNow.AddMinutes(15);

            AuthenticationProperties props = new AuthenticationProperties() { ExpiresUtc = expiry };
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), props);
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "hash"));

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.IsType<SDK.Security.Session>(test);
            Assert.Equal("hash", test.Token);
            Assert.Equal(ticket, test.Ticket);
            Assert.False(test.IsExpired);
            Assert.Equal("name", test.Name);
            Assert.Equal(SDK.Security.Role.Reader, test.Role);
            Assert.NotNull(test.Expiriation);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.IsExpired"/> property with an expired Ticket.
        /// </summary>
        [Fact]
        public void IsExpiredExpired()
        {
            AuthenticationProperties props = new AuthenticationProperties() { ExpiresUtc = DateTime.UtcNow.AddMinutes(-15) };
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), props);
            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.True(test.IsExpired);
            Assert.NotNull(test.Expiriation);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.IsExpired"/> property with a Ticket which does not contain the ExpiresUtc property.
        /// </summary>
        [Fact]
        public void IsExpiredNullProperty()
        {
            AuthenticationProperties props = new AuthenticationProperties();
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), props);
            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.True(test.IsExpired);
            Assert.Null(test.Expiriation);
        }

        [Fact]
        public void Name()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal("name", test.Name);
        }

        [Fact]
        public void NameNoClaim()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal(string.Empty, test.Name);
        }

        [Fact]
        public void Role()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal(SDK.Security.Role.Reader, test.Role);
        }

        [Fact]
        public void RoleNoClaim()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal(SDK.Security.Role.Reader, test.Role);
        }

        [Fact]
        public void Ticket()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal(ticket, test.Ticket);
        }

        [Fact]
        public void TicketNull()
        {
            SDK.Security.Session test = new SDK.Security.Session(null);

            Assert.Equal(null, test.Ticket);
        }

        [Fact]
        public void Token()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "token"));

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal("token", test.Token);
        }

        [Fact]
        public void TokenNoClaim()
        {
            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties());

            SDK.Security.Session test = new SDK.Security.Session(ticket);

            Assert.Equal(string.Empty, test.Token);
        }

        #endregion Public Methods
    }
}