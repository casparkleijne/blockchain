# blockchain
A simple blockchain example in c# using SHA512 for hashing.

This lib  can:

- Generate a block with data.
- Add that block to a chain (in this case a List<T>)
- Create a hash for that block
- Create a hash based non a Nonce, a proof of work, or: mining a block.
- Validate that hash and the hash of a previous block
- Validate the whole chain

Enjoy

usage, as like in a Console application:

      using nl.hyperdata.blockchain;
      using System;
      using System.Linq;

      namespace ConsoleApp5
      {
      class Program
      {
          private static Random random = new Random(DateTime.Now.Millisecond);
          private static readonly IBlock genesis = new Block(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
          
          /** proof of work (https://en.wikipedia.org/wiki/Proof-of-work_system)  is set here: a hash needs 2 trailing zero bytes, increase the number of bytes to reduce the number of valid  hashes, and increse the proof of work time **/
          private static readonly byte[] difficulty = new byte[] { 0x00, 0x00 };

          static void Main(string[] args)
          {
          
              /** Initiate the chain, set a difficulty for genarating the hash (proof of work) 
              and define the genesis data (not really important) **/
              BlockChain chain = new BlockChain(difficulty, genesis);
              
              // ** start mining 20 blocks in a loop **/
              for (int i = 0; i < 20; i++)
              {
                  /** randomly generated dummy data **/
                  var data = Enumerable.Range(0, 256).Select(x => (byte)random.Next());
                  
                  /** add the fresh, unhashed block with the data to the chain **/
                  chain.Add(new Block(data.ToArray()));

                  /**-> blockchain magic happens here <-**/

                  /** output the generated block details **/
                  Console.WriteLine(chain.LastOrDefault().ToString());
                  
                  /** validate the chain (ie: is each block's hash valid and is the prevoius block has valid)
                  Console.WriteLine(String.Format("Chain is valid {0}:", chain.IsValid()));
              }

           }
      }
      }

