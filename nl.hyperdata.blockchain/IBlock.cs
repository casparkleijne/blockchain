using System;

namespace nl.hyperdata.blockchain
{
    public interface IBlock
    {
        byte[] Data { get; }
        byte[] Hash { get; set; }
        int Nonce { get; set;}
        byte[] PreviousHash { get; set;}
        DateTime TimeStamp { get; }
    }
}