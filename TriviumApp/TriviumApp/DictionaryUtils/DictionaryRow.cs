using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace TriviumApp.DictionaryUtils
{
    public class DictionaryRow
    {
        public List<string> Items { get; }
        public DictionaryRow(List<string> items) 
        {
            this.Items = items;
        }
    }

}
