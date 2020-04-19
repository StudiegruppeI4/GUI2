using System;

namespace Morgenmadsbuffeten.Models
{
    public class CheckedIn
    {
        public DateTime Date { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }
    }
}