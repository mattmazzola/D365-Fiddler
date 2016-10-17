using Fiddler;
using Standard;
using System.Windows.Forms;

[assembly: Fiddler.RequiredVersion("2.3.0.0")]
namespace D365_Fiddler
{
    public class D365FiddlerExtension : Inspector2, IRequestInspector2
    {
        JSONRequestViewer jsonRequestViewer;
        HTTPRequestHeaders requestHeaders;
        Decoder decoder;

        public byte[] body
        {
            get
            {
                return jsonRequestViewer.body;
            }
            set
            {
                if (decoder != null && value != null)
                {
                    value = decoder.Decode(headers);
                }

                jsonRequestViewer.body = value;
            }
        }

        public bool bReadOnly
        {
            get
            {
                return jsonRequestViewer.bReadOnly;
            }
            set
            {
                jsonRequestViewer.bReadOnly = value;
            }
        }

        public bool bDirty
        {
            get
            {
                return jsonRequestViewer.bDirty;
            }
        }

        public HTTPRequestHeaders headers
        {
            get
            {
                return requestHeaders;
            }
            set
            {
                requestHeaders = value;
                jsonRequestViewer.headers = value;
            }
        }

        public override void AssignSession(Session oS)
        {
            decoder = new Decoder();
            base.AssignSession(oS);
        }

        public override void AddToTab(TabPage o)
        {
            jsonRequestViewer = new JSONRequestViewer();
            jsonRequestViewer.AddToTab(o);
            o.Text = Constants.TabName;
        }

        public void Clear()
        {
            jsonRequestViewer.Clear();
        }

        public override int GetOrder()
        {
            return jsonRequestViewer.GetOrder();
        }

        public override int ScoreForContentType(string sMIMEType)
        {
            return jsonRequestViewer.ScoreForContentType(sMIMEType);
        }

        public override void SetFontSize(float flSizeInPoints)
        {
            jsonRequestViewer.SetFontSize(flSizeInPoints);
        }
    }
}
