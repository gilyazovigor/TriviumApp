using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviumApp.DictionaryUtils
{
    public enum DictionaryType
    {
        Buildings,
        Versions
        // Сюда добавить новый тип словаря при необходимости.
    }

    public class Dictionary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<DictionaryAttribute> Attributes { get; set; }
    }
}
