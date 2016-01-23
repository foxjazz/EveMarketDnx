using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveMarketDnx.Models
{
    public class EveBuy
    {
        int EveBuyID { get; set; }
        int EveItemId { get; set; }
        int EveRegionId { get; set; }
        double BuyPrice { get; set; }
        int Quantity { get; set; }
        int System { get; set; }
    }
}
