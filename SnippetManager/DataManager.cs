using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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

        public Color color
        {
            get; set;
        }

        public int R
        {
            get; set;
        }

        public int G
        {
            get; set;
        }

        public int B
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

        public Font font
        {
            get; set;
        }

        public Color fontColor
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
                    modifier = 2;
                    saveData();
                    font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);
                    fontColor = Color.FromArgb(255, 255, 255, 255);
                    color = Color.FromArgb(255, 255, 128, 0);
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
                    color = item.color;
                    font = item.font;
                    fontColor = item.fontColor;
                }
            }
        }

        public class Item
        {
            public List<Snippet> snippets;
            public Boolean startup;
            public Color color;
            public int key;
            public int modifier;
            public Boolean theme;
            public String keyWord;
            public Font font;
            public Color fontColor;
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
            item.color = color;
            item.font = font;
            item.fontColor = fontColor;
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

        public object clone()
        {
            return MemberwiseClone();
        }
    }
}
