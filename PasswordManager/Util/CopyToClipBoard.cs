using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Util
{
    internal class CopyToClipBoard
    {
        public static void CopyToClipboard(string text)
        {
            System.Windows.Forms.Clipboard.SetText(text);
        }
    }
}
