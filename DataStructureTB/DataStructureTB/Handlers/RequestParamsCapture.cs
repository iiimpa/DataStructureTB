using CefSharp;
using DataStructureTB.Common;
using DataStructureTB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructureTB.Handlers
{
    internal class RequestParamsCapture
    {
        private IRequest _request { get; }

        private List<RequestParamsCaptureModel> _requestParams { get; set; }

        private IEnumerable<RequestParamsCaptureConfigItem> _requestParamsCaptureConfigItems { get; set; }

        internal void SetInjectionItem(IEnumerable<RequestParamsCaptureConfigItem> requestParamsCaptureConfigItems)
        {
            this._requestParamsCaptureConfigItems = requestParamsCaptureConfigItems;
        }

        internal RequestParamsCapture(List<RequestParamsCaptureModel> requestParams, IRequest request)
        {
            this._requestParams = requestParams;
            this._request = request;
        }

        internal bool IsTargetSite()
        {
            foreach (var requestParamsCaptureConfigItem in this._requestParamsCaptureConfigItems)
            {
                if (requestParamsCaptureConfigItem.Url == null)
                    continue;
                if (requestParamsCaptureConfigItem.Url == "*" || Regex.Match(this._request.Url, requestParamsCaptureConfigItem.Url).Success)
                    return true;
            }
            return false;
        }

        internal IEnumerable<RequestParamsCaptureModel> GetParams()
        {
            foreach (var requestParamsCaptureConfigItem in this._requestParamsCaptureConfigItems)
            {
                if (requestParamsCaptureConfigItem.Url == null)
                    continue;
                if (requestParamsCaptureConfigItem.Url != "*" && !Regex.Match(this._request.Url, requestParamsCaptureConfigItem.Url).Success)
                    continue;
                foreach (var field in requestParamsCaptureConfigItem.Fields)
                {
                    yield return new RequestParamsCaptureModel()
                    {
                        url = this._request.Url,
                        fields = new Dictionary<string, string>()
                        {
                            {field,this._request.Headers[field] ?? default(string) }
                        },
                        name = requestParamsCaptureConfigItem.Name
                    };
                }
            }
        }

        internal void GetAndAddParams()
        {
            foreach (var requestParamsCaptureConfigItem in this._requestParamsCaptureConfigItems)
            {
                if (requestParamsCaptureConfigItem.Url == null)
                    continue;
                if (requestParamsCaptureConfigItem.Url != "*" && !Regex.Match(this._request.Url, requestParamsCaptureConfigItem.Url).Success)
                    continue;
                var requestParam = new RequestParamsCaptureModel()
                {
                    url = this._request.Url,
                    fields = new Dictionary<string, string>(),
                    name = requestParamsCaptureConfigItem.Name
                };
                foreach (var field in requestParamsCaptureConfigItem.Fields)
                {
                    requestParam.fields.Add(field.Replace("-", "_"), this._request.Headers[field]?.Replace("\"", "\\\"") ?? default(string));
                }
                if (this._requestParams.Contains(requestParam))
                    continue;
                this._requestParams.Add(requestParam);
            }
        }

        internal string GetInjectJavaScriptObject()
        {
            if (this._requestParams == null)
                return "";
            StringBuilder InjectJson = new StringBuilder();
            foreach (var RequestParam in _requestParams)
            {
                InjectJson.AppendLine($"{AppConfigManager.Inst.AppConfig.InjectRequestParams}.{RequestParam.name} = " + "{};");
                foreach (var item in RequestParam.fields)
                {
                    InjectJson.AppendLine($"{AppConfigManager.Inst.AppConfig.InjectRequestParams}.{RequestParam.name}.{item.Key} = \"{item.Value}\";");
                }
            }
            return InjectJson.ToString();
        }
    }
}