using RouletteApi.Data.Enums;
using System;
using System.Collections.Generic;

namespace RouletteApi.Data.Entities
{
    public class Roulette
    {
        public string Id { get; set; }
        public RouletteStatus Status { get; set; }
        public DateTime? CreateDate { get; set; }        
        public DateTime? OpenDate { get; set; }
        public int? WinningNumber { get; set; }
        public string WinningColour { get; set; }
        public DateTime? CloseDate { get; set; }
    }
}
