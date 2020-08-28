using System.Collections.Generic;

namespace TriviumApp.DictionaryUtils
{
    public interface IDictionaryData
    {
        public List<DictionaryRow> Rows { get; set; }
    }
    public class DictionaryData : IDictionaryData
    {
        public List<DictionaryRow> Rows { get; set; }
        public DictionaryData() 
        {
            Rows = new List<DictionaryRow>();
        }
    }
}
