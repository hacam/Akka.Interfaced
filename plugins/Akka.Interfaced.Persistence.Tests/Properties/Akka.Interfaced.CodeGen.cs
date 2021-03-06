﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Interfaced;
using Akka.Actor;

#region Akka.Interfaced.Persistence.Tests.INotepad

namespace Akka.Interfaced.Persistence.Tests
{
    [PayloadTable(typeof(INotepad), PayloadTableKind.Request)]
    public static class INotepad_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Clear_Invoke), null },
                { typeof(FlushSnapshot_Invoke), null },
                { typeof(GetDocument_Invoke), typeof(GetDocument_Return) },
                { typeof(Write_Invoke), null },
            };
        }

        public class Clear_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(INotepad);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((INotepad)__target).Clear();
                return null;
            }
        }

        public class FlushSnapshot_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(INotepad);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((INotepad)__target).FlushSnapshot();
                return null;
            }
        }

        public class GetDocument_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(INotepad);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((INotepad)__target).GetDocument();
                return (IValueGetable)(new GetDocument_Return { v = __v });
            }
        }

        public class GetDocument_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Collections.Generic.IList<string> v;

            public Type GetInterfaceType()
            {
                return typeof(INotepad);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class Write_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public string message;

            public Type GetInterfaceType()
            {
                return typeof(INotepad);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((INotepad)__target).Write(message);
                return null;
            }
        }
    }

    public interface INotepad_NoReply
    {
        void Clear();
        void FlushSnapshot();
        void GetDocument();
        void Write(string message);
    }

    public class NotepadRef : InterfacedActorRef, INotepad, INotepad_NoReply
    {
        public override Type InterfaceType => typeof(INotepad);

        public NotepadRef() : base(null)
        {
        }

        public NotepadRef(IRequestTarget target) : base(target)
        {
        }

        public NotepadRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public INotepad_NoReply WithNoReply()
        {
            return this;
        }

        public NotepadRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new NotepadRef(Target, requestWaiter, Timeout);
        }

        public NotepadRef WithTimeout(TimeSpan? timeout)
        {
            return new NotepadRef(Target, RequestWaiter, timeout);
        }

        public Task Clear()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.Clear_Invoke {  }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task FlushSnapshot()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.FlushSnapshot_Invoke {  }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task<System.Collections.Generic.IList<string>> GetDocument()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.GetDocument_Invoke {  }
            };
            return SendRequestAndReceive<System.Collections.Generic.IList<string>>(requestMessage);
        }

        public Task Write(string message)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.Write_Invoke { message = message }
            };
            return SendRequestAndWait(requestMessage);
        }

        void INotepad_NoReply.Clear()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.Clear_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void INotepad_NoReply.FlushSnapshot()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.FlushSnapshot_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void INotepad_NoReply.GetDocument()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.GetDocument_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void INotepad_NoReply.Write(string message)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new INotepad_PayloadTable.Write_Invoke { message = message }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(INotepad))]
    public interface INotepadSync : IInterfacedActorSync
    {
        void Clear();
        void FlushSnapshot();
        System.Collections.Generic.IList<string> GetDocument();
        void Write(string message);
    }
}

#endregion
