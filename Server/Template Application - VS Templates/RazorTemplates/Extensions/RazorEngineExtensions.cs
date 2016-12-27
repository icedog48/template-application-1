using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorEngine
{
    public static class RazorEngineExtensions
    {
        /// <summary>
        /// http://csharphelper.com/blog/2014/10/convert-between-pascal-case-camel-case-and-proper-case-in-c/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string text)
        {
            // If there are 0 or 1 characters, just return the string.
            if (text == null) return text;

            if (text.Length < 2) return text.ToUpper();

            // Split the string into words.
            var words = text.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = "";

            foreach (string word in words)
            {
                result += word.Substring(0, 1).ToUpper() + word.Substring(1);
            }

            return result;
        }

        /// <summary>
        /// http://csharphelper.com/blog/2014/10/convert-between-pascal-case-camel-case-and-proper-case-in-c/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string text)
        {
            // If there are 0 or 1 characters, just return the string.
            if (text == null || text.Length < 2) return text;
            
            // Split the string into words.
            var words = new List<string>();

            var letters = text.ToCharArray();

            var buffer = letters[0].ToString();

            for (int i = 1; i < letters.Length; i++)
            {
                if (Char.IsUpper(letters[i]) || Char.IsWhiteSpace(letters[i]))
                {
                    words.Add(buffer);

                    buffer = string.Empty;
                }

                buffer += letters[i];
            }

            words.Add(buffer);

            // Combine the words.
            var result = words[0].ToLower();

            for (int i = 1; i < words.Count; i++)
            {
                result += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
            }

            return result;
        }
    }
}
