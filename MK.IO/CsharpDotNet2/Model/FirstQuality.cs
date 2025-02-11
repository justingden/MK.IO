using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class FirstQuality
    {
        /// <summary>
        /// Not yet implemented. Denotes the target video bitrate to be used when starting playback of an HLS video manifest.          If the defined bitrate exactly matches a bitrate in the video manifest, that playlist will be presented first among the available representations in the manifest.         If the defined bitrate is between quality levels, we take the closest of the adjacent playlists and move them to the top, ignoring sequencing for other playlists.         If the defined quality exceeds that of the bitrates in the manifest, we order largest to smallest.          If the defined bitrate underruns the bitrates in the manifest, we order smallest to largest.          
        /// </summary>
        /// <value>Not yet implemented. Denotes the target video bitrate to be used when starting playback of an HLS video manifest.          If the defined bitrate exactly matches a bitrate in the video manifest, that playlist will be presented first among the available representations in the manifest.         If the defined bitrate is between quality levels, we take the closest of the adjacent playlists and move them to the top, ignoring sequencing for other playlists.         If the defined quality exceeds that of the bitrates in the manifest, we order largest to smallest.          If the defined bitrate underruns the bitrates in the manifest, we order smallest to largest.          </value>
        [DataMember(Name = "bitrate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bitrate")]
        public int? Bitrate { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirstQuality {\n");
            sb.Append("  Bitrate: ").Append(Bitrate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
