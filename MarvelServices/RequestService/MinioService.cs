﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarvelServices.Interface;
using Microsoft.Extensions.Options;
using Minio;
using MarvelServices.Options;
namespace MarvelServices.RequestService
{
    public class MinioService : IStorageProvider
    {
        private readonly MinioClient _client;
        private readonly string? _bucketName;
        public MinioService(IOptions<MinIoOptions> options)
        {
            _bucketName = options.Value.BucketName;
            _client = new MinioClient()
                .WithEndpoint(options.Value.EndPoint)
                .WithCredentials(options.Value.AccessKey, options.Value.SecretKey)
                //Normally in the production we need to configure this as true
                //.WithSSL(options.Value.UseSSL)
                .Build();
        }
        public Task DeleteFileAsync(string fileName, string fileExtension)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPresignedUrl(string fileName)
        {
            var args = new PresignedGetObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(fileName)
                .WithExpiry(1000);
            var presignedUrl = await _client.PresignedGetObjectAsync(args).ConfigureAwait(false);
            return presignedUrl;
        }

        public async Task<string> GetPutPresignedUrl(string fileName)
        {
            var isBucketExist = await this.BucketExist(_bucketName);
            if (isBucketExist == false)
            {
                return string.Empty;
            }
            var args = new PresignedPutObjectArgs()
            .WithBucket(_bucketName)
                .WithObject(fileName)
                .WithExpiry(1000);
            var presignedUrl = await _client.PresignedPutObjectAsync(args).ConfigureAwait(false);
            return presignedUrl;
        }

        public async Task<bool> BucketExist(string bucketName)
        {
            var args = new BucketExistsArgs().WithBucket(bucketName);
            var isExist = await _client.BucketExistsAsync(args).ConfigureAwait(false);
            if (isExist == false)
            {
                await this.CreateBucket(bucketName);
                isExist = true;
            }
            return isExist;
        }

        public async Task CreateBucket(string bucketName)
        {
            await _client.MakeBucketAsync(
                new MakeBucketArgs()
                .WithBucket(bucketName))
                .ConfigureAwait(false);
        }
    }
}
