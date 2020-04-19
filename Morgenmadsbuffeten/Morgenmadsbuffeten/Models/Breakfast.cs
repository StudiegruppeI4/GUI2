using System;

namespace Morgenmadsbuffeten.Models
{
    public class Breakfast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }
    }
}