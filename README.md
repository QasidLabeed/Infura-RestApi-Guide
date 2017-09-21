# dotnet-csharp--infura-restful-api-nethereum

You can call Infura Restful API from Console Application

## Getting Started

This project can be Downloaded or cloned in Visual Studio

## Libraries

### Nuget Packages

- BigInteger
- BigRationalLibrary
- Microsoft.Asp.Net.WebApi.Client
- Nethereum.Web3
- Newtonsoft.Json
- Restful API Supported Methods

For GET request

"web3_clientVersion","net_version","net_listening","net_peerCount","eth_protocolVersion","eth_syncing","eth_mining","eth_hashrate",
"eth_gasPrice","eth_accounts","eth_blockNumber","eth_getBalance","eth_getStorageAt",
"eth_getTransactionCount","eth_getBlockTransactionCountByHash",
"eth_getBlockTransactionCountByNumber","eth_getUncleCountByBlockHash","eth_getUncleCountByBlockNumber",
"eth_getCode","eth_call","eth_getBlockByHash","eth_getBlockByNumber",
"eth_getTransactionByHash","eth_getTransactionByBlockHashAndIndex",
"eth_getTransactionByBlockNumberAndIndex","eth_getTransactionReceipt",
"eth_getUncleByBlockHashAndIndex","eth_getUncleByBlockNumberAndIndex",
"eth_getCompilers","eth_getLogs","eth_getWork","parity_pendingTransactions"

For POST request

"eth_sendRawTransaction","eth_estimateGas","eth_submitWork","eth_submitHashrate"
## How To Use

Just add Parameters in program.cs according to the requirements of method. Required paramters can be seen on https://github.com/ethereum/wiki/wiki/JSON-RPC#web3_clientversion

## Functions Provided

- Calling API through HttpWebRequest
- Get the response through HttpWebRequest
- The response is converted to JSON Object
- The Result is converted to from Hexadecimal to Decimal
- Nethereum is used to convert balance to wei
- BigInteger is used to store the balance
- BigRational is used to Divide the balance with 10^18 (Decimal places for ethereum)


## Build With

Visual Studio

## Authors

Qasid Labeed - [QasidLabeed](https://github.com/QasidLabeed)

## Acknowledgments

- Hat tip to anyone who's code was used
- Inspiration
- etc
