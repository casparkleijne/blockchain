using System;

namespace nl.hyperdata.blockchain
{
    public class Block : IBlock
    {
        public Block(byte[] data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            Nonce = 0;
            PreviousHash = new byte[] { 0x00 };
            TimeStamp = DateTime.Now;

        }
        public byte[] Data { get; }

        public byte[] Hash { get; set; }

        public byte[] PreviousHash { get; set; }

        public int Nonce { get; set; }

        public DateTime TimeStamp { get; }

        public override string ToString()
        {
            return String.Format("{0}:\n:{1}:\n:{2}:\n{3}\n\r", BitConverter.ToString(Hash).Replace("-", ""), BitConverter.ToString(PreviousHash).Replace("-", ""), Nonce, TimeStamp);
        }
    }
}
