using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Common
{
    /// <summary>
    /// js对象构造
    /// </summary>
    internal class JavaScriptObjectBuilder
    {
        internal JavaScriptObjectBuilder()
        {
            this.result = new StringBuilder("", 2000);
        }
         
        private StringBuilder result;

        internal void Begin()
        {
            this.result.Append('{');
            this.result.Append('\n');
        }

        internal void WriteProperty(string name, string val)
        {
            this.result.AppendLine($"{name}: \"{val}\",");
        }
        internal void WriteProperty(string name, int val)
        {
            this.result.AppendLine($"{name}: {val},");
        }

        internal void End()
        {
            this.result.Append('}'); 
            this.result.Append('\n');
        }

        internal string Build()
        {
            return this.result.ToString();
        }

    }
}
