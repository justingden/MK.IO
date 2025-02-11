﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using MK.IO.Models;
using Newtonsoft.Json;

namespace MK.IO
{
    /// <summary>
    /// REST Client for MKIO
    /// https://io.mediakind.com
    /// 
    /// </summary>
    internal class LiveOutputsOperations : ILiveOutputsOperations
    {
        //
        // live outputs
        //
        private const string _liveOutputsApiUrl = MKIOClient._liveEventsApiUrl + "/{1}/liveOutputs";
        private const string _liveOutputApiUrl = _liveOutputsApiUrl + "/{2}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the LiveEventsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal LiveOutputsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public List<LiveOutputSchema> List(string liveEventName)
        {
            var task = Task.Run<List<LiveOutputSchema>>(async () => await ListAsync(liveEventName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<List<LiveOutputSchema>> ListAsync(string liveEventName)
        {
            var url = Client.GenerateApiUrl(_liveOutputsApiUrl, liveEventName);
            string responseContent = await Client.GetObjectContentAsync(url);
            return JsonConvert.DeserializeObject<LiveOutputListResponseSchema>(responseContent, ConverterLE.Settings).Value;
        }

        /// <inheritdoc/>
        public LiveOutputSchema Get(string liveEventName, string liveOutputName)
        {
            var task = Task.Run<LiveOutputSchema>(async () => await GetAsync(liveEventName, liveOutputName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveOutputSchema> GetAsync(string liveEventName, string liveOutputName)
        {
            var url = Client.GenerateApiUrl(_liveOutputApiUrl, liveEventName, liveOutputName);
            string responseContent = await Client.GetObjectContentAsync(url);
            return JsonConvert.DeserializeObject<LiveOutputSchema>(responseContent, ConverterLE.Settings);
        }

        /// <inheritdoc/>
        public LiveOutputSchema Create(string liveEventName, string liveOutputName, LiveOutputProperties properties)
        {
            var task = Task.Run<LiveOutputSchema>(async () => await CreateAsync(liveEventName, liveOutputName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveOutputSchema> CreateAsync(string liveEventName, string liveOutputName, LiveOutputProperties properties)
        {
            var url = Client.GenerateApiUrl(_liveOutputApiUrl, liveEventName, liveOutputName);
            //tags ??= new Dictionary<string, string>();
            var content = new LiveOutputSchema { Properties = properties };
            string responseContent = await Client.CreateObjectAsync(url, content.ToJson());
            return JsonConvert.DeserializeObject<LiveOutputSchema>(responseContent, ConverterLE.Settings);
        }

        /// <inheritdoc/>
        public void Delete(string liveEventName, string liveOutputName)
        {
            Task.Run(async () => await DeleteAsync(liveEventName, liveOutputName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string liveEventName, string liveOutputName)
        {
            var url = Client.GenerateApiUrl(_liveOutputApiUrl, liveEventName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete);
        }
    }
}