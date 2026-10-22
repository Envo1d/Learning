using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace WindowsForms8
{
    [Serializable]
    public class LoadKeys
    {
        List<List<string>> keyWords = new List<List<string>>();

        [NonSerialized]
        string path = "keyWords.xml";
        int idx;

        public LoadKeys()
        {
            for (int i = 0; i < 26; i++)
            {
                keyWords.Add(new List<string>());
            }

            LoadFile();
        }

        private void LoadFile()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<List<string>>));

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                if (fs.Length != 0)
                {
                    keyWords = null;
                    keyWords = (List<List<string>>)formatter.Deserialize(fs);
                }
            }
        }
        private void GetIdx(char c)
        {
            idx = (int)c - 97;
        }
        public List<string> GetList(string word)
        {
            GetIdx(word[0]);
            if (idx >= 0 && idx <= 25)
                return keyWords[idx];
            else return null;
        }
    }
}
