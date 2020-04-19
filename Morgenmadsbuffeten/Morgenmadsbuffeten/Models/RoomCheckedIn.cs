using System;

namespace Morgenmadsbuffeten.Models
{
    public class RoomCheckedIn
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public DateTime Date { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }
    }
}