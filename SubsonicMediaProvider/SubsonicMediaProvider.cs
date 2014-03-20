using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaPlayerModel;

namespace SubsonicMediaProvider
{
    public class SubsonicMediaProvider : IMediaProvider
    {
        public ServiceInfo GetServiceInfo()
        {
            var si = new ServiceInfo();
            si.RequiresServerName = true;
            si.ServiceName = "Subsonic";
            si.ImageData = new byte[0];

            return si;
        }
    }
}
