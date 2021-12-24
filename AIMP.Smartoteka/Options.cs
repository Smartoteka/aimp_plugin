namespace AIMP.Smartoteka
{
    using System;

    public class Options
    {
        public Guid? UUID { get; set; }
        public string CurrentListName { get; set; }

        public string CacheTagsPath { get; set; }
        public string ExportPath { get; set; }
        public string WorkingDirectory { get; set; }
    }
}