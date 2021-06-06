using System.Windows.Forms;

namespace DataStructureTB.Common
{
    /// <summary>
    /// MessageBox helpe
    /// </summary>
    internal class MessageTools
    {
        internal static void ShowMessage(string content, string title = "消息")
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
