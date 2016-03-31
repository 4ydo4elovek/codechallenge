using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfServices
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public IList<int> Nodes { get; set; }
    }
}