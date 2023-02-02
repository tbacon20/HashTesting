using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Crypto.NET.HashTesting
{
    class HashTesting
    {
        static void Main(string[] args)
        {
            
            FilePath fp = new FilePath();
            string filePath = fp.filePath;
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), filePath, "RootBeerTest365A.pdf");
            using FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs);

            string fileName2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), filePath, "RootBeerTest365B.pdf");
            using FileStream fs2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader streamReader2 = new StreamReader(fs2);

            string data1 = streamReader.ReadToEnd();
            string data2 = streamReader2.ReadToEnd();

            /*

            string data1 = "Hello World";
            string data2 = "Hello World";

            */

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