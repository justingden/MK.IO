﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO
{
    public partial class LocationResponseSchema
    {
        public static LocationResponseSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LocationResponseSchema>(json, ConverterLE.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }


        [JsonProperty("metadata")]
        public MetadataLocation Metadata { get; set; }
    }


    public class MetadataLocation
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}