using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto.NET.HashTesting
{
    class HashTesting
    {
        static void Main(string[] args)
        {
            string data1 = "Hello World!";
            string data2 = "Hello World";

            HashAlgorithm sha256Hasher = SHA256.Create();


            byte[] result1Bytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(data1)); // compute the hash of data1
            string hexResults1 = BitConverter.ToString(result1Bytes).Replace("-", ""); // convert the resultant byte array to a hex string
            Console.WriteLine(hexResults1);

            byte[] result2Bytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(data2));  // compute the hash of data2
            string hexResults2 = BitConverter.ToString(result2Bytes).Replace("-", ""); // convert the resultant byte array to a hex string
            Console.WriteLine(hexResults2);


            // Let's do the same with a different hashing Algorithm

            HashAlgorithm sha1Hasher = SHA1.Create();

            result1Bytes = sha1Hasher.ComputeHash(Encoding.ASCII.GetBytes(data1)); // compute the hash of data1
            hexResults1 = BitConverter.ToString(result1Bytes).Replace("-", ""); // convert the resultant byte array to a hex string
            Console.WriteLine(hexResults1);

            result2Bytes = sha1Hasher.ComputeHash(Encoding.ASCII.GetBytes(data2));  // compute the hash of data2
            hexResults2 = BitConverter.ToString(result2Bytes).Replace("-", ""); // convert the resultant byte array to a hex string
            Console.WriteLine(hexResults2);
        }
    }
}