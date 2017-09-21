using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Numerics;
using Nethereum.Web3;




namespace Restful_API_test
{
    
    class Program
    {

        static void Main(string[] args)
        {
            string network = "rinkeby"; // Enter Network Here e.g mainnet, rinkeby, ropsten, Kovan,infuranet

            /*For GET request
             * "web3_clientVersion","net_version","net_listening","net_peerCount","eth_protocolVersion","eth_syncing","eth_mining","eth_hashrate",
             * "eth_gasPrice","eth_accounts","eth_blockNumber","eth_getBalance","eth_getStorageAt",
             * "eth_getTransactionCount","eth_getBlockTransactionCountByHash",
             * "eth_getBlockTransactionCountByNumber","eth_getUncleCountByBlockHash","eth_getUncleCountByBlockNumber",
             * "eth_getCode","eth_call","eth_getBlockByHash","eth_getBlockByNumber",
             * "eth_getTransactionByHash","eth_getTransactionByBlockHashAndIndex",
             * "eth_getTransactionByBlockNumberAndIndex","eth_getTransactionReceipt",
             * "eth_getUncleByBlockHashAndIndex","eth_getUncleByBlockNumberAndIndex",
             * "eth_getCompilers","eth_getLogs","eth_getWork","parity_pendingTransactions"
             
            For POST request
            * "eth_sendRawTransaction","eth_estimateGas","eth_submitWork","eth_submitHashrate" */
            // supported methods mentioned above
            string method = "eth_getBalance";

            //change the value based on number of parameters
            string[] parameters = new string[2];

            // leave it empty for methods that don't require parameters
            //More Parameters can be added (Any Added parameter also needs to be added to the url string 
            //e.g "\"" + parameters[number] + "\"" 
            parameters[0] = "0x29bf8bE493122F010FCD9db8d6466a8F8B1da7F0"; 
            parameters[1] = "latest";
            //parameter[2]="";
            

            /*API format
            https://api.infura.io/v1/jsonrpc/network/method?parms= */

            string url = "https://api.infura.io/v1/jsonrpc/"+ network + "/" + method + "?params=" + "[" + "\"" + parameters[0] + "\"" + "," + "\"" + parameters[1] + "\"" + "]";
            Api api = new Api();
            var ApiResult = api.CallApi(url);

            //String value from Api call is converted to JSON object then [result] is extracted
            var JsonObject = api.GetJsonObj(ApiResult);
            var StringResult = api.GetStringResult(JsonObject);

            //To Convert hex values to Decimal
            var Str = api.HexToDecString(StringResult);

            //To Convert to Ether Balance
            Double Balance = api.StringToEther(Str);

            //To print the final result
            Console.WriteLine("Your Balance in Ether = " + Balance +" Ethers"); 
            Console.ReadKey();

        }
    }
}
