using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nl.hyperdata.blockchain.test
{
    [TestClass]
    public class BlockChainTest
    {
        private static Random random = new Random(DateTime.Now.Millisecond);
        private static readonly IBlock genesis = new Block(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        private static readonly byte[] difficulty = new byte[] { 0x00, 0x00 };


        BlockChain chain = new BlockChain(difficulty, genesis);

        [TestMethod]
        public void TestBlockChainConstructor()
        {
            Assert.IsNotNull(chain);
        }

        [TestMethod]
        public void TestBlockChainGenesisBlock()
        {
            Assert.AreEqual(1, chain.Items.Count);
        }


        [TestMethod]
        public void TestBlockChainNewBlock()
        {
            var data = Enumerable.Range(0, 256).Select(x => (byte)random.Next());
            chain.Add(new Block(data.ToArray()));

            Assert.AreEqual(2, chain.Items.Count);
        }


    }
}
