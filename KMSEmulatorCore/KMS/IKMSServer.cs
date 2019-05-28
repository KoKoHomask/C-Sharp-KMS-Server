using KMSEmulatorCore.Logging;

namespace KMSEmulatorCore.KMS
{
    interface IKMSServer
    {
        byte[] ExecuteKMSServerLogic(byte[] kmsRequestBytes, ILogger logger);
    }
}
