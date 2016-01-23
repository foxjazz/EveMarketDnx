using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EveMarketDnx.Data
{
    public class EveData
    {
        public List<KeyValuePair<string, string>> EveItems;
        public EveData()
        {
            PopulateEveItems();
        }
        public void PopulateEveItems()
        {
            if (EveItems != null)
                return;
            var json = new JsonSerializer();
            var fileContents = System.IO.File.ReadAllText(@"lkvp.json");
            EveItems = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(fileContents);
        }
    }
}
