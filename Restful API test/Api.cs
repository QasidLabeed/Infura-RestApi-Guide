using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;
using Numerics;
using Nethereum.Web3;

namespace Restful_API_test
{
    
    public class Api
    {
        /* This function is used to send http request to API*/
        public string CallApi(string url) {

            string Result = string.Empty;
           
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            Request.KeepAlive = false;
            Request.Method = "GET"; // Would be POST for some methods 
            
            //For SSL/TLS exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Result = reader.ReadToEnd();
                }

                //To Get Result in Hex Value 
                var HexValue = GetStringResult(GetJsonObj(Result));

                //To Convert Hex To Decimal
                var DecValue = HexToDecString(HexValue);
                return Result;

            }

            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    Console.WriteLine(errorText);
                }
                throw;
            }            
        }

        public JObject GetJsonObj(string result)
        {
            var JObj = JObject.Parse(result);
            return JObj;
        }

        public string GetStringResult(JObject res) {

            /*For result containing multiple values can be extracted by calling the relevant index
            * e.g (string)res["result"]["nounce"] */
            string Str = Convert.ToString(res["result"]);
            return Str;
        }

        public string HexToDecString(string val) {

            //Removes the '0x' from the result to passed to BigInteger
            var str = val.Substring(2, (val.Length) - 2);

            BigInteger dec = new BigInteger(str, 16);
            var ToString = dec.ToString();
            return ToString;
        }

        public Double StringToEther(string str)
        {
            Web3 web3 = new Web3();
            var Wei = web3.Convert.ToWei(str, UnitConversion.EthUnit.Wei);

            //Balance divided by 10^18
            var Balance = new BigRational(Wei, 1000000000000000000); 
            return (double)Balance;

        }
    }
}
