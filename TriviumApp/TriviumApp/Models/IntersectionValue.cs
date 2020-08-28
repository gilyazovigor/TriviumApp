using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviumApp.Models
{
    public class IntersectionValue
    {
        public int RightHeaderDictionaryId { get; set; }
        public int TopHeaderDictionaryId { get; set; }
        public int RightHeaderDictionaryRowId { get; set; }
        public int TopHeaderDictionaryRowId { get; set; }
        public int Value { get; set; }
    }
}
