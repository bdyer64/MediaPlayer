﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerModel
{
    public interface IMediaProvider
    {
        ServiceInfo GetServiceInfo();
    }
}
