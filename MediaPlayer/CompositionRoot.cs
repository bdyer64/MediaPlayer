using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace MediaPlayer
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
            ServiceLocator.Current.GetInstance<Views.ViewNavigator>();
        }
    }
}
