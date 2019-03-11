using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager
{
    public class DataManager
    {

        public List<Snippet> snippets
        {
            get;
        }

        public Boolean startup {
            get; set;
        }

        public char key
        {
            get; set;
        }

        public DataManager()
        {
            snippets = new List<Snippet>();
            startup = true;
            key = 'X';
            //READ FILE
            //FOREACH ADD
            snippets.Add(new Snippet("table", "Table Snippet"));
            snippets.Add(new Snippet("shrug", "¯\\_{(}ツ{)}_/¯"));
            snippets.Add(new Snippet("navbar", "Navbar Snippet"));
        }

        public void saveData()
        {

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
