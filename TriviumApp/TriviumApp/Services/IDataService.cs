using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TriviumApp.Models;

namespace TriviumApp.Services
{
    interface IDataService
    {
        public int GetIntersectionData(int rightHeaderDictionaryId,
                                           int topHeaderDictionaryId,
                                           int rightHeaderDictionaryRowId,
                                           int topHeaderDictionaryRowId);
    }

    public class DataService : IDataService
    {
        public const string DatabasePath = @"Data\database.json";

        private List<IntersectionValue> data;
        public List<IntersectionValue> Data
        {
            get
            {
                if (data == null)
                {
                    using (StreamReader r = new StreamReader(DatabasePath))
                    {
                        string json = r.ReadToEnd();
                        data = JsonConvert.DeserializeObject<List<IntersectionValue>>(json);
                    }
                }
                return data;
            }
        }

        public int GetIntersectionData(int rightHeaderDictionaryId, 
                                           int topHeaderDictionaryId, 
                                           int rightHeaderDictionaryRowId, 
                                           int topHeaderDictionaryRowId)
        {
            return Data.Find(x => (
                (x.RightHeaderDictionaryId ==   rightHeaderDictionaryId &&
                x.TopHeaderDictionaryId ==      topHeaderDictionaryId &&
                x.RightHeaderDictionaryRowId == rightHeaderDictionaryRowId &&
                x.TopHeaderDictionaryRowId ==   topHeaderDictionaryRowId) 
                ||
                (x.RightHeaderDictionaryId ==   topHeaderDictionaryId &&
                x.TopHeaderDictionaryId ==      rightHeaderDictionaryId &&
                x.RightHeaderDictionaryRowId == topHeaderDictionaryRowId &&
                x.TopHeaderDictionaryRowId ==   rightHeaderDictionaryRowId)
                )).Value;
        }
    }
}
