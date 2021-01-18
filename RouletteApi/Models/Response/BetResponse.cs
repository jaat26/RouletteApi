namespace RouletteApi.Models.Response
{
    public class BetResponse : RouletteResponse
    {
        public int Number { get; set; }
        public string Coulor { get; set; }
        public double Money { get; set; }
        public string UserId { get; set; }
    }
}
