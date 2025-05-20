using Newtonsoft.Json;

namespace EmbyMissingEpisodes
{
    public static class Utilities
    {
        public static string LogName = "EmbyMissingEpisodes";
        public static bool noLog;

        /// <summary>
        /// Delete any existing log file
        /// </summary>
        public static void CleanLog()
        {
            File.Delete($"{LogName}.log");
        }

        /// <summary>
        /// Write the supplied strong to the console and optionally to a log file
        /// </summary>
        /// <param name="text"></param>
        public static void ConsoleWithLog(string text)
        {
            Console.WriteLine(text);

            if (noLog == false)
            {
                using (StreamWriter file = File.AppendText($"{LogName}.log"))
                {
                    file.Write(text + Environment.NewLine);
                }
            }
        }


        /// <summary>
        /// Indents and adds line breaks etc to make it pretty for printing/viewing
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Newtonsoft.Json.Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}
