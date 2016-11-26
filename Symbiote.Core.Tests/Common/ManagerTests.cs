﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████                                                                                        ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                                                     ▄██▀▀▀███▀▀▀██▄
      █     ███    ███    █████▄    █████▄  █        █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███   ██   ██   ██   ██ ██       ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀███████████   ██   ██   ██   ██ ██       ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███    ███ ▀██████▀  ▀██████▀  ██       ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███    ███   ██        ██      ██▌    ▄ ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █     ███    █▀   ▄███▀     ▄███▀    ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
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
      █  Unit tests for the ApplicationManager class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Symbiote.Core.SDK;
using Symbiote.Core.SDK.Exceptions;
using Symbiote.Core.Tests.Mockups;
using Utility.OperationResult;
using Xunit;
using Symbiote.Core.Tests.Common.Mockups;
using System.Threading;

namespace Symbiote.Core.Tests.Common
{
    /// <summary>
    ///     Tests <see cref="Manager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("Manager")]
    public class ManagerTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests <see cref="Manager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            ManagerMock test = ManagerMock.Instantiate(a);

            Assert.Equal("Mock Manager", test.ManagerName);
            Assert.Equal(test.GetType().Name, test.EventProviderName);

            Assert.Equal(true, test.CheckDependency());
            Assert.Throws<DependencyNotResolvedException>(() => test.CheckBadDependency());

            test.Dispose();
        }

        [Fact]
        public void Start()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            ManagerMock test = ManagerMock.Instantiate(a);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // try to start again and assert that the operation fails
            Result startAgain = test.Start();
            Assert.Equal(ResultCode.Failure, startAgain.ResultCode);
        }

        [Fact]
        public void StartWithStoppedDependency()
        {
            ApplicationManagerMockNotStarted a = new ApplicationManagerMockNotStarted();
            a.Start();

            ManagerMock test = ManagerMock.Instantiate(a);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(ResultCode.Failure, start.ResultCode);
        }

        [Fact]
        public void Restart()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            ManagerMock test = ManagerMock.Instantiate(a);

            // start the manager and assert that it is running
            test.Start();
            Assert.Equal(State.Running, test.State);

            // restart the manager and assert that the operation succeeded
            Result restart = test.Restart();
            Assert.Equal(ResultCode.Success, restart.ResultCode);
            Assert.Equal(State.Running, test.State);
        }

        [Fact]
        public void RestartNotRunning()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            ManagerMock test = ManagerMock.Instantiate(a);

            Result restart = test.Restart();
            Assert.Equal(ResultCode.Failure, restart.ResultCode);
        }

        [Fact]
        public void Stop()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            ManagerMock test = ManagerMock.Instantiate(a);

            // start the manager and assert that it is running
            test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the manager and assert that it is stopped
            test.Stop();
            Assert.Equal(State.Stopped, test.State);

            // try to stop again and assert that the operation fails
            Result stop = test.Stop();
            Assert.Equal(ResultCode.Failure, stop.ResultCode);
        }

        [Fact]
        public void DependencyStop()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            OtherManagerMock o = OtherManagerMock.Instantiate(a);
            o.Start();

            ManagerMockWithDependency test = ManagerMockWithDependency.Instantiate(a, o);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the other manager (the manager upon which this test manager is dependent) ensure
            // that this manager stops. restart the other manager and ensure that this manager
            // remains stopped.
            o.Stop();
            Assert.Equal(State.Stopped, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(false, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);
            Assert.Equal(State.Stopped, test.State);

            // restart this manager in preparation for the next
            test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the other manager with the restart flag
            o.Stop(StopType.Restart);
            Assert.Equal(State.Stopped, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(true, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);

            // wait 1500ms for the manager to restart (the restart timer is set for 500ms)
            Thread.Sleep(1000);

            // assert that the manager has restarted.
            Assert.Equal(State.Running, test.State);
        }

        [Fact]
        public void DependencyFault()
        {
            ApplicationManagerMock a = new ApplicationManagerMock();
            a.Start();

            OtherManagerMock o = OtherManagerMock.Instantiate(a);
            o.Start();

            ManagerMockWithDependency test = ManagerMockWithDependency.Instantiate(a, o);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // start the manager and assert that it is running Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // fault the manager upon which the test manager is dependent ensure that this manager
            //stops.start the other manager and ensure that this manager remains stopped.
            o.Fault();
            Assert.Equal(State.Faulted, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(false, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);
            Assert.Equal(State.Stopped, test.State);

            // restart this manager in preparation for the next
            test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the other manager with the restart flag
            o.FaultWithRestart();
            Assert.Equal(State.Faulted, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(true, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);

            // wait 1500ms for the manager to restart (the restart timer is set for 500ms)
            Thread.Sleep(1000);

            // assert that the manager has restarted.
            Assert.Equal(State.Running, test.State);
        }

        #endregion Public Methods
    }
}