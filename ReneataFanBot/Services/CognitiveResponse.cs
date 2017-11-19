namespace ReneataFanBot.Services
{
    public class CognitiveResponse
    {
        public string Query { get; set; }
        public TopScoringIntentData TopScoringIntent { get; set; }
        public IntentData[] Intents { get; set; }
        public object[] Entities { get; set; }
    }

}