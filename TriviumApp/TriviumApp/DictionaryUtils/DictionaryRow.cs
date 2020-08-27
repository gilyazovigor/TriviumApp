using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace TriviumApp.DictionaryUtils
{
    public interface IDictionaryRow
    {
        public List<string> Items { get; }
    }

    public class DictionaryRow : IDictionaryRow
    {
        public List<string> Items { get; }
        public DictionaryRow(List<string> items) 
        {
            this.Items = items;
        }
    }

    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Budget { get; set; }
    }

    public class Version
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

}
