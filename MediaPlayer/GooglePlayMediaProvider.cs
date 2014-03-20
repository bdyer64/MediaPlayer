using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerModel;

namespace MediaPlayer
{
    public class GooglePlayMediaProvider : IMediaProvider
    {
        public ServiceInfo GetServiceInfo()
        {
            var si = new ServiceInfo();
            si.RequiresServerName = false;
            si.ServiceName = "Google Play";
            si.ImageData = new byte[0];

            return si;
        }
    }
}
