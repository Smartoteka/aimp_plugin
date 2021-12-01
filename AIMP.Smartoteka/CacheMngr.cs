namespace AIMP.Smartoteka
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class CacheMngr
    {
        public static void ExportToFile(List<Record> records, string path)
        {
            var value = OptionsMngr.ToJson(records);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var buf = System.Text.Encoding.UTF8.GetBytes(value);
                stream.Write(buf, 0, buf.Length);
            }
        }

        public static List<Record> Load(string path)
        {
            if (!File.Exists(path))
                return new List<Record>();

            using (var streamReader = File.OpenText(path))
            {
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var records = JsonSerializer.Create().Deserialize<List<Record>>(jsonTextReader);

                    return records;
                }
            }
        }
    }
}