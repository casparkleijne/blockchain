using System;

namespace nl.hyperdata.blockchain
{
    public class Block : IBlock
    {
        public Block(byte[] data)
        {
            if (data == null || data.Length < 1)
            {
                throw new ArgumentException("data is to short", "data");
            }
            Data = data;
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
            return String.Format("{0}:\n:{1}:\n:{2}:\n{3}", BitConverter.ToString(Hash).Replace("-", ""), BitConverter.ToString(PreviousHash).Replace("-", ""), Nonce, TimeStamp);
        }
    }
}
