using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GAPSZ.WebAPI.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}