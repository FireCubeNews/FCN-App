using FCN.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCN.Helpers
{
    public class JsonHelper
    {
        public async static Task<Articles> DeserializeArticlesAsync(string JSON)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<Articles>(JSON);
            });
        }

        public async static Task<string> SerializeArticlesAsync(Articles JSONObj)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.SerializeObject(JSONObj);
            });
        }
    }
}
