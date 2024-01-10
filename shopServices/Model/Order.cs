using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopServices.Model
{
    class Order
    {
        public string fioMaster { get; set; } = string.Empty;
        public string telephoneClient { get; set; } = string.Empty;
        public string duration { get; set; } = string.Empty;
        public string animatedImage { get; set; } = string.Empty;
        public string day { get; set; } = string.Empty;
        public string timeIn { get; set; } = string.Empty;
        public string timeout { get; set; } = string.Empty;
        public double price { get; set; } = 0.0;
    }
}
