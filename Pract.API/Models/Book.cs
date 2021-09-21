using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Pract.API.Models
{
    [DataContract]
    public class Books
    {
        
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int price { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string author { get; set; }
    }
}
