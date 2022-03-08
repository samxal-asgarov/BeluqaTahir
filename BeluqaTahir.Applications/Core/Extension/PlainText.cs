using System.Text.RegularExpressions;

namespace BeluqaTahir.Applications.Core.Extension
{
    static public partial class Extension
    {
        static public string PlainText(this string text)
        {
            return Regex.Replace(text, @"<[^>]*>", "");
        }
    }
}
