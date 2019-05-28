using KMSEmulatorCore.KMS;
using KMSEmulatorCore.RPC.Bind;
using KMSEmulatorCore.RPC.Request;
using System;

namespace KMSEmulatorCore.RPC
{
    public class RpcMessageHandler : IMessageHandler
    {
        private IMessageHandler RequestMessageHandler { get; set; }
        private IKMSServerSettings Settings { get; set; }

        public RpcMessageHandler(IKMSServerSettings settings, IMessageHandler requestMessageHandler)
        {
            RequestMessageHandler = requestMessageHandler;
            Settings = settings;
        }

        public byte[] HandleRequest(byte[] request)
        {
            byte messageType = request[2];
            try
            {
                IMessageHandler requestHandler = GetMessageHandler(messageType);

                byte[] response = requestHandler.HandleRequest(request);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new byte[0];
            }
        }

        private IMessageHandler GetMessageHandler(byte messageType)
        {
            IMessageHandler requestHandler;
            switch (messageType)
            {
                case 0x0b:
                    requestHandler = new RpcBindMessageHandler(Settings);
                    break;
                case 0x00:
                    requestHandler = new RpcRequestMessageHandler(RequestMessageHandler);
                    break;
                default:
                    throw new ApplicationException("Unhandled message type: " + messageType);
            }
            return requestHandler;
        }
    }
}
