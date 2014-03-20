using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerModel
{
    public class ServiceInfo
    {
        public bool RequiresServerName { get; set; }
        public string ServiceName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
