using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.IO;

namespace AzureStorageCopydatafromExternalresources
{
    class Program
    {
        static void Main(string[] args)
        {
            CopydatafromExternalresources();
            Console.WriteLine("Copied..");
            Console.ReadLine();

        }


        static void CopydatafromExternalresources()
        {
            string accountName = "";
            string accountKey = "";
            string newFileName = "";
            string destinationContainer = "";
            string sourceUrl = "";

            CloudStorageAccount csa = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            CloudBlobClient blobClient = csa.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference(destinationContainer);
            blobContainer.CreateIfNotExists();
            var newBlockBlob = blobContainer.GetBlockBlobReference(newFileName);
            newBlockBlob.StartCopy(new Uri(sourceUrl), null, null, null);
        }
    }
}
