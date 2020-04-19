using System;
using System.Generic;

namespace Morgenmadsbuffeten.Models
{
    public class CheckedIn
    {
        public int CheckedInChildren { get; set; }
        public int CheckedInAdults { get; set; }
        public DateTime CheckedInDate { get; set; }
        public int CheckedInTotal { get; set; }
    }
}