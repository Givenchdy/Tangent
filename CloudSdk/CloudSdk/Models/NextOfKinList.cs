using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.Models
{

    [Newtonsoft.Json.JsonObject(Title = "employee_next_of_kin")]
    class NextOfKinList
    {
        public LinkedList<NextOfKin> employee_next_of_kin = new LinkedList<NextOfKin>();
    }
}
