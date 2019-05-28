using System;

namespace KMSEmulatorCore
{
    public interface IMessageHandler
    {
        byte[] HandleRequest(byte[] request);
    }
}
