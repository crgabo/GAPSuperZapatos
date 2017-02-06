using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GAPSZ.WebAPI.Models
{
    public class APIResponse
    {
        [XmlElement("success")]
        public bool Success { get; set; }

        [XmlElement("error_code")]
        public int ErrorCode { get; set; }
    }

   
}