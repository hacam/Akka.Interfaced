﻿using System;
using System.Threading;
using Akka.Actor;

namespace Akka.Interfaced
{
    internal class MessageHandleContext
    {
        public IActorRef Self { get; set; }
        public IActorRef Sender { get; set; }
    }

    internal class ActorSynchronizationContext : SynchronizationContext
    {
        private readonly MessageHandleContext _context;

        public ActorSynchronizationContext(MessageHandleContext context)
        {
            _context = context;
        }

        public override SynchronizationContext CreateCopy()
        {
            return new ActorSynchronizationContext(_context);
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            if (s_synchronousPostEnabled)
            {
                s_synchronousPostEnabled = false;
                if (s_currentAtomicContext == null)
                {
                    d(state);
                    return;
                }
                if (s_currentAtomicContext == _context)
                {
                    s_currentAtomicContext = null;
                    d(state);
                    return;
                }
            }

            _context.Self.Tell(
                new TaskContinuationMessage
                {
                    Context = _context,
                    CallbackAction = d,
                    CallbackState = state
                },
                _context.Sender);
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotImplementedException("Send");
        }

        // SynchronousPost

        [ThreadStatic]
        private static bool s_synchronousPostEnabled;

        [ThreadStatic]
        private static MessageHandleContext s_currentAtomicContext;

        public static void EnableSynchronousPost(MessageHandleContext currentAtomicContext)
        {
            s_synchronousPostEnabled = true;
            s_currentAtomicContext = currentAtomicContext;
        }
    }
}
