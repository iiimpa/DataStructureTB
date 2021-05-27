using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructureTB.Handlers
{
    class ResponseFilter : IResponseFilter
    {
        private readonly string _url;

        private readonly IWebBrowser _chromiumBrowser;

        private string _fingerprint;

        public ResponseFilter(string url, IWebBrowser chromiumBrowser, string fingerprint)
        {
            _fingerprint = fingerprint;
            _url = url;
            _chromiumBrowser = chromiumBrowser;
        }

        private List<byte> dataOutBuffer = new List<byte>();

        bool IResponseFilter.InitFilter()
        {
            return true;
        }

        FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            #region Update
            if (dataIn == null)
            {
                dataInRead = 0;
                dataOutWritten = 0;

                var maxWrite = Math.Min(dataOutBuffer.Count, dataOut.Length);

                //Write the maximum portion that fits in dataOut.
                if (maxWrite > 0)
                {
                    dataOut.Write(dataOutBuffer.ToArray(), 0, (int)maxWrite);
                    dataOutWritten += maxWrite;
                }

                //If dataOutBuffer is bigger than dataOut then we'll write the
                // data on the second pass
                if (maxWrite < dataOutBuffer.Count)
                {
                    // Need to write more bytes than will fit in the output buffer. 
                    // Remove the bytes that were written already
                    dataOutBuffer.RemoveRange(0, (int)(maxWrite - 1));

                    return FilterStatus.NeedMoreData;
                }

                //All data was written, so we clear the buffer and return FilterStatus.Done
                dataOutBuffer.Clear();

                return FilterStatus.Done;
            }

            //We're going to read all of dataIn
            dataInRead = dataIn.Length;

            var dataInBuffer = new byte[(int)dataIn.Length];
            dataIn.Read(dataInBuffer, 0, dataInBuffer.Length);
            //Add all the bytes to the dataOutBuffer
            dataOutBuffer.AddRange(dataInBuffer);

            dataOutWritten = 0;

            //The assumption here is dataIn is smaller than dataOut then this will be the last of the
            //data to read and we can start processing, this is not a production tested assumption
            if (dataIn.Length < dataOut.Length)
            {
                var bytes = ReplaceTextInBufferedData(dataOutBuffer.ToArray());

                //Clear the buffer and add the processed data, it's possible
                //that with our processing the data has become to large to fit in dataOut
                //So we'll have to write the data in multiple passes in that case
                dataOutBuffer.Clear();
                dataOutBuffer.AddRange(bytes);

                var maxWrite = Math.Min(dataOutBuffer.Count, dataOut.Length);

                //Write the maximum portion that fits in dataOut.
                if (maxWrite > 0)
                {
                    dataOut.Write(dataOutBuffer.ToArray(), 0, (int)maxWrite);
                    dataOutWritten += maxWrite;
                }

                //If dataOutBuffer is bigger than dataOut then we'll write the
                // data on the second pass
                if (maxWrite < dataOutBuffer.Count)
                {
                    // Need to write more bytes than will fit in the output buffer. 
                    // Remove the bytes that were written already
                    dataOutBuffer.RemoveRange(0, (int)(maxWrite - 1));

                    return FilterStatus.NeedMoreData;
                }

                //All data was written, so we clear the buffer and return FilterStatus.Done
                dataOutBuffer.Clear();

                return FilterStatus.Done;
            }
            else
            {
                //We haven't got all of our dataIn yet, so we keep buffering so that when it's finished
                //we can process the buffer, replace some words etc and then write it all out.
                return FilterStatus.NeedMoreData;
            }
            #endregion
        }

        private byte[] ReplaceTextInBufferedData(byte[] bytes)
        {
            if (_url.Contains("https://a.alipayobjects.com/??seajs/seajs/2.1.1/sea.js,seajs/seajs-combo/1.0.0/seajs-combo.js,seajs/seajs-style/1.0.0/seajs-style.js"))
                return bytes;
            string js = "";
            var html = Encoding.UTF8.GetString(bytes);
            int position = html.IndexOf("</head>");
            if (position != -1)
                html = html.Insert(position, _fingerprint).ToString().Replace("\t", "").Replace("\n", "");
            html = html.Replace("// 希望停靠的容器，可选，提供了之后，会计算容器的位置从而使服务窗悬浮在容器的一侧。", "")
                        .Replace("// 停靠容器的选择器", "")
                        .Replace("// 在页面上出现的位置, 可选，可填入的属性为 'left', 'right', 'top', 'bottom'，值必须是数字，默认单位为 px�~B", "")
                        .Replace("// 如果同时提供了 container 和 position，前者计算得出的位置会被后者覆盖�~B", "")
                        .Replace("// 如果 container 和 position 都不提供，默认出现的位置为距离右侧 100px，距离底部 50px�~B", "")
                        .Replace("// 基于上面的参数所计算出来位置作偏移量，可选，x 为水平偏移量，y 为垂直偏移量，值必须是数字，可以是正数或者负数，默认单位为 px�", "")
                        .Replace("// 配置服务窗是否可拖动，false 为可拖动，true 为不可拖动，默认为 false�~B", "")
                        .Replace("// 服务窗的 z-index 值，可选，默认为999999", "")
                        .Replace("// 在后台注册的页面名称, 必填�~B", "")
                        .Replace("// 在后台注册的页面名称, 必填", "")
                        .Replace("// 配置 dialog 相对 layout 的垂直位�|;", "")
                        .Replace("// 配置 dialog 相对 layout 的垂��位�|;", "")
                        .Replace("//校验提示信息", "")
                        .Replace("//短信验证码转换语音的逻辑", "")
                        .Replace("//ignore exception", "")
                        .Replace("//重定向跳转页面", "")
                        .Replace("// 显示错误信息", "")
                        .Replace("//parent 重定向跳转页面", "")
                        .Replace("//ifame页面跳转", "")
                        .Replace("// SNS登录走自己的handler", "")
                        .Replace("// 登录成功", "")
                        .Replace("// 七巧板定制逻辑错误不做处理", "")
                        .Replace("// FIXME", "");
            if (html.IndexOf("<script>") != -1)
                html = html.Insert(html.IndexOf("<script>"), "\r\n");
            if (html.IndexOf("var safeCheck") != -1)
                html = html.Insert(html.IndexOf("var safeCheck"), "\r\n");
            if (html.IndexOf("AsyncUrlUtils") != -1)
                html = html.Insert(html.IndexOf("AsyncUrlUtils"), "\r\n");
            if (html.IndexOf("AsyncUrlUtils") != -1)
                html = html.Insert(html.IndexOf("AsyncUrlUtils"), "\r\n");
            if (_url.Contains("https://login.taobao.com"))
            {
                js += @"
                <script>
                    document.getElementById('header').style.display = 'none';
                    document.getElementsByClassName('footer')[0].style.display = 'none';
                    document.getElementsByClassName('sms-login-tab-item')[0].style.display = 'none';
                    document.getElementsByClassName('sms-login-tab-item')[0].style.display = 'none';
                    document.getElementsByClassName('iconfont icon-qrcode')[0].style.display = 'none';
                    document.getElementsByClassName('login-tip')[0].style.display = 'none';
                    document.getElementsByClassName('login-blocks sns-login-links')[0].style.display = 'none';
                    document.getElementsByClassName('login-blocks login-links')[0].style.display = 'none';
                    document.getElementById('fm-login-id').type = 'password';
                    document.getElementById('fm-login-id').value = '都英数码专营店:伟';
                    document.getElementById('fm-login-password').value = 'a123456789';
                </script>";
            }
            else if (_url.Contains("https://sycm.taobao.com"))
            {
                js += "<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900\">";
                js += "<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/@mdi/font@latest/css/materialdesignicons.min.css\">";
                js += "<link href=\"https://localhost:44343/wwwroot/static/css/chunk-vendors.7b7072aa.css\" rel=\"preload\" as=\"style\">";
                js += "<link href=\"https://localhost:44343/wwwroot/static/js/app.158525fd.js\" rel=\"preload\" as=\"script\" >";
                js += "<link href=\"https://localhost:44343/wwwroot/static/js/chunk-vendors.4671a3a8.js\" rel=\"preload\" as=\"script\" >";
                js += "<link href=\"https://localhost:44343/wwwroot/static/css/chunk-vendors.7b7072aa.css\" rel=\"stylesheet\" >";
                position = html.IndexOf("</head>");
                if (position != -1)
                    html = html.Insert(position, js);
                js = "<div id=\"Extensions\" style=\"display:none;\"></div>";
                js += "<script src=\"https://localhost:44343/wwwroot/static/js/chunk-vendors.4671a3a8.js\" ></script>";
                js += "<script src=\"https://localhost:44343/wwwroot/static/js/app.158525fd.js\"></script>";
                position = html.IndexOf("</body>");
                if (position != -1)
                    html = html.Insert(position, js);
                js = @"<script>
                    var iframe = document.createElement('iframe');
                    iframe.style.display = 'none';
                    document.body.appendChild(iframe);
                    console = iframe.contentWindow.console;
                    window.console = console;
                    document.getElementsByClassName('ebase-frame-header-inner')[0].firstChild.nextSibling.style.display = 'none';
                    document.getElementsByClassName('ebase-frame-header-inner')[0].firstChild.nextSibling.nextSibling.style.display = 'none';
                    document.getElementsByClassName('ebase-frame-header-inner')[0].firstChild.nextSibling.nextSibling.nextSibling.style.display = 'none';
                </script>";
            }
            position = html.IndexOf("</body>");
            if (position != -1)
                html = html.Insert(position, js);
            return Encoding.UTF8.GetBytes(html);
        }

        void IDisposable.Dispose()
        {

        }
    }
}
