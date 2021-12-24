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
        private const string AIMP_Smartoteka_flags_path = "AIMP.SMARTOTEKA\\FLAGS";

        public static void Save(IAimpPlayer player, Options options)
        {
            Save(player, options, AIMP_Smartoteka_config_path);
        }

        public static Options Load(IAimpPlayer player)
        {
            Options records = Load<Options>(player, AIMP_Smartoteka_config_path);

            return records;
        }

        public static void SaveFlags(IAimpPlayer player, Flags options)
        {
            Save(player, options, AIMP_Smartoteka_flags_path);
        }

        public static Flags LoadFlags(IAimpPlayer player)
        {
            var records = Load<Flags>(player, AIMP_Smartoteka_flags_path);

            return records;
        }

        private static void Save(IAimpPlayer player, object options, string path)
        {
            var value = OptionsMngr.ToJson(options);

            using (var stream = player.Core.CreateStream().Result)
            {
                var buf = System.Text.Encoding.UTF8.GetBytes(value);
                stream.Write(buf, buf.Length, out int written);

                var result = player.ServiceConfig.SetValueAsStream(path, stream);
            }
        }

        static T Load<T>(IAimpPlayer player, string path)
        {
            T records = default(T);
            try
            {
                var streamResult = player.ServiceConfig.GetValueAsStream(path);

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

                        records = JsonSerializer.Create().Deserialize<T>(jsonTextReader);
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