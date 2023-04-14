using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Logging;
using System.Security.Cryptography;
using System.IO;

namespace VAdvantage.Utility
{
    public class SecureEngine
    //internal class SecureEngine
    {
        /// <summary>
        /// Encrypt the text
        /// </summary>
        /// <param name="value">Value to be encrypted</param>
        /// <returns>Encrypted Value</returns>
        public static String Encrypt(string value)
        {
            String ret = Lambda.Encrypt(value).GetStorableValue();
            return ret; 
            //return  SecureEngineUtility.SecureEngine.Encrypt(value);
        }	//	encrypt
        /// <summary>
        /// Encrypt the text
        /// </summary>
        /// <param name="value">Value to be encrypted</param>
        /// <returns>Encrypted Value</returns>
        public static byte[] Encrypt(char[] value)
        {
            string data = new string(value);
            LambdaBean lb = Lambda.Encrypt(data);
            byte[] ret = Encoding.ASCII.GetBytes(lb.GetStorableValue());
            return ret; 
            //return SecureEngineUtility.SecureEngine.Encrypt(value);
        }	//	encrypt

        /// <summary>
        /// Decrypt the Text
        /// </summary>
        /// <param name="value">Value to be decrypted</param>
        /// <returns>Decrypted Text</returns>
        public static String Decrypt(String value)
        {
            string data = value;
            LambdaBean lb = Lambda.Decrypt(data);
            string ret = lb.value;
            return ret;
            //return SecureEngineUtility.SecureEngine.Decrypt(value);
        }	//	decrypt



        /// <summary>
        /// Decrypt the Text
        /// </summary>
        /// <param name="value">Value to be decrypted</param>
        /// <returns>Decrypted Text</returns>
        public static byte[] Decrypt(byte[] value)
        {
            string data = Encoding.ASCII.GetString(value);
            LambdaBean lb = Lambda.Decrypt(data);
            byte[] ret = Encoding.UTF8.GetBytes(lb.value);
            return ret;
            //return SecureEngineUtility.SecureEngine.Decrypt(value);
        }	//	decrypt

        /// <summary>
        /// 	Encryption.
        /// The methods must recognize clear values
        /// </summary>
        /// <param name="value">@param value clear value</param>
        /// <returns>   @return encrypted String</returns>
        public static Object Encrypt(Object value)
        {

            return Lambda.Encrypt(value.ToString()).GetStorableValue();
            //return SecureEngineUtility.SecureEngine.Encrypt(value);
        }	//	encrypt

        /// <summary>
        ///	Decryption.
        /// the methods must recognize clear values
        /// </summary>
        /// <param name="value">value encrypted value</param>
        /// <returns>Decrypted value</returns>
        public static Object Decrypt(Object value)
        {
            string data = (string)value;
            LambdaBean lb = Lambda.Decrypt(data);
            return lb.value;
            //return SecureEngineUtility.SecureEngine.Decrypt(value);
        }	//	decrypt

        public static bool IsEncrypted(String value)
        {
            //return SecureEngineUtility.SecureEngine.IsEncrypted(value);
            if(value is null)
            {
                return false;
            }
            return value.Contains("|");
        }	//	isEncrypted
    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <returns>
        /// returns Fullpath of file
        /// </returns>
        public static byte[] EncryptFile(byte[] inputFile, string password)
        {
            return SecureEngineUtility.SecureEngine.EncryptFile(inputFile, password);
        }

        public static byte[] DecryptFile(byte[] inputFile, string password)
        {
            return SecureEngineUtility.SecureEngine.DecryptFile(inputFile, password);
        }



        public static bool EncryptFile(string inputFilePath, string password, string outputFileName)
        {
            return SecureEngineUtility.SecureEngine.EncryptFile(inputFilePath, password, outputFileName);
        }



        public static bool DecryptFile(string inputFilePath, string password, string outputFileName)
        {
            return SecureEngineUtility.SecureEngine.DecryptFile(inputFilePath, password, outputFileName);
        }


        internal static string GetClassName()
        {
            return SecureEngineUtility.SecureEngine.GetClassName();
        }
    }
}
