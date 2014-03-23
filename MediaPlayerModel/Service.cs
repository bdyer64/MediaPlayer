using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MediaPlayerModel
{
    public class Service
    {
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ServerURL { get; set; }

        virtual public async Task<bool> TestConnection()
        {
            await Task.Delay(1000);
            return false;
        }

        virtual public void Save()
        {

        }
    }
}
