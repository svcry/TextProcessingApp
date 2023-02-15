using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace TextProcessingApp
{
    public class ChangeFile
    {
        private string _textFile;
        public ChangeFile(string textFile) => _textFile = textFile;
        
        public static string RemoveWords(string textFile, int lettersNum)
        {
            string pattern = "( ?(?<!\\G)((?<=[^\\p{P}])(?=\\p{P})|\\b) ?)";
            string[] textSplited = Regex.Split(textFile, pattern);
            string textResult = String.Join(" ", textSplited.Where(x => x != String.Empty && CheckWord(x, lettersNum)).ToArray());
            textResult = Regex.Replace(textResult, @"\s+", " ");
            return Regex.Replace(textResult, @" ?([.,!?:;_)(-]) ?(?:\1 ?)*", "$1 ");
        }

        public static bool CheckWord(string word, int lettersNum)
        {
            if (word.Length >= lettersNum || Char.IsPunctuation(word, 0)) 
            { 
                return true;
            }
            return false;
        }

        public static string RemovePunctuation(string textFile)
        {
            return new string(textFile.Where(c => !char.IsPunctuation(c)).ToArray());
        }
    }

}
