using System.Globalization;
using Newtonsoft.Json;

namespace EmbyMissingEpisodes
{
    internal sealed class EmbyMissingEpisodes
    {
        private const string MissingFormat = "http://{1}:{2}/emby/Shows/Missing?api_key={0}";

        public static void Main(string[] args)
        {
            Utilities.CleanLog();

            Utilities.ConsoleWithLog("EmbyMissingEpisodes version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            Utilities.ConsoleWithLog("");

            if (args.Length != 4)
            {
                Utilities.ConsoleWithLog("EmbyMissingEpisodes needs Emby API key parameter as well as the servers port and number of days to check.");
                Utilities.ConsoleWithLog("EmbyMissingEpisodes API_KEY urlORlocalhost port daysToCheck");
                Utilities.ConsoleWithLog("To get Emby api key go to dashboard>advanced>security and generate one");
                return;
            }

            string uriName = string.Format(CultureInfo.InvariantCulture, MissingFormat, args[0], args[1], args[2]);
            if (int.TryParse(args[3], out int daysToCheck))
            {
                Utilities.ConsoleWithLog($"Checking back {daysToCheck} days");
                Utilities.ConsoleWithLog("");
            }
            else
            {
                Utilities.ConsoleWithLog($"Invalid number format for days to check {args[2]}.");
                return;
            }

            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out Uri? uriResult) && uriResult?.Scheme == Uri.UriSchemeHttp;
            if (!result)
            {
                Utilities.ConsoleWithLog("Invalid URI parameters");
                Utilities.ConsoleWithLog("EmbyMissingEpisodes API_KEY urlORlocalhost port daysToCheck");
                Utilities.ConsoleWithLog("To get Emby api key go to dashboard>advanced>security and generate one");
                return;
            }

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("user-agent", "EmbyShutdown");
            string sessionJson = httpClient.GetStringAsync(uriResult).Result;

            if (sessionJson == null)
            {
                Utilities.ConsoleWithLog("No data returned from Emby");
                return;
            }

            //using (StreamWriter file = File.CreateText("MissingEpisodes.json"))
            //{
            //    file.Write(Utilities.JsonPrettify(sessionJson));
            //}

            MissingEpisodesRoot missingEpisodeList = JsonConvert.DeserializeObject<MissingEpisodesRoot>(sessionJson)!;

            foreach(Item item in missingEpisodeList.Items)
            {
                if((DateTime.Now - item.PremiereDate).TotalDays <= daysToCheck)
                {
                    Utilities.ConsoleWithLog($"Series Name: {item.SeriesName} Episode Name: {item.Name} Episode: S{item.SeasonNumber.ToString("D2")}E{item.EpisodeNumber.ToString("D2")} Aired: {item.PremiereDate.ToShortDateString()} ({Math.Round((DateTime.Now - item.PremiereDate).TotalDays)} days)");
                }
            }
        }
    }

    #region Json Classes
    public class Item
    {
        public required string Name { get; set; }
        public required string ServerId { get; set; }
        public DateTime PremiereDate { get; set; }
        public required string Overview { get; set; }
        public int ProductionYear { get; set; }
        [JsonProperty("IndexNumber")]
        public int EpisodeNumber { get; set; }
        [JsonProperty("ParentIndexNumber")]
        public int SeasonNumber { get; set; }
        public required ProviderIds ProviderIds { get; set; }
        public required string Type { get; set; }
        public required string SeriesName { get; set; }
        public required string SeriesId { get; set; }
        public required string SeriesPrimaryImageTag { get; set; }
        public required string ParentThumbItemId { get; set; }
        public required string ParentThumbImageTag { get; set; }
        public required string LocationType { get; set; }
    }

    public class ProviderIds
    {
    }

    public class MissingEpisodesRoot
    {
        public required List<Item> Items { get; set; }
        public int TotalRecordCount { get; set; }
    }
    #endregion Json Classes
}
