namespace AIMP.Smartoteka
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using SDK;
    using SDK.Player;

    internal static class OptionsMngr
    {
        private const string AIMP_Smartoteka_config_path = "AIMP.SMARTOTEKA\\OPTIONS";

        public static void Save(IAimpPlayer player, Options options)
        {
            var value = OptionsMngr.ToJson(options);

            using (var stream = player.Core.CreateStream().Result)
            {
                var buf = System.Text.Encoding.UTF8.GetBytes(value);
                stream.Write(buf, buf.Length, out int written);
                player.ServiceConfig.SetValueAsStream(AIMP_Smartoteka_config_path, stream);
            }
        }

        public static Options Load(IAimpPlayer player)
        {
            Options records = null;
            try
            {
                var streamResult = player.ServiceConfig.GetValueAsStream(AIMP_Smartoteka_config_path);

                if (streamResult.ResultType == ActionResultType.OK)
                {
                    using (var streamValue = streamResult.Result)
                    {
                        long bufferSize = streamValue.GetSize();
                        var buf = new byte[bufferSize];
                        streamValue.Read(buf, (int)bufferSize);
                        var strData = System.Text.Encoding.UTF8.GetString(buf);

                        var stringReader = new StringReader(strData);
                        var jsonTextReader = new JsonTextReader(stringReader);

                        records = JsonSerializer.Create().Deserialize<Options>(jsonTextReader);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return records;
        }

        public static string ToJson(object records)
        {
            string value;
            using (var stringWriter = new StringWriter())
            {
                JsonSerializer.Create().Serialize(stringWriter, records);


                value = stringWriter.ToString();
            }

            return value;
        }
    }
}