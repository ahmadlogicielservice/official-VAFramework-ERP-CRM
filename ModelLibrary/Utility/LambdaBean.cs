using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAdvantage.Utility
{
    /// <summary>
    /// Holds Encrypt/Decrypt JSON return as class
    /// </summary>
    class LambdaBean
    {
        public int code = -1;
        public string message = "";
        public string value = "";
        public string nonce = "";

        /// <summary>
        /// Gives the base64 String for nonce and value, seperated by |
        /// Nonce should be 16 characters long
        /// </summary>
        /// <returns>String</returns>
        public string GetStorableValue()
        {
            return this.nonce + "|" + this.value;
        }

        /// <summary>
        /// Get byte version of value
        /// </summary>
        /// <returns>value byte[]</returns>
        public byte[] GetByteValue()
        {
            return Convert.FromBase64String(this.value);
        }

        /// <summary>
        /// Get byte version of nonce
        /// </summary>
        /// <returns>nonce as byte[]</returns>
        public byte[] GetByteNonce()
        {
            return Convert.FromBase64String(this.nonce);
        }

        public override string ToString()
        {
            return string.Format("Lambda Bean{{\"code\": {0}, \"message\": \"{1}\", \"value\": \"{2}\", \"nonce\": \"{3}\"}}", this.code, this.message, this.value, this.nonce);
        }
    }
}