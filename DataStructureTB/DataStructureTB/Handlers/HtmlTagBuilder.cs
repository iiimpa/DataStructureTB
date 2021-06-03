using System;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// html 标签生成
    /// </summary>
    internal class HtmlTagBuilder
    {
        internal HtmlTagBuilder()
        {
            this.stackHtml = new Stack<char>();
            this.stackTags = new Stack<string>();
        }


        private Stack<char> stackHtml;
        private Stack<string> stackTags;
        private WriteState wState;

        //common output char
        private const char LESS = '<';
        private const char GREATER = '>';
        private const char SLASH = '/';
        private const char QUOTES = '\"';


        private void WriteString(string str)
        {
            foreach(char c in str)
            {
                this.stackHtml.Push(c);
            }
        }
        //生成一个标签的头部
        private string GetTagHead(string tagName, bool isClose)
        {
            return isClose ? $"</{tagName}>" : $"<{tagName} >";
        }
        private string GetAttribute(string attri, string val)
        {
            return $"{attri} = \"{val}\" ";
        }
        private string GetAttribute(string attri)
        {
            return attri + " ";
        }
        private void SetWriteState(WriteState state)
        {
            this.wState = state;
        }
        private void ThrowExceptionIfNotWrite()
        {
            if (this.wState == WriteState.None)
                throw new Exception("未开始写入标签。");
        }


        internal void BeginTag(string tagName)
        {
            string tag = this.GetTagHead(tagName, false);
            this.WriteString(tag);
            this.SetWriteState(WriteState.Tag);
            this.stackTags.Push(tagName);
        }
        internal void SetAttribute(string attrName)
        {
            if (this.wState != WriteState.Tag && this.wState != WriteState.Atrribute)
                throw new Exception("写入顺序错误，设置标签名之后紧接着才能设置属性。");

            this.stackHtml.Pop();

            string attr = this.GetAttribute(attrName);
            this.WriteString(attr);
            this.WriteString(">");
            this.SetWriteState(WriteState.Atrribute);
        }
        internal void SetAttribute(string attrName, string attrValue)
        {
            if (this.wState != WriteState.Tag && this.wState != WriteState.Atrribute)
                throw new Exception("写入顺序错误，设置标签名之后紧接着才能设置属性。");

            this.stackHtml.Pop();

            string attr = this.GetAttribute(attrName, attrValue);
            this.WriteString(attr);
            this.WriteString(">");
            this.SetWriteState(WriteState.Atrribute);
        }
        internal void SetContent(string content)
        {
            this.WriteString(content);
            this.SetWriteState(WriteState.Content);
        }
        internal void EndTag()
        {
            this.ThrowExceptionIfNotWrite();

            string tag = this.GetTagHead(this.stackTags.Pop(), true);
            this.WriteString(tag);
            this.SetWriteState(WriteState.Close);
        }


        internal string Build()
        {
            if (this.stackHtml.Count <= 0)
                return string.Empty;

            StringBuilder str = new StringBuilder(this.stackHtml.Count);
            Stack<char> output = new Stack<char>(this.stackHtml.Count);
            while (this.stackHtml.Count > 0)
                output.Push(this.stackHtml.Pop());
            while (output.Count > 0)
                str.Append(output.Pop());

            return str.ToString();
        }

        /// <summary>
        /// 编写器的状态
        /// </summary>
        private enum WriteState
        {
            None = 0,
            Tag,
            Atrribute,
            Content,
            Close
        }
    }
}
