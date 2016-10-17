using Fiddler;
using System;

namespace D365_Fiddler
{
    public class Decoder
    {
        public byte[] Decode(HTTPRequestHeaders headers)
        {
            byte[] jsonByteArray = new byte[0];

            if (headers.Exists(Constants.CustomHeader))
            {
                var contextHeader = headers[Constants.CustomHeader];

                jsonByteArray = Convert.FromBase64String(contextHeader);
            }

            return jsonByteArray;
        }
    }
}
