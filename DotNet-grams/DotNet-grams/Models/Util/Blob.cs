﻿using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_grams.Models.Util
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// get container
        /// </summary>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
          await  cbc.CreateIfNotExistsAsync();
           await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess =
                BlobContainerPublicAccessType.Blob
            });

            return cbc;
        }

        /// <summary>
        /// get blob
        /// </summary>
        /// <returns></returns>
        public async Task<CloudBlob> GetBlob(string imageName,string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
        }


        public void UploadFile(CloudBlobContainer cloudBlobContainer,string fileName,string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }

    }
}
