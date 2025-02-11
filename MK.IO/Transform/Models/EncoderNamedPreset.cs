﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace MK.IO
{
    /// <summary> The built-in preset to be used for encoding videos. </summary>
    public readonly partial struct EncoderNamedPreset
    {
        public static readonly string H264SingleBitrateSD = "H264SingleBitrateSD";
        public static readonly string H264SingleBitrate720p = "H264SingleBitrate720p";
        public static readonly string H264SingleBitrate1080p = "H264SingleBitrate1080p";
        public static readonly string H264MultipleBitrate1080p = "H264MultipleBitrate1080p";
        public static readonly string H264MultipleBitrate720p = "H264MultipleBitrate720p";
        public static readonly string H264MultipleBitrateSD = "H264MultipleBitrateSD";

        public static readonly string H265SingleBitrate1080p = "H265SingleBitrate1080p";
        public static readonly string H265SingleBitrate4K = "H265SingleBitrate4K";
    }
}