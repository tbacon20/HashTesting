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

            // Here is an example of checking the hash on two images
            string data1 = CollectFileData(filePath, "console1.png");
            string data2 = CollectFileData(filePath, "console2.png");

            // Here is an example of checking the hash on two pdfs
            
            string data3 = CollectFileData(filePath, "RootBeerTest365A.pdf");
            string data4 = CollectFileData(filePath, "RootBeerTest365B.pdf");
            

            /*

            string data1 = "Hello World";
            string data2 = "Hello World";

            */


            Console.WriteLine("\nSHA256 hashes: ");
            HashAlgorithm sha256Hasher = SHA256.Create();

            GetHashResults(sha256Hasher, data1);
            GetHashResults(sha256Hasher, data2);
            GetHashResults(sha256Hasher, data3);
            GetHashResults(sha256Hasher, data4);


            // Let's do the same with a different hashing Algorithm
            Console.WriteLine("\nSHA1 hashes: ");
            HashAlgorithm sha1Hasher = SHA1.Create();

            GetHashResults(sha1Hasher, data1);
            GetHashResults(sha1Hasher, data2);
            GetHashResults(sha1Hasher, data3);
            GetHashResults(sha1Hasher, data4);

            // Finally, with MD5
            Console.WriteLine("\nMD5 hashes: ");
            HashAlgorithm md5Hasher = MD5.Create();

            GetHashResults(md5Hasher, data1);
            GetHashResults(md5Hasher, data2);
            GetHashResults(md5Hasher, data3);
            GetHashResults(md5Hasher, data4);
        }

        // This is a method for collecting the data from a file
        static string CollectFileData(string filePath, string fileNameString)
        {

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), filePath, fileNameString);
            
            using FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs);

            string dataString = streamReader.ReadToEnd();

            return dataString;
        }

        static void GetHashResults(HashAlgorithm hashTypeName, string data)
        {
            byte[] result1Bytes = hashTypeName.ComputeHash(Encoding.ASCII.GetBytes(data)); // compute the hash of data1
            string hexResults1 = BitConverter.ToString(result1Bytes).Replace("-", ""); // convert the resultant byte array to a hex string
            Console.WriteLine(hexResults1);
        }
    }
}