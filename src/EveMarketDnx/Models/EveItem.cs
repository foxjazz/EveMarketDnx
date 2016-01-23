using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EveMarketDnx.Models
{
    public class EveItem
    {
        [Key]
        public int ItemId { get; set; }
        //public int GroupId { get; set; }
        public string TypeName { get; set; }
    }
}
