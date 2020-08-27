using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using TriviumApp.DictionaryUtils;

namespace TriviumApp.Services
{
    public interface IDictionaryService
    {
        IDictionaryData GetDictionaryDataById(int dictionaryId, DictionaryType dictionaryType);
        IDictionaryMetadata GetDictionaryMetadataById(int dictionaryId);
    }

    public class DictionaryService : IDictionaryService
    {
        public const string DictionariesListPath = @"Data\dictionaries.json";
        
        private List<Dictionary> dictionaries;
        public List<Dictionary> Dictionaries
        {
            get
            {
                if (dictionaries == null)
                {
                    using (StreamReader r = new StreamReader(@"Data\dictionaries.json"))
                    {
                        string json = r.ReadToEnd();
                        dictionaries = JsonConvert.DeserializeObject<List<Dictionary>>(json);
                    }
                }
                return dictionaries;
            }
        }


        public IDictionaryData GetDictionaryDataById(int dictionaryId, DictionaryType dictionaryType)
        {
            IDictionaryData dictionaryData = new DictionaryData();
            
            Dictionary dictionary = Dictionaries.Find(x => x.Id == dictionaryId);
            string json;
            using (StreamReader r = new StreamReader(dictionary.Path))
            {
                json = r.ReadToEnd();
            }
 
            switch (dictionaryType)
            {
                case DictionaryType.Buildings: 
                    foreach (Building row in JsonConvert.DeserializeObject<List<Building>>(json))
                    {
                        var items = new List<string>();
                        items.Add(row.Id.ToString());
                        items.Add(row.Name);
                        items.Add(row.Code);
                        items.Add(row.Budget.ToString());
                        dictionaryData.Rows.Add(new DictionaryRow(items));
                    }
                    break;
                case DictionaryType.Versions:
                    foreach (Version row in JsonConvert.DeserializeObject<List<Version>>(json))
                    {
                        var items = new List<string>();
                        items.Add(row.Id.ToString());
                        items.Add(row.Name);
                        items.Add(row.Type);
                        dictionaryData.Rows.Add(new DictionaryRow(items));
                    }
                    break;
                // Сюда добавить формирование dictionaryData.Rows для новыого типа словаря при необходимости.
            }

            return dictionaryData;
        }


        public IDictionaryMetadata GetDictionaryMetadataById(int dictionaryId)
        {
            IDictionaryMetadata dictionaryMetadata = new DictionaryMetadata();

            Dictionary dictionary = Dictionaries.Find(x => x.Id == dictionaryId);
            dictionaryMetadata.Id = dictionary.Id;
            dictionaryMetadata.Name = dictionary.Name;
            dictionaryMetadata.Attributes = dictionary.Attributes;

            return dictionaryMetadata;
        }
    }
}
