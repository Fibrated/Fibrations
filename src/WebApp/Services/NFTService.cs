using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;

namespace FiberNest.Services
{
    public class NFTService
    {
        private readonly string _abi = "<Your Smart Contract ABI>";
        private readonly string _contractAddress = "<Your Smart Contract Address>";
        private Web3 _web3;

        public async Task InitializeWeb3Async(string providerUrl)
        {
            _web3 = new Web3(providerUrl);
        }

        public async Task<string> MintNFTAsync(string toAddress, string tokenURI)
        {
            var mintFunction = new MintFunction
            {
                To = toAddress,
                TokenURI = tokenURI,
                FromAddress = _web3.TransactionManager.Account.Address,
                Gas = new Nethereum.Hex.HexTypes.HexBigInteger(500000),
                Value = BigInteger.Zero // Set the Value property to 0
            };

            var contract = _web3.Eth.GetContract(_abi, _contractAddress);
            var mintHandler = contract.GetFunction<MintFunction>();

            var estimatedGas = await mintHandler.EstimateGasAsync(mintFunction).ConfigureAwait(false);

            var transactionHash = await mintHandler.SendTransactionAsync(mintFunction, _web3.TransactionManager.Account.Address, estimatedGas, new HexBigInteger(0)).ConfigureAwait(false);
            var transactionReceipt = await _web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            while (transactionReceipt == null)
            {
                Thread.Sleep(5000); // Wait for 5 seconds before checking again
                transactionReceipt = await _web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
            }

            return transactionHash;
        }

        public async Task<string> GetTokenURIAsync(BigInteger tokenId)
        {
            var getTokenURIHandler = _web3.Eth.GetContract(_abi, _contractAddress).GetFunction("tokenURI");
            var tokenURI = await getTokenURIHandler.CallAsync<string>(tokenId);
            return tokenURI;
        }


    }
    [Function("mint")]
    public class MintFunction : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public string To { get; set; }

        [Parameter("string", "tokenURI", 2)]
        public string TokenURI { get; set; }

        [Parameter("uint256", "value", 3)]
        public BigInteger Value { get; set; }

    }

    [Function("tokenURI", "string")]
    public class GetTokenURIFunction : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public ulong TokenId { get; set; }
    }

}
