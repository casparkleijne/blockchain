using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.blockchain
{
    public static class BlockChainExtensions
    {
        public static bool IsValid(this IEnumerable<IBlock> items)
        {
            return items
                .Zip(items.Skip(1), Tuple.Create)
                .All(block => block.Item2.HasValidHash() && block.Item2.HasValidPreviousHash(block.Item1));
        }
    }
}
