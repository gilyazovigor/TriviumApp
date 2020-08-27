using System.Collections.Generic;

namespace TriviumApp.DictionaryUtils
{
    public interface IDictionaryData
    {
        public List<IDictionaryRow> Rows { get; set; }
    }
    public class DictionaryData : IDictionaryData
    {
        public List<IDictionaryRow> Rows { get; set; }
        public DictionaryData() 
        {
            Rows = new List<IDictionaryRow>();
        }
    }
}
