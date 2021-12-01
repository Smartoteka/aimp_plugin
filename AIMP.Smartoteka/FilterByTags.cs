namespace AIMP.Smartoteka
{
    using System.Text;

    public class FilterByTags
    {
        public static string BuildFilter(string[] tags)
        {
            var filter = new StringBuilder();


            for (var i = 0; i < tags.Length; i++)
            {
                filter.AppendFormat("Tags like '%;{0};%'", tags[i]);

                if (i < tags.Length - 1)
                {
                    filter.Append(" and ");
                }
            }

            var resultFilter = filter.ToString();
            return resultFilter;
        }
    }
}