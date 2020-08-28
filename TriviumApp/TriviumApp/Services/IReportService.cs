using System.Linq;
using System.Text;
using TriviumApp.DictionaryUtils;

namespace TriviumApp.Services
{
    public interface IReportService
    {
        public string GetReportByDictionaryMetadata(
            IDictionaryMetadata rightHeaderDictionaryMetadata,
            IDictionaryMetadata topHeaderDictionaryMetadata,
            IDictionaryData rightHeaderDictionary,
            IDictionaryData topHeaderDictionary);
    }

    public class ReportService : IReportService
    {
        public string GetReportByDictionaryMetadata(
            IDictionaryMetadata rightHeaderDictionaryMetadata,
            IDictionaryMetadata topHeaderDictionaryMetadata,
            IDictionaryData rightHeaderDictionary,
            IDictionaryData topHeaderDictionary) 
        {
            var sb = new StringBuilder();
            sb.Append("<table border=\"1\">");

            var rightHeaderFirstRow = rightHeaderDictionary.Rows.First();
            var topHeaderFirstRow = topHeaderDictionary.Rows.First();

            // Displaying top header rows.
            for (int i = 0; i < topHeaderFirstRow.Items.Count; i++)
            {
                sb.Append("<tr>");
                for (int j = 0; j < rightHeaderFirstRow.Items.Count; j++)
                {
                    sb.Append($"<td></td>");
                }
                foreach (DictionaryRow topRow in topHeaderDictionary.Rows)
                {
                    sb.Append($"<td>{topRow.Items[i]}</td>");
                }
                sb.Append("</tr>");
            }

            var dataService = new DataService();

            // Displaying right header rows and data.
            foreach (DictionaryRow rightHeaderRow in rightHeaderDictionary.Rows)
            {
                sb.Append("<tr>");
                foreach (var item in rightHeaderRow.Items)
                {
                    sb.Append($"<td>{item}</td>");
                }
                foreach (DictionaryRow topHeaderRow in topHeaderDictionary.Rows)
                {
                    sb.Append($"<td>");
                    // Getting data from IDataService.
                    sb.Append(dataService.GetIntersectionData(
                        rightHeaderDictionaryMetadata.Id,
                        topHeaderDictionaryMetadata.Id,
                        rightHeaderDictionary.Rows.IndexOf(rightHeaderRow) + 1,
                        topHeaderDictionary.Rows.IndexOf(topHeaderRow) + 1
                        ));
                    sb.Append($"</td>");
                }
                sb.Append("</tr>");
            }
            return sb.ToString();
        }
    }
}
