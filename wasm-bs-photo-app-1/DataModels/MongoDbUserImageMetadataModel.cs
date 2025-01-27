
using System;
using System.Collections.Generic;

namespace auth_api_1.Data
{

    public class MongoDbUserImageMetadataModel
    {

        public int Id { get; set; }

        public long OwnerUserId { get; set; }

        public string OriginalName { get; set; }
        public string CurrentName { get; set; }

        public string UserDescription { get; set; }

        public int SizeKB { get; set; }


        public DateTime ImageUploadedDatetime { get; set; }

        public string CameraType { get; set; }

        public string UploadSource { get; set; }


        public string Folder { get; set; }

        public List<Competition> Competitions { get; set; }

        public string NrOfViews { get; set; }
    }

    public class Competition
    {
        public string CompetitionId { get; set; }

        public string Status { get; set; }


        public string Approval { get; set; }

        public int Votes { get; set; }

        public string MyMotivation { get; set; }
    }
}
