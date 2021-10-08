using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Data
{
    public class ModFileUpdate
    {
        public int old_file_id { get; set; }
        public int new_file_id { get; set; }
        public string old_file_name { get; set; }
        public string new_file_name { get; set; }
        public int uploaded_timestamp { get; set; }
        public DateTime uploaded_time { get; set; }
    }
}
