using System;
using DataStructureTB.Model;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// script 标签生成
    /// </summary>
    internal class ScriptTabDirectror
    {
        internal ScriptTabDirectror()
        { }

        internal void Construct(ResponseFilterConfigItem jsCfg, HtmlTagBuilder build)
        {
            build.BeginTag(jsCfg.Tag);
            if (jsCfg.Tag == "script")
                build.SetAttribute("type", "text/javascript");
            else if (jsCfg.Tag == "link")
                build.SetAttribute("rel", "stylesheet");

            //设置src
            if (!string.IsNullOrWhiteSpace(jsCfg.Src))
            {
                if (jsCfg.Tag == "script")
                    build.SetAttribute("src", jsCfg.Src);
                else if (jsCfg.Tag == "link")
                    build.SetAttribute("href", jsCfg.Src);
            }


            //设置js文件内容
            if (System.IO.File.Exists(jsCfg.Path))
                build.SetContent(System.IO.File.ReadAllText(jsCfg.Path));

            //设置js文件内容
            if (!string.IsNullOrEmpty(jsCfg.ScriptContent))
                build.SetContent(jsCfg.ScriptContent);

            build.EndTag();
        }
    }
}
