﻿using Symbiote.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerBadDependency : Manager, IStateful, IManager
    {
        private static MockManagerBadDependency instance;

        private MockManagerBadDependency(MockManager manager)
        {
            ManagerName = "Mock Manager";

            ChangeState(State.Initialized);
        }

        public static MockManagerBadDependency Instantiate(MockManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerBadDependency(manager);
            }

            return instance;
        }

        protected override void Setup()
        {
            return;
        }

        protected override Result Startup()
        {
            return new Result();
        }

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result();
        }
    }
}