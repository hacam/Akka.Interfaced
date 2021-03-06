﻿using System;
using System.Linq;
using System.Threading.Tasks;

namespace Akka.Interfaced.LogFilter.Tests
{
    [Log, ResponsiveException(typeof(ArgumentNullException))]
    public class TestActor : InterfacedActor, ITest
    {
        private NLog.ILogger _logger;
        private int _helloCount;

        public TestActor()
        {
            _logger = NLog.LogManager.GetLogger("TestActor");
        }

        public Task Call(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(value);
            _logger.Trace($"Call({value})");
            return Task.FromResult(0);
        }

        public Task CallWithActor(ITest test)
        {
            _logger.Trace($"CallWithActor({((TestRef)test).CastToIActorRef().Path})");
            return Task.FromResult(0);
        }

        Task<string> ITest.SayHello(string name)
        {
            _logger.Trace($"SayHello({name})");
            _helloCount += 1;
            return Task.FromResult("Hello " + name);
        }

        Task<int> ITest.GetHelloCount()
        {
            _logger.Trace("GetHelloCount()");
            return Task.FromResult(_helloCount);
        }
    }
}
