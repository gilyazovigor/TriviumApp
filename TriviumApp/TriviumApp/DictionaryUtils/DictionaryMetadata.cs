using System.Collections.Generic;

namespace TriviumApp.DictionaryUtils
{
    public interface IDictionaryMetadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DictionaryAttribute> Attributes { get; set; }
    }

    public class DictionaryMetadata : IDictionaryMetadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DictionaryAttribute> Attributes { get; set; }
    }
}