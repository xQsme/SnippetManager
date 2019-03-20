using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager
{
    public class DataManager
    {

        public List<Snippet> snippets
        {
            get; set;
        }

        public Boolean startup {
            get; set;
        }

        public Boolean theme
        {
            get; set;
        }

        public String keyWord
        {
            get; set;
        }

        public int key
        {
            get; set;
        }

        public int modifier
        {
            get; set;
        }

        public DataManager()
        {
            loadData();
        }

        public void loadData()
        {
            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            if (!File.Exists(homePath + "/.snippets"))
            {
                File.WriteAllText(homePath + "/.snippets", "{}");
            }
            using (StreamReader r = new StreamReader(homePath + "/.snippets"))
            {
                string json = r.ReadToEnd();
                r.Close();
                Item item = JsonConvert.DeserializeObject<Item>(json);
                if(item.snippets == null)
                {
                    snippets = new List<Snippet>();
                    startup = false;
                    theme = true;
                    key = ' ';
                    keyWord = "Space";
                    /*
                     Alt = 1,
                     Control = 2,
                     Shift = 4,
                     Windows = 8
                     */
                    modifier = 2;
                    saveData();
                }
                else
                {
                    snippets = item.snippets;
                    startup = item.startup;
                    theme = item.theme;
                    key = item.key;
                    modifier = item.modifier;
                    keyWord = item.keyWord;
                }
            }
        }

        public class Item
        {
            public List<Snippet> snippets;
            public Boolean startup;
            public int key;
            public int modifier;
            public Boolean theme;
            public String keyWord;
        }

        public void saveData()
        {
            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            Item item = new Item();
            item.snippets = snippets;
            item.startup = startup;
            item.key = key;
            item.keyWord = keyWord;
            item.modifier = modifier;
            item.theme = theme;
            String json = JsonConvert.SerializeObject(item);
            File.WriteAllText(homePath + "/.snippets", json);
        }

        public Boolean add(Snippet snippet)
        {
            foreach(Snippet s in snippets)
            {
                if (snippet.keyword.ToLower() == s.keyword.ToLower())
                {
                    return false;
                }
            }
            snippets.Add(snippet);
            return true;
        }
    }
}
