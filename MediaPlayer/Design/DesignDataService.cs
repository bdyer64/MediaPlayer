using System;
using MediaPlayerModel;
using System.Collections.Generic;

namespace MediaPlayer.Design
{
    public class DesignDataService : IMediaPlayerService
    {
        public IEnumerable<ServiceInfo> GetMediaServices()
        {
            return null;
        }

        public bool UpdateService(Service serviceInfo)
        {
            throw new NotImplementedException();
        }
    }
}