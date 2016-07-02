using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ReactDotNetApi.Models
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string author { get; set; }
        [DataMember]
        public string text { get; set; }
    }
}