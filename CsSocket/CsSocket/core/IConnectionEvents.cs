using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSocket.core
{
    interface IConnectionEvents
    {

        void OnConnectEvent(Guid guid);

        void OnDisconnectEvent(Guid guid);

    }
}
