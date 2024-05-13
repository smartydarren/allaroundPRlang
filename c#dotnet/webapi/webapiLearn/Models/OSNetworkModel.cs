using System;
using System.Collections.Generic;
using System.Text;

namespace webapiLearn.Models
{
    public class OSNetworksGetResponse
    {
        public List<NetworkItem> Networks { get; set; }
        public List<LogoItem> Logos { get; set; }

        public OSNetworksGetResponse()
        { 
            this.Networks = new List<NetworkItem>();
            this.Logos = new List<LogoItem>();
        }

        public class NetworkItem
        { 
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int? LogoId { get; set; }
            public string LogoName { get; set; }
            public string? LogoUrl { get; set; }
            public bool IsActive { get; set; }
        }
        public class LogoItem
        { 
            public long Id { get; set; }
            public string Name { get; set; }
            public long ImageId { get; set; }
            public string LogoURL { get; set; }
        }
    }

    public class OSNetworkCreateRequest
    {
        public string NetworkName { get; set; }     //required
        public string NetworkDescription { get; set; }      //required
        public long? LogoId { get; set; }
        public string LogoName { get; set; }
        public string ImageFileName { get; set; }
        public string FileBody { get; set; }
        public string CarrierCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class OSNetworkCreateResponse
    {
        public long Id { get; set; }
    }

    public class OSNetworkUpdateRequest
    {
        public string NetworkName { get; set; }     //required
        public string NetworkDescription { get; set; }      //required
        public long? LogoId { get; set; }
        public string LogoName { get; set; }
        public string ImageFileName { get; set; }
        public string FileBody { get; set; }
        public string CarrierCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class OSNetworkUpdateResponse
    {
        public long Id { get; set; }
    }
}
