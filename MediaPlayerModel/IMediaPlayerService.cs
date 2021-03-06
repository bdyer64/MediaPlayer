﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerModel
{
    public interface IMediaPlayerService
    {
        IEnumerable<ServiceInfo> GetMediaServices();
        bool UpdateService(Service serviceInfo);
    }
}
