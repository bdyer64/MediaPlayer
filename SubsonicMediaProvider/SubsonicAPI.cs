using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SubsonicMediaProvider
{
    public class SubsonicAPI
    {
        private Action<Stream> httpCallback;

        public SubsonicAPI()
        {

        }

        private void HttpRequestCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            WebResponse response = request.EndGetResponse(result);

            Stream s = response.GetResponseStream();

            httpCallback(s);
        }

        public void MakeHTTPRequest(string url,Action<Stream> callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            httpCallback = callback;

            var  uri = new Uri(url);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.BeginGetResponse(HttpRequestCallback, request);
        }
    }
}

