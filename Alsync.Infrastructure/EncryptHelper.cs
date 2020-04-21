﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Alsync.Infrastructure
{
    public static class EncryptHelper
    {
        /// <summary>
        /// MD5哈希加密字节数组。
        /// </summary>
        /// <param name="bytes">要加密的字节数组。</param>
        /// <returns>返回MD5加密后的哈希值。</returns>
        public static string MD5Hash(byte[] bytes)
        {
            var hash = new StringBuilder();
            var algorithm = new MD5CryptoServiceProvider(); //replace MD5.Create()
            //algorithm.Hash as same as the value execute algorithm.ComputeHash(bytes);
            algorithm.ComputeHash(bytes)
                .ToList()
                .ForEach(m => hash.AppendFormat("{0:X2}", m));  //{0:x2} hex string, replace the method of BitConverter.ToString.
            var hexString = hash.ToString();
            return hexString;
        }

        /// <summary>
        /// MD5哈希加密字符串。
        /// </summary>
        /// <param name="text">要加密的文本。</param>
        /// <returns>返回MD5加密后的哈希值。</returns>
        public static string MD5Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var hexString = MD5Hash(bytes);
            return hexString;
        }

        /// <summary>
        /// SHA1哈希加密字符串。
        /// </summary>
        /// <param name="text">要加密的文本。</param>
        /// <returns>返回SHA1加密后的哈希值。</returns>
        public static string SHA1Hash(string text)
        {
            //var algorithm = SHA1.Create();
            var algorithm = new SHA1CryptoServiceProvider();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            var hexString = BitConverter.ToString(algorithm.Hash).Replace("-", string.Empty).ToUpper();
            return hexString;
        }
    }
}
