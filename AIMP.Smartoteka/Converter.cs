namespace Autocomplete
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AIMP.Smartoteka;

    public class Converter
    {
        public static Dictionary<string, int> CommonTagsDict(DataRow[] rows, int selectedRowsCount)
        {
            var commonTagsDict = new Dictionary<string, int>();

            foreach (var row in rows)
            {
                var tags = GetTags(row);

                foreach (var tag in tags)
                {
                    commonTagsDict[tag] = (commonTagsDict.ContainsKey(tag) ? commonTagsDict[tag] : 0) + 1;
                }
            }

            commonTagsDict = commonTagsDict.Where(el => el.Value == selectedRowsCount)
                .ToDictionary(el => el.Key, el => el.Value);
            return commonTagsDict;
        }

        public static string ToTagsString(IEnumerable<string> resultTags)
        {
            return ";" + String.Join(";", resultTags) + ";";
        }

        public static IEnumerable<string> GetTags(DataRow row)
        {
            var tags = (row["Tags"] + "");
            return GetTags(tags);
        }

        public static IEnumerable<string> GetTags(string tags)
        {
            return tags?.Split(';').Where(el => !string.IsNullOrEmpty(el)) ?? new string[] { };
        }

        public static DataTable ToDataTable(IEnumerable<Record> records)
        {
            var table = DataTable();

            foreach (var record in records)
            {
                var row = table.NewRow();

                row["Title"] = record.Title;
                row["Duration"] = record.Duration;
                var tags = record.Tags ?? "";
                row["Tags"] = (tags.StartsWith(";") ? "" : ";")
                              + tags +
                              (tags.EndsWith(";") ? "" : ";");

                row["FileName"] = record.FileName;

                table.Rows.Add(row);
            }

            return table;
        }

        private static DataTable DataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Title");
            table.Columns.Add("Duration");
            table.Columns.Add("Tags");
            table.Columns["Tags"].MaxLength = 1000;

            var key = table.Columns.Add("FileName");

            table.PrimaryKey = new DataColumn[] {key};

            return table;
        }
    }
}