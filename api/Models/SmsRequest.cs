using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api.Models
{
    public class SmsRequest
    {
        public string Number { get; set; }
        public string Content { get; set; }
    }
}