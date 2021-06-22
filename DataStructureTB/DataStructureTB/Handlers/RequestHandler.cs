using CefSharp;
using DataStructureTB.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// http资源请求的处理
    /// </summary>
    class RequestHandler : CefSharp.Handler.RequestHandler
    {

        protected override bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return base.GetAuthCredentials(chromiumWebBrowser, browser, originUrl, isProxy, host, port, realm, scheme, callback);
        }

        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            var JavaScriptObject = chromiumWebBrowser as IJavaScriptObject;
            var requestParamsCapture = new RequestParamsCapture(JavaScriptObject.RequestParams, request);
            requestParamsCapture.SetInjectionItem(AppConfigManager.Inst.GetRequestParamsCaptureConfigItem());
            requestParamsCapture.GetAndAddParams();
            if (requestParamsCapture.IsTargetSite())
                chromiumWebBrowser.ExecuteScriptAsync(requestParamsCapture.GetInjectJavaScriptObject());

            return new ResourceRequestHandler();
        }

        protected override bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            if (chromiumWebBrowser.Address.Contains("application/vnd.ms-excel;base64"))
            {
                string tmpContent = chromiumWebBrowser.Address;//获取传递上来的文件内容
                string contentHead = "data:application/vnd.ms-excel;base64,";
                int startIndex = tmpContent.IndexOf(contentHead);
                int name_StartIndex = tmpContent.IndexOf(contentHead) + contentHead.Length;
                int name_EndIndex = tmpContent.IndexOf('#');
                string fileName = "Excel表格";
                if (name_EndIndex != -1)
                {
                    fileName = Uri.UnescapeDataString(tmpContent.Substring(name_StartIndex, name_EndIndex - name_StartIndex));
                    tmpContent = tmpContent.Substring(name_EndIndex + 1);
                }
                else
                {
                    tmpContent = tmpContent.Substring(name_StartIndex);
                }
                byte[] output = Convert.FromBase64String(tmpContent);
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = fileName + ".xls";
                dialog.Filter = "(Excel文件)|*.xls";
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(output, 0, output.Length);
                        fs.Flush();
                    }
                    return true;
                }
            }
            return false;
        }

    }
}
