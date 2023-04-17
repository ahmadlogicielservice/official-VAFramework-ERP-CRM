using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp; //Nuget package v105.0.0

namespace VIS.Helpers
{
    class Lambda
    {

        private static readonly string url = "https://wfya6dmbkvmavfz7uv6grsshwu0fgngi.lambda-url.ap-south-1.on.aws/";
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Encrypt the provided data
        /// </summary>
        /// <param name="body">String to encrypt</param>
        /// <returns>JSON as a Lambda Class</returns>
        public static async Task<LambdaBean> EncryptData(string body)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(body);
                    var response = await client.PostAsync(url, content);
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<LambdaBean>(jsonString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// Decrypt the provided data
        /// </summary>
        /// <param name="body">String to decrypt</param>
        /// <param name="nonce">nonce value, provided by encrypt</param>
        /// <returns>JSON as a Lambda Class</returns>
        public static async Task<LambdaBean> DecryptData(string body, String nonce)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("x_nonce", nonce);
                    var content = new StringContent(body);
                    var response = await client.PutAsync(url, content);
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<LambdaBean>(jsonString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// Encrypt the provided data (non async)
        /// </summary>
        /// <param name="body">String to encrypt</param>
        /// <returns>JSON as a Lambda Class</returns>
        public static LambdaBean Encrypt(string data)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddParameter("text/plaintext", data, ParameterType.RequestBody);
                var response = client.Post(request);
                return JsonConvert.DeserializeObject<LambdaBean>(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        /// <summary>
        /// Decrypt the provided data (non async)
        /// </summary>
        /// <param name="body">String to decrypt</param>
        /// <param name="nonce">nonce value, provided by encrypt</param>
        /// <returns>JSON as a Lambda Class</returns>
        public static LambdaBean Decrypt(string data, string nonce)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddParameter("text/plaintext", data, ParameterType.RequestBody);
                request.AddHeader("x_nonce", nonce);
                var response = client.Put(request);
                return JsonConvert.DeserializeObject<LambdaBean>(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public static LambdaBean Decrypt(string value)
        {
            var values = value.Split('|');
            var data = values[1];
            var nonce = values[0];
            return Decrypt(data, nonce);
        }
    }
}