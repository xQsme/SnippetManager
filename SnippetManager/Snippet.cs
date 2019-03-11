using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager
{

    public class Snippet
    {
        public string keyword
        {
            get; set;
        }
        public string snippet
        {
            get; set;
        }
        public int count
        {
            get; set;
        }
        public Snippet(string keyword, string snippet)
        {
            this.keyword = keyword;
            this.snippet = snippet;
            count = 0;
        }
        public void increment()
        {
            count++;
        }
        public override string ToString()
        {
            return keyword;
        }
    }
}
