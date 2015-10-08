﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Interfaced;

namespace PingpongInterface
{
    public interface IServer : IInterfacedActor
    {
        Task<int> Echo(int value);
    }
}
