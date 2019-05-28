namespace KMSEmulatorCore.KMS
{
    abstract class KMSResponseBase
    {
        public abstract uint BodyLength
        {
            get;
        }

        public byte[] Unknown
        {
            get
            {
                return new byte[] { 0x00, 0x00, 0x02, 0x00 };
            }
        }
        public uint BodyLength2
        {
            get
            {
                return BodyLength;
            }
        }

        public byte[] Padding
        {
            get
            {
                uint currentLength = BodyLength;
                uint remainder = currentLength % 8;
                return remainder == 0 ? new byte[0] : new byte[8 - remainder];
            }
        }
    }
}
