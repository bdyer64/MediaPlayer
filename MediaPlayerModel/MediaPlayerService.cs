using System;
using System.Linq;
using System.Collections.Generic;

namespace MediaPlayerModel

{
    public class MediaPlayerService : IMediaPlayerService
    {
        private readonly List<IMediaProvider> mediaProviders;

        public MediaPlayerService(List<IMediaProvider> mediaProviders)
        {
            if (mediaProviders.Count == 0)
            {
                throw new ArgumentException("mediaProviders");
            }

            this.mediaProviders = mediaProviders;
        }

        public IEnumerable<ServiceInfo> GetMediaServices()
        {
            return (from ms in mediaProviders select ms.GetServiceInfo()).ToList();
        }
    }
}