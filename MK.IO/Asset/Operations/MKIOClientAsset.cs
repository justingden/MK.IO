﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MK.IO
{
    /// <summary>
    /// REST Client for MKIO
    /// https://io.mediakind.com
    /// 
    /// </summary>
    public partial class MKIOClient
    {
        //
        // assets
        //
        private const string assetsApiUrl = "api/ams/{0}/assets";
        private const string assetApiUrl = assetsApiUrl + "/{1}";
        private const string assetListStreamingLocatorsApiUrl = assetApiUrl + "/listStreamingLocators";
        private const string assetListTracksAndDirectoryApiUrl = assetApiUrl + "/storage/";

        /// <summary>
        /// Retrieves a list of assets in the instance.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        public List<AssetSchema> ListAssets(string? orderBy = null, int? top = null)
        {
            Task<List<AssetSchema>> task = Task.Run<List<AssetSchema>>(async () => await ListAssetsAsync(orderBy, top));
            return task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a list of assets in the instance.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        public async Task<List<AssetSchema>> ListAssetsAsync(string? orderBy = null, int? top = null)
        {
            string URL = GenerateApiUrl(assetsApiUrl);
            URL = AddParametersToUrl(URL, "$orderby", orderBy);
            URL = AddParametersToUrl(URL, "$top", top != null ? ((int)top).ToString() : null);
            string responseContent = await GetObjectContentAsync(URL);
            return JsonConvert.DeserializeObject<AssetListResponseSchema>(responseContent, ConverterLE.Settings).Value;
        }

        public AssetSchema GetAsset(string assetName)
        {
            Task<AssetSchema> task = Task.Run<AssetSchema>(async () => await GetAssetAsync(assetName));
            return task.GetAwaiter().GetResult();
        }

        public async Task<AssetSchema> GetAssetAsync(string assetName)
        {
            string URL = GenerateApiUrl(assetApiUrl, assetName);
            string responseContent = await GetObjectContentAsync(URL);
            return JsonConvert.DeserializeObject<AssetSchema>(responseContent, ConverterLE.Settings);
        }

        public AssetSchema CreateOrUpdateAsset(string assetName, string containerName, string storageName, string description = null)
        {
            Task<AssetSchema> task = Task.Run<AssetSchema>(async () => await CreateOrUpdateAssetAsync(assetName, containerName, storageName, description));
            return task.GetAwaiter().GetResult();
        }

        public async Task<AssetSchema> CreateOrUpdateAssetAsync(string assetName, string containerName, string storageName, string description = null)
        {
            string URL = GenerateApiUrl(assetApiUrl, assetName);
            AssetSchema content = new()
            {
                Name = assetName,
                Properties = new AssetProperties
                {
                    Container = containerName,
                    Description = description,
                    StorageAccountName = storageName
                }
            };

            string responseContent = await CreateObjectAsync(URL, JsonConvert.SerializeObject(content, Formatting.Indented));
            return JsonConvert.DeserializeObject<AssetSchema>(responseContent, ConverterLE.Settings);
        }

        public void DeleteAsset(string assetName)
        {
            Task.Run(async () => await DeleteAssetAsync(assetName));
        }

        public async Task DeleteAssetAsync(string assetName)
        {
            string URL = GenerateApiUrl(assetApiUrl, assetName);
            await ObjectContentAsync(URL, HttpMethod.Delete);
        }

        public List<AssetStreamingLocator> ListStreamingLocatorsForAsset(string assetName)
        {
            Task<List<AssetStreamingLocator>> task = Task.Run<List<AssetStreamingLocator>>(async () => await ListStreamingLocatorsForAssetAsync(assetName));
            return task.GetAwaiter().GetResult();
        }

        public async Task<List<AssetStreamingLocator>> ListStreamingLocatorsForAssetAsync(string assetName)
        {
            string URL = GenerateApiUrl(assetListStreamingLocatorsApiUrl, assetName);
            string responseContent = await GetObjectContentAsync(URL);
            return AssetListStreamingLocators.FromJson(responseContent).StreamingLocators;
        }

        public AssetStorageResponseSchema ListTracksAndDirListingForAsset(string assetName)
        {
            var task = Task.Run<AssetStorageResponseSchema>(async () => await ListTracksAndDirListingForAssetAsync(assetName));
            return task.GetAwaiter().GetResult();
        }

        public async Task<AssetStorageResponseSchema> ListTracksAndDirListingForAssetAsync(string assetName)
        {
            string URL = GenerateApiUrl(assetListTracksAndDirectoryApiUrl, assetName);
            string responseContent = await GetObjectContentAsync(URL);
            //return AssetStorageResponseSchema.FromJson(responseContent).Spec;
            return JsonConvert.DeserializeObject<AssetStorageResponseSchema>(responseContent, ConverterLE.Settings);
        }
    }
}