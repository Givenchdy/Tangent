using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.Models
{

    [Newtonsoft.Json.JsonObject(Title = "position")]
    public class Position
    {
        public int id;
        public string name;
        public string level;
        public int sort;

    }
}
