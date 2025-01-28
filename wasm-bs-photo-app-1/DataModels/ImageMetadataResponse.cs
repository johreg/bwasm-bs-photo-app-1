
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace auth_api_1.Data
{



    public class PagedResponse
    {
        [JsonPropertyName("items")]
        public List<ImageItem> Items { get; set; }

        [JsonPropertyName("nextPageUrl")]
        public string NextPageUrl { get; set; }
    }

    public class ImageItem
    {
        [JsonPropertyName("_id")]
        public MongoId Id { get; set; }

        [JsonPropertyName("id")]
        public long ImageId { get; set; }

        [JsonPropertyName("ownerUserId")]
        public long OwnerUserId { get; set; }

        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }

        [JsonPropertyName("currentName")]
        public string CurrentName { get; set; }

        [JsonPropertyName("userDescription")]
        public string UserDescription { get; set; }

        [JsonPropertyName("sizeKB")]
        public int SizeKB { get; set; }

        [JsonPropertyName("imageUploadedDatetime")]
        public DateTime ImageUploadedDatetime { get; set; }

        [JsonPropertyName("cameraType")]
        public string CameraType { get; set; }

        [JsonPropertyName("uploadSource")]
        public string UploadSource { get; set; }

        [JsonPropertyName("folder")]
        public string Folder { get; set; }

        [JsonPropertyName("competitions")]
        public List<Competition> Competitions { get; set; }

        [JsonPropertyName("nrOfViews")]
        public string NrOfViews { get; set; }
    }

    public class MongoId
    {
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }
    }

    public class Competition
    {
        [JsonPropertyName("competitionId")]
        public string CompetitionId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("approval")]
        public string Approval { get; set; }

        [JsonPropertyName("votes")]
        public int Votes { get; set; }

        [JsonPropertyName("myMotivation")]
        public string MyMotivation { get; set; }
    }
}
