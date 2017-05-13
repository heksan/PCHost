using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost.Objects
{
    [DataContract]
    public class PlayableElement
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Length { get; set; }
        [DataMember]
        public string Link { get; set; }
        public PlayableElement()
        {

        }
        public PlayableElement(string title,string length,string link)
        {
            Title = title;
            Length = length;
            Link = link;
        }
    }
}
